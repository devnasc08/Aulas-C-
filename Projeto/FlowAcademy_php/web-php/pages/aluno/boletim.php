<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['aluno'], '../../');

// Identifica o aluno da sessao para mostrar somente as proprias notas.
$usuario = usuarioLogado();
$aluno = buscarUm('SELECT * FROM alunos WHERE id_usuario = :id_usuario', [':id_usuario' => $usuario['id_usuario']]);
$matriculaAtual = null;
$notas = [];

if ($aluno) {
    // Primeiro procura a matricula ativa mais recente do aluno.
    // Assim o boletim mostra exatamente a turma atual onde o professor lancou as notas.
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
        // Caso nao exista matricula ativa, usa a ultima matricula cadastrada como apoio visual.
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
        // Lista todas as UCs do curso e cruza com as notas salvas para esta matricula.
        $notas = buscarTodos(
            'SELECT d.nome AS disciplina, n.prova_1, n.prova_2, n.trabalho, n.comportamental, n.media_uc, n.status
             FROM disciplinas d
             LEFT JOIN notas n ON n.id_disciplina = d.id_disciplina AND n.id_matricula = :id_matricula
             WHERE d.id_curso = :id_curso
             ORDER BY d.nome',
            [
                ':id_matricula' => $matriculaAtual['id_matricula'],
                ':id_curso' => $matriculaAtual['id_curso'],
            ]
        );
    }
}

appInicio('Boletim', 'aluno', 'boletim', '../../');
pageHeading('Notas', 'Boletim', 'Notas por unidade curricular, usando a media ponderada do SQL.');
?>
    <!-- Painel principal do boletim do aluno. -->
    <section class="panel">
      <div class="panel-header"><h2>Unidades curriculares</h2></div>
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
                <th>Prova 1</th>
                <th>Prova 2</th>
                <th>Trabalho</th>
                <th>Comportamental</th>
                <th>Media</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              <?php foreach ($notas as $nota): ?>
                <tr>
                  <td><strong><?= e($nota['disciplina']) ?></strong></td>
                  <td><?= e(numeroBr($nota['prova_1'])) ?></td>
                  <td><?= e(numeroBr($nota['prova_2'])) ?></td>
                  <td><?= e(numeroBr($nota['trabalho'])) ?></td>
                  <td><?= e(numeroBr($nota['comportamental'])) ?></td>
                  <td><strong><?= e(numeroBr($nota['media_uc'])) ?></strong></td>
                  <td><?= badge($nota['status'] ?? 'em_andamento', $nota['status'] ?? 'em_andamento') ?></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$notas): ?>
                <tr><td colspan="7">Nenhuma nota encontrada.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
