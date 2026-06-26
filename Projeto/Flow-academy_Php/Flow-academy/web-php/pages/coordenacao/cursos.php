<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin'], '../../');

// Lista cursos, conta UCs e soma as cargas horarias individuais cadastradas.
$cursos = buscarTodos(
    'SELECT c.*, COUNT(d.id_disciplina) AS total_ucs,
            COALESCE(SUM(d.carga_horaria), 0) AS carga_ucs
     FROM cursos c
     LEFT JOIN disciplinas d ON d.id_curso = c.id_curso
     GROUP BY c.id_curso
     ORDER BY c.nome'
);

appInicio('Cursos', 'coordenacao', 'cursos', '../../');
pageHeading('Cursos', 'Cursos', 'Lista de cursos cadastrados no banco.', '<a class="btn primary" href="curso_form.php">Novo curso</a>');
?>
    <!-- Tabela pesquisavel de cursos. -->
    <section class="panel">
      <div class="panel-header"><h2>Cursos cadastrados</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Curso</th><th>Carga do curso</th><th>UCs</th><th>Horas nas UCs</th><th>Status</th><th>Descricao</th><th>Acoes</th></tr></thead>
            <tbody>
              <?php foreach ($cursos as $curso): ?>
                <tr>
                  <td><strong><?= e($curso['nome']) ?></strong></td>
                  <td><?= e($curso['carga_horaria']) ?>h</td>
                  <td><?= e($curso['total_ucs']) ?></td>
                  <td><?= e($curso['carga_ucs']) ?>h</td>
                  <td><?= badge($curso['status'], $curso['status']) ?></td>
                  <td><?= e($curso['descricao']) ?></td>
                  <td><a class="btn ghost" href="curso_form.php?id=<?= e($curso['id_curso']) ?>">Editar</a></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$cursos): ?>
                <tr><td colspan="7">Nenhum curso cadastrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
