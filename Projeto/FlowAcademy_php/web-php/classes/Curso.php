<?php
// Classe que representa um curso cadastrado na tabela cursos.
class Curso
{
    // Campos principais do curso.
    private $id_curso;
    private $nome;
    private $descricao;
    private $carga_horaria;
    private $status;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para um curso novo.
        $this->id_curso = null;
        $this->nome = '';
        $this->descricao = '';
        $this->carga_horaria = 0;
        $this->status = 'ativo';

        preencherObjeto($this, $dados);
    }

    // Getters e setters permitem acessar os campos privados do curso.
    public function getIdCurso() { return $this->id_curso; }
    public function setIdCurso($id_curso) { $this->id_curso = $id_curso; }

    public function getNome() { return $this->nome; }
    public function setNome($nome) { $this->nome = $nome; }

    public function getDescricao() { return $this->descricao; }
    public function setDescricao($descricao) { $this->descricao = $descricao; }

    public function getCargaHoraria() { return $this->carga_horaria; }
    public function setCargaHoraria($carga_horaria) { $this->carga_horaria = $carga_horaria; }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function cadastrar()
    {
        global $pdo;

        // Insere um novo curso no banco.
        $stmt = $pdo->prepare('INSERT INTO cursos (nome, descricao, carga_horaria, status) VALUES (:nome, :descricao, :carga_horaria, :status)');
        $stmt->execute([
            ':nome' => $this->nome,
            ':descricao' => $this->descricao,
            ':carga_horaria' => $this->carga_horaria,
            ':status' => $this->status,
        ]);
    }
    public function editar()
    {
        global $pdo;

        // Atualiza os dados principais de um curso ja existente.
        $stmt = $pdo->prepare('UPDATE cursos SET nome = :nome, descricao = :descricao, carga_horaria = :carga_horaria, status = :status WHERE id_curso = :id');
        $stmt->execute([
            ':nome' => $this->nome,
            ':descricao' => $this->descricao,
            ':carga_horaria' => $this->carga_horaria,
            ':status' => $this->status,
            ':id' => $this->id_curso,
        ]);
    }

    public function desativar()
    {
        global $pdo;

        // Mantem o curso no historico, mas impede novo uso como ativo.
        $stmt = $pdo->prepare('UPDATE cursos SET status = "inativo" WHERE id_curso = :id');
        $stmt->execute([':id' => $this->id_curso]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca o curso pelo id armazenado no objeto.
        $stmt = $pdo->prepare('SELECT * FROM cursos WHERE id_curso = :id');
        $stmt->execute([':id' => $this->id_curso]);
        return $stmt->fetch();
    }
}
