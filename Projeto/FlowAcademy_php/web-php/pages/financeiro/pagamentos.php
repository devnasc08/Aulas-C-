<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['administrativo', 'admin'], '../../');

// Mantem os pagamentos atrasados atualizados antes da consulta por aluno.
atualizarPagamentosAtrasados();

// Filtros vindos pela URL depois que o usuario escolhe turma e aluno.
$idTurmaSelecionada = (int) getValor('id_turma', 0);
$idAlunoSelecionado = (int) getValor('id_aluno', 0);
$turmas = [];
$alunosMatriculados = [];
$pagamentos = [];
$alunoSelecionado = null;
$totalAberto = 0;
$totalPago = 0;
$erro = '';

// Lista de turmas usada como primeiro filtro da tela financeira.
$turmas = buscarTodos(
    'SELECT t.id_turma, t.codigo_turma, c.nome AS curso
     FROM turmas t
     JOIN cursos c ON c.id_curso = t.id_curso
     WHERE t.status = "ativa"
     ORDER BY c.nome, t.codigo_turma'
);

// Cada opcao de aluno recebe data-turma para o JavaScript filtrar igual nas telas do professor.
$alunosMatriculados = buscarTodos(
    'SELECT m.id_turma, a.id_aluno, a.matricula, u.nome AS aluno, t.codigo_turma, c.nome AS curso
     FROM matriculas m
     JOIN alunos a ON a.id_aluno = m.id_aluno
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     JOIN turmas t ON t.id_turma = m.id_turma
     JOIN cursos c ON c.id_curso = t.id_curso
     WHERE m.status = "ativa" AND t.status = "ativa"
     ORDER BY t.codigo_turma, u.nome'
);

if ($idTurmaSelecionada > 0 && $idAlunoSelecionado > 0) {
    // Valida se o aluno pertence mesmo a turma escolhida antes de mostrar dados financeiros.
    $alunoSelecionado = buscarUm(
        'SELECT a.id_aluno, a.matricula, u.nome AS aluno, t.codigo_turma, c.nome AS curso
         FROM matriculas m
         JOIN alunos a ON a.id_aluno = m.id_aluno
         JOIN usuarios u ON u.id_usuario = a.id_usuario
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE m.id_turma = :id_turma
           AND a.id_aluno = :id_aluno
           AND m.status = "ativa"
         LIMIT 1',
        [
            ':id_turma' => $idTurmaSelecionada,
            ':id_aluno' => $idAlunoSelecionado,
        ]
    );

    if ($alunoSelecionado) {
        // Pagamentos ficam vinculados ao aluno, por isso a busca final usa id_aluno.
        $pagamentos = buscarTodos(
            'SELECT *
             FROM pagamentos
             WHERE id_aluno = :id_aluno
             ORDER BY vencimento DESC, id_pagamento DESC',
            [':id_aluno' => $idAlunoSelecionado]
        );

        $linhaAberto = buscarUm(
            // Soma valores que ainda precisam ser recebidos.
            'SELECT SUM(valor) AS total FROM pagamentos WHERE id_aluno = :id_aluno AND status IN ("pendente", "atrasado")',
            [':id_aluno' => $idAlunoSelecionado]
        );
        $totalAberto = (float) ($linhaAberto['total'] ?? 0);

        $linhaPago = buscarUm(
            // Soma valores ja pagos pelo aluno.
            'SELECT SUM(valor) AS total FROM pagamentos WHERE id_aluno = :id_aluno AND status = "pago"',
            [':id_aluno' => $idAlunoSelecionado]
        );
        $totalPago = (float) ($linhaPago['total'] ?? 0);
    } else {
        $erro = 'O aluno selecionado nao pertence a turma informada.';
    }
}

appInicio('Pagamentos', 'administrativo', 'pagamentos', '../../');
pageHeading('Administrativo', 'Pagamentos', 'Consulta de pagamentos por turma e aluno.', '<a class="btn primary" href="pagamento_form.php">Novo pagamento</a>');
?>
    <?php if ($erro): ?><?php alerta('danger', 'Filtro invalido', $erro); ?><?php endif; ?>

    <!-- Filtro financeiro: primeiro escolhe turma, depois aluno. -->
    <section class="panel">
      <div class="panel-header"><h2>Filtrar aluno</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="get">
          <label class="field span-2">
            <span>Turma</span>
            <select
              class="select"
              name="id_turma"
              id="id_turma_pagamentos"
              data-turma-filter
              data-filter-students="#id_aluno_pagamentos"
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

          <label class="field">
            <span>Buscar aluno</span>
            <input
              class="control"
              type="search"
              placeholder="Nome ou matricula"
              data-student-search="#id_aluno_pagamentos"
              data-turma-source="#id_turma_pagamentos"
            >
          </label>

          <label class="field">
            <span>Aluno</span>
            <select class="select" name="id_aluno" id="id_aluno_pagamentos" required>
              <option value="">Selecione a turma primeiro</option>
              <?php foreach ($alunosMatriculados as $aluno): ?>
                <option
                  value="<?= e($aluno['id_aluno']) ?>"
                  data-turma="<?= e($aluno['id_turma']) ?>"
                  data-search="<?= e($aluno['aluno'] . ' ' . $aluno['matricula']) ?>"
                  <?= $idAlunoSelecionado === (int) $aluno['id_aluno'] && $idTurmaSelecionada === (int) $aluno['id_turma'] ? 'selected' : '' ?>
                >
                  <?= e($aluno['aluno'] . ' - ' . $aluno['matricula']) ?>
                </option>
              <?php endforeach; ?>
            </select>
          </label>

          <div class="actions span-2" style="justify-content:flex-start">
            <button class="btn primary" type="submit">Buscar pagamentos</button>
            <a class="btn ghost" href="pagamentos.php">Limpar filtro</a>
          </div>
        </form>
      </div>
    </section>

    <?php if ($alunoSelecionado): ?>
      <!-- Cards com resumo financeiro do aluno selecionado. -->
      <section class="grid three">
        <article class="card metric-card">
          <div class="metric-label">Aluno</div>
          <div class="metric-value" style="font-size:1.5rem"><?= e($alunoSelecionado['aluno']) ?></div>
          <div class="metric-meta">Matricula <?= e($alunoSelecionado['matricula']) ?></div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Em aberto</div>
          <div class="metric-value"><?= e(moedaBr($totalAberto)) ?></div>
          <div class="metric-meta warning">Pendentes e atrasados</div>
        </article>
        <article class="card metric-card">
          <div class="metric-label">Recebido</div>
          <div class="metric-value"><?= e(moedaBr($totalPago)) ?></div>
          <div class="metric-meta positive">Pagamentos quitados</div>
        </article>
      </section>

      <!-- Tabela com pagamentos encontrados para o aluno. -->
      <section class="panel">
        <div class="panel-header"><h2>Pagamentos do aluno</h2></div>
        <div class="panel-body">
          <p class="muted">Turma <?= e($alunoSelecionado['codigo_turma']) ?> - <?= e($alunoSelecionado['curso']) ?></p>
          <div class="table-wrap">
            <table id="tabela-principal">
              <thead><tr><th>Vencimento</th><th>Valor</th><th>Status</th><th>Acoes</th></tr></thead>
              <tbody>
                <?php foreach ($pagamentos as $pagamento): ?>
                  <tr>
                    <td><?= e(dataBr($pagamento['vencimento'])) ?></td>
                    <td><?= e(moedaBr($pagamento['valor'])) ?></td>
                    <td><?= badge($pagamento['status'], $pagamento['status']) ?></td>
                    <td><a class="btn ghost" href="pagamento_form.php?id=<?= e($pagamento['id_pagamento']) ?>">Editar</a></td>
                  </tr>
                <?php endforeach; ?>
                <?php if (!$pagamentos): ?>
                  <tr><td colspan="4">Nenhum pagamento cadastrado para este aluno.</td></tr>
                <?php endif; ?>
              </tbody>
            </table>
          </div>
        </div>
      </section>
    <?php else: ?>
      <!-- Estado inicial antes da escolha de um aluno. -->
      <section class="panel">
        <div class="panel-header"><h2>Pagamentos do aluno</h2></div>
        <div class="panel-body">
          <?php alerta('warning', 'Selecione um aluno', 'Escolha uma turma e um aluno para visualizar os pagamentos.'); ?>
        </div>
      </section>
    <?php endif; ?>
<?php appFim('../../'); ?>
