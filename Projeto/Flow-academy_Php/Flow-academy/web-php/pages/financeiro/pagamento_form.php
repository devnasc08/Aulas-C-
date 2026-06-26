<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['administrativo', 'admin'], '../../');

// Atualiza vencidos antes de abrir o formulario.
atualizarPagamentosAtrasados();

// A mesma tela serve para novo pagamento e edicao.
$erro = '';
$sucesso = '';
$idPagamento = (int) getValor('id', 0);
$modoEdicao = $idPagamento > 0;
$pagamento = null;

if ($modoEdicao) {
    // Se veio id pela URL, esta tela abre em modo edicao.
    $pagamento = buscarUm('SELECT * FROM pagamentos WHERE id_pagamento = :id_pagamento', [
        ':id_pagamento' => $idPagamento,
    ]);

    if (!$pagamento) {
        flash('danger', 'Pagamento nao encontrado.');
        redirecionar('dashboard.php');
    }
}

$valores = [
    // Valores usados para preencher o formulario.
    'id_aluno' => $pagamento['id_aluno'] ?? '',
    'valor' => $pagamento['valor'] ?? '',
    'vencimento' => $pagamento['vencimento'] ?? '',
    'status' => $pagamento['status'] ?? 'pendente',
];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Dados da cobranca vinculada a um aluno.
    $idAluno = (int) post('id_aluno');
    $valor = str_replace(',', '.', post('valor'));
    $vencimento = post('vencimento');
    $status = post('status', 'pendente');

    $valores = [
        'id_aluno' => $idAluno,
        'valor' => $valor,
        'vencimento' => $vencimento,
        'status' => $status,
    ];

    if ($idAluno <= 0) {
        // Validacoes simples antes de inserir ou atualizar.
        $erro = 'Selecione um aluno.';
    } elseif (!is_numeric($valor) || (float) $valor <= 0) {
        $erro = 'Informe um valor maior que zero.';
    } elseif ($vencimento === '') {
        $erro = 'Informe a data de vencimento.';
    } elseif (!in_array($status, ['pendente', 'pago', 'atrasado', 'cancelado'], true)) {
        $erro = 'Status invalido.';
    } else {
        // Recalcula o status aberto pela data antes de gravar no banco.
        $status = statusPagamentoPorVencimento($status, $vencimento);
        $valores['status'] = $status;

        if ($modoEdicao) {
            // UPDATE altera o pagamento existente.
            executar(
                'UPDATE pagamentos
                 SET id_aluno = :id_aluno, valor = :valor, vencimento = :vencimento, status = :status
                 WHERE id_pagamento = :id_pagamento',
                [
                    ':id_aluno' => $idAluno,
                    ':valor' => $valor,
                    ':vencimento' => $vencimento,
                    ':status' => $status,
                    ':id_pagamento' => $idPagamento,
                ]
            );
            registrarLogSistema('Editou pagamento');
            $sucesso = 'Pagamento atualizado com sucesso.';
        } else {
            // INSERT cria um novo pagamento na tabela pagamentos.
            executar(
                'INSERT INTO pagamentos (id_aluno, valor, vencimento, status)
                 VALUES (:id_aluno, :valor, :vencimento, :status)',
                [
                    ':id_aluno' => $idAluno,
                    ':valor' => $valor,
                    ':vencimento' => $vencimento,
                    ':status' => $status,
                ]
            );
            registrarLogSistema('Cadastrou pagamento');
            $sucesso = 'Pagamento cadastrado com sucesso.';
        }
    }
}

// Select usado para preencher a lista de alunos no formulario.
$alunos = buscarTodos(
    'SELECT a.id_aluno, a.matricula, u.nome
     FROM alunos a
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     ORDER BY u.nome'
);

$tituloPagina = $modoEdicao ? 'Editar Pagamento' : 'Novo Pagamento';
$textoPagina = $modoEdicao ? 'Atualize aluno, valor, vencimento ou status do pagamento.' : 'Cadastre cobrancas vinculadas ao aluno.';

appInicio($tituloPagina, 'administrativo', 'pagamento_form', '../../');
pageHeading('Administrativo', $tituloPagina, $textoPagina);
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Pagamento salvo', $sucesso); ?><?php endif; ?>

    <!-- Formulario com aluno, valor, vencimento e status do pagamento. -->
    <section class="panel">
      <div class="panel-header"><h2>Dados do pagamento</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field span-2">
            <span>Aluno</span>
            <select class="select" name="id_aluno" required>
              <option value="">Selecione</option>
              <?php foreach ($alunos as $aluno): ?>
                <option value="<?= e($aluno['id_aluno']) ?>" <?= (int) $valores['id_aluno'] === (int) $aluno['id_aluno'] ? 'selected' : '' ?>>
                  <?= e($aluno['nome'] . ' - ' . $aluno['matricula']) ?>
                </option>
              <?php endforeach; ?>
            </select>
          </label>
          <label class="field"><span>Valor</span><input class="control" name="valor" type="number" min="0.01" step="0.01" value="<?= e($valores['valor']) ?>" required></label>
          <label class="field"><span>Vencimento</span><input class="control" name="vencimento" type="date" value="<?= e($valores['vencimento']) ?>" required></label>
          <label class="field">
            <span>Status</span>
            <select class="select" name="status">
              <option value="pendente" <?= $valores['status'] === 'pendente' ? 'selected' : '' ?>>Pendente</option>
              <option value="pago" <?= $valores['status'] === 'pago' ? 'selected' : '' ?>>Pago</option>
              <option value="atrasado" <?= $valores['status'] === 'atrasado' ? 'selected' : '' ?>>Atrasado</option>
              <option value="cancelado" <?= $valores['status'] === 'cancelado' ? 'selected' : '' ?>>Cancelado</option>
            </select>
          </label>
          <div class="actions span-2" style="justify-content:flex-start">
            <button class="btn primary" type="submit"><?= $modoEdicao ? 'Atualizar pagamento' : 'Salvar pagamento' ?></button>
            <a class="btn ghost" href="dashboard.php">Voltar</a>
          </div>
        </form>
      </div>
    </section>
<?php appFim('../../'); ?>
