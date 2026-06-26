<?php

require_once __DIR__ . '/../../includes/layout.php';

// Somente o administrador do sistema pode criar contas de funcionarios.
exigirPerfil(['admin'], '../../');

// As paginas que incluem este arquivo precisam informar o perfil e os textos da tela.
if (!isset($perfilFuncionario, $ativoMenu, $tituloPagina, $subtituloPagina, $rotuloFuncionario, $acaoLog)) {
    exit('Configuracao do formulario de funcionario ausente.');
}

// Lista branca: esta pagina nunca cria aluno, professor ou outro perfil por alteracao de formulario.
$perfisPermitidos = ['coordenacao', 'administrativo'];
if (!in_array($perfilFuncionario, $perfisPermitidos, true)) {
    flash('danger', 'Perfil de funcionario invalido.');
    redirecionar('dashboard.php');
}

// Valores sao mantidos para que o admin nao precise digitar tudo novamente se houver erro.
$nome = '';
$email = '';
$status = 'ativo';
$erros = [];

function perfilFuncionarioParaBanco($perfilFuncionario)
{
    // Coordenacao existe em todas as versoes do banco e nao precisa de conversao.
    if ($perfilFuncionario !== 'administrativo') {
        return $perfilFuncionario;
    }

    // Durante a migracao, identifica se o ENUM ja aceita administrativo.
    // Isso permite cadastrar sem erro tanto antes quanto depois da atualizacao do banco.
    $colunaPerfil = buscarUm('SHOW COLUMNS FROM usuarios LIKE "perfil"');
    $tipoPerfil = strtolower((string) ($colunaPerfil['Type'] ?? ''));

    return strpos($tipoPerfil, "'administrativo'") !== false ? 'administrativo' : 'financeiro';
}

// O valor usado no INSERT acompanha a versao real do banco conectado.
$perfilBanco = perfilFuncionarioParaBanco($perfilFuncionario);

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Le os campos enviados pelo formulario e remove espacos extras.
    $nome = post('nome');
    $email = strtolower(post('email'));
    $senha = post('senha');
    $status = post('status', 'ativo');

    // Validacoes simples antes de qualquer INSERT no banco.
    if ($nome === '') {
        $erros[] = 'Informe o nome do funcionario.';
    }

    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $erros[] = 'Informe um e-mail valido.';
    }

    if (strlen($senha) < 6) {
        $erros[] = 'A senha inicial deve ter pelo menos 6 caracteres.';
    }

    if (!in_array($status, ['ativo', 'inativo'], true)) {
        $erros[] = 'Selecione um status valido.';
    }

    // O e-mail e unico na tabela usuarios, por isso conferimos antes de salvar.
    if (!$erros && buscarUm('SELECT id_usuario FROM usuarios WHERE email = :email', [':email' => $email])) {
        $erros[] = 'Ja existe um usuario cadastrado com este e-mail.';
    }

    if (!$erros) {
        try {
            // gerarHashSenha protege a senha: o banco recebe apenas o SHA256, nunca texto puro.
            executar(
                'INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
                 VALUES (:nome, :email, :senha_hash, :perfil, :status)',
                [
                    ':nome' => $nome,
                    ':email' => $email,
                    ':senha_hash' => gerarHashSenha($senha),
                    ':perfil' => $perfilBanco,
                    ':status' => $status,
                ]
            );

            // ultimo_login fica nulo; por isso o novo funcionario sera direcionado a trocar a senha no primeiro acesso.
            registrarLogSistema($acaoLog);
            flash('success', $rotuloFuncionario . ' cadastrado com sucesso.');
            redirecionar(basename((string) $_SERVER['PHP_SELF']));
        } catch (Throwable $erroBanco) {
            // Mantem a mensagem amigavel e evita exibir detalhes tecnicos do banco na tela.
            $erros[] = 'Nao foi possivel cadastrar o funcionario. Tente novamente.';
        }
    }
}

// Mostra os funcionarios mais recentes do perfil desta aba para facilitar a conferencia.
$funcionarios = buscarTodos(
    'SELECT nome, email, status, ultimo_login, created_at
     FROM usuarios
     WHERE perfil = :perfil
     ORDER BY created_at DESC
     LIMIT 20',
    [':perfil' => $perfilBanco]
);

appInicio($tituloPagina, 'admin', $ativoMenu, '../../');
pageHeading('Admin', $tituloPagina, $subtituloPagina);
?>
    <?php foreach ($erros as $erro): ?>
      <?php alerta('danger', 'Nao foi possivel salvar', $erro); ?>
    <?php endforeach; ?>

    <section class="panel">
      <div class="panel-header"><h2>Dados do usuario</h2></div>
      <div class="panel-body">
        <form class="stack" method="post" action="">
          <!-- O perfil nao aparece como select: cada aba salva apenas o seu proprio tipo de funcionario. -->
          <div class="form-grid two">
            <label class="field">
              <span>Nome completo</span>
              <input class="control" type="text" name="nome" value="<?= e($nome) ?>" required maxlength="150">
            </label>
            <label class="field">
              <span>E-mail</span>
              <input class="control" type="email" name="email" value="<?= e($email) ?>" required maxlength="150">
            </label>
            <label class="field">
              <span>Senha inicial</span>
              <input class="control" type="password" name="senha" required minlength="6" autocomplete="new-password">
            </label>
            <label class="field">
              <span>Status de acesso</span>
              <select class="control" name="status">
                <option value="ativo" <?= $status === 'ativo' ? 'selected' : '' ?>>Ativo</option>
                <option value="inativo" <?= $status === 'inativo' ? 'selected' : '' ?>>Inativo</option>
              </select>
            </label>
          </div>
          <div class="actions"><button class="btn primary" type="submit">Cadastrar usuario</button><a class="btn ghost" href="dashboard.php">Voltar</a></div>
        </form>
      </div>
    </section>

    <section class="panel">
      <div class="panel-header"><h2><?= e($rotuloFuncionario) ?>s cadastrados</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Nome</th><th>E-mail</th><th>Status</th><th>Ultimo login</th><th>Cadastro</th></tr></thead>
            <tbody>
              <?php foreach ($funcionarios as $funcionario): ?>
                <tr>
                  <td><strong><?= e($funcionario['nome']) ?></strong></td>
                  <td><?= e($funcionario['email']) ?></td>
                  <td><?= badge($funcionario['status'], $funcionario['status']) ?></td>
                  <td><?= e(dataBr($funcionario['ultimo_login'])) ?></td>
                  <td><?= e(dataBr($funcionario['created_at'])) ?></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$funcionarios): ?>
                <tr><td colspan="5">Nenhum usuario cadastrado nesta categoria.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
