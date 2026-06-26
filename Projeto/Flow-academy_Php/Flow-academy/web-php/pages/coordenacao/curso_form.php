<?php

require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['coordenacao', 'admin'], '../../');

// Formulario usado para cadastrar novo curso ou editar curso existente.
$erro = '';
$sucesso = '';
$idCurso = (int) getValor('id', 0);
$modoEdicao = $idCurso > 0;
$curso = null;
$unidadesCadastradas = [];
$ucEditada = null;

// Se veio id pela URL, a mesma tela funciona como edicao.
if ($modoEdicao) {
    $curso = buscarUm('SELECT * FROM cursos WHERE id_curso = :id_curso', [
        ':id_curso' => $idCurso,
    ]);

    if (!$curso) {
        flash('danger', 'Curso nao encontrado.');
        redirecionar('cursos.php');
    }

    $unidadesCadastradas = buscarTodos(
        // Mostra UCs que ja pertencem ao curso em modo edicao.
        'SELECT * FROM disciplinas WHERE id_curso = :id_curso ORDER BY nome',
        [':id_curso' => $idCurso]
    );
}

// Carrega a UC escolhida no botao Editar e confirma que ela pertence ao curso aberto.
$idUcEdicao = (int) getValor('editar_uc', 0);
if ($modoEdicao && $idUcEdicao > 0) {
    $ucEditada = buscarUm(
        'SELECT *
         FROM disciplinas
         WHERE id_disciplina = :id_disciplina AND id_curso = :id_curso',
        [':id_disciplina' => $idUcEdicao, ':id_curso' => $idCurso]
    );

    if (!$ucEditada) {
        flash('danger', 'Unidade curricular nao encontrada neste curso.');
        redirecionar('curso_form.php?id=' . $idCurso);
    }
}

// Trata a edicao e a remocao das UCs antes do formulario principal do curso.
if ($_SERVER['REQUEST_METHOD'] === 'POST' && post('acao_uc') !== '') {
    $acaoUc = post('acao_uc');
    $idDisciplina = (int) post('id_disciplina');
    $unidade = buscarUm(
        'SELECT *
         FROM disciplinas
         WHERE id_disciplina = :id_disciplina AND id_curso = :id_curso',
        [':id_disciplina' => $idDisciplina, ':id_curso' => $idCurso]
    );

    if (!$modoEdicao || !$unidade) {
        $erro = 'Unidade curricular nao encontrada neste curso.';
    } elseif ($acaoUc === 'atualizar_uc') {
        // Valida os dois dados que pertencem a uma UC antes de atualizar.
        $nomeUc = post('nome_uc');
        $cargaUcTexto = post('carga_horaria_uc');

        if ($nomeUc === '' || !ctype_digit($cargaUcTexto) || (int) $cargaUcTexto <= 0) {
            $erro = 'Informe o nome e uma carga horaria maior que zero para a UC.';
        } else {
            // Impede que a edicao gere duas UCs com o mesmo nome no curso.
            $mesmoNome = buscarUm(
                'SELECT id_disciplina
                 FROM disciplinas
                 WHERE id_curso = :id_curso
                   AND nome = :nome
                   AND id_disciplina <> :id_disciplina',
                [
                    ':id_curso' => $idCurso,
                    ':nome' => $nomeUc,
                    ':id_disciplina' => $idDisciplina,
                ]
            );

            if ($mesmoNome) {
                $erro = 'Ja existe uma unidade curricular com este nome neste curso.';
            } else {
                try {
                    // Atualiza nome e horas diretamente na tabela disciplinas.
                    executar(
                        'UPDATE disciplinas
                         SET nome = :nome, carga_horaria = :carga_horaria
                         WHERE id_disciplina = :id_disciplina AND id_curso = :id_curso',
                        [
                            ':nome' => $nomeUc,
                            ':carga_horaria' => (int) $cargaUcTexto,
                            ':id_disciplina' => $idDisciplina,
                            ':id_curso' => $idCurso,
                        ]
                    );
                    registrarLogSistema('Editou unidade curricular');
                    flash('success', 'Unidade curricular atualizada com sucesso.');
                    redirecionar('curso_form.php?id=' . $idCurso);
                } catch (Throwable $erroBanco) {
                    $erro = 'Nao foi possivel atualizar a unidade curricular.';
                }
            }
        }
    } elseif ($acaoUc === 'remover_uc') {
        // Notas e frequencias dependem da UC; por isso o historico precisa ser preservado.
        $notas = buscarUm(
            'SELECT COUNT(*) AS total FROM notas WHERE id_disciplina = :id_disciplina',
            [':id_disciplina' => $idDisciplina]
        );
        $frequencias = buscarUm(
            'SELECT COUNT(*) AS total FROM frequencia WHERE id_disciplina = :id_disciplina',
            [':id_disciplina' => $idDisciplina]
        );

        if ((int) ($notas['total'] ?? 0) > 0 || (int) ($frequencias['total'] ?? 0) > 0) {
            $erro = 'Esta UC nao pode ser removida porque ja possui notas ou frequencias registradas.';
        } else {
            try {
                // Remove apenas a UC informada e vinculada ao curso atual.
                executar(
                    'DELETE FROM disciplinas
                     WHERE id_disciplina = :id_disciplina AND id_curso = :id_curso',
                    [':id_disciplina' => $idDisciplina, ':id_curso' => $idCurso]
                );
                registrarLogSistema('Removeu unidade curricular');
                flash('success', 'Unidade curricular removida com sucesso.');
                redirecionar('curso_form.php?id=' . $idCurso);
            } catch (Throwable $erroBanco) {
                $erro = 'Nao foi possivel remover a unidade curricular.';
            }
        }
    } else {
        $erro = 'Acao de unidade curricular invalida.';
    }
}

$valores = [
    // Mantem os valores no formulario apos validacao ou carregamento do banco.
    'nome' => $curso['nome'] ?? '',
    'descricao' => $curso['descricao'] ?? '',
    'carga_horaria' => $curso['carga_horaria'] ?? '',
    'status' => $curso['status'] ?? 'ativo',
    // Cada item representa uma linha com nome e carga horaria de uma UC.
    'unidades' => [['nome' => '', 'carga_horaria' => '']],
];

if ($_SERVER['REQUEST_METHOD'] === 'POST' && post('acao_uc') === '') {
    // Dados digitados pelo usuario no formulario.
    $nome = post('nome');
    $descricao = post('descricao');
    $cargaHoraria = (int) post('carga_horaria');
    $status = post('status', 'ativo');
    $nomesUcs = $_POST['uc_nome'] ?? [];
    $cargasUcs = $_POST['uc_carga_horaria'] ?? [];
    $unidades = [];
    $erroUnidades = '';

    // Garante que os campos enviados pelo formulario sejam arrays antes de percorre-los.
    if (!is_array($nomesUcs)) {
        $nomesUcs = [];
    }

    if (!is_array($cargasUcs)) {
        $cargasUcs = [];
    }

    // Mantem ao menos uma linha vazia quando o formulario foi enviado sem UCs.
    $quantidadeLinhas = max(count($nomesUcs), count($cargasUcs), 1);
    $nomesNormalizados = [];

    for ($indice = 0; $indice < $quantidadeLinhas; $indice++) {
        // Le os dois campos da mesma linha: nome da UC e sua carga horaria.
        $nomeUc = trim((string) ($nomesUcs[$indice] ?? ''));
        $cargaUcTexto = trim((string) ($cargasUcs[$indice] ?? ''));
        $unidades[] = ['nome' => $nomeUc, 'carga_horaria' => $cargaUcTexto];

        // Uma linha totalmente vazia e ignorada para permitir adicionar UCs opcionalmente.
        if ($nomeUc === '' && $cargaUcTexto === '') {
            continue;
        }

        // Nome e horas precisam ser informados juntos para formar uma UC valida.
        if ($nomeUc === '' || !ctype_digit($cargaUcTexto) || (int) $cargaUcTexto <= 0) {
            $erroUnidades = 'Informe o nome e uma carga horaria maior que zero para cada UC adicionada.';
            continue;
        }

        // Evita duas UCs com o mesmo nome no mesmo envio do formulario.
        // A alternativa com strtolower mantem o formulario funcional mesmo se
        // a extensao mbstring nao estiver ativa no servidor PHP.
        $nomeNormalizado = function_exists('mb_strtolower')
            ? mb_strtolower($nomeUc, 'UTF-8')
            : strtolower($nomeUc);
        if (in_array($nomeNormalizado, $nomesNormalizados, true)) {
            $erroUnidades = 'Nao adicione a mesma unidade curricular duas vezes.';
            continue;
        }

        $nomesNormalizados[] = $nomeNormalizado;
    }

    $valores = [
        'nome' => $nome,
        'descricao' => $descricao,
        'carga_horaria' => $cargaHoraria,
        'status' => $status,
        'unidades' => $unidades,
    ];

    if ($nome === '') {
        $erro = 'Informe o nome do curso.';
    } elseif ($cargaHoraria <= 0) {
        $erro = 'A carga horaria deve ser maior que zero.';
    } elseif (!in_array($status, ['ativo', 'inativo'], true)) {
        $erro = 'Status invalido.';
    } elseif ($erroUnidades !== '') {
        $erro = $erroUnidades;
    } else {
        // Transacao garante que curso e UCs sejam salvos juntos.
        // Se der erro no meio, o rollback desfaz tudo.
        $pdo->beginTransaction();
        try {
            if ($modoEdicao) {
                executar(
                    'UPDATE cursos
                     SET nome = :nome, descricao = :descricao, carga_horaria = :carga_horaria, status = :status
                     WHERE id_curso = :id_curso',
                    [
                        ':nome' => $nome,
                        ':descricao' => $descricao,
                        ':carga_horaria' => $cargaHoraria,
                        ':status' => $status,
                        ':id_curso' => $idCurso,
                    ]
                );
            } else {
                executar(
                    'INSERT INTO cursos (nome, descricao, carga_horaria, status)
                     VALUES (:nome, :descricao, :carga_horaria, :status)',
                    [
                        ':nome' => $nome,
                        ':descricao' => $descricao,
                        ':carga_horaria' => $cargaHoraria,
                        ':status' => $status,
                    ]
                );

                // Converte o id gerado para inteiro antes de usa-lo nas UCs.
                $idCurso = (int) $pdo->lastInsertId();
            }

            // Confirma que o curso existe antes de salvar as UCs vinculadas a ele.
            $cursoSalvo = buscarUm(
                'SELECT id_curso FROM cursos WHERE id_curso = :id_curso',
                [':id_curso' => $idCurso]
            );

            if (!$cursoSalvo) {
                throw new RuntimeException('Nao foi possivel identificar o curso para vincular as unidades curriculares.');
            }

            // Cada linha valida vira um INSERT na tabela disciplinas.
            foreach ($unidades as $unidade) {
                if ($unidade['nome'] === '' && $unidade['carga_horaria'] === '') {
                    continue;
                }

                executar(
                    'INSERT INTO disciplinas (id_curso, nome, carga_horaria)
                     VALUES (:id_curso, :nome, :carga_horaria)',
                    [
                        ':id_curso' => $idCurso,
                        ':nome' => $unidade['nome'],
                        // Este valor fica salvo no atributo carga_horaria da UC.
                        ':carga_horaria' => (int) $unidade['carga_horaria'],
                    ]
                );
            }

            $pdo->commit();
            registrarLogSistema($modoEdicao ? 'Editou curso' : 'Cadastrou curso');
            $sucesso = $modoEdicao ? 'Curso atualizado com sucesso.' : 'Curso cadastrado com sucesso.';
            $valores['unidades'] = [['nome' => '', 'carga_horaria' => '']];

            if ($modoEdicao) {
                $curso = buscarUm('SELECT * FROM cursos WHERE id_curso = :id_curso', [
                    ':id_curso' => $idCurso,
                ]);
                $unidadesCadastradas = buscarTodos(
                    'SELECT * FROM disciplinas WHERE id_curso = :id_curso ORDER BY nome',
                    [':id_curso' => $idCurso]
                );
                $valores['nome'] = $curso['nome'];
                $valores['descricao'] = $curso['descricao'];
                $valores['carga_horaria'] = $curso['carga_horaria'];
                $valores['status'] = $curso['status'];
            }
        } catch (Throwable $erroBanco) {
            // Em caso de erro, nada fica salvo pela metade.
            $pdo->rollBack();
            $erro = 'Erro ao salvar curso: ' . $erroBanco->getMessage();
        }
    }
}

$tituloPagina = $modoEdicao ? 'Editar Curso' : 'Novo Curso';
$textoPagina = $modoEdicao ? 'Atualize os dados do curso e adicione novas unidades curriculares.' : 'Cadastre o curso e informe a carga horaria de cada unidade curricular.';

appInicio($tituloPagina, 'coordenacao', 'curso_form', '../../');
pageHeading('Cadastro', $tituloPagina, $textoPagina);
?>
    <?php if ($erro): ?><?php alerta('danger', 'Nao foi possivel salvar', $erro); ?><?php endif; ?>
    <?php if ($sucesso): ?><?php alerta('success', 'Curso salvo', $sucesso); ?><?php endif; ?>

    <!-- Formulario principal do curso e das UCs com carga horaria individual. -->
    <section class="panel">
      <div class="panel-header"><h2>Dados do curso</h2></div>
      <div class="panel-body">
        <form class="form-grid" method="post">
          <label class="field span-2"><span>Nome</span><input class="control" name="nome" value="<?= e($valores['nome']) ?>" required></label>
          <label class="field"><span>Carga horaria</span><input class="control" name="carga_horaria" type="number" min="1" value="<?= e($valores['carga_horaria']) ?>" required></label>
          <label class="field">
            <span>Status</span>
            <select class="select" name="status">
              <option value="ativo" <?= $valores['status'] === 'ativo' ? 'selected' : '' ?>>Ativo</option>
              <option value="inativo" <?= $valores['status'] === 'inativo' ? 'selected' : '' ?>>Inativo</option>
            </select>
          </label>
          <label class="field span-2"><span>Descricao</span><textarea class="textarea" name="descricao"><?= e($valores['descricao']) ?></textarea></label>
          <div class="field span-2 uc-editor" data-uc-editor data-uc-template="#modelo-linha-uc">
            <span><?= $modoEdicao ? 'Adicionar novas unidades curriculares' : 'Unidades curriculares' ?></span>
            <div data-uc-list>
              <?php foreach ($valores['unidades'] as $unidade): ?>
                <!-- Cada linha envia o nome e as horas da mesma UC em arrays correspondentes. -->
                <div class="uc-row" data-uc-row>
                  <label class="field"><span>Nome da UC</span><input class="control" name="uc_nome[]" value="<?= e($unidade['nome']) ?>" placeholder="Ex.: Banco de dados"></label>
                  <label class="field"><span>Carga horaria</span><input class="control" name="uc_carga_horaria[]" type="number" min="1" step="1" value="<?= e($unidade['carga_horaria']) ?>" placeholder="Horas"></label>
                  <button class="btn ghost" type="button" data-remove-uc>Remover</button>
                </div>
              <?php endforeach; ?>
            </div>
            <div class="actions" style="justify-content:flex-start"><button class="btn ghost" type="button" data-add-uc>Adicionar UC</button></div>
          </div>
          <div class="actions span-2" style="justify-content:flex-start">
            <button class="btn primary" type="submit"><?= $modoEdicao ? 'Atualizar curso' : 'Salvar curso' ?></button>
            <a class="btn ghost" href="cursos.php">Voltar</a>
          </div>
        </form>
      </div>
    </section>

    <!-- Modelo que o JavaScript usa para criar mais linhas de UC sem recarregar a pagina. -->
    <template id="modelo-linha-uc">
      <div class="uc-row" data-uc-row>
        <label class="field"><span>Nome da UC</span><input class="control" name="uc_nome[]" placeholder="Ex.: Banco de dados"></label>
        <label class="field"><span>Carga horaria</span><input class="control" name="uc_carga_horaria[]" type="number" min="1" step="1" placeholder="Horas"></label>
        <button class="btn ghost" type="button" data-remove-uc>Remover</button>
      </div>
    </template>

    <?php if ($modoEdicao): ?>
      <?php if ($ucEditada): ?>
        <!-- Formulario exclusivo da UC selecionada pelo botao Editar. -->
        <section class="panel">
          <div class="panel-header"><h2>Editar unidade curricular</h2></div>
          <div class="panel-body">
            <form class="form-grid" method="post">
              <input type="hidden" name="acao_uc" value="atualizar_uc">
              <input type="hidden" name="id_disciplina" value="<?= e($ucEditada['id_disciplina']) ?>">
              <label class="field"><span>Nome da UC</span><input class="control" name="nome_uc" value="<?= e($ucEditada['nome']) ?>" required></label>
              <label class="field"><span>Carga horaria</span><input class="control" name="carga_horaria_uc" type="number" min="1" step="1" value="<?= e($ucEditada['carga_horaria']) ?>" required></label>
              <div class="actions span-2" style="justify-content:flex-start">
                <button class="btn primary" type="submit">Salvar UC</button>
                <a class="btn ghost" href="curso_form.php?id=<?= e($idCurso) ?>">Cancelar</a>
              </div>
            </form>
          </div>
        </section>
      <?php endif; ?>

      <!-- Lista de UCs ja salvas para facilitar conferencia durante a edicao. -->
      <section class="panel">
        <div class="panel-header"><h2>Unidades curriculares cadastradas</h2></div>
        <div class="panel-body">
          <div class="table-wrap">
            <table>
              <thead><tr><th>UC</th><th>Carga horaria</th><th>Acoes</th></tr></thead>
              <tbody>
                <?php foreach ($unidadesCadastradas as $unidade): ?>
                  <tr>
                    <td><strong><?= e($unidade['nome']) ?></strong></td>
                    <td><?= e($unidade['carga_horaria']) ?>h</td>
                    <td>
                      <div class="actions table-actions">
                        <a class="btn ghost" href="curso_form.php?id=<?= e($idCurso) ?>&editar_uc=<?= e($unidade['id_disciplina']) ?>">Editar</a>
                        <!-- O form separado envia somente a acao e o id da UC que deve ser removida. -->
                        <form method="post" onsubmit="return confirm('Remover esta unidade curricular?');">
                          <input type="hidden" name="acao_uc" value="remover_uc">
                          <input type="hidden" name="id_disciplina" value="<?= e($unidade['id_disciplina']) ?>">
                          <button class="btn danger" type="submit">Remover</button>
                        </form>
                      </div>
                    </td>
                  </tr>
                <?php endforeach; ?>
                <?php if (!$unidadesCadastradas): ?>
                  <tr><td colspan="3">Nenhuma UC cadastrada.</td></tr>
                <?php endif; ?>
              </tbody>
            </table>
          </div>
        </div>
      </section>
    <?php endif; ?>
<?php appFim('../../'); ?>
