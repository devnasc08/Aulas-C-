<?php
// Classe que representa a frequencia de uma matricula em uma Unidade Curricular.
class Frequencia
{
    // Campos da tabela frequencia, incluindo aulas, presencas e percentual.
    private $id_frequencia;
    private $id_matricula;
    private $id_disciplina;
    private $total_aulas;
    private $presencas;
    private $percentual;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para uma frequencia nova.
        $this->id_frequencia = null;
        $this->id_matricula = null;
        $this->id_disciplina = null;
        $this->total_aulas = 0;
        $this->presencas = 0;
        $this->percentual = 0;

        preencherObjeto($this, $dados);
    }

    // Getters e setters para acessar os campos privados da frequencia.
    public function getIdFrequencia() { return $this->id_frequencia; }
    public function setIdFrequencia($id_frequencia) { $this->id_frequencia = $id_frequencia; }

    public function getIdMatricula() { return $this->id_matricula; }
    public function setIdMatricula($id_matricula) { $this->id_matricula = $id_matricula; }

    public function getIdDisciplina() { return $this->id_disciplina; }
    public function setIdDisciplina($id_disciplina) { $this->id_disciplina = $id_disciplina; }

    public function getTotalAulas() { return $this->total_aulas; }
    public function setTotalAulas($total_aulas) { $this->total_aulas = $total_aulas; }

    public function getPresencas() { return $this->presencas; }
    public function setPresencas($presencas) { $this->presencas = $presencas; }

    public function getPercentual() { return $this->percentual; }
    public function setPercentual($percentual) { $this->percentual = $percentual; }

    public function registrar()
    {
        global $pdo;

        // Insere ou atualiza a frequencia da mesma matricula e UC.
        $sql = 'INSERT INTO frequencia (id_matricula, id_disciplina, total_aulas, presencas)
                VALUES (:id_matricula, :id_disciplina, :total_aulas, :presencas)
                ON DUPLICATE KEY UPDATE total_aulas = VALUES(total_aulas), presencas = VALUES(presencas)';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':id_matricula' => $this->id_matricula,
            ':id_disciplina' => $this->id_disciplina,
            ':total_aulas' => $this->total_aulas,
            ':presencas' => $this->presencas,
        ]);
    }

    public function editar()
    {
        // Editar usa o mesmo metodo registrar porque o SQL ja faz atualizacao.
        $this->registrar();
    }

    public function consultar()
    {
        global $pdo;

        // Busca a frequencia de um aluno em uma UC especifica.
        $stmt = $pdo->prepare('SELECT * FROM frequencia WHERE id_matricula = :id_matricula AND id_disciplina = :id_disciplina');
        $stmt->execute([
            ':id_matricula' => $this->id_matricula,
            ':id_disciplina' => $this->id_disciplina,
        ]);

        return $stmt->fetch();
    }

    public function calcularPercentual()
    {
        // Evita divisao por zero quando ainda nao existe aula registrada.
        if ($this->total_aulas == 0) {
            return 0;
        }

        // Percentual simples: presencas dividido pelo total de aulas.
        return ($this->presencas / $this->total_aulas) * 100;
    }
}
