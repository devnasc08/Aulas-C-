<?php

require_once __DIR__ . '/includes/auth.php';

// Tela publica de login do sistema.
// Se o usuario ja estiver logado, ele nao precisa ver a tela de login de novo.
if (estaLogado()) {
    if (precisaAlterarSenha()) {
        redirecionar('alterar_senha.php');
    }

    redirecionar(paginaInicialPorPerfil(usuarioLogado()['perfil']));
}

$erro = '';
$email = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Os dados do formulario sao lidos com a funcao post(), que tambem remove espacos extras.
    $email = post('email');
    $senha = post('senha');

    // autenticarUsuario() faz a consulta no banco e valida a senha com SHA256.
    [$ok, $mensagem] = autenticarUsuario($email, $senha);

    if ($ok) {
        if (precisaAlterarSenha()) {
            redirecionar('alterar_senha.php');
        }

        redirecionar(paginaInicialPorPerfil(usuarioLogado()['perfil']));
    }

    $erro = $mensagem;
}
?>
<!doctype html>
<html lang="pt-BR">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Login | Flow Academy Platform</title>
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link rel="stylesheet" href="assets/css/main.css?v=20260622-2">
</head>
<body class="auth-shell">
  <!-- Card central com marca, formulario e mensagens de erro. -->
  <main class="auth-card">
    <a class="brand" href="index.php">
      <img class="brand-logo" src="assets/images/logo-flow-academy-gold.jpg" alt="Logo Flow Academy">
    </a>
    <h1 class="auth-title">Acesso institucional</h1>
    <p class="auth-subtitle">Entre com um usuario cadastrado na tabela usuarios do banco flow_academy.</p>

    <?php if ($erro !== ''): ?>
      <!-- Mensagem exibida quando o e-mail ou a senha nao passam na autenticacao. -->
      <div class="alert danger">
        <span class="alert-marker"></span>
        <div><strong>Erro de autenticacao</strong><span class="muted"><?= e($erro) ?></span></div>
      </div>
    <?php endif; ?>

    <form class="stack" method="post" action="login.php">
      <!-- Campos enviados por POST para serem validados no PHP acima. -->
      <label class="field">
        <span>E-mail</span>
        <input class="control" type="email" name="email" value="<?= e($email) ?>" placeholder="seu.email@flowacademy.com" required>
      </label>
      <label class="field">
        <span>Senha</span>
        <span class="password-wrap">
          <input class="control" id="login-password" type="password" name="senha" placeholder="Digite sua senha" required>
          <button class="btn ghost password-action" type="button" data-password-toggle="#login-password">Mostrar</button>
        </span>
      </label>
      <button class="btn primary" type="submit">Entrar</button>
    </form>

  </main>
  <div class="toast" data-toast-root></div>
  <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="assets/js/app.js?v=20260616-3"></script>
</body>
</html>
