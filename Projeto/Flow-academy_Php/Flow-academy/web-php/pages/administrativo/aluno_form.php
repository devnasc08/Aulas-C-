<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin', 'administrativo'], '../../');

// Esta tela serve tanto para cadastrar quanto para editar aluno.
$erro = '';
$sucesso = '';
$idAluno = (int) getValor('id', 0);
$modoEdicao = $idAluno > 0;
$aluno = null;

if ($modoEdicao) {
    // No modo edicao, buscamos dados das duas tabelas envolvidas: usuarios e alunos.
    $aluno = buscarUm(
        'SELECT a.*, u.nome, u.email, u.status AS status_usuario
         FROM alunos a
         JOIN usuarios u ON u.id_usuario = a.id_usuario
         WHERE a.id_aluno = :id_aluno',
        [':id_aluno' => $idAluno]
    );

    if (!$aluno) {
        flash('danger', 'Aluno nao encontrado.');
        redirecionar('alunos.php');
    }
}

$valores = [
    // Array usado para preencher o formulario com dados atuais ou digitados.
    'nome' => $aluno['nome'] ?? '',
    'email' => $aluno['email'] ?? '',
    'matricula' => $aluno['matricula'] ?? '',
    'cpf' => $aluno['cpf'] ?? '',
    'telefone' => $aluno['telefone'] ?? '',
    'data_nascimento' => $aluno['data_nascimento'] ?? '',
    'endereco' => $aluno['endereco'] ?? '',
    'status_academico' => $aluno['status_academico'] ?? 'regular',
    'status_usuario' => $aluno['status_usuario'] ?? 'ativo',
];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Este formulario cria ou edita dois registros: um em usuarios e outro em alunos.
    $nome = post('nome');
    $email = post('email');
    $senha = post('senha');
    $matricula = post('matricula') ?: (!$modoEdicao ? date('Y') . '-' . random_int(1000, 9999) : '');
    $cpf = post('cpf');
    $telefone = post('telefone');
    $dataNascimento = post('data_nascimento') ?: null;
    $endereco = post('endereco');
    $statusAcademico = post('status_academico', 'regular');
    $statusUsuario = post('status_usuario', 'ativo');

    $valores = [
        'nome' => $nome,
        'email' => $email,
        'matricula' => $matricula,
        'cpf' => $cpf,
        'telefone' => $telefone,
        'data_nascimento' => $dataNascimento,
        'endereco' => $endereco,
        'status_academico' => $statusAcademico,
        'status_usuario' => $statusUsuario,
    ];

    if ($nome === '' || $email === '' || $matricula === '' || $cpf === '') {
        // Validacoes simples antes de gravar no banco.
        $erro = 'Nome, e-mail, matricula e CPF sao obrigatorios.';
    } elseif (!$modoEdicao && $senha === '') {
        $erro = 'Informe a senha inicial do aluno.';
    } elseif (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $erro = 'Informe um e-mail valido.';
    } elseif ($senha !== '' && strlen($senha) < 6) {
        $erro = 'A senha deve ter pelo menos 6 caracteres.';
    } elseif (!in_array($statusAcademico, ['regular', 'trancado', 'jubilado', 'evadido'], true)) {
        $erro = 'Status academico invalido.';
    } elseif (!in_array($statusUsuario, ['ativo', 'inativo'], true)) {
        $erro = 'Status de acesso invalido.';
    } else {
        // A transacao evita aluno sem usuario ou usuario sem aluno.
        $pdo->beginTransaction();
        try {
            if ($modoEdicao) {
                // Atualiza primeiro a tabela usuarios, que controla login e acesso.
                $paramsUsuario = [
                    ':nome' => $nome,
                    ':email' => $email,
                    ':status' => $statusUsuario,
                    ':id_usuario' => $aluno['id_usuario'],
                ];
                $sqlUsuario = 'UPDATE usuarios SET nome = :nome, email = :email, status = :status';

                if ($senha !== '') {
                    // Na edicao, a senha so muda se o campo for preenchido.
                    $sqlUsuario .= ', senha_hash = :senha_hash';
                    $paramsUsuario[':senha_hash'] = gerarHashSenha($senha);
                }

                $sqlUsuario .= ' WHERE id_usuario = :id_usuario';
                executar($sqlUsuario, $paramsUsuario);

                // Depois atualiza a tabela alunos, que guarda dados academicos.
                executar(
                    'UPDATE alunos
                     SET matricula = :matricula, cpf = :cpf, telefone = :telefone,
                         data_nascimento = :data_nascimento, endereco = :endereco,
                         status_academico = :status_academico
                     WHERE id_aluno = :id_aluno',
                    [
                        ':matricula' => $matricula,
                        ':cpf' => $cpf,
                        ':telefone' => $telefone,
                        ':data_nascimento' => $dataNascimento,
                        ':endereco' => $endereco,
                        ':status_academico' => $statusAcademico,
                        ':id_aluno' => $idAluno,
                    ]
                );
            } else {
                // No cadastro, cria primeiro o usuario de login com perfil aluno.
                executar(
                    'INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
                     VALUES (:nome, :email, :senha_hash, "aluno", :status)',
                    [
                        ':nome' => $nome,
                        ':email' => $email,
                        // A senha nunca e salva em texto puro; somente o SHA256.
                        ':senha_hash' => gerarHashSenha($senha),
                        ':status' => $statusUsuario,
                    ]
                );
                $idUsuario = $pdo->lastInsertId();

                // Depois cria o cadastro academico ligado ao id_usuario criado.
                executar(
                    'INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
                     VALUES (:id_usuario, :matricula, :cpf, :telefone, :data_nascimento, :endereco, :status_academico)',
                    [
                        ':id_usuario' => $idUsuario,
                        ':matricula' => $matricula,
                        ':cpf' => $cpf,
                        ':telefone' => $telefone,
                        ':data_nascimento' => $dataNascimento,
                        ':endereco' => $endereco,
                        ':status_academico' => $statusAcademico,
                    ]
                );
            }

            $pdo->commit();
            registrarLogSistema($modoEdicao ? 'Editou aluno' : 'Cadastrou aluno');
            $sucesso = $modoEdicao ? 'Aluno atualizado com sucesso.' : 'Aluno cadastrado com sucesso. Matricula: ' . $matricula;
        } catch (Throwable $erroBanco) {
            // Desfaz as alteracoes se qualquer parte falhar.
            $pdo->rollBack();
            $erro = 'Erro ao salvar aluno: ' . $erroBanco->getMessage();
        }
    }
}

$tituloPagina = $modoEdicao ? 'Editar Aluno' : 'Cadastro de Aluno';
$textoPagina = $modoEdicao ? 'Atualize os dados pessoais, academicos e de acesso do aluno.' : 'Cria o usuario de login e o cadastro academico do aluno.';

appInicio($tituloPagina, 'administrativo', 'aluno_form', '../../');
pageHeading('Cadastro', $tituloPagina, $textoPagina);
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Aluno salvo', $sucesso); ?><?php endif; ?>

    <!-- Formulario com dados pessoais, academicos e de acesso do aluno. -->
    <section class="panel">
      <div class="panel-header"><h2>Dados pessoais</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field"><span>Nome completo</span><input class="control" name="nome" value="<?= e($valores['nome']) ?>" required></label>
          <label class="field"><span>E-mail</span><input class="control" type="email" name="email" value="<?= e($valores['email']) ?>" required></label>
          <label class="field"><span><?= $modoEdicao ? 'Nova senha' : 'Senha inicial' ?></span><input class="control" type="password" name="senha" <?= $modoEdicao ? 'placeholder="Preencha apenas se quiser trocar"' : 'required' ?>></label>
          <label class="field"><span>Matricula</span><input class="control" name="matricula" value="<?= e($valores['matricula']) ?>" placeholder="Gerada automaticamente se vazio" <?= $modoEdicao ? 'required' : '' ?>></label>
          <label class="field"><span>CPF</span><input class="control" name="cpf" data-mask="cpf" value="<?= e($valores['cpf']) ?>" required></label>
          <label class="field"><span>Telefone</span><input class="control" name="telefone" data-mask="phone" value="<?= e($valores['telefone']) ?>"></label>
          <label class="field"><span>Data de nascimento</span><input class="control" name="data_nascimento" type="date" value="<?= e($valores['data_nascimento']) ?>"></label>
          <label class="field">
            <span>Status academico</span>
            <select class="select" name="status_academico">
              <option value="regular" <?= $valores['status_academico'] === 'regular' ? 'selected' : '' ?>>Regular</option>
              <option value="trancado" <?= $valores['status_academico'] === 'trancado' ? 'selected' : '' ?>>Trancado</option>
              <option value="jubilado" <?= $valores['status_academico'] === 'jubilado' ? 'selected' : '' ?>>Jubilado</option>
              <option value="evadido" <?= $valores['status_academico'] === 'evadido' ? 'selected' : '' ?>>Evadido</option>
            </select>
          </label>
          <label class="field">
            <span>Acesso</span>
            <select class="select" name="status_usuario">
              <option value="ativo" <?= $valores['status_usuario'] === 'ativo' ? 'selected' : '' ?>>Ativo</option>
              <option value="inativo" <?= $valores['status_usuario'] === 'inativo' ? 'selected' : '' ?>>Inativo</option>
            </select>
          </label>
          <label class="field span-2"><span>Endereco</span><input class="control" name="endereco" value="<?= e($valores['endereco']) ?>"></label>
          <div class="actions span-2" style="justify-content:flex-start">
            <button class="btn primary" type="submit"><?= $modoEdicao ? 'Atualizar aluno' : 'Salvar aluno' ?></button>
            <a class="btn ghost" href="alunos.php">Voltar</a>
          </div>
        </form>
      </div>
    </section>
<?php appFim('../../'); ?>
