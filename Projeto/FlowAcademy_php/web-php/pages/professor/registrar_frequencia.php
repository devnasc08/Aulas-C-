<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['professor'], '../../');

// Identifica o professor logado para restringir a chamada as turmas dele.
$usuario = usuarioLogado();
$professor = buscarUm('SELECT * FROM professores WHERE id_usuario = :id_usuario', [':id_usuario' => $usuario['id_usuario']]);
$erro = '';
$sucesso = '';

// Mantem as escolhas na tela quando existe erro de validacao.
$idTurmaSelecionada = 0;
$idMatriculaSelecionada = 0;
$idDisciplinaSelecionada = 0;

if ($professor && $_SERVER['REQUEST_METHOD'] === 'POST') {
    // O professor informa a turma, a UC, o total de aulas e quantas presencas o aluno teve.
    $idTurmaSelecionada = (int) post('id_turma');
    $idMatriculaSelecionada = (int) post('id_matricula');
    $idDisciplinaSelecionada = (int) post('id_disciplina');
    $totalAulas = (int) post('total_aulas');
    $presencas = (int) post('presencas');

    if ($idTurmaSelecionada <= 0 || $idMatriculaSelecionada <= 0 || $idDisciplinaSelecionada <= 0) {
        $erro = 'Selecione turma, aluno e UC antes de salvar.';
    } else {
        // Garante que o professor so altere frequencia da turma que ele realmente leciona.
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
        } elseif ($totalAulas <= 0) {
            $erro = 'O total de aulas deve ser maior que zero.';
        } elseif ($presencas < 0 || $presencas > $totalAulas) {
            $erro = 'As presencas nao podem ser negativas nem maiores que o total de aulas.';
        } else {
            // ON DUPLICATE KEY UPDATE atualiza se ja existir frequencia para a mesma matricula e UC.
            executar(
                'INSERT INTO frequencia (id_matricula, id_disciplina, total_aulas, presencas)
                 VALUES (:id_matricula, :id_disciplina, :total_aulas, :presencas)
                 ON DUPLICATE KEY UPDATE total_aulas = VALUES(total_aulas), presencas = VALUES(presencas)',
                [
                    ':id_matricula' => $idMatriculaSelecionada,
                    ':id_disciplina' => $idDisciplinaSelecionada,
                    ':total_aulas' => $totalAulas,
                    ':presencas' => $presencas,
                ]
            );
            registrarLogSistema('Registrou frequencia');
            $sucesso = 'Frequencia salva com sucesso.';
        }
    }
}

$turmas = [];
$matriculas = [];
$disciplinas = [];
$disciplinasPorTurma = [];
$frequencias = [];
$frequenciasFiltradas = [];
$idDisciplinaFiltro = (int) getValor('uc', 0);

if ($professor) {
    // Turmas ativas do professor para filtrar a chamada.
    $turmas = buscarTodos(
        'SELECT t.id_turma, t.codigo_turma, c.nome AS curso
         FROM turmas t
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor AND t.status = "ativa"
         ORDER BY t.codigo_turma',
        [':id_professor' => $professor['id_professor']]
    );

    // Opcoes do select de alunos. O data-turma deixa o JavaScript exibir apenas a turma escolhida.
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

    // UCs unicas para o filtro da tabela de frequencias.
    $disciplinas = buscarTodos(
        'SELECT DISTINCT d.id_disciplina, d.nome, c.nome AS curso
         FROM disciplinas d
         JOIN cursos c ON c.id_curso = d.id_curso
         JOIN turmas t ON t.id_curso = c.id_curso
         WHERE t.id_professor = :id_professor AND t.status = "ativa"
         ORDER BY c.nome, d.nome',
        [':id_professor' => $professor['id_professor']]
    );

    // UCs por turma para o formulario de chamada.
    $disciplinasPorTurma = buscarTodos(
        'SELECT t.id_turma, d.id_disciplina, d.nome, c.nome AS curso
         FROM turmas t
         JOIN cursos c ON c.id_curso = t.id_curso
         JOIN disciplinas d ON d.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor AND t.status = "ativa"
         ORDER BY t.codigo_turma, d.nome',
        [':id_professor' => $professor['id_professor']]
    );

    // Tabela final exibida na pagina com o percentual calculado pelo banco.
    $frequencias = buscarTodos(
        'SELECT u.nome AS aluno, a.matricula, t.codigo_turma, c.nome AS curso,
                d.id_disciplina, d.nome AS disciplina,
                f.total_aulas, f.presencas, f.percentual
         FROM frequencia f
         JOIN matriculas m ON m.id_matricula = f.id_matricula
         JOIN alunos a ON a.id_aluno = m.id_aluno
         JOIN usuarios u ON u.id_usuario = a.id_usuario
         JOIN disciplinas d ON d.id_disciplina = f.id_disciplina
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE t.id_professor = :id_professor
         ORDER BY d.nome, t.codigo_turma, u.nome',
        [':id_professor' => $professor['id_professor']]
    );

    if ($idDisciplinaFiltro <= 0 && $disciplinas) {
        // Sem filtro informado, a tela abre na primeira UC disponivel.
        $idDisciplinaFiltro = (int) $disciplinas[0]['id_disciplina'];
    }

    $filtroExiste = false;
    // Evita aceitar pela URL uma UC que nao pertence ao professor.
    foreach ($disciplinas as $disciplina) {
        if ((int) $disciplina['id_disciplina'] === $idDisciplinaFiltro) {
            $filtroExiste = true;
            break;
        }
    }

    if (!$filtroExiste) {
        $idDisciplinaFiltro = (int) ($disciplinas[0]['id_disciplina'] ?? 0);
    }

    foreach ($frequencias as $linha) {
        // Filtra em PHP para mostrar somente a UC selecionada.
        if ((int) $linha['id_disciplina'] === $idDisciplinaFiltro) {
            $frequenciasFiltradas[] = $linha;
        }
    }
}

appInicio('Registrar Frequencia', 'professor', 'frequencia', '../../');
pageHeading('Chamada', 'Registrar Frequencia', 'Atualize total de aulas e presencas com validacao simples.');
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Frequencia salva', $sucesso); ?><?php endif; ?>

    <!-- Formulario de chamada: turma filtra alunos e UCs pelo JavaScript. -->
    <section class="panel">
      <div class="panel-header"><h2>Novo registro</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field span-2">
            <span>Turma</span>
            <select
              class="select"
              name="id_turma"
              id="id_turma_frequencia"
              data-turma-filter
              data-filter-students="#id_matricula_frequencia"
              data-filter-ucs="#id_disciplina_frequencia"
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
            <select class="select" name="id_matricula" id="id_matricula_frequencia" required>
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
            <select class="select" name="id_disciplina" id="id_disciplina_frequencia" required>
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
          <label class="field"><span>Total de aulas</span><input class="control" name="total_aulas" type="number" min="1" required></label>
          <label class="field"><span>Presencas</span><input class="control" name="presencas" type="number" min="0" required></label>
          <div class="actions span-2" style="justify-content:flex-start"><button class="btn primary" type="submit">Salvar frequencia</button></div>
        </form>
      </div>
    </section>

    <!-- Tabela de frequencias por UC selecionada. -->
    <section class="panel">
      <div class="panel-header"><h2>Frequencias por UC</h2></div>
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
              <thead><tr><th>Aluno</th><th>Turma</th><th>Aulas</th><th>Presencas</th><th>Percentual</th><th>Situacao</th></tr></thead>
              <tbody>
                <?php foreach ($frequenciasFiltradas as $linha): ?>
                  <?php $percentual = (float) ($linha['percentual'] ?? 0); ?>
                  <tr>
                    <td><strong><?= e($linha['aluno']) ?></strong><br><span class="muted"><?= e($linha['matricula']) ?></span></td>
                    <td><?= e($linha['codigo_turma']) ?></td>
                    <td><?= e($linha['total_aulas']) ?></td>
                    <td><?= e($linha['presencas']) ?></td>
                    <td><strong><?= e(numeroBr($percentual, 0)) ?>%</strong></td>
                    <td><?= badge($percentual >= 75 ? 'regular' : 'atencao', $percentual >= 75 ? 'regular' : 'pendente') ?></td>
                  </tr>
                <?php endforeach; ?>
                <?php if (!$frequenciasFiltradas): ?>
                  <tr><td colspan="6">Nenhuma frequencia registrada para esta UC.</td></tr>
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
