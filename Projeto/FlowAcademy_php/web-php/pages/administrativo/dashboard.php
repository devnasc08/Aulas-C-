<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin', 'administrativo'], '../../');

// Dashboard administrativo unificado: indicadores de cadastro e financeiro.
atualizarPagamentosAtrasados();

$totalAlunos = contarRegistros('alunos');
$matriculasAtivas = contarRegistros('matriculas', '*', 'status = "ativa"');
$alunosRegulares = contarRegistros('alunos', '*', 'status_academico = "regular"');
$totalReceber = buscarUm('SELECT SUM(valor) AS total FROM pagamentos WHERE status IN ("pendente", "atrasado")');
$totalPago = buscarUm('SELECT SUM(valor) AS total FROM pagamentos WHERE status = "pago"');
$pendentes = contarRegistros('pagamentos', '*', 'status = "pendente"');
$atrasados = contarRegistros('pagamentos', '*', 'status = "atrasado"');

// Mostra os alunos mais recentes para acesso rapido ao perfil.
$ultimosAlunos = buscarTodos(
    'SELECT a.id_aluno, a.matricula, a.status_academico, u.nome, u.email
     FROM alunos a
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     ORDER BY a.id_aluno DESC
     LIMIT 8'
);

$pagamentosRecentes = buscarTodos(
    'SELECT p.*, u.nome AS aluno, a.matricula
     FROM pagamentos p
     JOIN alunos a ON a.id_aluno = p.id_aluno
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     ORDER BY p.vencimento DESC
     LIMIT 8'
);

appInicio('Dashboard Administrativo', 'administrativo', 'dashboard', '../../');
pageHeading(
    'Administrativo',
    'Dashboard Administrativo',
    'Cadastros, matriculas e financeiro em um unico painel.',
    '<a class="btn primary" href="../financeiro/pagamento_form.php">Novo pagamento</a>'
);
?>
    <!-- Cards com os numeros principais do administrativo. -->
    <section class="grid four">
      <article class="card metric-card"><div class="metric-label">Alunos</div><div class="metric-value" data-count-to="<?= e($totalAlunos) ?>"><?= e($totalAlunos) ?></div><div class="metric-meta positive">Cadastrados</div></article>
      <article class="card metric-card"><div class="metric-label">Matriculas</div><div class="metric-value" data-count-to="<?= e($matriculasAtivas) ?>"><?= e($matriculasAtivas) ?></div><div class="metric-meta">Ativas</div></article>
      <article class="card metric-card"><div class="metric-label">Regulares</div><div class="metric-value" data-count-to="<?= e($alunosRegulares) ?>"><?= e($alunosRegulares) ?></div><div class="metric-meta">Status academico</div></article>
      <article class="card metric-card"><div class="metric-label">A receber</div><div class="metric-value"><?= e(moedaBr($totalReceber['total'] ?? 0)) ?></div><div class="metric-meta warning">Pendentes e atrasados</div></article>
    </section>

    <!-- Segunda linha do mesmo dashboard com os detalhes financeiros. -->
    <section class="grid four">
      <article class="card metric-card"><div class="metric-label">Recebido</div><div class="metric-value"><?= e(moedaBr($totalPago['total'] ?? 0)) ?></div><div class="metric-meta positive">Pagos</div></article>
      <article class="card metric-card"><div class="metric-label">Pendentes</div><div class="metric-value" data-count-to="<?= e($pendentes) ?>"><?= e($pendentes) ?></div><div class="metric-meta">Aguardando pagamento</div></article>
      <article class="card metric-card"><div class="metric-label">Atrasados</div><div class="metric-value" data-count-to="<?= e($atrasados) ?>"><?= e($atrasados) ?></div><div class="metric-meta warning">Necessitam contato</div></article>
      <article class="card metric-card"><div class="metric-label">Painel unico</div><div class="metric-value">ADM</div><div class="metric-meta">Financeiro integrado</div></article>
    </section>

    <!-- Tabela dos ultimos alunos cadastrados. -->
    <section class="panel">
      <div class="panel-header"><h2>Ultimos alunos</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Aluno</th><th>Matricula</th><th>E-mail</th><th>Status</th><th>Acoes</th></tr></thead>
            <tbody>
              <?php foreach ($ultimosAlunos as $aluno): ?>
                <tr>
                  <td><strong><?= e($aluno['nome']) ?></strong></td>
                  <td><?= e($aluno['matricula']) ?></td>
                  <td><?= e($aluno['email']) ?></td>
                  <td><?= badge($aluno['status_academico'], $aluno['status_academico']) ?></td>
                  <td>
                    <div class="actions" style="justify-content:flex-start">
                      <a class="btn ghost" href="aluno_ver.php?id=<?= e($aluno['id_aluno']) ?>">Ver</a>
                      <a class="btn ghost" href="aluno_form.php?id=<?= e($aluno['id_aluno']) ?>">Editar</a>
                    </div>
                  </td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$ultimosAlunos): ?>
                <tr><td colspan="5">Nenhum aluno cadastrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>

    <!-- Pagamentos recentes ficam no mesmo dashboard administrativo. -->
    <section class="panel">
      <div class="panel-header"><h2>Pagamentos recentes</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table>
            <thead><tr><th>Aluno</th><th>Matricula</th><th>Valor</th><th>Vencimento</th><th>Status</th><th>Acoes</th></tr></thead>
            <tbody>
              <?php foreach ($pagamentosRecentes as $pagamento): ?>
                <tr>
                  <td><strong><?= e($pagamento['aluno']) ?></strong></td>
                  <td><?= e($pagamento['matricula']) ?></td>
                  <td><?= e(moedaBr($pagamento['valor'])) ?></td>
                  <td><?= e(dataBr($pagamento['vencimento'])) ?></td>
                  <td><?= badge($pagamento['status'], $pagamento['status']) ?></td>
                  <td><a class="btn ghost" href="../financeiro/pagamento_form.php?id=<?= e($pagamento['id_pagamento']) ?>">Editar</a></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$pagamentosRecentes): ?>
                <tr><td colspan="6">Nenhum pagamento cadastrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
