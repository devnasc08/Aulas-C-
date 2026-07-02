<?php

require_once __DIR__ . '/../models/Usuario.php';

// Service antigo de autenticacao usado como apoio para login e permissoes.
class AuthService
{
    public function autenticar($email, $senha)
    {
        // Cria um Usuario e tenta autenticar usando e-mail e senha.
        $usuario = new Usuario();

        if ($usuario->login($email, $senha)) {
            return $usuario;
        }

        return false;
    }

    public function encerrarSessao()
    {
        // Garante que exista sessao antes de tentar destruir.
        if (session_status() === PHP_SESSION_NONE) {
            session_start();
        }

        session_destroy();
    }

    public function redirecionarPorPerfil($perfil)
    {
        // Reaproveita a regra da classe Usuario para descobrir o dashboard correto.
        $usuario = new Usuario(['perfil' => $perfil]);
        return $usuario->redirecionarPorPerfil();
    }

    public function verificarPermissao($perfil, $rota)
    {
        // Evita negacao de acesso para objetos carregados antes da reversao do banco.
        $perfil = $perfil === 'financeiro' ? 'administrativo' : $perfil;

        // Admin tem acesso total.
        if ($perfil == 'admin') {
            return true;
        }

        // Regras simples de quais rotas cada perfil pode abrir.
        if ($perfil == 'administrativo' && $rota == 'pagamentos') {
            return true;
        }

        if ($perfil == 'professor' && ($rota == 'notas' || $rota == 'frequencia')) {
            return true;
        }

        if ($perfil == 'aluno' && ($rota == 'boletim' || $rota == 'pagamentos')) {
            return true;
        }

        if ($perfil == 'coordenacao' && ($rota == 'cursos' || $rota == 'turmas' || $rota == 'alunos')) {
            return true;
        }

        return false;
    }
}
