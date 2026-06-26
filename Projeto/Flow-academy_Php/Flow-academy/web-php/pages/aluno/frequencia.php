<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['aluno'], '../../');

// Identifica o aluno logado para exibir somente a propria frequencia.
$usuario = usuarioLogado();
$aluno = buscarUm('SELECT * FROM alunos WHERE id_usuario = :id_usuario', [':id_usuario' => $usuario['id_usuario']]);
$matriculaAtual = null;
$frequencias = [];

if ($aluno) {
    // Usa a matricula ativa mais recente para mostrar a frequencia da turma atual.
    $matriculaAtual = buscarUm(
        'SELECT m.*, t.id_curso, t.codigo_turma, c.nome AS curso
         FROM matriculas m
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE m.id_aluno = :id_aluno AND m.status = "ativa"
         ORDER BY m.data_matricula DESC, m.id_matricula DESC
         LIMIT 1',
        [':id_aluno' => $aluno['id_aluno']]
    );

    if (!$matriculaAtual) {
        // Se nao houver matricula ativa, usa a ultima matricula como fallback visual.
        $matriculaAtual = buscarUm(
            'SELECT m.*, t.id_curso, t.codigo_turma, c.nome AS curso
             FROM matriculas m
             JOIN turmas t ON t.id_turma = m.id_turma
             JOIN cursos c ON c.id_curso = t.id_curso
             WHERE m.id_aluno = :id_aluno
             ORDER BY m.data_matricula DESC, m.id_matricula DESC
             LIMIT 1',
            [':id_aluno' => $aluno['id_aluno']]
        );
    }

    if ($matriculaAtual) {
        // Cruza todas as UCs do curso com a frequencia ja lancada para esta matricula.
        $frequencias = buscarTodos(
            'SELECT d.nome AS disciplina, f.total_aulas, f.presencas, f.percentual
             FROM disciplinas d
             LEFT JOIN frequencia f ON f.id_disciplina = d.id_disciplina AND f.id_matricula = :id_matricula
             WHERE d.id_curso = :id_curso
             ORDER BY d.nome',
            [
                ':id_matricula' => $matriculaAtual['id_matricula'],
                ':id_curso' => $matriculaAtual['id_curso'],
            ]
        );
    }
}

appInicio('Frequencia', 'aluno', 'frequencia', '../../');
pageHeading('Presenca', 'Frequencia', 'Acompanhamento por unidade curricular.');
?>
    <!-- Painel de frequencia por UC do aluno. -->
    <section class="panel">
      <div class="panel-header"><h2>Resumo de frequencia</h2></div>
      <div class="panel-body">
        <?php if ($matriculaAtual): ?>
          <p class="muted">Turma <?= e($matriculaAtual['codigo_turma']) ?> - <?= e($matriculaAtual['curso']) ?></p>
        <?php else: ?>
          <?php alerta('warning', 'Sem matricula', 'Nenhuma matricula foi encontrada para este aluno.'); ?>
        <?php endif; ?>
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead>
              <tr>
                <th>UC</th>
                <th>Total de aulas</th>
                <th>Presencas</th>
                <th>Percentual</th>
                <th>Situacao</th>
              </tr>
            </thead>
            <tbody>
              <?php foreach ($frequencias as $linha): ?>
                <?php $percentual = (float) ($linha['percentual'] ?? 0); ?>
                <tr>
                  <td><strong><?= e($linha['disciplina']) ?></strong></td>
                  <td><?= e($linha['total_aulas'] ?? 0) ?></td>
                  <td><?= e($linha['presencas'] ?? 0) ?></td>
                  <td><strong><?= e(numeroBr($percentual, 0)) ?>%</strong></td>
                  <td><?= badge($percentual >= 75 ? 'regular' : 'atencao', $percentual >= 75 ? 'regular' : 'pendente') ?></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$frequencias): ?>
                <tr><td colspan="5">Nenhum registro de frequencia encontrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
