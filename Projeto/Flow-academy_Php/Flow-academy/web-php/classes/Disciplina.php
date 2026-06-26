<?php
// Classe que representa uma Unidade Curricular (UC), salva na tabela disciplinas.
class Disciplina
{
    // Cada UC pertence a um curso e possui carga horaria propria.
    private $id_disciplina;
    private $id_curso;
    private $nome;
    private $carga_horaria;

    public function __construct(array $dados = [])
    {
        // Valores padrao para criar uma UC nova.
        $this->id_disciplina = null;
        $this->id_curso = null;
        $this->nome = '';
        $this->carga_horaria = 0;

        preencherObjeto($this, $dados);
    }

    // Getters e setters usados para ler ou preencher os dados da UC.
    public function getIdDisciplina() { return $this->id_disciplina; }
    public function setIdDisciplina($id_disciplina) { $this->id_disciplina = $id_disciplina; }

    public function getIdCurso() { return $this->id_curso; }
    public function setIdCurso($id_curso) { $this->id_curso = $id_curso; }

    public function getNome() { return $this->nome; }
    public function setNome($nome) { $this->nome = $nome; }

    public function getCargaHoraria() { return $this->carga_horaria; }
    public function setCargaHoraria($carga_horaria) { $this->carga_horaria = $carga_horaria; }

    public function cadastrar()
    {
        global $pdo;

        // Cadastra a UC vinculada a um curso existente.
        $stmt = $pdo->prepare('INSERT INTO disciplinas (id_curso, nome, carga_horaria) VALUES (:id_curso, :nome, :carga_horaria)');
        $stmt->execute([
            ':id_curso' => $this->id_curso,
            ':nome' => $this->nome,
            ':carga_horaria' => $this->carga_horaria,
        ]);
    }

    public function consultar()
    {
        global $pdo;

        // Consulta uma UC especifica pelo seu id.
        $stmt = $pdo->prepare('SELECT * FROM disciplinas WHERE id_disciplina = :id');
        $stmt->execute([':id' => $this->id_disciplina]);
        return $stmt->fetch();
    }
}
