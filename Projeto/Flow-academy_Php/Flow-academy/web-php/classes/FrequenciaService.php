<?php
// Service de frequencia: concentra regras de chamada e risco por presenca.
class FrequenciaService
{
    public function registrarFrequencia($matricula, $disciplina, $presenca)
    {
        global $pdo;

        // Booleano vira 1 para presente e 0 para falta.
        $presencas = $presenca ? 1 : 0;

        // Se ja existir frequencia para a matricula e UC, soma mais uma aula.
        $sql = 'INSERT INTO frequencia (id_matricula, id_disciplina, total_aulas, presencas)
                VALUES (:id_matricula, :id_disciplina, 1, :presencas)
                ON DUPLICATE KEY UPDATE total_aulas = total_aulas + 1, presencas = presencas + :presencas_update';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([
            ':id_matricula' => $matricula->getIdMatricula(),
            ':id_disciplina' => $disciplina->getIdDisciplina(),
            ':presencas' => $presencas,
            ':presencas_update' => $presencas,
        ]);
    }

    public function calcularPercentual($matricula, $disciplina)
    {
        global $pdo;

        // Le o percentual calculado pelo proprio banco na tabela frequencia.
        $stmt = $pdo->prepare('SELECT percentual FROM frequencia WHERE id_matricula = :id_matricula AND id_disciplina = :id_disciplina');
        $stmt->execute([
            ':id_matricula' => $matricula->getIdMatricula(),
            ':id_disciplina' => $disciplina->getIdDisciplina(),
        ]);

        $dados = $stmt->fetch();
        return $dados ? $dados['percentual'] : 0;
    }

    public function verificarRiscoReprovacao($matricula)
    {
        global $pdo;

        // Se alguma UC estiver abaixo de 75%, o aluno entra em risco de frequencia.
        $stmt = $pdo->prepare('SELECT COUNT(*) AS total FROM frequencia WHERE id_matricula = :id_matricula AND percentual < 75');
        $stmt->execute([':id_matricula' => $matricula->getIdMatricula()]);
        $dados = $stmt->fetch();

        return $dados['total'] > 0;
    }
}
