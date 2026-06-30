<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin'], '../../');

// Indicadores principais da coordenacao academica.
$totalCursos = contarRegistros('cursos');
$totalTurmas = contarRegistros('turmas');
$totalDisciplinas = contarRegistros('disciplinas');
$alertas = contarRegistros('alerta_risco', '*', 'status = "pendente"');

// Lista turmas recentes com curso e professor responsavel.
$ultimasTurmas = buscarTodos(
    'SELECT t.codigo_turma, t.turno, t.periodo_letivo, t.status, c.nome AS curso, u.nome AS professor
     FROM turmas t
     JOIN cursos c ON c.id_curso = t.id_curso
     JOIN professores p ON p.id_professor = t.id_professor
     JOIN usuarios u ON u.id_usuario = p.id_usuario
     ORDER BY t.id_turma DESC
     LIMIT 8'
);

appInicio('Dashboard Coordenacao', 'coordenacao', 'dashboard', '../../');
pageHeading('Coordenacao', 'Dashboard Coordenacao', 'Indicadores de cursos, turmas e alertas academicos.');
?>
    <!-- Cards de resumo da area pedagogica. -->
    <section class="grid four">
      <article class="card metric-card"><div class="metric-label">Cursos</div><div class="metric-value" data-count-to="<?= e($totalCursos) ?>"><?= e($totalCursos) ?></div><div class="metric-meta positive">Cadastrados</div></article>
      <article class="card metric-card"><div class="metric-label">Turmas</div><div class="metric-value" data-count-to="<?= e($totalTurmas) ?>"><?= e($totalTurmas) ?></div><div class="metric-meta">No banco</div></article>
      <article class="card metric-card"><div class="metric-label">UCs</div><div class="metric-value" data-count-to="<?= e($totalDisciplinas) ?>"><?= e($totalDisciplinas) ?></div><div class="metric-meta">Unidades curriculares</div></article>
      <article class="card metric-card"><div class="metric-label">Alertas</div><div class="metric-value" data-count-to="<?= e($alertas) ?>"><?= e($alertas) ?></div><div class="metric-meta warning">Pendentes</div></article>
    </section>

    <!-- Tabela com as turmas cadastradas mais recentemente. -->
    <section class="panel">
      <div class="panel-header"><h2>Ultimas turmas</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Turma</th><th>Curso</th><th>Professor</th><th>Turno</th><th>Periodo</th><th>Status</th></tr></thead>
            <tbody>
              <?php foreach ($ultimasTurmas as $turma): ?>
                <tr>
                  <td><strong><?= e($turma['codigo_turma']) ?></strong></td>
                  <td><?= e($turma['curso']) ?></td>
                  <td><?= e($turma['professor']) ?></td>
                  <td><?= e(textoStatus($turma['turno'])) ?></td>
                  <td><?= e($turma['periodo_letivo']) ?></td>
                  <td><?= badge($turma['status'], $turma['status']) ?></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$ultimasTurmas): ?>
                <tr><td colspan="6">Nenhuma turma cadastrada.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
