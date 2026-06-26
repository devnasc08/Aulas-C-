<?php
// Classe que representa a matricula de um aluno em uma turma.
class Matricula
{
    // Campos principais da tabela matriculas.
    private $id_matricula;
    private $id_aluno;
    private $id_turma;
    private $data_matricula;
    private $status;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para uma matricula nova.
        $this->id_matricula = null;
        $this->id_aluno = null;
        $this->id_turma = null;
        $this->data_matricula = null;
        $this->status = 'ativa';

        preencherObjeto($this, $dados);
    }

    // Getters e setters usados para manipular os campos privados.
    public function getIdMatricula() { return $this->id_matricula; }
    public function setIdMatricula($id_matricula) { $this->id_matricula = $id_matricula; }

    public function getIdAluno() { return $this->id_aluno; }
    public function setIdAluno($id_aluno) { $this->id_aluno = $id_aluno; }

    public function getIdTurma() { return $this->id_turma; }
    public function setIdTurma($id_turma) { $this->id_turma = $id_turma; }

    public function getDataMatricula() { return $this->data_matricula; }
    public function setDataMatricula($data_matricula) { $this->data_matricula = $data_matricula; }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function realizar()
    {
        global $pdo;

        // Bloqueia a turma durante a verificacao para evitar duas matriculas
        // ocuparem a ultima vaga ao mesmo tempo.
        $iniciouTransacao = !$pdo->inTransaction();

        if ($iniciouTransacao) {
            $pdo->beginTransaction();
        }

        try {
            $stmtTurma = $pdo->prepare(
                'SELECT capacidade_maxima, status
                 FROM turmas
                 WHERE id_turma = :id_turma
                 FOR UPDATE'
            );
            $stmtTurma->execute([':id_turma' => $this->id_turma]);
            $turma = $stmtTurma->fetch();

            if (!$turma || $turma['status'] !== 'ativa') {
                throw new RuntimeException('A turma selecionada nao esta disponivel para matricula.');
            }

            // Confere a chave unica antes de tentar inserir a matricula.
            if ($this->verificarDuplicidade()) {
                throw new RuntimeException('Este aluno ja possui matricula nesta turma.');
            }

            $stmtLotacao = $pdo->prepare(
                'SELECT COUNT(*) AS total
                 FROM matriculas
                 WHERE id_turma = :id_turma AND status = "ativa"'
            );
            $stmtLotacao->execute([':id_turma' => $this->id_turma]);
            $lotacao = $stmtLotacao->fetch();

            if ((int) $lotacao['total'] >= (int) $turma['capacidade_maxima']) {
                throw new RuntimeException('Limite de vagas da turma atingido.');
            }

            // Insere a matricula diretamente, sem chamar procedure no MySQL.
            $stmtInserir = $pdo->prepare(
                'INSERT INTO matriculas (id_aluno, id_turma, data_matricula, status)
                 VALUES (:id_aluno, :id_turma, CURDATE(), "ativa")'
            );
            $stmtInserir->execute([
                ':id_aluno' => $this->id_aluno,
                ':id_turma' => $this->id_turma,
            ]);
            $this->id_matricula = $pdo->lastInsertId();

            if ($iniciouTransacao) {
                $pdo->commit();
            }
        } catch (Throwable $erro) {
            if ($iniciouTransacao && $pdo->inTransaction()) {
                $pdo->rollBack();
            }

            throw $erro;
        }
    }

    public function cancelar()
    {
        global $pdo;

        // Cancela sem apagar, mantendo historico academico.
        $stmt = $pdo->prepare('UPDATE matriculas SET status = "cancelada" WHERE id_matricula = :id');
        $stmt->execute([':id' => $this->id_matricula]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca uma matricula pelo id armazenado no objeto.
        $stmt = $pdo->prepare('SELECT * FROM matriculas WHERE id_matricula = :id');
        $stmt->execute([':id' => $this->id_matricula]);
        return $stmt->fetch();
    }

    public function transferir($novaTurma)
    {
        global $pdo;

        // Altera a turma da matricula para transferir o aluno.
        $stmt = $pdo->prepare('UPDATE matriculas SET id_turma = :id_turma WHERE id_matricula = :id');
        $stmt->execute([
            ':id_turma' => $novaTurma->getIdTurma(),
            ':id' => $this->id_matricula,
        ]);
    }

    public function verificarDuplicidade()
    {
        global $pdo;

        // Confere se o aluno ja esta matriculado na mesma turma.
        $stmt = $pdo->prepare('SELECT COUNT(*) AS total FROM matriculas WHERE id_aluno = :id_aluno AND id_turma = :id_turma');
        $stmt->execute([
            ':id_aluno' => $this->id_aluno,
            ':id_turma' => $this->id_turma,
        ]);

        $dados = $stmt->fetch();
        return $dados['total'] > 0;
    }
}
