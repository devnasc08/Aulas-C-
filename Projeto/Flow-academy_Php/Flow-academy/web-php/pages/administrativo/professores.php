<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin'], '../../');

// Apenas admin pode consultar e editar professores.
$professores = buscarTodos(
    'SELECT p.*, u.nome, u.email, u.status AS status_usuario
     FROM professores p
     JOIN usuarios u ON u.id_usuario = p.id_usuario
     ORDER BY u.nome'
);

appInicio('Professores', 'administrativo', 'professores', '../../');
pageHeading('Professores', 'Professores', 'Consulta de professores cadastrados.', '<a class="btn primary" href="professor_form.php">Novo professor</a>');
?>
    <!-- Tabela pesquisavel de professores. -->
    <section class="panel">
      <div class="panel-header"><h2>Lista de professores</h2></div>
      <div class="panel-body">
        <div class="table-wrap">
          <table id="tabela-principal">
            <thead><tr><th>Nome</th><th>CPF</th><th>Especialidade</th><th>Acesso</th><th>Acoes</th></tr></thead>
            <tbody>
              <?php foreach ($professores as $professor): ?>
                <tr>
                  <td><strong><?= e($professor['nome']) ?></strong><br><span class="muted"><?= e($professor['email']) ?></span></td>
                  <td><?= e($professor['cpf']) ?></td>
                  <td><?= e($professor['especialidade']) ?></td>
                  <td><?= badge($professor['status_usuario'], $professor['status_usuario']) ?></td>
                  <td><a class="btn ghost" href="professor_form.php?id=<?= e($professor['id_professor']) ?>">Editar</a></td>
                </tr>
              <?php endforeach; ?>
              <?php if (!$professores): ?>
                <tr><td colspan="5">Nenhum professor cadastrado.</td></tr>
              <?php endif; ?>
            </tbody>
          </table>
        </div>
      </div>
    </section>
<?php appFim('../../'); ?>
