# 08 - Guia Tecnico

## Padroes do projeto

O projeto usa PHP puro, sem Laravel, Symfony ou outro framework.

Padroes adotados:

- Uma pasta por modulo dentro de `pages`.
- Arquivos compartilhados em `includes`.
- Assets separados por tipo.
- Classes separadas em `models`, `services` e `database`.
- Nomes de formulario no padrao `*_form.php`.
- Listagens no plural, como `alunos.php`, `professores.php`, `cursos.php`.

## Conexao com banco

Arquivo:

```text
web-php/config/config.php
```

A conexao usa PDO:

```php
$pdo = new PDO($dsn, $usuario, $senha, [
    PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
]);
```

## Funcoes auxiliares

Arquivo:

```text
web-php/includes/helpers.php
```

Funcoes principais:

- `e()`: escapa HTML.
- `post()`: le dados de POST.
- `getValor()`: le dados de GET.
- `redirecionar()`: redireciona e encerra execucao.
- `flash()`: grava mensagem temporaria.
- `pegarFlash()`: consome mensagem temporaria.
- `buscarUm()`: busca uma linha.
- `buscarTodos()`: busca varias linhas.
- `executar()`: executa INSERT, UPDATE ou DELETE.
- `gerarHashSenha()`: gera SHA256.
- `senhaConfere()`: compara senha.

## Autenticacao

Arquivo:

```text
web-php/includes/auth.php
```

Funcoes principais:

- `normalizarPerfil()`
- `usuarioLogado()`
- `estaLogado()`
- `paginaInicialPorPerfil()`
- `exigirLogin()`
- `exigirPerfil()`
- `autenticarUsuario()`
- `registrarLogSistema()`
- `fazerLogout()`

## Layout

Arquivo:

```text
web-php/includes/layout.php
```

Funcoes principais:

- `menusDoSistema()`
- `areasVisiveisPorPerfil()`
- `appInicio()`
- `pageHeading()`
- `alerta()`
- `badge()`
- `appFim()`

Cada pagina interna normalmente segue o modelo:

```php
<?php
require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin'], '../../');

appInicio('Titulo', 'area', 'menu_ativo', '../../');
pageHeading('Area', 'Titulo', 'Descricao');
?>

<!-- conteudo da pagina -->

<?php appFim('../../'); ?>
```

## Como criar uma nova pagina

1. Escolha o modulo dentro de `pages`.
2. Crie o arquivo PHP.
3. Inclua `layout.php`.
4. Chame `exigirPerfil()`.
5. Chame `appInicio()`.
6. Escreva o conteudo.
7. Chame `appFim()`.
8. Adicione o link no menu em `menusDoSistema()`, se necessario.

## Como adicionar um asset

Bootstrap CSS obrigatorio, local e na versao 5.0.2:

```text
web-php/assets/bootstrap/css/bootstrap.min.css
```

Bootstrap JS obrigatorio, local e na versao 5.0.2:

```text
web-php/assets/bootstrap/js/bootstrap.bundle.min.js
```

CSS complementar:

```text
web-php/assets/css/
```

JavaScript complementar:

```text
web-php/assets/js/
```

Imagem:

```text
web-php/assets/img/
```

Pasta do Bootstrap local 5.0.2:

```text
web-php/assets/bootstrap/
```

## Observacoes tecnicas

- O PHP principal usa consultas preparadas via PDO.
- O SQL oficial tambem possui procedures e functions armazenadas.
- A aplicacao PHP nao depende obrigatoriamente das procedures para as telas principais.
- O projeto prioriza clareza e compatibilidade com estudantes de curso tecnico.

## Pontos de atencao para manutencao

- Ajustar `config.php` ao ambiente local antes de apresentar.
- Manter apenas um `login.php`.
- Evitar duplicar Bootstrap.
- Manter `main.css` e `app.js` como complementos, nunca como substitutos do Bootstrap.
- Sempre usar `e()` para imprimir dados vindos do banco ou do usuario.
- Sempre usar consultas preparadas para valores informados pelo usuario.
- Conferir caminhos relativos ao mover arquivos.
