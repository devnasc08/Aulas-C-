<?php
// Classe que representa as notas de uma matricula em uma Unidade Curricular.
class Nota
{
    // Campos da tabela notas, incluindo as quatro avaliacoes e a media final.
    private $id_nota;
    private $id_matricula;
    private $id_disciplina;
    private $prova_1;
    private $prova_2;
    private $trabalho;
    private $comportamental;
    private $media_uc;
    private $status;
    private $data_lancamento;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para uma nota ainda nao lancada.
        $this->id_nota = null;
        $this->id_matricula = null;
        $this->id_disciplina = null;
        $this->prova_1 = 0;
        $this->prova_2 = 0;
        $this->trabalho = 0;
        $this->comportamental = 0;
        $this->media_uc = 0;
        $this->status = 'em_andamento';
        $this->data_lancamento = null;

        preencherObjeto($this, $dados);
    }

    // Getters e setters usados para preencher ou consultar os campos da nota.
    public function getIdNota() { return $this->id_nota; }
    public function setIdNota($id_nota) { $this->id_nota = $id_nota; }

    public function getIdMatricula() { return $this->id_matricula; }
    public function setIdMatricula($id_matricula) { $this->id_matricula = $id_matricula; }

    public function getIdDisciplina() { return $this->id_disciplina; }
    public function setIdDisciplina($id_disciplina) { $this->id_disciplina = $id_disciplina; }

    public function getProva1() { return $this->prova_1; }
    public function setProva1($prova_1) { $this->prova_1 = $prova_1; }

    public function getProva2() { return $this->prova_2; }
    public function setProva2($prova_2) { $this->prova_2 = $prova_2; }

    public function getTrabalho() { return $this->trabalho; }
    public function setTrabalho($trabalho) { $this->trabalho = $trabalho; }

    public function getComportamental() { return $this->comportamental; }
    public function setComportamental($comportamental) { $this->comportamental = $comportamental; }

    public function getMediaUc() { return $this->media_uc; }
    public function setMediaUc($media_uc) { $this->media_uc = $media_uc; }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function getDataLancamento() { return $this->data_lancamento; }
    public function setDataLancamento($data_lancamento) { $this->data_lancamento = $data_lancamento; }

    public function lancar()
    {
        global $pdo;

        // Calcula e guarda a regra de avaliacao no PHP, sem function/procedure no banco.
        $this->media_uc = round($this->calcularMedia(), 2);
        $this->status = $this->media_uc >= 6 ? 'aprovado' : 'reprovado';
        $iniciouTransacao = !$pdo->inTransaction();

        if ($iniciouTransacao) {
            $pdo->beginTransaction();
        }

        try {
            // A chave unica (matricula + UC) permite inserir ou atualizar a mesma nota.
            $stmtNota = $pdo->prepare(
                'INSERT INTO notas
                    (id_matricula, id_disciplina, prova_1, prova_2, trabalho, comportamental, media_uc, status, data_lancamento)
                 VALUES
                    (:id_matricula, :id_disciplina, :prova_1, :prova_2, :trabalho, :comportamental, :media_uc, :status, NOW())
                 ON DUPLICATE KEY UPDATE
                    prova_1 = VALUES(prova_1),
                    prova_2 = VALUES(prova_2),
                    trabalho = VALUES(trabalho),
                    comportamental = VALUES(comportamental),
                    media_uc = VALUES(media_uc),
                    status = VALUES(status),
                    data_lancamento = NOW()'
            );
            $stmtNota->execute([
                ':id_matricula' => $this->id_matricula,
                ':id_disciplina' => $this->id_disciplina,
                ':prova_1' => $this->prova_1,
                ':prova_2' => $this->prova_2,
                ':trabalho' => $this->trabalho,
                ':comportamental' => $this->comportamental,
                ':media_uc' => $this->media_uc,
                ':status' => $this->status,
            ]);

            // Media menor que 5 gera ou atualiza um alerta academico pendente.
            if ($this->media_uc < 5) {
                $stmtAlerta = $pdo->prepare(
                    'SELECT id_alerta
                     FROM alerta_risco
                     WHERE id_matricula = :id_matricula
                       AND tipo_risco = "nota"
                       AND status = "pendente"
                     ORDER BY id_alerta
                     LIMIT 1'
                );
                $stmtAlerta->execute([':id_matricula' => $this->id_matricula]);
                $alerta = $stmtAlerta->fetch();

                if ($alerta) {
                    $stmtAtualizarAlerta = $pdo->prepare(
                        'UPDATE alerta_risco
                         SET score = :score, status = "pendente"
                         WHERE id_alerta = :id_alerta'
                    );
                    $stmtAtualizarAlerta->execute([
                        ':score' => 10 - $this->media_uc,
                        ':id_alerta' => $alerta['id_alerta'],
                    ]);
                } else {
                    $stmtInserirAlerta = $pdo->prepare(
                        'INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status)
                         VALUES (:id_matricula, "nota", :score, "pendente")'
                    );
                    $stmtInserirAlerta->execute([
                        ':id_matricula' => $this->id_matricula,
                        ':score' => 10 - $this->media_uc,
                    ]);
                }
            }

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

    public function editar()
    {
        // Editar reaproveita o INSERT ... ON DUPLICATE KEY UPDATE de lancar().
        $this->lancar();
    }

    public function consultarBoletim()
    {
        global $pdo;

        // Busca a nota de uma matricula em uma UC especifica para exibir no boletim.
        $stmt = $pdo->prepare('SELECT * FROM notas WHERE id_matricula = :id_matricula AND id_disciplina = :id_disciplina');
        $stmt->execute([
            ':id_matricula' => $this->id_matricula,
            ':id_disciplina' => $this->id_disciplina,
        ]);

        return $stmt->fetch();
    }

    public function calcularMedia()
    {
        // Regra de media: provas valem 60%, trabalho 30% e comportamental 10%.
        return ($this->prova_1 * 0.30) + ($this->prova_2 * 0.30) + ($this->trabalho * 0.30) + ($this->comportamental * 0.10);
    }
}
