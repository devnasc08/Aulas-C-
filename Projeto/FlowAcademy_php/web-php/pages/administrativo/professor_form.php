<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin'], '../../');

// Tela usada pelo admin para cadastrar ou editar professores.
$erro = '';
$sucesso = '';
$idProfessor = (int) getValor('id', 0);
$modoEdicao = $idProfessor > 0;
$professor = null;

if ($modoEdicao) {
    // No modo edicao, carregamos os dados do usuario e do professor.
    $professor = buscarUm(
        'SELECT p.*, u.nome, u.email, u.status AS status_usuario
         FROM professores p
         JOIN usuarios u ON u.id_usuario = p.id_usuario
         WHERE p.id_professor = :id_professor',
        [':id_professor' => $idProfessor]
    );

    if (!$professor) {
        flash('danger', 'Professor nao encontrado.');
        redirecionar('professores.php');
    }
}

$valores = [
    // Guarda os valores exibidos no formulario.
    'nome' => $professor['nome'] ?? '',
    'email' => $professor['email'] ?? '',
    'cpf' => $professor['cpf'] ?? '',
    'especialidade' => $professor['especialidade'] ?? '',
    'status_usuario' => $professor['status_usuario'] ?? 'ativo',
];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Professor tambem precisa de um usuario para conseguir fazer login.
    $nome = post('nome');
    $email = post('email');
    $senha = post('senha');
    $cpf = post('cpf');
    $especialidade = post('especialidade');
    $statusUsuario = post('status_usuario', 'ativo');

    $valores = [
        'nome' => $nome,
        'email' => $email,
        'cpf' => $cpf,
        'especialidade' => $especialidade,
        'status_usuario' => $statusUsuario,
    ];

    if ($nome === '' || $email === '' || $cpf === '') {
        // Validacoes antes de abrir transacao e gravar no banco.
        $erro = 'Nome, e-mail e CPF sao obrigatorios.';
    } elseif (!$modoEdicao && $senha === '') {
        $erro = 'Informe a senha inicial do professor.';
    } elseif (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $erro = 'Informe um e-mail valido.';
    } elseif ($senha !== '' && strlen($senha) < 6) {
        $erro = 'A senha deve ter pelo menos 6 caracteres.';
    } elseif (!in_array($statusUsuario, ['ativo', 'inativo'], true)) {
        $erro = 'Status de acesso invalido.';
    } else {
        // Transacao: usuario e professor precisam ser salvos juntos.
        $pdo->beginTransaction();
        try {
            if ($modoEdicao) {
                // Atualiza o usuario de login do professor.
                $paramsUsuario = [
                    ':nome' => $nome,
                    ':email' => $email,
                    ':status' => $statusUsuario,
                    ':id_usuario' => $professor['id_usuario'],
                ];
                $sqlUsuario = 'UPDATE usuarios SET nome = :nome, email = :email, status = :status';

                if ($senha !== '') {
                    // Na edicao, a senha so muda se o campo for preenchido.
                    $sqlUsuario .= ', senha_hash = :senha_hash';
                    $paramsUsuario[':senha_hash'] = gerarHashSenha($senha);
                }

                $sqlUsuario .= ' WHERE id_usuario = :id_usuario';
                executar($sqlUsuario, $paramsUsuario);

                // Atualiza os dados profissionais do professor.
                executar(
                    'UPDATE professores
                     SET cpf = :cpf, especialidade = :especialidade
                     WHERE id_professor = :id_professor',
                    [
                        ':cpf' => $cpf,
                        ':especialidade' => $especialidade,
                        ':id_professor' => $idProfessor,
                    ]
                );
            } else {
                // Primeiro cria o usuario de login com perfil professor.
                executar(
                    'INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
                     VALUES (:nome, :email, :senha_hash, "professor", :status)',
                    [
                        ':nome' => $nome,
                        ':email' => $email,
                        ':senha_hash' => gerarHashSenha($senha),
                        ':status' => $statusUsuario,
                    ]
                );
                $idUsuario = $pdo->lastInsertId();

                // Depois cria o cadastro profissional ligado ao usuario criado.
                executar(
                    'INSERT INTO professores (id_usuario, cpf, especialidade)
                     VALUES (:id_usuario, :cpf, :especialidade)',
                    [
                        ':id_usuario' => $idUsuario,
                        ':cpf' => $cpf,
                        ':especialidade' => $especialidade,
                    ]
                );
            }

            $pdo->commit();
            registrarLogSistema($modoEdicao ? 'Editou professor' : 'Cadastrou professor');
            $sucesso = $modoEdicao ? 'Professor atualizado com sucesso.' : 'Professor cadastrado com sucesso.';
        } catch (Throwable $erroBanco) {
            // Se uma das tabelas falhar, desfaz a outra tambem.
            $pdo->rollBack();
            $erro = 'Erro ao salvar professor: ' . $erroBanco->getMessage();
        }
    }
}

$tituloPagina = $modoEdicao ? 'Editar Professor' : 'Cadastro de Professor';
$textoPagina = $modoEdicao ? 'Atualize os dados e o acesso do professor.' : 'Cria o usuario de login e o cadastro profissional do professor.';

appInicio($tituloPagina, 'administrativo', 'professor_form', '../../');
pageHeading('Cadastro', $tituloPagina, $textoPagina);
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Professor salvo', $sucesso); ?><?php endif; ?>

    <!-- Formulario de dados pessoais, profissionais e acesso do professor. -->
    <section class="panel">
      <div class="panel-header"><h2>Dados do professor</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field"><span>Nome completo</span><input class="control" name="nome" value="<?= e($valores['nome']) ?>" required></label>
          <label class="field"><span>E-mail</span><input class="control" type="email" name="email" value="<?= e($valores['email']) ?>" required></label>
          <label class="field"><span><?= $modoEdicao ? 'Nova senha' : 'Senha inicial' ?></span><input class="control" type="password" name="senha" <?= $modoEdicao ? 'placeholder="Preencha apenas se quiser trocar"' : 'required' ?>></label>
          <label class="field"><span>CPF</span><input class="control" name="cpf" data-mask="cpf" value="<?= e($valores['cpf']) ?>" required></label>
          <label class="field span-2"><span>Especialidade</span><input class="control" name="especialidade" value="<?= e($valores['especialidade']) ?>" placeholder="Ex.: Banco de dados"></label>
          <label class="field">
            <span>Acesso</span>
            <select class="select" name="status_usuario">
              <option value="ativo" <?= $valores['status_usuario'] === 'ativo' ? 'selected' : '' ?>>Ativo</option>
              <option value="inativo" <?= $valores['status_usuario'] === 'inativo' ? 'selected' : '' ?>>Inativo</option>
            </select>
          </label>
          <div class="actions span-2" style="justify-content:flex-start">
            <button class="btn primary" type="submit"><?= $modoEdicao ? 'Atualizar professor' : 'Salvar professor' ?></button>
            <a class="btn ghost" href="professores.php">Voltar</a>
          </div>
        </form>
      </div>
    </section>
<?php appFim('../../'); ?>
