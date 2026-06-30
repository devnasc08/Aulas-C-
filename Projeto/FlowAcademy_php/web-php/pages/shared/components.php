<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirLogin('../../');

$perfil = usuarioLogado()['perfil'];
$area = $perfil === 'admin' ? 'admin' : $perfil;

appInicio('Componentes', $area, 'dashboard', '../../');
pageHeading('Design system', 'Componentes', 'Referencia visual mantida a partir do frontend original.');
?>
    <section class="grid three">
      <article class="card metric-card"><div class="metric-label">Card</div><div class="metric-value">42</div><div class="metric-meta positive">Indicador</div></article>
      <article class="panel"><div class="panel-header"><h2>Alertas</h2></div><div class="panel-body"><div class="stack"><?php alerta('success', 'Sucesso', 'Operacao concluida.'); ?><?php alerta('warning', 'Atencao', 'Revise os dados.'); ?><?php alerta('danger', 'Erro', 'Nao foi possivel salvar.'); ?></div></div></article>
      <article class="panel"><div class="panel-header"><h2>Botoes</h2></div><div class="panel-body"><div class="actions" style="justify-content:flex-start"><button class="btn primary">Principal</button><button class="btn ghost">Secundario</button></div></div></article>
    </section>
<?php appFim('../../'); ?>
