<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin'], '../../');

// Formulario para criar ou editar turmas.
$erro = '';
$sucesso = '';
$idTurma = (int) getValor('id', 0);
$modoEdicao = $idTurma > 0;
$turma = null;

if ($modoEdicao) {
    // Se veio id pela URL, a tela entra em modo edicao e carrega a turma.
    $turma = buscarUm('SELECT * FROM turmas WHERE id_turma = :id_turma', [
        ':id_turma' => $idTurma,
    ]);

    if (!$turma) {
        flash('danger', 'Turma nao encontrada.');
        redirecionar('turmas.php');
    }
}

$valores = [
    // Valores usados para preencher o formulario em cadastro, edicao ou erro.
    'id_curso' => $turma['id_curso'] ?? '',
    'id_professor' => $turma['id_professor'] ?? '',
    'codigo_turma' => $turma['codigo_turma'] ?? '',
    'turno' => $turma['turno'] ?? 'noite',
    'periodo_letivo' => $turma['periodo_letivo'] ?? '',
    'capacidade_maxima' => $turma['capacidade_maxima'] ?? 35,
    'status' => $turma['status'] ?? 'ativa',
];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Dados da turma enviados pelo formulario.
    $idCurso = (int) post('id_curso');
    $idProfessor = (int) post('id_professor');
    $codigo = strtoupper(post('codigo_turma'));
    $turno = post('turno');
    $periodo = post('periodo_letivo');
    $capacidade = (int) post('capacidade_maxima', 35);
    $status = post('status', 'ativa');

    $valores = [
        'id_curso' => $idCurso,
        'id_professor' => $idProfessor,
        'codigo_turma' => $codigo,
        'turno' => $turno,
        'periodo_letivo' => $periodo,
        'capacidade_maxima' => $capacidade,
        'status' => $status,
    ];

    // Na edicao, ignoramos a propria turma para nao acusar conflito com ela mesma.
    $conflito = buscarUm(
        'SELECT COUNT(*) AS total
         FROM turmas
         WHERE id_professor = :id_professor
           AND turno = :turno
           AND periodo_letivo = :periodo
           AND status = "ativa"
           AND id_turma <> :id_turma',
        [
            ':id_professor' => $idProfessor,
            ':turno' => $turno,
            ':periodo' => $periodo,
            ':id_turma' => $modoEdicao ? $idTurma : 0,
        ]
    );

    // Confirma que os ids escolhidos existem antes de tentar salvar a turma.
    // Isso evita erro de chave estrangeira e garante o vinculo por id_curso.
    $cursoSelecionado = $idCurso > 0 ? buscarUm(
        'SELECT id_curso FROM cursos WHERE id_curso = :id_curso',
        [':id_curso' => $idCurso]
    ) : null;
    $professorSelecionado = $idProfessor > 0 ? buscarUm(
        'SELECT id_professor FROM professores WHERE id_professor = :id_professor',
        [':id_professor' => $idProfessor]
    ) : null;

    if ($idCurso <= 0 || $idProfessor <= 0 || $codigo === '' || $periodo === '') {
        $erro = 'Preencha todos os campos obrigatorios.';
    } elseif (!$cursoSelecionado) {
        $erro = 'O curso selecionado nao foi encontrado.';
    } elseif (!$professorSelecionado) {
        $erro = 'O professor selecionado nao foi encontrado.';
    } elseif (!in_array($turno, ['manha', 'tarde', 'noite'], true)) {
        $erro = 'Turno invalido.';
    } elseif (!in_array($status, ['ativa', 'encerrada'], true)) {
        $erro = 'Status invalido.';
    } elseif ($capacidade <= 0) {
        $erro = 'A capacidade deve ser maior que zero.';
    } elseif ((int) ($conflito['total'] ?? 0) > 0) {
        $erro = 'Este professor ja possui turma ativa no mesmo turno e periodo.';
    } else {
        try {
            if ($modoEdicao) {
                // Atualiza a turma existente.
                executar(
                    'UPDATE turmas
                     SET id_curso = :id_curso, id_professor = :id_professor, codigo_turma = :codigo_turma,
                         turno = :turno, periodo_letivo = :periodo_letivo,
                         capacidade_maxima = :capacidade_maxima, status = :status
                     WHERE id_turma = :id_turma',
                    [
                        ':id_curso' => $idCurso,
                        ':id_professor' => $idProfessor,
                        ':codigo_turma' => $codigo,
                        ':turno' => $turno,
                        ':periodo_letivo' => $periodo,
                        ':capacidade_maxima' => $capacidade,
                        ':status' => $status,
                        ':id_turma' => $idTurma,
                    ]
                );
                registrarLogSistema('Editou turma');
                $sucesso = 'Turma atualizada com sucesso.';
            } else {
                // Cria uma nova turma vinculada ao curso e professor escolhidos.
                executar(
                    'INSERT INTO turmas (id_curso, id_professor, codigo_turma, turno, periodo_letivo, capacidade_maxima, status)
                     VALUES (:id_curso, :id_professor, :codigo_turma, :turno, :periodo_letivo, :capacidade_maxima, :status)',
                    [
                        ':id_curso' => $idCurso,
                        ':id_professor' => $idProfessor,
                        ':codigo_turma' => $codigo,
                        ':turno' => $turno,
                        ':periodo_letivo' => $periodo,
                        ':capacidade_maxima' => $capacidade,
                        ':status' => $status,
                    ]
                );
                registrarLogSistema('Cadastrou turma');
                $sucesso = 'Turma cadastrada com sucesso.';
            }
        } catch (Throwable $erroBanco) {
            $erro = 'Erro ao salvar turma: ' . $erroBanco->getMessage();
        }
    }
}

// Cursos ativos aparecem no select; em edicao o curso atual tambem aparece mesmo se inativo.
$cursos = buscarTodos('SELECT id_curso, nome FROM cursos WHERE status = "ativo" OR id_curso = :id_curso ORDER BY nome', [
    ':id_curso' => $valores['id_curso'] ?: 0,
]);
// Professores disponiveis para assumir a turma.
$professores = buscarTodos(
    'SELECT p.id_professor, u.nome
     FROM professores p
     JOIN usuarios u ON u.id_usuario = p.id_usuario
     ORDER BY u.nome'
);

$tituloPagina = $modoEdicao ? 'Editar Turma' : 'Nova Turma';
$textoPagina = $modoEdicao ? 'Atualize curso, professor, turno, capacidade ou status da turma.' : 'Crie uma turma vinculando curso e professor.';

appInicio($tituloPagina, 'coordenacao', 'turma_form', '../../');
pageHeading('Cadastro', $tituloPagina, $textoPagina);
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Turma salva', $sucesso); ?><?php endif; ?>

    <!-- Formulario com curso, professor, turno, periodo e capacidade da turma. -->
    <section class="panel">
      <div class="panel-header"><h2>Dados da turma</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field">
            <span>Curso</span>
            <select class="select" name="id_curso" required>
              <option value="">Selecione</option>
              <?php foreach ($cursos as $curso): ?>
                <option value="<?= e($curso['id_curso']) ?>" <?= (int) $valores['id_curso'] === (int) $curso['id_curso'] ? 'selected' : '' ?>><?= e($curso['nome']) ?></option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field">
            <span>Professor</span>
            <select class="select" name="id_professor" required>
              <option value="">Selecione</option>
              <?php foreach ($professores as $professor): ?>
                <option value="<?= e($professor['id_professor']) ?>" <?= (int) $valores['id_professor'] === (int) $professor['id_professor'] ? 'selected' : '' ?>><?= e($professor['nome']) ?></option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field"><span>Codigo da turma</span><input class="control" name="codigo_turma" value="<?= e($valores['codigo_turma']) ?>" placeholder="TI-1A" required></label>
          <label class="field">
            <span>Turno</span>
            <select class="select" name="turno" required>
              <option value="manha" <?= $valores['turno'] === 'manha' ? 'selected' : '' ?>>Manha</option>
              <option value="tarde" <?= $valores['turno'] === 'tarde' ? 'selected' : '' ?>>Tarde</option>
              <option value="noite" <?= $valores['turno'] === 'noite' ? 'selected' : '' ?>>Noite</option>
            </select>
          </label>
          <label class="field"><span>Periodo letivo</span><input class="control" name="periodo_letivo" value="<?= e($valores['periodo_letivo']) ?>" placeholder="2026.1" required></label>
          <label class="field"><span>Capacidade</span><input class="control" name="capacidade_maxima" type="number" min="1" value="<?= e($valores['capacidade_maxima']) ?>" required></label>
          <label class="field">
            <span>Status</span>
            <select class="select" name="status">
              <option value="ativa" <?= $valores['status'] === 'ativa' ? 'selected' : '' ?>>Ativa</option>
              <option value="encerrada" <?= $valores['status'] === 'encerrada' ? 'selected' : '' ?>>Encerrada</option>
            </select>
          </label>
          <div class="actions span-2" style="justify-content:flex-start">
            <button class="btn primary" type="submit"><?= $modoEdicao ? 'Atualizar turma' : 'Salvar turma' ?></button>
            <a class="btn ghost" href="turmas.php">Voltar</a>
          </div>
        </form>
      </div>
    </section>
<?php appFim('../../'); ?>
