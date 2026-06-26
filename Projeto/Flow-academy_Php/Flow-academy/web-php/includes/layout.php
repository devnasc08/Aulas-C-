<?php

require_once __DIR__ . '/auth.php';

// Arquivo que concentra a estrutura visual compartilhada pelas paginas internas.
// Assim sidebar, topbar, componentes e scripts ficam padronizados em um so lugar.

function menusDoSistema()
{
    // Menu centralizado: cada area mostra apenas os links que fazem sentido para ela.
    return [
        'aluno' => [
            'titulo' => 'Aluno',
            'itens' => [
                'dashboard' => ['texto' => 'Dashboard', 'href' => 'pages/aluno/dashboard.php'],
                'boletim' => ['texto' => 'Boletim', 'href' => 'pages/aluno/boletim.php'],
                'frequencia' => ['texto' => 'Frequencia', 'href' => 'pages/aluno/frequencia.php'],
            ],
        ],
        'professor' => [
            'titulo' => 'Professor',
            'itens' => [
                'dashboard' => ['texto' => 'Dashboard', 'href' => 'pages/professor/dashboard.php'],
                'notas' => ['texto' => 'Lancar notas', 'href' => 'pages/professor/lancar_notas.php'],
                'frequencia' => ['texto' => 'Registrar frequencia', 'href' => 'pages/professor/registrar_frequencia.php'],
            ],
        ],
        'coordenacao' => [
            'titulo' => 'Coordenacao',
            'itens' => [
                'dashboard' => ['texto' => 'Dashboard', 'href' => 'pages/coordenacao/dashboard.php'],
                'cursos' => ['texto' => 'Cursos', 'href' => 'pages/coordenacao/cursos.php'],
                'curso_form' => ['texto' => 'Novo curso', 'href' => 'pages/coordenacao/curso_form.php'],
                'turmas' => ['texto' => 'Turmas', 'href' => 'pages/coordenacao/turmas.php'],
                'turma_form' => ['texto' => 'Nova turma', 'href' => 'pages/coordenacao/turma_form.php'],
            ],
        ],
        'administrativo' => [
            'titulo' => 'Administrativo',
            'itens' => [
                'dashboard' => ['texto' => 'Dashboard', 'href' => 'pages/administrativo/dashboard.php', 'perfis' => ['admin', 'administrativo']],
                'alunos' => ['texto' => 'Alunos', 'href' => 'pages/administrativo/alunos.php', 'perfis' => ['admin', 'coordenacao', 'administrativo']],
                'aluno_form' => ['texto' => 'Cadastro de aluno', 'href' => 'pages/administrativo/aluno_form.php', 'perfis' => ['admin', 'coordenacao', 'administrativo']],
                'professores' => ['texto' => 'Professores', 'href' => 'pages/administrativo/professores.php', 'perfis' => ['admin']],
                'professor_form' => ['texto' => 'Cadastro professor', 'href' => 'pages/administrativo/professor_form.php', 'perfis' => ['admin']],
                'matricula' => ['texto' => 'Matricula', 'href' => 'pages/administrativo/matricula_form.php', 'perfis' => ['admin', 'coordenacao', 'administrativo']],
                'pagamentos' => ['texto' => 'Pagamentos', 'href' => 'pages/financeiro/pagamentos.php', 'perfis' => ['admin', 'administrativo']],
                'pagamento_form' => ['texto' => 'Novo pagamento', 'href' => 'pages/financeiro/pagamento_form.php', 'perfis' => ['admin', 'administrativo']],
            ],
        ],
        'admin' => [
            'titulo' => 'Admin',
            'itens' => [
                'dashboard' => ['texto' => 'Dashboard', 'href' => 'pages/admin/dashboard.php'],
                // Cada cadastro possui sua propria pagina para impedir a escolha de outros perfis.
                'coordenacao_form' => ['texto' => 'Cadastrar coordenacao', 'href' => 'pages/admin/coordenacao_form.php'],
                'administrativo_form' => ['texto' => 'Cadastrar administrativo', 'href' => 'pages/admin/administrativo_form.php'],
                'logs' => ['texto' => 'Logs', 'href' => 'pages/admin/logs.php'],
            ],
        ],
    ];
}

function areasVisiveisPorPerfil($perfil)
{
    // Esta lista controla a aba "Perfis" da sidebar.
    // Ela mostra somente areas que o usuario logado consegue acessar.
    $areas = [
        'aluno' => ['aluno'],
        'professor' => ['professor'],
        'coordenacao' => ['coordenacao'],
        'administrativo' => ['administrativo'],
        'admin' => ['admin', 'coordenacao', 'administrativo'],
    ];

    return $areas[$perfil] ?? [];
}

function appInicio($titulo, $area, $ativo, $prefixo = '../../')
{
    // Esta funcao abre o HTML comum das paginas: sidebar, topbar, busca e flash message.
    $usuario = usuarioLogado();
    $menus = menusDoSistema();
    $menuAtual = $menus[$area] ?? $menus['aluno'];
    $perfil = $usuario['perfil'] ?? 'visitante';
    $areasVisiveis = areasVisiveisPorPerfil($perfil);
    $mostrarPerfis = count($areasVisiveis) > 1;
    $dashboardUsuario = paginaInicialPorPerfil($perfil);
    $nome = $usuario['nome'] ?? 'Flow Academy';
    $flash = pegarFlash();
    ?>
<!doctype html>
<html lang="pt-BR">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title><?= e($titulo) ?> | Flow Academy Platform</title>
  <link href="<?= e($prefixo) ?>assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link rel="stylesheet" href="<?= e($prefixo) ?>assets/css/main.css?v=20260622-2">
</head>
<body class="app-shell">
  <aside class="sidebar" aria-label="Navegacao principal">
    <div class="sidebar-header">
      <a class="brand" href="<?= e($prefixo . $dashboardUsuario) ?>">
        <img class="brand-logo" src="<?= e($prefixo) ?>assets/images/logo-flow-academy-gold.jpg" alt="Logo Flow Academy">
      </a>
    </div>
    <div class="sidebar-content">
      <nav class="nav-section">
        <p class="nav-title"><?= e($menuAtual['titulo']) ?></p>
        <ul class="nav-list">
          <?php foreach ($menuAtual['itens'] as $chave => $item): ?>
            <?php if (isset($item['perfis']) && !in_array($perfil, $item['perfis'], true)) { continue; } ?>
            <li>
              <a class="nav-link <?= $ativo === $chave ? 'active' : '' ?>" href="<?= e($prefixo . $item['href']) ?>">
                <span class="nav-dot"></span><?= e($item['texto']) ?>
              </a>
            </li>
          <?php endforeach; ?>
        </ul>
      </nav>
      <?php if ($mostrarPerfis): ?>
        <nav class="nav-section">
          <p class="nav-title">Perfis</p>
          <ul class="nav-list">
            <?php foreach ($areasVisiveis as $chaveArea): ?>
              <?php
                $menuPerfil = $menus[$chaveArea];
                $primeiroItem = array_values($menuPerfil['itens'])[0];
              ?>
              <li>
                <a class="nav-link <?= $area === $chaveArea ? 'active' : '' ?>" href="<?= e($prefixo . $primeiroItem['href']) ?>">
                  <span class="nav-dot"></span><?= e($menuPerfil['titulo']) ?>
                </a>
              </li>
            <?php endforeach; ?>
          </ul>
        </nav>
      <?php endif; ?>
    </div>
    <div class="sidebar-footer">
      <a class="role-pill" href="<?= e($prefixo) ?>logout.php">
        <span><span>Sessao ativa</span><strong><?= e($nome) ?></strong></span>
        <span class="badge success">Online</span>
      </a>
    </div>
  </aside>
  <button class="sidebar-backdrop js-sidebar-close" aria-label="Fechar menu"></button>
  <div class="app-frame">
    <header class="topbar">
      <div class="topbar-left">
        <button class="icon-btn mobile-only js-sidebar-toggle" aria-label="Abrir menu"><span class="hamburger"><span></span><span></span><span></span></span></button>
        <div class="top-path"><strong><?= e($titulo) ?></strong></div>
      </div>
      <div class="topbar-right">
        <input class="control top-search" type="search" placeholder="Buscar na tabela" data-table-filter="#tabela-principal">
        <button class="icon-btn" type="button" data-tooltip="Notificacoes" data-toast="Nenhuma notificacao nova." aria-label="Notificacoes">
          <svg class="icon" viewBox="0 0 24 24" aria-hidden="true">
            <path d="M18 8a6 6 0 0 0-12 0c0 7-3 7-3 9h18c0-2-3-2-3-9"></path>
            <path d="M13.73 21a2 2 0 0 1-3.46 0"></path>
          </svg>
        </button>
        <div class="dropdown">
          <button class="avatar" type="button" data-bs-toggle="dropdown" aria-expanded="false" aria-label="Menu do usuario"><?= e(iniciais($nome)) ?></button>
          <div class="dropdown-menu">
            <a href="<?= e($prefixo) ?>logout.php">Sair</a>
          </div>
        </div>
      </div>
    </header>
    <main class="main-content">
      <?php if ($flash): ?>
        <div class="alert <?= e($flash['tipo']) ?>">
          <span class="alert-marker"></span>
          <div><strong>Aviso</strong><span class="muted"><?= e($flash['mensagem']) ?></span></div>
        </div>
      <?php endif; ?>
    <?php
}

function pageHeading($eyebrow, $titulo, $texto, $acoes = '')
{
    // Cabecalho padrao usado no topo de cada pagina interna.
    ?>
      <section class="page-heading">
        <div>
          <span class="eyebrow"><?= e($eyebrow) ?></span>
          <h1><?= e($titulo) ?></h1>
          <p><?= e($texto) ?></p>
        </div>
        <?php if ($acoes !== ''): ?>
          <div class="actions"><?= $acoes ?></div>
        <?php endif; ?>
      </section>
    <?php
}

function alerta($tipo, $titulo, $mensagem)
{
    // Componente visual para mensagens de sucesso, atencao ou erro.
    ?>
      <div class="alert <?= e($tipo) ?>">
        <span class="alert-marker"></span>
        <div><strong><?= e($titulo) ?></strong><span class="muted"><?= e($mensagem) ?></span></div>
      </div>
    <?php
}

function badge($texto, $status)
{
    // Retorna o HTML do badge ja com a classe correta conforme o status.
    return '<span class="badge ' . e(statusBadge($status)) . '">' . e(textoStatus($texto)) . '</span>';
}

function appFim($prefixo = '../../')
{
    // Fecha o HTML aberto em appInicio() e carrega o JavaScript principal.
    ?>
    </main>
  </div>
  <div class="modal fade" id="confirm-modal" tabindex="-1" aria-labelledby="modal-title" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header"><h2 id="modal-title" class="modal-title">Confirmar acao</h2><button class="icon-btn" data-bs-dismiss="modal" aria-label="Fechar">X</button></div>
        <div class="modal-body"><p class="muted">Revise os dados antes de confirmar a operacao.</p></div>
        <div class="modal-footer"><button class="btn ghost" data-bs-dismiss="modal">Cancelar</button><button class="btn primary" data-bs-dismiss="modal" data-toast="Acao confirmada.">Confirmar</button></div>
      </div>
    </div>
  </div>
  <div class="toast" data-toast-root></div>
  <script src="<?= e($prefixo) ?>assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="<?= e($prefixo) ?>assets/js/app.js?v=20260616-3"></script>
</body>
</html>
    <?php
}
