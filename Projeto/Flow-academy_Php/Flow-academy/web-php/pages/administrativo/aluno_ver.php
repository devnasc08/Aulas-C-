<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin', 'administrativo'], '../../');

// Perfil detalhado do aluno selecionado pela URL.
$idAluno = (int) getValor('id', 0);

if ($idAluno <= 0) {
    // Se nenhum id for enviado, abre o aluno mais recente como apoio.
    $primeiro = buscarUm('SELECT id_aluno FROM alunos ORDER BY id_aluno DESC LIMIT 1');
    $idAluno = (int) ($primeiro['id_aluno'] ?? 0);
}

$aluno = $idAluno > 0 ? buscarUm(
    'SELECT a.*, u.nome, u.email, u.status AS status_usuario, u.ultimo_login
     FROM alunos a
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     WHERE a.id_aluno = :id_aluno',
    [':id_aluno' => $idAluno]
) : null;

$matriculas = [];
$pagamentos = [];

if ($aluno) {
    // Historico de matriculas do aluno.
    $matriculas = buscarTodos(
        'SELECT m.*, t.codigo_turma, c.nome AS curso
         FROM matriculas m
         JOIN turmas t ON t.id_turma = m.id_turma
         JOIN cursos c ON c.id_curso = t.id_curso
         WHERE m.id_aluno = :id_aluno
         ORDER BY m.data_matricula DESC',
        [':id_aluno' => $idAluno]
    );

    // Historico financeiro do aluno.
    $pagamentos = buscarTodos(
        'SELECT * FROM pagamentos WHERE id_aluno = :id_aluno ORDER BY vencimento DESC',
        [':id_aluno' => $idAluno]
    );
}

appInicio('Perfil do Aluno', 'administrativo', 'alunos', '../../');
pageHeading('Aluno', 'Perfil do Aluno', 'Visualizacao completa dos dados principais do aluno.');
?>
    <?php if (!$aluno): ?>
      <?php alerta('warning', 'Nenhum aluno encontrado', 'Cadastre um aluno para visualizar o perfil.'); ?>
    <?php else: ?>
      <!-- Resumo de dados pessoais e pagamentos em duas colunas. -->
      <section class="grid two">
        <article class="panel">
          <div class="panel-header"><h2>Dados pessoais</h2></div>
          <div class="panel-body">
            <div class="info-list">
              <div><span>Nome</span><strong><?= e($aluno['nome']) ?></strong></div>
              <div><span>E-mail</span><strong><?= e($aluno['email']) ?></strong></div>
              <div><span>Matricula</span><strong><?= e($aluno['matricula']) ?></strong></div>
              <div><span>CPF</span><strong><?= e($aluno['cpf']) ?></strong></div>
              <div><span>Telefone</span><strong><?= e($aluno['telefone']) ?></strong></div>
              <div><span>Status academico</span><strong><?= badge($aluno['status_academico'], $aluno['status_academico']) ?></strong></div>
            </div>
          </div>
        </article>

        <article class="panel">
          <div class="panel-header"><h2>Pagamentos</h2></div>
          <div class="panel-body">
            <div class="table-wrap">
              <table>
                <thead><tr><th>Vencimento</th><th>Valor</th><th>Status</th></tr></thead>
                <tbody>
                  <?php foreach ($pagamentos as $pagamento): ?>
                    <tr><td><?= e(dataBr($pagamento['vencimento'])) ?></td><td><?= e(moedaBr($pagamento['valor'])) ?></td><td><?= badge($pagamento['status'], $pagamento['status']) ?></td></tr>
                  <?php endforeach; ?>
                  <?php if (!$pagamentos): ?><tr><td colspan="3">Sem pagamentos.</td></tr><?php endif; ?>
                </tbody>
              </table>
            </div>
          </div>
        </article>
      </section>

      <!-- Historico de matriculas do aluno. -->
      <section class="panel">
        <div class="panel-header"><h2>Matriculas</h2></div>
        <div class="panel-body">
          <div class="table-wrap">
            <table id="tabela-principal">
              <thead><tr><th>Curso</th><th>Turma</th><th>Data</th><th>Status</th></tr></thead>
              <tbody>
                <?php foreach ($matriculas as $matricula): ?>
                  <tr><td><?= e($matricula['curso']) ?></td><td><strong><?= e($matricula['codigo_turma']) ?></strong></td><td><?= e(dataBr($matricula['data_matricula'])) ?></td><td><?= badge($matricula['status'], $matricula['status']) ?></td></tr>
                <?php endforeach; ?>
                <?php if (!$matriculas): ?><tr><td colspan="4">Sem matriculas.</td></tr><?php endif; ?>
              </tbody>
            </table>
          </div>
        </div>
      </section>
    <?php endif; ?>
<?php appFim('../../'); ?>
