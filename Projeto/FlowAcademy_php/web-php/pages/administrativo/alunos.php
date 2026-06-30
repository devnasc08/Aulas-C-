<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin', 'administrativo'], '../../');

// Lista alunos juntando dados academicos com dados de usuario.
$alunos = buscarTodos(
    'SELECT a.*, u.nome, u.email
     FROM alunos a
     JOIN usuarios u ON u.id_usuario = a.id_usuario
     ORDER BY u.nome'
);

appInicio('Alunos', 'administrativo', 'alunos', '../../');
pageHeading('Alunos', 'Alunos', 'Consulta de alunos cadastrados.', '<a class="btn primary" href="aluno_form.php">Novo aluno</a>');
?>
    <!-- Tabela pesquisavel de alunos cadastrados. -->
    <section class="panel">
      <div class="panel-header"><h2>Lista de alunos</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Nome</th><th>Matricula</th><th>CPF</th><th>Telefone</th><th>Status</th><th>Acoes</th></tr></thead>
            <tbody>
              <?php foreach ($alunos as $aluno): ?>
                <tr>
                  <td><strong><?= e($aluno['nome']) ?></strong><br><span class="muted"><?= e($aluno['email']) ?></span></td>
                  <td><?= e($aluno['matricula']) ?></td>
                  <td><?= e($aluno['cpf']) ?></td>
                  <td><?= e($aluno['telefone']) ?></td>
                  <td><?= badge($aluno['status_academico'], $aluno['status_academico']) ?></td>
                  <td>
                    <div class="actions" style="justify-content:flex-start">
                      <a class="btn ghost" href="aluno_ver.php?id=<?= e($aluno['id_aluno']) ?>">Ver</a>
                      <a class="btn ghost" href="aluno_form.php?id=<?= e($aluno['id_aluno']) ?>">Editar</a>
                    </div>
                  </td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$alunos): ?>
                <tr><td colspan="6">Nenhum aluno cadastrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
