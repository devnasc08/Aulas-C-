<?php

require_once __DIR__ . '/../database/Conexao.php';

function preencherObjeto($objeto, array $dados)
{
    // Converte nomes do banco, como id_usuario, para setters como setIdUsuario().
    foreach ($dados as $campo => $valor) {
        $partes = explode('_', $campo);
        $metodo = 'set';

        foreach ($partes as $parte) {
            $metodo .= ucfirst($parte);
        }

        if (method_exists($objeto, $metodo)) {
            $objeto->$metodo($valor);
        }
    }
}

// Classe base do usuario de login. Ela representa registros da tabela usuarios.
class Usuario
{
    // Propriedades privadas equivalentes as colunas principais da tabela usuarios.
    private $id_usuario;
    private $nome;
    private $email;
    private $senha_hash;
    private $perfil;
    private $status;
    private $ultimo_login;
    private $created_at;

    public function __construct(array $dados = [])
    {
        // Valores padrao para criar o objeto mesmo antes de consultar o banco.
        $this->id_usuario = null;
        $this->nome = '';
        $this->email = '';
        $this->senha_hash = '';
        $this->perfil = '';
        $this->status = 'ativo';
        $this->ultimo_login = null;
        $this->created_at = null;

        preencherObjeto($this, $dados);
    }

    // Getters e setters fazem a ponte entre as propriedades privadas e o restante do sistema.
    public function getIdUsuario() { return $this->id_usuario; }
    public function setIdUsuario($id_usuario) { $this->id_usuario = $id_usuario; }

    public function getNome() { return $this->nome; }
    public function setNome($nome) { $this->nome = $nome; }

    public function getEmail() { return $this->email; }
    public function setEmail($email) { $this->email = $email; }

    public function getSenhaHash() { return $this->senha_hash; }
    public function setSenhaHash($senha_hash) { $this->senha_hash = $senha_hash; }

    public function getPerfil() { return $this->perfil; }

    public function setPerfil($perfil)
    {
        // Mantem objetos vindos de registros antigos compativeis com o perfil oficial.
        $this->perfil = $perfil === 'financeiro' ? 'administrativo' : $perfil;
    }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function getUltimoLogin() { return $this->ultimo_login; }
    public function setUltimoLogin($ultimo_login) { $this->ultimo_login = $ultimo_login; }

    public function getCreatedAt() { return $this->created_at; }
    public function setCreatedAt($created_at) { $this->created_at = $created_at; }

    private function gerarHashSenhaUsuario($senha)
    {
        // Mesmo padrao usado no restante do PHP e no C#: SHA256 da senha digitada.
        return hash('sha256', (string) $senha);
    }

    private function senhaConfereUsuario($senhaDigitada, $hashBanco)
    {
        // hash_equals evita comparacao insegura entre os textos dos hashes.
        return hash_equals((string) $hashBanco, $this->gerarHashSenhaUsuario($senhaDigitada));
    }

    public function cadastrar()
    {
        global $pdo;

        // Cria o usuario de login. A senha e salva como SHA256, nao em texto puro.
        $sql = 'INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
                VALUES (:nome, :email, :senha_hash, :perfil, :status)';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':nome' => $this->nome,
            ':email' => $this->email,
            ':senha_hash' => $this->gerarHashSenhaUsuario($this->senha_hash),
            ':perfil' => $this->perfil,
            ':status' => $this->status,
        ]);

        $this->id_usuario = $pdo->lastInsertId();
    }

    public function login($email, $senha)
    {
        global $pdo;

        // Procura usuario ativo pelo e-mail informado na tela de login.
        $stmt = $pdo->prepare('SELECT * FROM usuarios WHERE email = :email AND status = "ativo" LIMIT 1');
        $stmt->execute([':email' => $email]);
        $dados = $stmt->fetch();

        if ($dados && $this->senhaConfereUsuario($senha, $dados['senha_hash'])) {
            // Quando a senha confere, preenche o objeto com os dados vindos do banco.
            preencherObjeto($this, $dados);
            $pdo->prepare('UPDATE usuarios SET ultimo_login = NOW() WHERE id_usuario = :id')
                ->execute([':id' => $this->id_usuario]);
            return true;
        }

        return false;
    }

    public function logout()
    {
        // Encerra a sessao PHP usada para manter o usuario logado.
        session_start();
        session_destroy();
    }

    public function verificarSenha($senha)
    {
        // Confere uma senha digitada contra o hash salvo no usuario.
        return $this->senhaConfereUsuario($senha, $this->senha_hash);
    }

    public function redirecionarPorPerfil()
    {
        // Define qual dashboard cada perfil deve abrir apos o login.
        if ($this->perfil == 'admin') {
            return 'admin/dashboard.php';
        }

        if ($this->perfil == 'professor') {
            return 'professor/dashboard.php';
        }

        if ($this->perfil == 'aluno') {
            return 'aluno/dashboard.php';
        }

        if ($this->perfil == 'coordenacao') {
            return 'coordenacao/dashboard.php';
        }

        if ($this->perfil == 'administrativo') {
            return 'administrativo/dashboard.php';
        }

        return 'login.php';
    }

    public function desativar()
    {
        global $pdo;

        // Inativa o usuario sem apagar o registro do banco.
        $stmt = $pdo->prepare('UPDATE usuarios SET status = "inativo" WHERE id_usuario = :id');
        $stmt->execute([':id' => $this->id_usuario]);
        $this->status = 'inativo';
    }
}
