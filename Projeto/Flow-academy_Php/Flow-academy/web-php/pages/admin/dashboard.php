<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin'], '../../');

// Dashboard exclusivo do admin com indicadores gerais do sistema.
$usuarios = contarRegistros('usuarios');
$usuariosAtivos = contarRegistros('usuarios', '*', 'status = "ativo"');
$logs = contarRegistros('logs');
$alertas = contarRegistros('alerta_risco', '*', 'status = "pendente"');

// Lista os ultimos eventos registrados para auditoria.
$ultimosLogs = buscarTodos(
    'SELECT l.*, u.nome, u.perfil
     FROM logs l
     JOIN usuarios u ON u.id_usuario = l.id_usuario
     ORDER BY l.data_evento DESC
     LIMIT 10'
);

appInicio('Dashboard Admin', 'admin', 'dashboard', '../../');
pageHeading(
    'Admin',
    'Dashboard Admin',
    'Visao de usuarios, logs e alertas do sistema.',
    '<a class="btn ghost" href="coordenacao_form.php">Cadastrar coordenacao</a><a class="btn primary" href="administrativo_form.php">Cadastrar administrativo</a>'
);
?>
    <!-- Cards de indicadores principais do perfil admin. -->
    <section class="grid four">
      <article class="card metric-card"><div class="metric-label">Usuarios</div><div class="metric-value" data-count-to="<?= e($usuarios) ?>"><?= e($usuarios) ?></div><div class="metric-meta">Total cadastrado</div></article>
      <article class="card metric-card"><div class="metric-label">Ativos</div><div class="metric-value" data-count-to="<?= e($usuariosAtivos) ?>"><?= e($usuariosAtivos) ?></div><div class="metric-meta positive">Podem acessar</div></article>
      <article class="card metric-card"><div class="metric-label">Logs</div><div class="metric-value" data-count-to="<?= e($logs) ?>"><?= e($logs) ?></div><div class="metric-meta">Eventos registrados</div></article>
      <article class="card metric-card"><div class="metric-label">Alertas</div><div class="metric-value" data-count-to="<?= e($alertas) ?>"><?= e($alertas) ?></div><div class="metric-meta warning">Risco academico</div></article>
    </section>

    <!-- Tabela com os logs mais recentes. -->
    <section class="panel">
      <div class="panel-header"><h2>Ultimos logs</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Usuario</th><th>Perfil</th><th>Acao</th><th>IP</th><th>Data</th></tr></thead>
            <tbody>
              <?php foreach ($ultimosLogs as $log): ?>
                <tr>
                  <td><strong><?= e($log['nome']) ?></strong></td>
                  <td><?= e(nomePerfil($log['perfil'])) ?></td>
                  <td><?= e($log['acao']) ?></td>
                  <td><?= e($log['ip']) ?></td>
                  <td><?= e(dataBr($log['data_evento'])) ?></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$ultimosLogs): ?>
                <tr><td colspan="5">Nenhum log registrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
