<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin'], '../../');

// Pagina de auditoria: mostra as ultimas acoes feitas pelos usuarios.
$logs = buscarTodos(
    'SELECT l.*, u.nome, u.email, u.perfil
     FROM logs l
     JOIN usuarios u ON u.id_usuario = l.id_usuario
     ORDER BY l.data_evento DESC
     LIMIT 100'
);

appInicio('Logs', 'admin', 'logs', '../../');
pageHeading('Auditoria', 'Logs do Sistema', 'Historico das principais acoes realizadas no sistema.');
?>
    <!-- Tabela completa de auditoria para o admin consultar. -->
    <section class="panel">
      <div class="panel-header"><h2>Eventos registrados</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Data</th><th>Usuario</th><th>E-mail</th><th>Perfil</th><th>Acao</th><th>IP</th></tr></thead>
            <tbody>
              <?php foreach ($logs as $log): ?>
                <tr>
                  <td><?= e(dataBr($log['data_evento'])) ?></td>
                  <td><strong><?= e($log['nome']) ?></strong></td>
                  <td><?= e($log['email']) ?></td>
                  <td><?= e(nomePerfil($log['perfil'])) ?></td>
                  <td><?= e($log['acao']) ?></td>
                  <td><?= e($log['ip']) ?></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$logs): ?>
                <tr><td colspan="6">Nenhum log registrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
