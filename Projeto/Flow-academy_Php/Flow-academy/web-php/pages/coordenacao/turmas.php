<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin'], '../../');

// Lista turmas com curso, professor e quantidade de matriculas ativas.
$turmas = buscarTodos(
    'SELECT t.*, c.nome AS curso, u.nome AS professor, COUNT(m.id_matricula) AS matriculados
     FROM turmas t
     JOIN cursos c ON c.id_curso = t.id_curso
     JOIN professores p ON p.id_professor = t.id_professor
     JOIN usuarios u ON u.id_usuario = p.id_usuario
     LEFT JOIN matriculas m ON m.id_turma = t.id_turma AND m.status = "ativa"
     GROUP BY t.id_turma
     ORDER BY t.periodo_letivo DESC, t.codigo_turma'
);

appInicio('Turmas', 'coordenacao', 'turmas', '../../');
pageHeading('Turmas', 'Turmas', 'Controle de turmas, professores e capacidade.', '<a class="btn primary" href="turma_form.php">Nova turma</a>');
?>
    <!-- Tabela pesquisavel de turmas cadastradas. -->
    <section class="panel">
      <div class="panel-header"><h2>Turmas cadastradas</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Turma</th><th>Curso</th><th>Professor</th><th>Turno</th><th>Periodo</th><th>Vagas</th><th>Status</th><th>Acoes</th></tr></thead>
            <tbody>
              <?php foreach ($turmas as $turma): ?>
                <tr>
                  <td><strong><?= e($turma['codigo_turma']) ?></strong></td>
                  <td><?= e($turma['curso']) ?></td>
                  <td><?= e($turma['professor']) ?></td>
                  <td><?= e(textoStatus($turma['turno'])) ?></td>
                  <td><?= e($turma['periodo_letivo']) ?></td>
                  <td><?= e($turma['matriculados']) ?>/<?= e($turma['capacidade_maxima']) ?></td>
                  <td><?= badge($turma['status'], $turma['status']) ?></td>
                  <td><a class="btn ghost" href="turma_form.php?id=<?= e($turma['id_turma']) ?>">Editar</a></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$turmas): ?>
                <tr><td colspan="8">Nenhuma turma cadastrada.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
