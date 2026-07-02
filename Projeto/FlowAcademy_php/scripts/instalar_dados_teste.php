<?php

require_once __DIR__ . '/../web-php/includes/helpers.php';

// Pagina auxiliar para criar dados de demonstracao depois de importar o SQL.
// Ela nao aparece no login; serve apenas para facilitar testes durante o projeto.

$mensagem = '';
$erro = '';

function criarUsuarioTeste($nome, $email, $perfil)
{
    global $pdo;

    // Primeiro verifica se o usuario ja existe para nao duplicar dados.
    $usuario = buscarUm('SELECT id_usuario FROM usuarios WHERE email = :email', [':email' => $email]);

    if ($usuario) {
        return (int) $usuario['id_usuario'];
    }

    // Todos os usuarios de teste recebem a senha 123456, salva com SHA256.
    executar(
        'INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
         VALUES (:nome, :email, :senha_hash, :perfil, "ativo")',
        [
            ':nome' => $nome,
            ':email' => $email,
            ':senha_hash' => gerarHashSenha('123456'),
            ':perfil' => $perfil,
        ]
    );

    return (int) $pdo->lastInsertId();
}

function criarAlunoTeste($idUsuario, $matricula, $cpf, $telefone)
{
    global $pdo;

    // Evita criar dois alunos para o mesmo usuario.
    $aluno = buscarUm('SELECT id_aluno FROM alunos WHERE id_usuario = :id_usuario', [':id_usuario' => $idUsuario]);

    if ($aluno) {
        return (int) $aluno['id_aluno'];
    }

    // Cria o cadastro academico vinculado ao usuario de login.
    executar(
        'INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
         VALUES (:id_usuario, :matricula, :cpf, :telefone, :data_nascimento, :endereco, "regular")',
        [
            ':id_usuario' => $idUsuario,
            ':matricula' => $matricula,
            ':cpf' => $cpf,
            ':telefone' => $telefone,
            ':data_nascimento' => '2006-03-18',
            ':endereco' => 'Rua das Palmeiras, 120',
        ]
    );

    return (int) $pdo->lastInsertId();
}

function criarProfessorTeste($idUsuario)
{
    global $pdo;

    // Evita criar dois professores para o mesmo usuario.
    $professor = buscarUm('SELECT id_professor FROM professores WHERE id_usuario = :id_usuario', [':id_usuario' => $idUsuario]);

    if ($professor) {
        return (int) $professor['id_professor'];
    }

    // Cria o cadastro profissional vinculado ao usuario de login.
    executar(
        'INSERT INTO professores (id_usuario, cpf, especialidade)
         VALUES (:id_usuario, :cpf, :especialidade)',
        [
            ':id_usuario' => $idUsuario,
            ':cpf' => '111.222.333-44',
            ':especialidade' => 'Desenvolvimento de sistemas',
        ]
    );

    return (int) $pdo->lastInsertId();
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    try {
        // Transacao garante que o pacote de dados de teste seja criado por completo.
        $pdo->beginTransaction();

        // Usuarios principais para testar os perfis do sistema.
        $idAdmin = criarUsuarioTeste('Admin Flow', 'admin@flowacademy.com', 'admin');
        criarUsuarioTeste('Coordenacao Flow', 'coordenacao@flowacademy.com', 'coordenacao');
        criarUsuarioTeste('Administrativo Flow', 'administrativo@flowacademy.com', 'administrativo');
        $idUsuarioProfessor = criarUsuarioTeste('Marcos Oliveira', 'professor@flowacademy.com', 'professor');
        $idUsuarioAluno = criarUsuarioTeste('Ana Martins', 'aluno@flowacademy.com', 'aluno');
        $idUsuarioAluno2 = criarUsuarioTeste('Bruno Farias', 'bruno@flowacademy.com', 'aluno');

        // Cadastros academicos vinculados aos usuarios de professor e alunos.
        $idProfessor = criarProfessorTeste($idUsuarioProfessor);
        $idAluno = criarAlunoTeste($idUsuarioAluno, '2026-0014', '123.456.789-10', '(11) 98888-1010');
        $idAluno2 = criarAlunoTeste($idUsuarioAluno2, '2026-0021', '987.654.321-10', '(11) 97777-2020');

        // Procura o curso de teste; se nao existir, cria.
        $curso = buscarUm('SELECT id_curso FROM cursos WHERE nome = :nome', [':nome' => 'Tecnico em Informatica']);
        if ($curso) {
            $idCurso = (int) $curso['id_curso'];
        } else {
            executar(
                'INSERT INTO cursos (nome, descricao, carga_horaria, status)
                 VALUES ("Tecnico em Informatica", "Curso tecnico com foco em sistemas web e banco de dados.", 1200, "ativo")'
            );
            $idCurso = (int) $pdo->lastInsertId();
        }

        // Unidades curriculares basicas usadas para boletim e frequencia.
        $ucs = [
            ['Logica de programacao', 80],
            ['Banco de dados', 80],
            ['Projeto Integrador', 100],
        ];

        foreach ($ucs as $uc) {
            // Cada UC so e criada se ainda nao existir para o curso.
            $existe = buscarUm(
                'SELECT id_disciplina FROM disciplinas WHERE id_curso = :id_curso AND nome = :nome',
                [':id_curso' => $idCurso, ':nome' => $uc[0]]
            );

            if (!$existe) {
                executar(
                    'INSERT INTO disciplinas (id_curso, nome, carga_horaria)
                     VALUES (:id_curso, :nome, :carga_horaria)',
                    [
                        ':id_curso' => $idCurso,
                        ':nome' => $uc[0],
                        ':carga_horaria' => $uc[1],
                    ]
                );
            }
        }

        // Cria uma turma padrao ligada ao curso e ao professor de teste.
        $turma = buscarUm('SELECT id_turma FROM turmas WHERE codigo_turma = "TI-1A"');
        if ($turma) {
            $idTurma = (int) $turma['id_turma'];
        } else {
            executar(
                'INSERT INTO turmas (id_curso, id_professor, codigo_turma, turno, periodo_letivo, capacidade_maxima, status)
                 VALUES (:id_curso, :id_professor, "TI-1A", "noite", "2026.1", 35, "ativa")',
                [
                    ':id_curso' => $idCurso,
                    ':id_professor' => $idProfessor,
                ]
            );
            $idTurma = (int) $pdo->lastInsertId();
        }

        foreach ([$idAluno, $idAluno2] as $idAlunoLoop) {
            // Matricula os alunos na turma de teste se ainda nao estiverem matriculados.
            $matricula = buscarUm(
                'SELECT id_matricula FROM matriculas WHERE id_aluno = :id_aluno AND id_turma = :id_turma',
                [':id_aluno' => $idAlunoLoop, ':id_turma' => $idTurma]
            );

            if ($matricula) {
                $idMatricula = (int) $matricula['id_matricula'];
            } else {
                executar(
                    'INSERT INTO matriculas (id_aluno, id_turma, data_matricula, status)
                     VALUES (:id_aluno, :id_turma, CURDATE(), "ativa")',
                    [':id_aluno' => $idAlunoLoop, ':id_turma' => $idTurma]
                );
                $idMatricula = (int) $pdo->lastInsertId();
            }

            // Busca todas as UCs do curso para gerar notas e frequencias iniciais.
            $disciplinas = buscarTodos('SELECT id_disciplina FROM disciplinas WHERE id_curso = :id_curso', [':id_curso' => $idCurso]);

            foreach ($disciplinas as $indice => $disciplina) {
                // Gera notas diferentes para cada aluno, simulando dados reais.
                $base = $idAlunoLoop === $idAluno ? 8.0 : 6.0;
                $p1 = $base + ($indice * 0.2);
                $p2 = $base - 0.3;
                $trabalho = $base + 0.5;
                $comportamental = 9.0;
                $media = ($p1 * 0.30) + ($p2 * 0.30) + ($trabalho * 0.30) + ($comportamental * 0.10);
                $status = $media >= 6.0 ? 'aprovado' : 'reprovado';

                // Insere ou atualiza as notas de cada UC.
                executar(
                    'INSERT INTO notas (id_matricula, id_disciplina, prova_1, prova_2, trabalho, comportamental, media_uc, status)
                     VALUES (:id_matricula, :id_disciplina, :prova_1, :prova_2, :trabalho, :comportamental, :media_uc, :status)
                     ON DUPLICATE KEY UPDATE prova_1 = VALUES(prova_1), prova_2 = VALUES(prova_2),
                       trabalho = VALUES(trabalho), comportamental = VALUES(comportamental),
                       media_uc = VALUES(media_uc), status = VALUES(status)',
                    [
                        ':id_matricula' => $idMatricula,
                        ':id_disciplina' => $disciplina['id_disciplina'],
                        ':prova_1' => $p1,
                        ':prova_2' => $p2,
                        ':trabalho' => $trabalho,
                        ':comportamental' => $comportamental,
                        ':media_uc' => $media,
                        ':status' => $status,
                    ]
                );

                // Insere ou atualiza a frequencia de cada UC.
                executar(
                    'INSERT INTO frequencia (id_matricula, id_disciplina, total_aulas, presencas)
                     VALUES (:id_matricula, :id_disciplina, 20, :presencas)
                     ON DUPLICATE KEY UPDATE total_aulas = VALUES(total_aulas), presencas = VALUES(presencas)',
                    [
                        ':id_matricula' => $idMatricula,
                        ':id_disciplina' => $disciplina['id_disciplina'],
                        ':presencas' => $idAlunoLoop === $idAluno ? 18 : 15,
                    ]
                );
            }
        }

        foreach ([$idAluno, $idAluno2] as $indice => $idAlunoLoop) {
            // Cria um pagamento inicial para cada aluno, se ele ainda nao tiver cobranca.
            $existePagamento = buscarUm('SELECT id_pagamento FROM pagamentos WHERE id_aluno = :id_aluno LIMIT 1', [':id_aluno' => $idAlunoLoop]);

            if (!$existePagamento) {
                executar(
                    'INSERT INTO pagamentos (id_aluno, valor, vencimento, status)
                     VALUES (:id_aluno, :valor, :vencimento, :status)',
                    [
                        ':id_aluno' => $idAlunoLoop,
                        ':valor' => $indice === 0 ? 350.00 : 350.00,
                        ':vencimento' => $indice === 0 ? date('Y-m-d', strtotime('+10 days')) : date('Y-m-d', strtotime('-5 days')),
                        ':status' => $indice === 0 ? 'pendente' : 'atrasado',
                    ]
                );
            }
        }

        // Registra no log que os dados de teste foram criados.
        executar(
            'INSERT INTO logs (id_usuario, acao, ip) VALUES (:id_usuario, :acao, :ip)',
            [
                ':id_usuario' => $idAdmin,
                ':acao' => 'Criou dados de teste',
                ':ip' => $_SERVER['REMOTE_ADDR'] ?? null,
            ]
        );

        $pdo->commit();
        $mensagem = 'Dados de teste criados com sucesso.';
    } catch (Throwable $erroBanco) {
        // Se qualquer etapa falhar, nada fica salvo pela metade.
        $pdo->rollBack();
        $erro = 'Erro ao criar dados de teste: ' . $erroBanco->getMessage();
    }
}
?>
<!doctype html>
<html lang="pt-BR">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Dados de Teste | Flow Academy Platform</title>
  <!-- Bootstrap 5.0.2 local: base obrigatoria de CSS do sistema PHP. -->
  <link href="../web-php/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Complemento visual proprio do projeto, sempre carregado depois do Bootstrap. -->
  <link rel="stylesheet" href="../web-php/assets/css/main.css?v=20260622-2">
</head>
<body class="auth-shell">
  <!-- Tela simples para executar a carga de dados de teste. -->
  <main class="auth-card">
    <a class="brand" href="../web-php/login.php">
      <img class="brand-logo" src="../web-php/assets/img/logos/logo-flow-academy-gold.jpg" alt="Logo Flow Academy">
    </a>
    <h1 class="auth-title">Dados de teste</h1>
    <p class="auth-subtitle">Use depois de importar o arquivo <strong>banco/Banco_oficial.sql</strong> no MySQL.</p>

    <?php if ($erro): ?>
      <div class="alert danger"><span class="alert-marker"></span><div><strong>Erro</strong><span class="muted"><?= e($erro) ?></span></div></div>
    <?php endif; ?>

    <?php if ($mensagem): ?>
      <div class="alert success"><span class="alert-marker"></span><div><strong>Pronto</strong><span class="muted"><?= e($mensagem) ?></span></div></div>
      <div class="stack">
        <p class="muted">Senha de todos os usuarios: <strong>123456</strong></p>
        <div class="quick-actions">
          <a class="quick-action" href="../web-php/login.php"><strong>admin@flowacademy.com</strong><span>Perfil admin</span></a>
          <a class="quick-action" href="../web-php/login.php"><strong>professor@flowacademy.com</strong><span>Perfil professor</span></a>
          <a class="quick-action" href="../web-php/login.php"><strong>aluno@flowacademy.com</strong><span>Perfil aluno</span></a>
        </div>
      </div>
    <?php else: ?>
      <form class="stack" method="post">
        <button class="btn primary" type="submit">Criar dados de teste</button>
        <a class="btn ghost" href="../web-php/login.php">Voltar ao login</a>
      </form>
    <?php endif; ?>
  </main>
  <!-- Bootstrap 5.0.2 local: bundle com componentes JS usados pela tela de script. -->
  <script src="../web-php/assets/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Complemento JS proprio do projeto, carregado depois do Bootstrap. -->
  <script src="../web-php/assets/js/app.js?v=20260616-3"></script>
</body>
</html>
