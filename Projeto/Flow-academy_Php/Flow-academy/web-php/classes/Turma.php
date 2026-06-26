<?php
// Classe que representa uma turma, ligando curso, professor e periodo letivo.
class Turma
{
    // Campos principais da tabela turmas.
    private $id_turma;
    private $id_curso;
    private $id_professor;
    private $codigo_turma;
    private $turno;
    private $periodo_letivo;
    private $capacidade_maxima;
    private $status;

    public function __construct(array $dados = [])
    {
        // Valores iniciais usados quando a turma ainda sera cadastrada.
        $this->id_turma = null;
        $this->id_curso = null;
        $this->id_professor = null;
        $this->codigo_turma = '';
        $this->turno = 'noite';
        $this->periodo_letivo = '';
        $this->capacidade_maxima = 35;
        $this->status = 'ativa';

        preencherObjeto($this, $dados);
    }

    // Getters e setters controlam o acesso as propriedades privadas.
    public function getIdTurma() { return $this->id_turma; }
    public function setIdTurma($id_turma) { $this->id_turma = $id_turma; }

    public function getIdCurso() { return $this->id_curso; }
    public function setIdCurso($id_curso) { $this->id_curso = $id_curso; }

    public function getIdProfessor() { return $this->id_professor; }
    public function setIdProfessor($id_professor) { $this->id_professor = $id_professor; }

    public function getCodigoTurma() { return $this->codigo_turma; }
    public function setCodigoTurma($codigo_turma) { $this->codigo_turma = $codigo_turma; }

    public function getTurno() { return $this->turno; }
    public function setTurno($turno) { $this->turno = $turno; }

    public function getPeriodoLetivo() { return $this->periodo_letivo; }
    public function setPeriodoLetivo($periodo_letivo) { $this->periodo_letivo = $periodo_letivo; }

    public function getCapacidadeMaxima() { return $this->capacidade_maxima; }
    public function setCapacidadeMaxima($capacidade_maxima) { $this->capacidade_maxima = $capacidade_maxima; }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function criar()
    {
        global $pdo;

        // Cria uma turma vinculando curso e professor.
        $sql = 'INSERT INTO turmas (id_curso, id_professor, codigo_turma, turno, periodo_letivo, capacidade_maxima, status)
                VALUES (:id_curso, :id_professor, :codigo_turma, :turno, :periodo_letivo, :capacidade_maxima, :status)';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':id_curso' => $this->id_curso,
            ':id_professor' => $this->id_professor,
            ':codigo_turma' => $this->codigo_turma,
            ':turno' => $this->turno,
            ':periodo_letivo' => $this->periodo_letivo,
            ':capacidade_maxima' => $this->capacidade_maxima,
            ':status' => $this->status,
        ]);
    }

    public function editar()
    {
        global $pdo;

        // Atualiza dados editaveis da turma, como professor, turno e capacidade.
        $sql = 'UPDATE turmas
                SET id_curso = :id_curso, id_professor = :id_professor, codigo_turma = :codigo_turma,
                    turno = :turno, periodo_letivo = :periodo_letivo, capacidade_maxima = :capacidade_maxima, status = :status
                WHERE id_turma = :id';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':id_curso' => $this->id_curso,
            ':id_professor' => $this->id_professor,
            ':codigo_turma' => $this->codigo_turma,
            ':turno' => $this->turno,
            ':periodo_letivo' => $this->periodo_letivo,
            ':capacidade_maxima' => $this->capacidade_maxima,
            ':status' => $this->status,
            ':id' => $this->id_turma,
        ]);
    }

    public function encerrar()
    {
        global $pdo;

        // Encerra a turma sem excluir matriculas e historico.
        $stmt = $pdo->prepare('UPDATE turmas SET status = "encerrada" WHERE id_turma = :id');
        $stmt->execute([':id' => $this->id_turma]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca uma turma pelo id armazenado no objeto.
        $stmt = $pdo->prepare('SELECT * FROM turmas WHERE id_turma = :id');
        $stmt->execute([':id' => $this->id_turma]);
        return $stmt->fetch();
    }

    public function verificarConflitoProfessor()
    {
        global $pdo;

        // Verifica se o professor ja tem turma ativa no mesmo turno e periodo.
        $sql = 'SELECT COUNT(*) AS total FROM turmas
                WHERE id_professor = :id_professor AND turno = :turno AND periodo_letivo = :periodo AND status = "ativa"';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':id_professor' => $this->id_professor,
            ':turno' => $this->turno,
            ':periodo' => $this->periodo_letivo,
        ]);

        $dados = $stmt->fetch();
        return $dados['total'] > 0;
    }

    public function verificarCapacidade()
    {
        global $pdo;

        // Conta matriculas ativas para saber se ainda existe vaga na turma.
        $sql = 'SELECT t.capacidade_maxima, COUNT(m.id_matricula) AS total_matriculados
                FROM turmas t
                LEFT JOIN matriculas m ON m.id_turma = t.id_turma AND m.status = "ativa"
                WHERE t.id_turma = :id_turma
                GROUP BY t.id_turma';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([':id_turma' => $this->id_turma]);
        $dados = $stmt->fetch();

        return $dados && $dados['total_matriculados'] < $dados['capacidade_maxima'];
    }
}
