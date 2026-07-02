<?php

require_once __DIR__ . '/includes/auth.php';

// Tela obrigatoria no primeiro acesso.
// A regra de negocio usa usuarios.ultimo_login: se estiver nulo, a senha precisa ser trocada.
exigirLogin('');

if (!precisaAlterarSenha()) {
    redirecionar(paginaInicialPorPerfil(usuarioLogado()['perfil']));
}

$erro = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Le a nova senha e a confirmacao digitadas pelo usuario.
    $novaSenha = post('nova_senha');
    $confirmarSenha = post('confirmar_senha');
    $usuario = usuarioLogado();

    // Busca o hash atual para impedir que o usuario mantenha a senha inicial.
    $usuarioBanco = buscarUm('SELECT senha_hash FROM usuarios WHERE id_usuario = :id_usuario', [
        ':id_usuario' => $usuario['id_usuario'],
    ]);

    if ($novaSenha === '' || $confirmarSenha === '') {
        $erro = 'Informe e confirme a nova senha.';
    } elseif (strlen($novaSenha) < 6) {
        $erro = 'A nova senha deve ter pelo menos 6 caracteres.';
    } elseif ($novaSenha !== $confirmarSenha) {
        $erro = 'A confirmacao precisa ser igual a nova senha.';
    } elseif ($usuarioBanco && senhaConfere($novaSenha, $usuarioBanco['senha_hash'])) {
        $erro = 'Escolha uma senha diferente da senha inicial.';
    } else {
        // Ao trocar a senha, gravamos ultimo_login para marcar que o primeiro acesso foi concluido.
        executar(
            'UPDATE usuarios
             SET senha_hash = :senha_hash, ultimo_login = NOW()
             WHERE id_usuario = :id_usuario',
            [
                ':senha_hash' => gerarHashSenha($novaSenha),
                ':id_usuario' => $usuario['id_usuario'],
            ]
        );

        $_SESSION['usuario']['trocar_senha'] = false;
        registrarLogSistema('Alterou senha no primeiro acesso');
        flash('success', 'Senha alterada com sucesso.');
        redirecionar(paginaInicialPorPerfil($usuario['perfil']));
    }
}
?>
<!doctype html>
<html lang="pt-BR">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Alterar senha | Flow Academy Platform</title>
  <!-- Bootstrap 5.0.2 local: base obrigatoria de CSS do sistema PHP. -->
  <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Complemento visual proprio do projeto, sempre carregado depois do Bootstrap. -->
  <link rel="stylesheet" href="assets/css/main.css?v=20260622-2">
</head>
<body class="auth-shell">
  <!-- Card de primeiro acesso: bloqueia o sistema ate a senha inicial ser trocada. -->
  <main class="auth-card">
    <a class="brand" href="alterar_senha.php">
      <img class="brand-logo" src="assets/img/logos/logo-flow-academy-gold.jpg" alt="Logo Flow Academy">
    </a>
    <h1 class="auth-title">Alterar senha</h1>
    <p class="auth-subtitle">Antes de acessar o sistema, cadastre uma senha nova.</p>

    <?php if ($erro !== ''): ?>
      <div class="alert danger">
        <span class="alert-marker"></span>
        <div><strong>Nao foi possivel alterar</strong><span class="muted"><?= e($erro) ?></span></div>
      </div>
    <?php endif; ?>

    <form class="stack" method="post" action="alterar_senha.php">
      <label class="field">
        <span>Nova senha</span>
        <input class="control" type="password" name="nova_senha" minlength="6" placeholder="Digite uma nova senha" required>
      </label>
      <label class="field">
        <span>Confirmar senha</span>
        <input class="control" type="password" name="confirmar_senha" minlength="6" placeholder="Confirme a nova senha" required>
      </label>
      <button class="btn primary" type="submit">Salvar nova senha</button>
      <a class="btn ghost" href="logout.php">Sair</a>
    </form>
  </main>
  <div class="toast" data-toast-root></div>
  <!-- Bootstrap 5.0.2 local: bundle com componentes JS usados na tela de troca de senha. -->
  <script src="assets/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Complemento JS proprio do projeto, carregado depois do Bootstrap. -->
  <script src="assets/js/app.js?v=20260616-3"></script>
</body>
</html>
