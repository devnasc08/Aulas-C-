<?php

require_once __DIR__ . '/includes/auth.php';

// Quem ja estiver logado continua indo direto para o dashboard do proprio perfil.
if (estaLogado()) {
    if (precisaAlterarSenha()) {
        redirecionar('alterar_senha.php');
    }

    redirecionar(paginaInicialPorPerfil(usuarioLogado()['perfil']));
}

// Cursos exibidos na landing page.
// A pagina publica mostra apenas cursos ativos para apresentar a escola ao visitante.
$cursosLanding = [];
$disciplinasPorCurso = [];

try {
    $cursosLanding = buscarTodos(
        'SELECT c.id_curso, c.nome, c.descricao, c.carga_horaria, c.status,
                COUNT(d.id_disciplina) AS total_ucs,
                COALESCE(SUM(d.carga_horaria), 0) AS carga_ucs
         FROM cursos c
         LEFT JOIN disciplinas d ON d.id_curso = c.id_curso
         WHERE c.status = "ativo"
         GROUP BY c.id_curso
         ORDER BY c.nome'
    );

    $disciplinas = buscarTodos(
        'SELECT d.id_curso, d.nome, d.carga_horaria
         FROM disciplinas d
         JOIN cursos c ON c.id_curso = d.id_curso
         WHERE c.status = "ativo"
         ORDER BY d.id_curso, d.nome'
    );

    foreach ($disciplinas as $disciplina) {
        $disciplinasPorCurso[(int) $disciplina['id_curso']][] = $disciplina;
    }
} catch (Throwable $erro) {
    // Se o banco ainda estiver vazio ou indisponivel, a landing continua abrindo.
    $cursosLanding = [];
    $disciplinasPorCurso = [];
}
?>
<!doctype html>
<html lang="pt-BR">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Flow Academy Platform | Gestao Academica Presencial</title>
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link rel="stylesheet" href="assets/css/main.css?v=20260626-landing">
</head>
<body class="landing-page">
  <nav class="navbar navbar-expand-lg landing-nav fixed-top">
    <div class="container">
      <a class="brand landing-brand" href="index.php" aria-label="Flow Academy">
        <img src="assets/images/logo-flow-academy-gold.jpg" alt="Logo Flow Academy">
        <span>
          <strong>Flow Academy</strong>
          <small>Gestao Academica Presencial</small>
        </span>
      </a>

      <button class="navbar-toggler landing-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#menuPrincipal" aria-controls="menuPrincipal" aria-expanded="false" aria-label="Abrir menu">
        <span class="hamburger"><span></span><span></span><span></span></span>
      </button>

      <div class="collapse navbar-collapse" id="menuPrincipal">
        <ul class="navbar-nav ms-auto mb-2 mb-lg-0 landing-menu">
          <li class="nav-item"><a class="nav-link" href="#sobre">Sobre</a></li>
          <li class="nav-item"><a class="nav-link" href="#proposta">Proposta</a></li>
          <li class="nav-item"><a class="nav-link" href="#cursos">Cursos</a></li>
          <li class="nav-item"><a class="nav-link" href="#perfis">Perfis</a></li>
        </ul>
        <a class="btn primary ms-lg-3" href="login.php">Entrar</a>
      </div>
    </div>
  </nav>

  <main>
    <section class="school-hero" id="sobre">
      <div class="container">
        <img class="school-hero-mark" src="assets/images/logo-flow-academy-final.png" alt="Flow Academy">
        <div class="school-hero-content">
          <span class="eyebrow">Escola tecnica presencial</span>
          <h1>Transformando estudantes em profissionais preparados para o mercado de trabalho.</h1>
          <p class="hero-text">Uma escola organizada para cursos tecnicos, com acompanhamento academico, professores conectados as turmas e informacoes claras para cada estudante.</p>
          <div class="actions landing-actions">
            <a class="btn primary" href="#cursos">Conhecer cursos</a>
            <a class="btn ghost" href="login.php">Area do aluno</a>
          </div>
          <div class="school-hero-stats" aria-label="Destaques da escola">
            <div><strong><?= e(count($cursosLanding)) ?></strong><span>Cursos ativos</span></div>
            <div><strong>100%</strong><span>Presencial</span></div>
            <div><strong>5</strong><span>Perfis de acesso</span></div>
          </div>
        </div>
      </div>
    </section>

    <section class="landing-section" id="proposta">
      <div class="container">
        <div class="section-title">
          <span class="eyebrow">O que a Flow representa</span>
          <h2>Uma escola com rotina academica clara e acompanhamento proximo.</h2>
          <p>A Flow Academy organiza a jornada do aluno desde o cadastro ate o acompanhamento de notas, frequencia e situacao academica. A proposta e unir ensino tecnico presencial com uma gestao simples e objetiva.</p>
        </div>

        <div class="row g-3">
          <div class="col-md-4">
            <article class="card landing-card">
              <span class="card-icon">01</span>
              <h3>Formacao tecnica</h3>
              <p>Cursos voltados para desenvolvimento profissional, com unidades curriculares organizadas por carga horaria.</p>
            </article>
          </div>
          <div class="col-md-4">
            <article class="card landing-card">
              <span class="card-icon">02</span>
              <h3>Acompanhamento real</h3>
              <p>Boletim, frequencia, matriculas e informacoes academicas ficam mais faceis de consultar e explicar.</p>
            </article>
          </div>
          <div class="col-md-4">
            <article class="card landing-card">
              <span class="card-icon">03</span>
              <h3>Gestao integrada</h3>
              <p>Coordenacao, administrativo, professores e alunos trabalham com informacoes separadas por perfil.</p>
            </article>
          </div>
        </div>
      </div>
    </section>

    <section class="landing-section soft-section" id="cursos">
      <div class="container">
        <div class="section-title courses-title">
          <span class="eyebrow">Cursos da escola</span>
          <h2>Conheca as formacoes da Flow Academy.</h2>
          <p>Os cursos abaixo são uma porta de entrada para um mundo profissional com foco em tecnologia e inovacao.</p>
        </div>

        <?php if ($cursosLanding): ?>
          <div id="coursesCarousel" class="carousel slide courses-carousel" data-bs-ride="false">
            <?php if (count($cursosLanding) > 1): ?>
              <div class="carousel-indicators courses-indicators">
                <?php foreach ($cursosLanding as $indiceCurso => $cursoIndicador): ?>
                  <button
                    type="button"
                    data-bs-target="#coursesCarousel"
                    data-bs-slide-to="<?= e($indiceCurso) ?>"
                    class="<?= $indiceCurso === 0 ? 'active' : '' ?>"
                    <?= $indiceCurso === 0 ? 'aria-current="true"' : '' ?>
                    aria-label="Curso <?= e($indiceCurso + 1) ?>">
                  </button>
                <?php endforeach; ?>
              </div>
            <?php endif; ?>

            <div class="carousel-inner">
              <?php foreach ($cursosLanding as $indiceCurso => $curso): ?>
                <?php
                  $idCurso = (int) $curso['id_curso'];
                  $ucsCurso = $disciplinasPorCurso[$idCurso] ?? [];
                  $ucsVisiveis = array_slice($ucsCurso, 0, 5);
                ?>
                <div class="carousel-item <?= $indiceCurso === 0 ? 'active' : '' ?>">
                  <article class="card course-card">
                    <div class="course-main">
                      <div class="course-card-head">
                        <span class="badge warning">Curso tecnico</span>
                        <strong><?= e((int) $curso['carga_horaria']) ?>h</strong>
                      </div>
                      <h3><?= e($curso['nome']) ?></h3>
                      <p><?= e($curso['descricao'] ?: 'Curso tecnico presencial com acompanhamento academico pela Flow Academy.') ?></p>
                      <div class="course-meta">
                        <span><?= e((int) $curso['total_ucs']) ?> UCs</span>
                        <span><?= e((int) $curso['carga_ucs']) ?>h em UCs</span>
                        <span><?= e(textoStatus($curso['status'])) ?></span>
                      </div>
                    </div>

                    <div class="course-uc-panel">
                      <h4>Unidades curriculares</h4>
                      <?php if ($ucsVisiveis): ?>
                        <ul class="course-uc-list">
                          <?php foreach ($ucsVisiveis as $uc): ?>
                            <li>
                              <span><?= e($uc['nome']) ?></span>
                              <strong><?= e((int) $uc['carga_horaria']) ?>h</strong>
                            </li>
                          <?php endforeach; ?>
                        </ul>
                      <?php else: ?>
                        <div class="course-empty">Unidades curriculares ainda nao cadastradas.</div>
                      <?php endif; ?>

                      <?php if (count($ucsCurso) > count($ucsVisiveis)): ?>
                        <div class="course-more">+ <?= e(count($ucsCurso) - count($ucsVisiveis)) ?> UCs cadastradas</div>
                      <?php endif; ?>
                    </div>
                  </article>
                </div>
              <?php endforeach; ?>
            </div>

            <?php if (count($cursosLanding) > 1): ?>
              <button class="carousel-control-prev courses-control courses-control-prev" type="button" data-bs-target="#coursesCarousel" data-bs-slide="prev" aria-label="Curso anterior">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              </button>
              <button class="carousel-control-next courses-control courses-control-next" type="button" data-bs-target="#coursesCarousel" data-bs-slide="next" aria-label="Proximo curso">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
              </button>
            <?php endif; ?>
          </div>
        <?php else: ?>
          <div class="course-empty-state">
            <span class="eyebrow">Cursos em cadastro</span>
            <h3>Nenhum curso ativo foi encontrado.</h3>
            <p>Assim que a coordenacao cadastrar cursos ativos, esta secao mostrara nome, descricao, carga horaria e unidades curriculares.</p>
            <a class="btn primary" href="login.php">Entrar no sistema</a>
          </div>
        <?php endif; ?>
      </div>
    </section>

    <section class="landing-section" id="perfis">
      <div class="container">
        <div class="section-title">
          <span class="eyebrow">Acesso por perfil</span>
          <h2>Cada perfil especifico tem seu proprio ambiente.</h2>
        </div>

        <div class="row g-3">
          <div class="col-sm-6 col-lg-3">
            <article class="panel profile-panel">
              <div class="panel-body">
                <span class="badge success">Aluno</span>
                <h3>Vida academica</h3>
                <p class="muted">Consulta de boletim, frequencia e informacoes do proprio curso.</p>
              </div>
            </article>
          </div>
          <div class="col-sm-6 col-lg-3">
            <article class="panel profile-panel">
              <div class="panel-body">
                <span class="badge warning">Professor</span>
                <h3>Turmas e avaliacoes</h3>
                <p class="muted">Lancamento de notas, registro de frequencia e acompanhamento das turmas.</p>
              </div>
            </article>
          </div>
          <div class="col-sm-6 col-lg-3">
            <article class="panel profile-panel">
              <div class="panel-body">
                <span class="badge info">Coordenacao</span>
                <h3>Cursos e turmas</h3>
                <p class="muted">Organizacao dos cursos, unidades curriculares, turmas e professores.</p>
              </div>
            </article>
          </div>
          <div class="col-sm-6 col-lg-3">
            <article class="panel profile-panel">
              <div class="panel-body">
                <span class="badge">Admin</span>
                <h3>Controle do sistema</h3>
                <p class="muted">Apoio aos cadastros, permissoes, logs e operacao institucional.</p>
              </div>
            </article>
          </div>
        </div>
      </div>
    </section>

    <section class="landing-cta">
      <div class="container">
        <div class="cta-box">
          <div>
            <span class="eyebrow">Acesso institucional</span>
            <h2>Acesse o ambiente academico da Flow.</h2>
            <p>Alunos, professores e equipe administrativa entram pela mesma tela de login. O sistema abre automaticamente o painel correto conforme o perfil do usuario.</p>
          </div>
          <a class="btn primary" href="login.php">Acessar login</a>
        </div>
      </div>
    </section>
  </main>

  <footer class="landing-footer">
    <footer class="footer py-4 border-top">
    <div class="container">
        <div class="row text-center text-md-start">

            <div class="col-md-3 mb-3">
                <h5>Flow Academy</h5>
                <p class="mb-0">Flow Academy Platform</p>
            </div>

          

            <div class="col-md-3 mb-3">
                <h5>Endereço</h5>
                <p class="mb-0">
                     Av. Itaquera, 8266<br>
                    Vila Carmosina - São Paulo/SP
                </p>
            </div>

            <div class="col-md-3 mb-3">
                <h5>Contato</h5>
                <p class="mb-0">
                     <a href="tel:+5511915528586"> (11) 91552-8586</a><br>
                   <a href="mailto:contato@flowacademy.com"> contato@flowacademy.com</a>
                       
                    
                </p>
            </div>

        </div>

        <hr>

        <div class="text-center">
            © Projeto Integrador UC16 - Curso Técnico em Informática.
        </div>
    </div>
</footer>

  <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="assets/js/app.js?v=20260616-3"></script>
</body>
</html>
