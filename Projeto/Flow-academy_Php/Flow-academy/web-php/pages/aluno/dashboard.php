<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['aluno'], '../../');

// Pega o usuario logado para descobrir qual aluno pertence a essa sessao.
$usuario = usuarioLogado();
$aluno = buscarUm(
    'SELECT a.*, u.nome, u.email
     FROM alunos a
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     WHERE a.id_usuario = :id_usuario',
    [':id_usuario' => $usuario['id_usuario']]
);

$matricula = null;
$mediaGeral = 0;
$frequenciaMedia = 0;
$pendencias = 0;

if ($aluno) {
    // Busca a matricula mais recente para mostrar a turma/curso atual do aluno.
    $matricula = buscarUm(
        'SELECT m.*, t.codigo_turma, c.nome AS curso
         FROM matriculas m
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE m.id_aluno = :id_aluno
         ORDER BY m.data_matricula DESC
         LIMIT 1',
        [':id_aluno' => $aluno['id_aluno']]
    );

    // Calcula a media geral com AVG nas medias das UCs lancadas.
    $linhaMedia = buscarUm(
        'SELECT AVG(media_uc) AS media FROM notas WHERE id_matricula = :id_matricula',
        [':id_matricula' => $matricula['id_matricula'] ?? 0]
    );
    $mediaGeral = (float) ($linhaMedia['media'] ?? 0);

    // Calcula a frequencia media das UCs do aluno.
    $linhaFrequencia = buscarUm(
        'SELECT AVG(percentual) AS frequencia FROM frequencia WHERE id_matricula = :id_matricula',
        [':id_matricula' => $matricula['id_matricula'] ?? 0]
    );
    $frequenciaMedia = (float) ($linhaFrequencia['frequencia'] ?? 0);

    // Conta pagamentos em aberto do aluno.
    $pendencias = contarRegistros('pagamentos', '*', 'id_aluno = :id_aluno AND status IN ("pendente", "atrasado")', [
        ':id_aluno' => $aluno['id_aluno'],
    ]);
}

appInicio('Dashboard Aluno', 'aluno', 'dashboard', '../../');
pageHeading('Aluno', 'Dashboard Aluno', 'Resumo academico conectado ao banco de dados.');
?>
    <?php if (!$aluno): ?>
      <?php alerta('danger', 'Aluno nao encontrado', 'Este usuario existe, mas ainda nao possui cadastro na tabela alunos.'); ?>
    <?php else: ?>
      <!-- Cards com resumo academico e financeiro do aluno. -->
      <section class="grid four">
        <article class="card metric-card">
          <div class="metric-label">Media geral</div>
          <div class="metric-value" data-count-to="<?= e(round($mediaGeral)) ?>"><?= e(numeroBr($mediaGeral, 1)) ?></div>
          <div class="metric-meta <?= $mediaGeral >= 6 ? 'positive' : 'warning' ?>">Criterio minimo: 6,0</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Frequencia</div>
          <div class="metric-value" data-count-to="<?= e(round($frequenciaMedia)) ?>" data-suffix="%"><?= e(numeroBr($frequenciaMedia, 0)) ?>%</div>
          <div class="metric-meta <?= $frequenciaMedia >= 75 ? 'positive' : 'warning' ?>">Minimo recomendado: 75%</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Pendencias</div>
          <div class="metric-value" data-count-to="<?= e($pendencias) ?>"><?= e($pendencias) ?></div>
          <div class="metric-meta warning">Pagamentos em aberto</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Status</div>
          <div class="metric-value"><?= e(textoStatus($aluno['status_academico'])) ?></div>
          <div class="metric-meta positive">Matricula <?= e($aluno['matricula']) ?></div>
        </article>
      </section>

      <!-- Dados pessoais e matricula atual ficam separados em dois paineis. -->
      <section class="grid two">
        <article class="panel">
          <div class="panel-header"><h2>Dados do aluno</h2></div>
          <div class="panel-body">
            <div class="info-list">
              <div><span>Nome</span><strong><?= e($aluno['nome']) ?></strong></div>
              <div><span>E-mail</span><strong><?= e($aluno['email']) ?></strong></div>
              <div><span>CPF</span><strong><?= e($aluno['cpf']) ?></strong></div>
              <div><span>Telefone</span><strong><?= e($aluno['telefone']) ?></strong></div>
            </div>
          </div>
        </article>

        <article class="panel">
          <div class="panel-header"><h2>Matricula atual</h2></div>
          <div class="panel-body">
            <?php if ($matricula): ?>
              <div class="info-list">
                <div><span>Curso</span><strong><?= e($matricula['curso']) ?></strong></div>
                <div><span>Turma</span><strong><?= e($matricula['codigo_turma']) ?></strong></div>
                <div><span>Data</span><strong><?= e(dataBr($matricula['data_matricula'])) ?></strong></div>
                <div><span>Status</span><strong><?= badge($matricula['status'], $matricula['status']) ?></strong></div>
              </div>
            <?php else: ?>
              <?php alerta('warning', 'Sem matricula', 'Nenhuma matricula foi encontrada para este aluno.'); ?>
            <?php endif; ?>
          </div>
        </article>
      </section>
    <?php endif; ?>
<?php appFim('../../'); ?>
