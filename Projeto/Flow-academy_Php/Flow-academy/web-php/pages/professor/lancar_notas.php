<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['professor'], '../../');

// Identifica o professor logado para limitar turmas, alunos e UCs.
$usuario = usuarioLogado();
$professor = buscarUm('SELECT * FROM professores WHERE id_usuario = :id_usuario', [':id_usuario' => $usuario['id_usuario']]);
$erro = '';
$sucesso = '';

// Guarda os campos selecionados para manter a tela preenchida se acontecer algum erro.
$idTurmaSelecionada = 0;
$idMatriculaSelecionada = 0;
$idDisciplinaSelecionada = 0;

if ($professor && $_SERVER['REQUEST_METHOD'] === 'POST') {
    // Valores recebidos do formulario de lancamento de notas.
    $idTurmaSelecionada = (int) post('id_turma');
    $idMatriculaSelecionada = (int) post('id_matricula');
    $idDisciplinaSelecionada = (int) post('id_disciplina');
    $prova1 = post('prova_1');
    $prova2 = post('prova_2');
    $trabalho = post('trabalho');
    $comportamental = post('comportamental');

    if ($idTurmaSelecionada <= 0 || $idMatriculaSelecionada <= 0 || $idDisciplinaSelecionada <= 0) {
        $erro = 'Selecione turma, aluno e UC antes de salvar.';
    } else {
        // Confere se a turma, a matricula e a UC pertencem ao professor logado.
        $vinculo = buscarUm(
            'SELECT COUNT(*) AS total
             FROM matriculas m
             JOIN turmas t ON t.id_turma = m.id_turma
             JOIN disciplinas d ON d.id_curso = t.id_curso
             WHERE t.id_turma = :id_turma
               AND m.id_matricula = :id_matricula
               AND d.id_disciplina = :id_disciplina
               AND t.id_professor = :id_professor
               AND m.status = "ativa"',
            [
                ':id_turma' => $idTurmaSelecionada,
                ':id_matricula' => $idMatriculaSelecionada,
                ':id_disciplina' => $idDisciplinaSelecionada,
                ':id_professor' => $professor['id_professor'],
            ]
        );

        if (!$vinculo || (int) $vinculo['total'] === 0) {
            $erro = 'Aluno ou UC nao pertence a turma selecionada.';
        } elseif (!notaValida($prova1) || !notaValida($prova2) || !notaValida($trabalho) || !notaValida($comportamental)) {
            $erro = 'Todas as notas devem estar entre 0 e 10.';
        } else {
            // Calcula a media no PHP: P1 30%, P2 30%, trabalho 30% e comportamento 10%.
            $media = round(
                ((float) $prova1 * 0.30)
                + ((float) $prova2 * 0.30)
                + ((float) $trabalho * 0.30)
                + ((float) $comportamental * 0.10),
                2
            );
            $statusNota = $media >= 6 ? 'aprovado' : 'reprovado';

            try {
                // A transacao agrupa a nota e o alerta de risco, quando necessario.
                $pdo->beginTransaction();

                // A chave unica id_matricula + id_disciplina atualiza a nota se ela ja existir.
                executar(
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
                        data_lancamento = NOW()',
                    [
                        ':id_matricula' => $idMatriculaSelecionada,
                        ':id_disciplina' => $idDisciplinaSelecionada,
                        ':prova_1' => $prova1,
                        ':prova_2' => $prova2,
                        ':trabalho' => $trabalho,
                        ':comportamental' => $comportamental,
                        ':media_uc' => $media,
                        ':status' => $statusNota,
                    ]
                );

                // Media abaixo de 5 gera um alerta para a equipe acompanhar o aluno.
                if ($media < 5) {
                    $alerta = buscarUm(
                        'SELECT id_alerta
                         FROM alerta_risco
                         WHERE id_matricula = :id_matricula
                           AND tipo_risco = "nota"
                           AND status = "pendente"
                         ORDER BY id_alerta
                         LIMIT 1',
                        [':id_matricula' => $idMatriculaSelecionada]
                    );

                    if ($alerta) {
                        executar(
                            'UPDATE alerta_risco
                             SET score = :score, status = "pendente"
                             WHERE id_alerta = :id_alerta',
                            [':score' => 10 - $media, ':id_alerta' => $alerta['id_alerta']]
                        );
                    } else {
                        executar(
                            'INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status)
                             VALUES (:id_matricula, "nota", :score, "pendente")',
                            [':id_matricula' => $idMatriculaSelecionada, ':score' => 10 - $media]
                        );
                    }
                }

                $pdo->commit();
                registrarLogSistema('Lancou nota');
                $sucesso = 'Notas salvas. Media calculada: ' . numeroBr($media, 1);
            } catch (Throwable $erroBanco) {
                // Cancela a alteracao se nota ou alerta nao puderem ser gravados.
                if ($pdo->inTransaction()) {
                    $pdo->rollBack();
                }

                $erro = 'Nao foi possivel salvar as notas.';
            }
        }
    }
}

$turmas = [];
$matriculas = [];
$disciplinas = [];
$disciplinasPorTurma = [];
$notas = [];
$notasFiltradas = [];
$idDisciplinaFiltro = (int) getValor('uc', 0);

if ($professor) {
    // Turmas ativas do professor. Este select sera usado como filtro principal.
    $turmas = buscarTodos(
        'SELECT t.id_turma, t.codigo_turma, c.nome AS curso
         FROM turmas t
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor AND t.status = "ativa"
         ORDER BY t.codigo_turma',
        [':id_professor' => $professor['id_professor']]
    );

    // Alunos ativos, ja trazendo o id_turma para o JavaScript filtrar o select.
    $matriculas = buscarTodos(
        'SELECT m.id_matricula, m.id_turma, a.matricula, u.nome AS aluno, t.codigo_turma, c.nome AS curso
         FROM matriculas m
         JOIN alunos a ON a.id_aluno = m.id_aluno
         JOIN usuarios u ON u.id_usuario = a.id_usuario
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor AND m.status = "ativa"
         ORDER BY t.codigo_turma, u.nome',
        [':id_professor' => $professor['id_professor']]
    );

    // UCs unicas para o filtro da tabela de notas lancadas.
    $disciplinas = buscarTodos(
        'SELECT DISTINCT d.id_disciplina, d.nome, c.nome AS curso
         FROM disciplinas d
         JOIN cursos c ON c.id_curso = d.id_curso
         JOIN turmas t ON t.id_curso = c.id_curso
         WHERE t.id_professor = :id_professor AND t.status = "ativa"
         ORDER BY c.nome, d.nome',
        [':id_professor' => $professor['id_professor']]
    );

    // UCs repetidas por turma para o select do formulario.
    // Isso permite mostrar somente as UCs do curso da turma escolhida.
    $disciplinasPorTurma = buscarTodos(
        'SELECT t.id_turma, d.id_disciplina, d.nome, c.nome AS curso
         FROM turmas t
         JOIN cursos c ON c.id_curso = t.id_curso
         JOIN disciplinas d ON d.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor AND t.status = "ativa"
         ORDER BY t.codigo_turma, d.nome',
        [':id_professor' => $professor['id_professor']]
    );

    // Listagem de notas ja lancadas pelo professor.
    $notas = buscarTodos(
        'SELECT u.nome AS aluno, a.matricula, t.codigo_turma, c.nome AS curso,
                d.id_disciplina, d.nome AS disciplina,
                n.prova_1, n.prova_2, n.trabalho, n.comportamental, n.media_uc, n.status
         FROM notas n
         JOIN matriculas m ON m.id_matricula = n.id_matricula
         JOIN alunos a ON a.id_aluno = m.id_aluno
         JOIN usuarios u ON u.id_usuario = a.id_usuario
         JOIN disciplinas d ON d.id_disciplina = n.id_disciplina
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor
         ORDER BY d.nome, t.codigo_turma, u.nome',
        [':id_professor' => $professor['id_professor']]
    );

    if ($idDisciplinaFiltro <= 0 && $disciplinas) {
        // Se o professor ainda nao escolheu UC no filtro, usa a primeira disponivel.
        $idDisciplinaFiltro = (int) $disciplinas[0]['id_disciplina'];
    }

    $filtroExiste = false;
    // Confere se a UC enviada na URL realmente pertence ao professor.
    foreach ($disciplinas as $disciplina) {
        if ((int) $disciplina['id_disciplina'] === $idDisciplinaFiltro) {
            $filtroExiste = true;
            break;
        }
    }

    if (!$filtroExiste) {
        $idDisciplinaFiltro = (int) ($disciplinas[0]['id_disciplina'] ?? 0);
    }

    foreach ($notas as $nota) {
        // Cria uma lista apenas com as notas da UC selecionada no filtro.
        if ((int) $nota['id_disciplina'] === $idDisciplinaFiltro) {
            $notasFiltradas[] = $nota;
        }
    }
}

appInicio('Lancar Notas', 'professor', 'notas', '../../');
pageHeading('Avaliacao', 'Lancar Notas', 'A media e calculada no sistema: provas 60%, trabalho 30% e comportamental 10%.');
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Notas salvas', $sucesso); ?><?php endif; ?>

    <!-- Formulario de lancamento: turma filtra alunos e UCs pelo JavaScript. -->
    <section class="panel">
      <div class="panel-header"><h2>Novo lancamento</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field span-2">
            <span>Turma</span>
            <select
              class="select"
              name="id_turma"
              id="id_turma_notas"
              data-turma-filter
              data-filter-students="#id_matricula_notas"
              data-filter-ucs="#id_disciplina_notas"
              required
            >
              <option value="">Selecione a turma</option>
              <?php foreach ($turmas as $turma): ?>
                <option value="<?= e($turma['id_turma']) ?>" <?= $idTurmaSelecionada === (int) $turma['id_turma'] ? 'selected' : '' ?>>
                  <?= e($turma['codigo_turma'] . ' - ' . $turma['curso']) ?>
                </option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field span-2">
            <span>Aluno matriculado</span>
            <select class="select" name="id_matricula" id="id_matricula_notas" required>
              <option value="">Selecione a turma primeiro</option>
              <?php foreach ($matriculas as $matricula): ?>
                <option
                  value="<?= e($matricula['id_matricula']) ?>"
                  data-turma="<?= e($matricula['id_turma']) ?>"
                  <?= $idMatriculaSelecionada === (int) $matricula['id_matricula'] ? 'selected' : '' ?>
                >
                  <?= e($matricula['aluno'] . ' - ' . $matricula['matricula']) ?>
                </option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field span-2">
            <span>Unidade curricular</span>
            <select class="select" name="id_disciplina" id="id_disciplina_notas" required>
              <option value="">Selecione a turma primeiro</option>
              <?php foreach ($disciplinasPorTurma as $disciplina): ?>
                <option
                  value="<?= e($disciplina['id_disciplina']) ?>"
                  data-turma="<?= e($disciplina['id_turma']) ?>"
                  <?= $idDisciplinaSelecionada === (int) $disciplina['id_disciplina'] && $idTurmaSelecionada === (int) $disciplina['id_turma'] ? 'selected' : '' ?>
                >
                  <?= e($disciplina['nome']) ?>
                </option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field"><span>Prova 1</span><input class="control" name="prova_1" type="number" min="0" max="10" step="0.1" required></label>
          <label class="field"><span>Prova 2</span><input class="control" name="prova_2" type="number" min="0" max="10" step="0.1" required></label>
          <label class="field"><span>Trabalho</span><input class="control" name="trabalho" type="number" min="0" max="10" step="0.1" required></label>
          <label class="field"><span>Comportamental</span><input class="control" name="comportamental" type="number" min="0" max="10" step="0.1" required></label>
          <div class="actions span-2" style="justify-content:flex-start"><button class="btn primary" type="submit">Salvar notas</button></div>
        </form>
      </div>
    </section>

    <!-- Listagem filtrada das notas ja lancadas por Unidade Curricular. -->
    <section class="panel">
      <div class="panel-header"><h2>Notas lancadas</h2></div>
      <div class="panel-body">
        <?php if ($disciplinas): ?>
          <form class="form-grid" method="get">
            <label class="field span-2">
              <span>Filtrar por UC</span>
              <select class="select" name="uc" onchange="this.form.submit()">
                <?php foreach ($disciplinas as $disciplina): ?>
                  <option value="<?= e($disciplina['id_disciplina']) ?>" <?= $idDisciplinaFiltro === (int) $disciplina['id_disciplina'] ? 'selected' : '' ?>>
                    <?= e($disciplina['curso'] . ' - ' . $disciplina['nome']) ?>
                  </option>
                <?php endforeach; ?>
              </select>
            </label>
          </form>

          <div class="table-wrap">
            <table id="tabela-principal">
              <thead><tr><th>Aluno</th><th>Turma</th><th>P1</th><th>P2</th><th>Trabalho</th><th>Comp.</th><th>Media</th><th>Status</th></tr></thead>
              <tbody>
                <?php foreach ($notasFiltradas as $nota): ?>
                  <tr>
                    <td><strong><?= e($nota['aluno']) ?></strong><br><span class="muted"><?= e($nota['matricula']) ?></span></td>
                    <td><?= e($nota['codigo_turma']) ?></td>
                    <td><?= e(numeroBr($nota['prova_1'])) ?></td>
                    <td><?= e(numeroBr($nota['prova_2'])) ?></td>
                    <td><?= e(numeroBr($nota['trabalho'])) ?></td>
                    <td><?= e(numeroBr($nota['comportamental'])) ?></td>
                    <td><strong><?= e(numeroBr($nota['media_uc'])) ?></strong></td>
                    <td><?= badge($nota['status'], $nota['status']) ?></td>
                  </tr>
                <?php endforeach; ?>
                <?php if (!$notasFiltradas): ?>
                  <tr><td colspan="8">Nenhuma nota lancada para esta UC.</td></tr>
                <?php endif; ?>
              </tbody>
            </table>
          </div>
        <?php else: ?>
          <?php alerta('warning', 'Nenhuma UC encontrada', 'Cadastre unidades curriculares nos cursos das turmas deste professor.'); ?>
        <?php endif; ?>
      </div>
    </section>
<?php appFim('../../'); ?>
