<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin', 'administrativo'], '../../');

// Tela de matricula: liga um aluno regular a uma turma ativa.
$erro = '';
$sucesso = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // A matricula liga um aluno a uma turma.
    $idAluno = (int) post('id_aluno');
    $idTurma = (int) post('id_turma');

    if ($idAluno <= 0 || $idTurma <= 0) {
        $erro = 'Selecione aluno e turma.';
    } else {
        try {
            // A transacao protege a verificacao de vagas e a insercao da matricula.
            $pdo->beginTransaction();

            // FOR UPDATE impede que duas requisicoes ocupem a mesma ultima vaga.
            $turma = buscarUm(
                'SELECT capacidade_maxima, status
                 FROM turmas
                 WHERE id_turma = :id_turma
                 FOR UPDATE',
                [':id_turma' => $idTurma]
            );

            if (!$turma || $turma['status'] !== 'ativa') {
                throw new RuntimeException('A turma selecionada nao esta disponivel para matricula.');
            }

            // A tabela possui uma chave unica para aluno e turma, mas validamos antes
            // para apresentar uma mensagem mais clara ao usuario.
            $duplicada = buscarUm(
                'SELECT COUNT(*) AS total
                 FROM matriculas
                 WHERE id_aluno = :id_aluno AND id_turma = :id_turma',
                [':id_aluno' => $idAluno, ':id_turma' => $idTurma]
            );

            if ((int) ($duplicada['total'] ?? 0) > 0) {
                throw new RuntimeException('Este aluno ja possui matricula nesta turma.');
            }

            // Conta somente matriculas ativas, porque canceladas nao ocupam vaga.
            $lotacao = buscarUm(
                'SELECT COUNT(*) AS total
                 FROM matriculas
                 WHERE id_turma = :id_turma AND status = "ativa"',
                [':id_turma' => $idTurma]
            );

            if ((int) ($lotacao['total'] ?? 0) >= (int) $turma['capacidade_maxima']) {
                throw new RuntimeException('Limite de vagas da turma atingido.');
            }

            // Insere a matricula diretamente com SQL preparado, sem procedure.
            executar(
                'INSERT INTO matriculas (id_aluno, id_turma, data_matricula, status)
                 VALUES (:id_aluno, :id_turma, CURDATE(), "ativa")',
                [':id_aluno' => $idAluno, ':id_turma' => $idTurma]
            );

            $pdo->commit();
            registrarLogSistema('Realizou matricula');
            $sucesso = 'Matricula realizada com sucesso.';
        } catch (Throwable $erroBanco) {
            // Nenhuma parte da matricula e salva se a turma estiver lotada ou ocorrer erro.
            if ($pdo->inTransaction()) {
                $pdo->rollBack();
            }

            $erro = $erroBanco->getMessage();
        }
    }
}

// Lista apenas alunos regulares para o cadastro de matricula.
$alunos = buscarTodos(
    'SELECT a.id_aluno, a.matricula, u.nome
     FROM alunos a
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     WHERE a.status_academico = "regular"
     ORDER BY u.nome'
);

// Mostra a lotacao atual da turma usando COUNT nas matriculas ativas.
$turmas = buscarTodos(
    'SELECT t.id_turma, t.codigo_turma, c.nome AS curso, t.capacidade_maxima,
            COUNT(m.id_matricula) AS matriculados
     FROM turmas t
     JOIN cursos c ON c.id_curso = t.id_curso
     LEFT JOIN matriculas m ON m.id_turma = t.id_turma AND m.status = "ativa"
     WHERE t.status = "ativa"
     GROUP BY t.id_turma
     ORDER BY c.nome, t.codigo_turma'
);

appInicio('Matricula', 'administrativo', 'matricula', '../../');
pageHeading('Matricula', 'Nova Matricula', 'Matricula o aluno em uma turma ativa, respeitando duplicidade e capacidade.');
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel matricular', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Matricula realizada', $sucesso); ?><?php endif; ?>

    <!-- Formulario com selects de aluno e turma disponiveis. -->
    <section class="panel">
      <div class="panel-header"><h2>Dados da matricula</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field">
            <span>Aluno</span>
            <select class="select" name="id_aluno" required>
              <option value="">Selecione</option>
              <?php foreach ($alunos as $aluno): ?>
                <option value="<?= e($aluno['id_aluno']) ?>"><?= e($aluno['nome'] . ' - ' . $aluno['matricula']) ?></option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field">
            <span>Turma</span>
            <select class="select" name="id_turma" required>
              <option value="">Selecione</option>
              <?php foreach ($turmas as $turma): ?>
                <option value="<?= e($turma['id_turma']) ?>"><?= e($turma['curso'] . ' - ' . $turma['codigo_turma'] . ' (' . $turma['matriculados'] . '/' . $turma['capacidade_maxima'] . ')') ?></option>
              <?php endforeach; ?>
            </select>
          </label>
          <div class="actions span-2" style="justify-content:flex-start"><button class="btn primary" type="submit">Realizar matricula</button></div>
        </form>
      </div>
    </section>
<?php appFim('../../'); ?>
