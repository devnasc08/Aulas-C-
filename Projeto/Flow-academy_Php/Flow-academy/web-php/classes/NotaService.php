<?php
// Service de notas: concentra regras de lancamento e calculo usadas por outras partes do sistema.
class NotaService
{
    public function lancarNota($matricula, $disciplina, $valores)
    {
        // Monta um objeto Nota com ids da matricula e da UC recebidas.
        $nota = new Nota([
            'id_matricula' => $matricula->getIdMatricula(),
            'id_disciplina' => $disciplina->getIdDisciplina(),
            'prova_1' => $valores['prova_1'],
            'prova_2' => $valores['prova_2'],
            'trabalho' => $valores['trabalho'],
            'comportamental' => $valores['comportamental'],
        ]);

        $nota->lancar();
        // Retorna o objeto para quem chamou poder continuar usando os dados.
        return $nota;
    }

    public function editarNota($nota, $valores)
    {
        // Atualiza o objeto com novos valores e reutiliza o metodo editar da classe Nota.
        preencherObjeto($nota, $valores);
        $nota->editar();
    }

    public function calcularMedia($prova_1, $prova_2, $trabalho, $comportamental)
    {
        // Mesma formula usada no banco: 30% + 30% + 30% + 10%.
        return ($prova_1 * 0.30) + ($prova_2 * 0.30) + ($trabalho * 0.30) + ($comportamental * 0.10);
    }

    public function verificarAprovacaoGeral($matricula)
    {
        global $pdo;

        // Busca quantas UCs o curso possui para comparar com as notas lancadas.
        $stmtTotal = $pdo->prepare(
            'SELECT COUNT(d.id_disciplina) AS total
             FROM matriculas m
             JOIN turmas t ON t.id_turma = m.id_turma
             JOIN disciplinas d ON d.id_curso = t.id_curso
             WHERE m.id_matricula = :id_matricula'
        );
        $stmtTotal->execute([':id_matricula' => $matricula->getIdMatricula()]);
        $totalUcs = (int) ($stmtTotal->fetch()['total'] ?? 0);

        // Conta notas aprovadas e reprovadas sem depender de uma function do MySQL.
        $stmtNotas = $pdo->prepare(
            'SELECT
                SUM(status = "aprovado") AS aprovadas,
                SUM(status = "reprovado") AS reprovadas
             FROM notas
             WHERE id_matricula = :id_matricula'
        );
        $stmtNotas->execute([':id_matricula' => $matricula->getIdMatricula()]);
        $notas = $stmtNotas->fetch() ?: [];
        $aprovadas = (int) ($notas['aprovadas'] ?? 0);
        $reprovadas = (int) ($notas['reprovadas'] ?? 0);

        if ($reprovadas > 0) {
            return 'Retido no Curso: Media inferior a 6.0 detectada em alguma UC.';
        }

        if ($totalUcs > 0 && $aprovadas === $totalUcs) {
            return 'Aprovado no Curso: Obteve media superior a 6.0 em todas as UCs!';
        }

        return 'Cursando: O aluno possui UCs pendentes de fechamento.';
    }
}
