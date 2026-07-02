<?php

require_once __DIR__ . '/helpers.php';

// Arquivo responsavel por login, sessao e permissao de acesso.
// A sessao guarda os dados do usuario enquanto ele navega pelo sistema.
if (session_status() === PHP_SESSION_NONE) {
    session_start();
}

function normalizarPerfil($perfil)
{
    // Sessoes e registros antigos podem conter "financeiro" durante a migracao.
    // A aplicacao usa administrativo como nome oficial sem obrigar o usuario a limpar cookies.
    return $perfil === 'financeiro' ? 'administrativo' : (string) $perfil;
}

function usuarioLogado()
{
    // Se nao existir usuario na sessao, retorna null.
    $usuario = $_SESSION['usuario'] ?? null;

    if ($usuario !== null && isset($usuario['perfil'])) {
        // Atualiza a sessao recente para impedir um ciclo de redirecionamento no index.php.
        $perfilNormalizado = normalizarPerfil($usuario['perfil']);
        $_SESSION['usuario']['perfil'] = $perfilNormalizado;
        $usuario['perfil'] = $perfilNormalizado;
    }

    return $usuario;
}

function estaLogado()
{
    // Retorna true quando existe usuario salvo na sessao.
    return usuarioLogado() !== null;
}

function paginaInicialPorPerfil($perfil)
{
    // Aceita o valor antigo somente enquanto a migracao SQL e aplicada.
    $perfil = normalizarPerfil($perfil);

    // Cada tipo de usuario entra primeiro no seu dashboard.
    $paginas = [
        'aluno' => 'pages/aluno/dashboard.php',
        'professor' => 'pages/professor/dashboard.php',
        'coordenacao' => 'pages/coordenacao/dashboard.php',
        // O perfil administrativo abre o painel que concentra cadastros e pagamentos.
        'administrativo' => 'pages/administrativo/dashboard.php',
        'admin' => 'pages/admin/dashboard.php',
    ];

    return $paginas[$perfil] ?? 'index.php';
}

function precisaAlterarSenha()
{
    // Quando ultimo_login esta nulo no banco, marcamos a sessao para troca obrigatoria.
    return estaLogado() && !empty($_SESSION['usuario']['trocar_senha']);
}

function paginaAtualEhTrocaSenha()
{
    // Evita loop de redirecionamento quando o usuario ja esta na tela de troca.
    return basename((string) ($_SERVER['SCRIPT_NAME'] ?? '')) === 'alterar_senha.php';
}

function exigirLogin($prefixo = '../../')
{
    // Protege paginas internas: sem login, volta para login.php.
    if (!estaLogado()) {
        flash('danger', 'Faca login para acessar o sistema.');
        redirecionar($prefixo . 'login.php');
    }

    // Primeiro acesso: antes de navegar pelo sistema, o usuario precisa trocar a senha.
    if (precisaAlterarSenha() && !paginaAtualEhTrocaSenha()) {
        redirecionar($prefixo . 'alterar_senha.php');
    }
}

function exigirPerfil(array $perfisPermitidos, $prefixo = '../../')
{
    exigirLogin($prefixo);

    $perfil = usuarioLogado()['perfil'] ?? '';

    // in_array verifica se o perfil do usuario esta na lista permitida da pagina.
    if (!in_array($perfil, $perfisPermitidos, true)) {
        flash('danger', 'Seu usuario nao tem permissao para acessar esta pagina.');
        redirecionar($prefixo . paginaInicialPorPerfil($perfil));
    }
}

function autenticarUsuario($email, $senha)
{
    global $pdo;

    // Validacao simples antes de consultar o banco.
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        return [false, 'Informe um e-mail valido.'];
    }

    if ($senha === '') {
        return [false, 'Informe a senha.'];
    }

    $stmt = $pdo->prepare('SELECT * FROM usuarios WHERE email = :email AND status = "ativo" LIMIT 1');
    $stmt->execute([':email' => $email]);
    $usuario = $stmt->fetch();

    // senhaConfere compara o SHA256 da senha digitada com usuarios.senha_hash.
    if (!$usuario || !senhaConfere($senha, $usuario['senha_hash'])) {
        return [false, 'E-mail ou senha incorretos.'];
    }

    // Guardamos apenas informacoes necessarias na sessao, nunca a senha.
    $primeiroAcesso = $usuario['ultimo_login'] === null;
    $perfil = normalizarPerfil($usuario['perfil']);
    $_SESSION['usuario'] = [
        'id_usuario' => (int) $usuario['id_usuario'],
        'nome' => $usuario['nome'],
        'email' => $usuario['email'],
        // Salva o perfil oficial na sessao mesmo se o banco ainda tiver um registro antigo.
        'perfil' => $perfil,
        'trocar_senha' => $primeiroAcesso,
    ];

    if (!$primeiroAcesso) {
        // Somente atualiza ultimo_login quando nao e primeiro acesso.
        // No primeiro acesso ele precisa ficar nulo ate a senha ser trocada.
        executar('UPDATE usuarios SET ultimo_login = NOW() WHERE id_usuario = :id', [
            ':id' => $usuario['id_usuario'],
        ]);
    }

    registrarLogSistema('Login realizado');
    return [true, 'Login realizado com sucesso.'];
}

function registrarLogSistema($acao)
{
    $usuario = usuarioLogado();

    if (!$usuario) {
        return;
    }

    try {
        // O log ajuda a demonstrar auditoria: quem fez, o que fez e de qual IP.
        executar('INSERT INTO logs (id_usuario, acao, ip) VALUES (:id_usuario, :acao, :ip)', [
            ':id_usuario' => $usuario['id_usuario'],
            ':acao' => $acao,
            ':ip' => $_SERVER['REMOTE_ADDR'] ?? null,
        ]);
    } catch (Throwable $erro) {
        // O log nao pode impedir a acao principal do sistema.
    }
}

function fazerLogout()
{
    registrarLogSistema('Logout realizado');

    // Limpa os dados da sessao para encerrar o acesso.
    $_SESSION = [];
    session_destroy();
}
