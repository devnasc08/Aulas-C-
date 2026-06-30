<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['professor'], '../../');

// Identifica o professor vinculado ao usuario logado.
$usuario = usuarioLogado();
$professor = buscarUm(
    'SELECT p.*, u.nome, u.email
     FROM professores p
     JOIN usuarios u ON u.id_usuario = p.id_usuario
     WHERE p.id_usuario = :id_usuario',
    [':id_usuario' => $usuario['id_usuario']]
);

$turmas = [];
$totalAlunos = 0;
$totalNotas = 0;
$mediaTurmas = 0;

if ($professor) {
    // Lista as turmas atribuidas ao professor, contando matriculas ativas.
    $turmas = buscarTodos(
        'SELECT t.*, c.nome AS curso, COUNT(m.id_matricula) AS matriculados
         FROM turmas t
         JOIN cursos c ON c.id_curso = t.id_curso
         LEFT JOIN matriculas m ON m.id_turma = t.id_turma AND m.status = "ativa"
         WHERE t.id_professor = :id_professor
         GROUP BY t.id_turma
         ORDER BY t.periodo_letivo DESC, t.codigo_turma',
        [':id_professor' => $professor['id_professor']]
    );

    // Resume quantidade de alunos, notas e media geral das turmas do professor.
    $linha = buscarUm(
        'SELECT COUNT(DISTINCT m.id_matricula) AS alunos, COUNT(n.id_nota) AS notas, AVG(n.media_uc) AS media
         FROM turmas t
         LEFT JOIN matriculas m ON m.id_turma = t.id_turma
         LEFT JOIN notas n ON n.id_matricula = m.id_matricula
         WHERE t.id_professor = :id_professor',
        [':id_professor' => $professor['id_professor']]
    );
    $totalAlunos = (int) ($linha['alunos'] ?? 0);
    $totalNotas = (int) ($linha['notas'] ?? 0);
    $mediaTurmas = (float) ($linha['media'] ?? 0);
}

appInicio('Dashboard Professor', 'professor', 'dashboard', '../../');
pageHeading('Professor', 'Dashboard Professor', 'Turmas, alunos e notas vinculados ao professor logado.');
?>
    <?php if (!$professor): ?>
      <?php alerta('danger', 'Professor nao encontrado', 'Este usuario existe, mas ainda nao possui cadastro na tabela professores.'); ?>
    <?php else: ?>
      <!-- Indicadores principais do professor logado. -->
      <section class="grid four">
        <article class="card metric-card">
          <div class="metric-label">Turmas</div>
          <div class="metric-value" data-count-to="<?= e(count($turmas)) ?>"><?= e(count($turmas)) ?></div>
          <div class="metric-meta positive">Turmas atribuidas</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Alunos</div>
          <div class="metric-value" data-count-to="<?= e($totalAlunos) ?>"><?= e($totalAlunos) ?></div>
          <div class="metric-meta">Matriculas ativas</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Notas lancadas</div>
          <div class="metric-value" data-count-to="<?= e($totalNotas) ?>"><?= e($totalNotas) ?></div>
          <div class="metric-meta">Registros em notas</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Media das turmas</div>
          <div class="metric-value"><?= e(numeroBr($mediaTurmas, 1)) ?></div>
          <div class="metric-meta <?= $mediaTurmas >= 6 ? 'positive' : 'warning' ?>">Base: medias lancadas</div>
        </article>
      </section>

      <!-- Tabela das turmas sob responsabilidade do professor. -->
      <section class="panel">
        <div class="panel-header"><h2>Minhas turmas</h2></div>
        <div class="panel-body">
          <div class="table-wrap">
            <table id="tabela-principal">
              <thead><tr><th>Turma</th><th>Curso</th><th>Turno</th><th>Periodo</th><th>Alunos</th><th>Status</th></tr></thead>
              <tbody>
                <?php foreach ($turmas as $turma): ?>
                  <tr>
                    <td><strong><?= e($turma['codigo_turma']) ?></strong></td>
                    <td><?= e($turma['curso']) ?></td>
                    <td><?= e(textoStatus($turma['turno'])) ?></td>
                    <td><?= e($turma['periodo_letivo']) ?></td>
                    <td><?= e($turma['matriculados']) ?>/<?= e($turma['capacidade_maxima']) ?></td>
                    <td><?= badge($turma['status'], $turma['status']) ?></td>
                  </tr>
                <?php endforeach; ?>
                <?php if (!$turmas): ?>
                  <tr><td colspan="6">Nenhuma turma vinculada a este professor.</td></tr>
                <?php endif; ?>
              </tbody>
            </table>
          </div>
        </div>
      </section>
    <?php endif; ?>
<?php appFim('../../'); ?>
