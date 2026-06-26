<?php

require_once __DIR__ . '/includes/auth.php';

// Quem ja estiver logado continua indo direto para o dashboard do proprio perfil.
if (estaLogado()) {
    if (precisaAlterarSenha()) {
        redirecionar('alterar_senha.php');
    }

    redirecionar(paginaInicialPorPerfil(usuarioLogado()['perfil']));
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
          <li class="nav-item"><a class="nav-link" href="#modulos">Modulos</a></li>
          <li class="nav-item"><a class="nav-link" href="#perfis">Perfis</a></li>
        </ul>
        <a class="btn primary ms-lg-3" href="login.php">Entrar</a>
      </div>
    </div>
  </nav>

  <main>
    <section class="landing-hero" id="sobre">
      <div class="container">
        <div class="row align-items-center g-4">
          <div class="col-lg-6">
            <span class="eyebrow">Projeto Integrador UC16</span>
            <h1>Flow Academy aproxima ensino tecnico, gestao e acompanhamento academico.</h1>
            <p class="hero-text">Uma plataforma feita por estudantes de curso tecnico para organizar cursos presenciais, apoiar professores, acompanhar alunos e facilitar a rotina de uma instituicao de ensino.</p>
            <div class="actions landing-actions">
              <a class="btn primary" href="login.php">Realizar login</a>
              <a class="btn ghost" href="#proposta">Conhecer a Flow</a>
            </div>
            <div class="hero-badges">
              <span class="badge warning">Cursos tecnicos</span>
              <span class="badge success">Acompanhamento academico</span>
              <span class="badge info">Sistema presencial</span>
            </div>
          </div>

          <div class="col-lg-6">
            <div id="landingCarousel" class="carousel slide landing-carousel" data-bs-ride="carousel">
              <div class="carousel-indicators">
                <button type="button" data-bs-target="#landingCarousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Gestao academica"></button>
                <button type="button" data-bs-target="#landingCarousel" data-bs-slide-to="1" aria-label="Cursos tecnicos"></button>
                <button type="button" data-bs-target="#landingCarousel" data-bs-slide-to="2" aria-label="Acompanhamento"></button>
              </div>
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <div class="landing-slide slide-academic">
                    <img src="assets/images/logo-flow-academy-transparent.png" alt="Flow Academy">
                    <div>
                      <strong>Gestao academica integrada</strong>
                      <span>Alunos, professores, cursos, turmas, notas e frequencia em um unico ambiente.</span>
                    </div>
                  </div>
                </div>
                <div class="carousel-item">
                  <div class="landing-slide slide-technical">
                    <img src="assets/images/logo-flow-academy-final.png" alt="Identidade Flow Academy">
                    <div>
                      <strong>Foco em cursos tecnicos presenciais</strong>
                      <span>Organizacao simples para a rotina de aulas, matriculas e acompanhamento pedagogico.</span>
                    </div>
                  </div>
                </div>
                <div class="carousel-item">
                  <div class="landing-slide slide-dashboard">
                    <div class="screen-preview">
                      <span></span>
                      <span></span>
                      <span></span>
                      <span></span>
                    </div>
                    <div>
                      <strong>Informacao clara para cada perfil</strong>
                      <span>Dashboards e telas separadas para aluno, professor, coordenacao, administrativo e admin.</span>
                    </div>
                  </div>
                </div>
              </div>
              <button class="carousel-control-prev" type="button" data-bs-target="#landingCarousel" data-bs-slide="prev" aria-label="Slide anterior">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              </button>
              <button class="carousel-control-next" type="button" data-bs-target="#landingCarousel" data-bs-slide="next" aria-label="Proximo slide">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </section>

    <section class="landing-section" id="proposta">
      <div class="container">
        <div class="section-title">
          <span class="eyebrow">O que a Flow representa</span>
          <h2>Uma experiencia academica organizada, moderna e objetiva.</h2>
          <p>A Flow Academy foi pensada para reduzir planilhas, registros manuais e informacoes espalhadas. A proposta e deixar a operacao de cursos tecnicos mais clara para todos os envolvidos.</p>
        </div>

        <div class="row g-3">
          <div class="col-md-4">
            <article class="card landing-card">
              <span class="card-icon">01</span>
              <h3>Organizacao institucional</h3>
              <p>Cadastros, turmas, matriculas e rotinas academicas ficam concentrados em uma plataforma com visual padronizado.</p>
            </article>
          </div>
          <div class="col-md-4">
            <article class="card landing-card">
              <span class="card-icon">02</span>
              <h3>Apoio ao professor</h3>
              <p>O professor tem acesso direto as turmas vinculadas, com lancamento de notas e controle de frequencia.</p>
            </article>
          </div>
          <div class="col-md-4">
            <article class="card landing-card">
              <span class="card-icon">03</span>
              <h3>Aluno acompanhado</h3>
              <p>O aluno consegue visualizar boletim, frequencia e sua situacao dentro do curso de forma mais transparente.</p>
            </article>
          </div>
        </div>
      </div>
    </section>

    <section class="landing-section soft-section" id="modulos">
      <div class="container">
        <div class="row align-items-center g-4">
          <div class="col-lg-5">
            <span class="eyebrow">Modulos do sistema</span>
            <h2>Estrutura simples para um projeto tecnico realista.</h2>
            <p class="section-note">A plataforma usa PHP, Bootstrap, JavaScript simples e uma identidade visual propria. Cada area tem telas objetivas para sua funcao no ambiente academico.</p>
          </div>
          <div class="col-lg-7">
            <div class="module-list">
              <span>Portal do aluno</span>
              <span>Portal do professor</span>
              <span>Coordenacao</span>
              <span>Administrativo</span>
              <span>Notas e frequencia</span>
              <span>Relatorios e logs</span>
            </div>
          </div>
        </div>
      </div>
    </section>

    <section class="landing-section" id="perfis">
      <div class="container">
        <div class="section-title">
          <span class="eyebrow">Acesso por perfil</span>
          <h2>Cada usuario entra no ambiente que faz sentido para sua rotina.</h2>
        </div>

        <div class="row g-3">
          <div class="col-sm-6 col-lg-3">
            <article class="panel profile-panel">
              <div class="panel-body">
                <span class="badge success">Aluno</span>
                <h3>Boletim e frequencia</h3>
                <p class="muted">Consulta de desempenho, presencas e informacoes do proprio curso.</p>
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
                <h3>Gestao academica</h3>
                <p class="muted">Visao sobre cursos, turmas, professores e indicadores academicos.</p>
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
            <h2>Entre na Flow Academy Platform.</h2>
            <p>O acesso ao sistema e feito pela tela de login, com redirecionamento para o painel correto conforme o perfil do usuario.</p>
          </div>
          <a class="btn primary" href="login.php">Acessar login</a>
        </div>
      </div>
    </section>
  </main>

  <footer class="landing-footer">
    <div class="container">
      <span>Flow Academy Platform</span>
      <span>Projeto Integrador UC16 - Curso Tecnico em Informatica</span>
    </div>
  </footer>

  <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="assets/js/app.js?v=20260616-3"></script>
</body>
</html>
