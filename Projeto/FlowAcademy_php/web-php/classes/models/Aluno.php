<?php

require_once __DIR__ . '/../../includes/helpers.php';

// Classe que representa um aluno no sistema.
// Ela guarda os mesmos campos principais da tabela alunos.
class Aluno
{
    // Propriedades privadas: so podem ser acessadas por metodos da propria classe.
    private $id_aluno;
    private $id_usuario;
    private $matricula;
    private $cpf;
    private $telefone;
    private $data_nascimento;
    private $endereco;
    private $status_academico;

    public function __construct(array $dados = [])
    {
        // Valores iniciais usados quando o objeto e criado vazio.
        $this->id_aluno = null;
        $this->id_usuario = null;
        $this->matricula = '';
        $this->cpf = '';
        $this->telefone = '';
        $this->data_nascimento = null;
        $this->endereco = '';
        $this->status_academico = 'regular';

        preencherObjeto($this, $dados);
    }

    // Getters e setters permitem ler e alterar propriedades privadas com controle.
    public function getIdAluno() { return $this->id_aluno; }
    public function setIdAluno($id_aluno) { $this->id_aluno = $id_aluno; }

    public function getIdUsuario() { return $this->id_usuario; }
    public function setIdUsuario($id_usuario) { $this->id_usuario = $id_usuario; }

    public function getMatricula() { return $this->matricula; }
    public function setMatricula($matricula) { $this->matricula = $matricula; }

    public function getCpf() { return $this->cpf; }
    public function setCpf($cpf) { $this->cpf = $cpf; }

    public function getTelefone() { return $this->telefone; }
    public function setTelefone($telefone) { $this->telefone = $telefone; }

    public function getDataNascimento() { return $this->data_nascimento; }
    public function setDataNascimento($data_nascimento) { $this->data_nascimento = $data_nascimento; }

    public function getEndereco() { return $this->endereco; }
    public function setEndereco($endereco) { $this->endereco = $endereco; }

    public function getStatusAcademico() { return $this->status_academico; }
    public function setStatusAcademico($status_academico) { $this->status_academico = $status_academico; }

    public function cadastrar()
    {
        global $pdo;

        // Insere apenas os dados academicos; o usuario de login ja precisa existir.
        $sql = 'INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
                VALUES (:id_usuario, :matricula, :cpf, :telefone, :data_nascimento, :endereco, :status_academico)';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':id_usuario' => $this->id_usuario,
            ':matricula' => $this->matricula,
            ':cpf' => $this->cpf,
            ':telefone' => $this->telefone,
            ':data_nascimento' => $this->data_nascimento,
            ':endereco' => $this->endereco,
            ':status_academico' => $this->status_academico,
        ]);
    }

    public function cadastrarComUsuario($nome, $email, $senha, $matricula, $cpf, $telefone, $data_nascimento, $endereco)
    {
        global $pdo;

        // A transacao garante que usuario e aluno sejam criados juntos.
        // Se uma das insercoes falhar, nenhuma alteracao permanece no banco.
        $iniciouTransacao = !$pdo->inTransaction();

        if ($iniciouTransacao) {
            $pdo->beginTransaction();
        }

        try {
            // Primeiro cria a conta usada para o login do aluno.
            $stmtUsuario = $pdo->prepare(
                'INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
                 VALUES (:nome, :email, :senha_hash, "aluno", "ativo")'
            );
            $stmtUsuario->execute([
                ':nome' => $nome,
                ':email' => $email,
                ':senha_hash' => gerarHashSenha($senha),
            ]);

            // O id gerado no usuario faz a ligacao com os dados academicos.
            $idUsuario = $pdo->lastInsertId();
            $stmtAluno = $pdo->prepare(
                'INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
                 VALUES (:id_usuario, :matricula, :cpf, :telefone, :data_nascimento, :endereco, "regular")'
            );
            $stmtAluno->execute([
                ':id_usuario' => $idUsuario,
                ':matricula' => $matricula,
                ':cpf' => $cpf,
                ':telefone' => $telefone,
                ':data_nascimento' => $data_nascimento,
                ':endereco' => $endereco,
            ]);

            // Salva as duas insercoes somente quando ambas terminaram sem erro.
            if ($iniciouTransacao) {
                $pdo->commit();
            }
        } catch (Throwable $erro) {
            // Desfaz apenas a transacao iniciada por este metodo.
            if ($iniciouTransacao && $pdo->inTransaction()) {
                $pdo->rollBack();
            }

            throw $erro;
        }
    }

    public function editar()
    {
        global $pdo;

        // Atualiza dados academicos que podem mudar depois do cadastro.
        $sql = 'UPDATE alunos
                SET telefone = :telefone, endereco = :endereco, status_academico = :status
                WHERE id_aluno = :id';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':telefone' => $this->telefone,
            ':endereco' => $this->endereco,
            ':status' => $this->status_academico,
            ':id' => $this->id_aluno,
        ]);
    }

    public function desativar()
    {
        global $pdo;

        // Marca o aluno como evadido sem apagar o historico dele.
        $stmt = $pdo->prepare('UPDATE alunos SET status_academico = "evadido" WHERE id_aluno = :id');
        $stmt->execute([':id' => $this->id_aluno]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca um aluno especifico pelo id salvo no objeto.
        $stmt = $pdo->prepare('SELECT * FROM alunos WHERE id_aluno = :id');
        $stmt->execute([':id' => $this->id_aluno]);
        return $stmt->fetch();
    }

    public function buscarPorMatricula($matricula)
    {
        global $pdo;

        // Localiza o aluno pela matricula, que deve ser unica.
        $stmt = $pdo->prepare('SELECT * FROM alunos WHERE matricula = :matricula');
        $stmt->execute([':matricula' => $matricula]);
        return $stmt->fetch();
    }

    public function gerarMatricula()
    {
        // Gera uma matricula simples com ano atual e numero aleatorio.
        return date('Y') . rand(10000, 99999);
    }
}
