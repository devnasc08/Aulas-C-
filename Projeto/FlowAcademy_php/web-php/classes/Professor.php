<?php
// Classe que representa o cadastro profissional do professor.
class Professor
{
    // Dados especificos do professor; o nome/e-mail ficam na tabela usuarios.
    private $id_professor;
    private $id_usuario;
    private $cpf;
    private $especialidade;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para criar o objeto professor.
        $this->id_professor = null;
        $this->id_usuario = null;
        $this->cpf = '';
        $this->especialidade = '';

        preencherObjeto($this, $dados);
    }

    // Getters e setters para ler e alterar os dados privados.
    public function getIdProfessor() { return $this->id_professor; }
    public function setIdProfessor($id_professor) { $this->id_professor = $id_professor; }

    public function getIdUsuario() { return $this->id_usuario; }
    public function setIdUsuario($id_usuario) { $this->id_usuario = $id_usuario; }

    public function getCpf() { return $this->cpf; }
    public function setCpf($cpf) { $this->cpf = $cpf; }

    public function getEspecialidade() { return $this->especialidade; }
    public function setEspecialidade($especialidade) { $this->especialidade = $especialidade; }

    public function cadastrar()
    {
        global $pdo;

        // Cadastra os dados profissionais vinculados a um usuario ja criado.
        $stmt = $pdo->prepare('INSERT INTO professores (id_usuario, cpf, especialidade) VALUES (:id_usuario, :cpf, :especialidade)');
        $stmt->execute([
            ':id_usuario' => $this->id_usuario,
            ':cpf' => $this->cpf,
            ':especialidade' => $this->especialidade,
        ]);
    }

    public function editar()
    {
        global $pdo;

        // Atualiza campos especificos do professor.
        $stmt = $pdo->prepare('UPDATE professores SET cpf = :cpf, especialidade = :especialidade WHERE id_professor = :id');
        $stmt->execute([
            ':cpf' => $this->cpf,
            ':especialidade' => $this->especialidade,
            ':id' => $this->id_professor,
        ]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca o professor pelo id salvo no objeto.
        $stmt = $pdo->prepare('SELECT * FROM professores WHERE id_professor = :id');
        $stmt->execute([':id' => $this->id_professor]);
        return $stmt->fetch();
    }

    public function vincularTurma($turma)
    {
        global $pdo;

        // Define este professor como responsavel por uma turma.
        $stmt = $pdo->prepare('UPDATE turmas SET id_professor = :id_professor WHERE id_turma = :id_turma');
        $stmt->execute([
            ':id_professor' => $this->id_professor,
            ':id_turma' => $turma->getIdTurma(),
        ]);
    }
}
