<?php
// Classe que representa alertas academicos de risco por nota ou frequencia.
class AlertaRisco
{
    // Campos da tabela alerta_risco.
    private $id_alerta;
    private $id_matricula;
    private $tipo_risco;
    private $score;
    private $status;

    public function __construct(array $dados = [])
    {
        // Valores padrao para um alerta novo.
        $this->id_alerta = null;
        $this->id_matricula = null;
        $this->tipo_risco = 'nota';
        $this->score = 0;
        $this->status = 'pendente';

        preencherObjeto($this, $dados);
    }

    // Getters e setters usados para manipular os campos privados.
    public function getIdAlerta() { return $this->id_alerta; }
    public function setIdAlerta($id_alerta) { $this->id_alerta = $id_alerta; }

    public function getIdMatricula() { return $this->id_matricula; }
    public function setIdMatricula($id_matricula) { $this->id_matricula = $id_matricula; }

    public function getTipoRisco() { return $this->tipo_risco; }
    public function setTipoRisco($tipo_risco) { $this->tipo_risco = $tipo_risco; }

    public function getScore() { return $this->score; }
    public function setScore($score) { $this->score = $score; }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function gerar()
    {
        global $pdo;

        // Insere um alerta para acompanhamento da coordenacao.
        $stmt = $pdo->prepare('INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status) VALUES (:id_matricula, :tipo_risco, :score, :status)');
        $stmt->execute([
            ':id_matricula' => $this->id_matricula,
            ':tipo_risco' => $this->tipo_risco,
            ':score' => $this->score,
            ':status' => $this->status,
        ]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca um alerta especifico pelo id.
        $stmt = $pdo->prepare('SELECT * FROM alerta_risco WHERE id_alerta = :id');
        $stmt->execute([':id' => $this->id_alerta]);
        return $stmt->fetch();
    }
}
