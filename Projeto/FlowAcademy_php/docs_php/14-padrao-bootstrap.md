# 14 - Padrao Bootstrap no PHP

## Regra principal

O sistema PHP deve usar Bootstrap 5.0.2 local como base obrigatoria de CSS e JavaScript.

Isso significa:

- O CSS principal do framework fica em `web-php/assets/bootstrap/css/bootstrap.min.css`.
- O JavaScript principal do framework fica em `web-php/assets/bootstrap/js/bootstrap.bundle.min.js`.
- A pasta `web-php/assets/bootstrap` deve conter a distribuicao local `bootstrap-5.0.2-dist`.
- O projeto nao deve depender de CDN para Bootstrap.
- O arquivo `main.css` e apenas complemento visual.
- O arquivo `app.js` e apenas complemento de comportamento.

## Ordem correta de carregamento

CSS:

```html
<link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet">
<link rel="stylesheet" href="assets/css/main.css">
```

JavaScript:

```html
<script src="assets/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="assets/js/app.js"></script>
```

## Por que essa ordem importa?

Bootstrap precisa carregar primeiro porque ele fornece a base de componentes, grid, dropdowns, modais e estilos padrao.

Depois disso, o projeto carrega:

- `main.css`, para identidade visual da Flow Academy.
- `app.js`, para filtros, busca, mascara e interacoes especificas.

## Arquivos obrigatorios

```text
web-php/assets/bootstrap/css/bootstrap.min.css
web-php/assets/bootstrap/js/bootstrap.bundle.min.js
```

A pasta tambem pode manter os demais arquivos da distribuicao 5.0.2, como `bootstrap.css`, `bootstrap.min.css.map`, `bootstrap.bundle.js` e seus mapas, porque eles pertencem ao mesmo pacote local do Bootstrap.

## Arquivos complementares

```text
web-php/assets/css/main.css
web-php/assets/js/app.js
```

## Onde o Bootstrap e carregado

Paginas publicas:

- `web-php/index.php`
- `web-php/login.php`
- `web-php/alterar_senha.php`

Paginas internas:

- `web-php/includes/layout.php`

Scripts auxiliares com tela:

- `scripts/instalar_dados_teste.php`

## O que nao fazer

- Nao usar `assets/vendor/bootstrap`.
- Nao usar CDN de Bootstrap.
- Nao duplicar pastas Bootstrap.
- Nao substituir Bootstrap por CSS proprio.
- Nao carregar `app.js` antes do `bootstrap.bundle.min.js`.

## Checklist rapido

- [ ] Existe `assets/bootstrap/css/bootstrap.min.css`.
- [ ] Existe `assets/bootstrap/js/bootstrap.bundle.min.js`.
- [ ] Bootstrap CSS carrega antes de `main.css`.
- [ ] Bootstrap JS carrega antes de `app.js`.
- [ ] Nao ha link para CDN.
- [ ] Nao ha pasta Bootstrap duplicada.
