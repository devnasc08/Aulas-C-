<?php
// Service de matricula: organiza regras de criar, cancelar, transferir e validar matriculas.
class MatriculaService
{
    public function realizarMatricula($aluno, $turma)
    {
        // Monta a matricula usando os ids vindos dos objetos Aluno e Turma.
        $matricula = new Matricula([
            'id_aluno' => $aluno->getIdAluno(),
            'id_turma' => $turma->getIdTurma(),
        ]);

        $matricula->realizar();
        // Retorna a matricula criada para continuar o fluxo se necessario.
        return $matricula;
    }

    public function cancelarMatricula($matricula)
    {
        // Encapsula o cancelamento para a tela nao chamar o metodo direto.
        $matricula->cancelar();
    }

    public function transferirAluno($matricula, $novaTurma)
    {
        // Move a matricula para outra turma.
        $matricula->transferir($novaTurma);
    }

    public function validarCapacidade($turma)
    {
        // Pergunta para a turma se ainda existe vaga disponivel.
        return $turma->verificarCapacidade();
    }

    public function validarDuplicidade($aluno, $turma)
    {
        // Cria um objeto temporario so para testar se ja existe matricula igual.
        $matricula = new Matricula([
            'id_aluno' => $aluno->getIdAluno(),
            'id_turma' => $turma->getIdTurma(),
        ]);

        return !$matricula->verificarDuplicidade();
    }
}
