# 12 - Guia de Manutencao

## Objetivo

Este guia orienta futuras alteracoes no Flow Academy PHP sem quebrar a estrutura atual.

## Cuidados antes de alterar

Antes de modificar o projeto:

1. Fazer backup da pasta.
2. Fazer backup do banco.
3. Anotar qual arquivo sera alterado.
4. Testar a tela antes e depois.
5. Conferir caminhos relativos.

## Como alterar conexao com banco

Arquivo:

```text
web-php/config/config.php
```

Campos que normalmente mudam:

```php
$host = 'localhost';
$dbname = 'flow_academy';
$usuario = 'root';
$senha = '';
```

Ao mudar o computador, este e o primeiro arquivo a conferir.

## Como adicionar um novo perfil

Passos:

1. Alterar o ENUM `perfil` na tabela `usuarios`.
2. Criar pasta em `web-php/pages`, se necessario.
3. Adicionar dashboard do perfil.
4. Atualizar `paginaInicialPorPerfil()` em `includes/auth.php`.
5. Atualizar `menusDoSistema()` em `includes/layout.php`.
6. Usar `exigirPerfil()` nas novas paginas.
7. Testar login e permissao.

## Como adicionar uma nova pagina

Modelo base:

```php
<?php
require_once __DIR__ . '/../../includes/layout.php';

exigirPerfil(['admin'], '../../');

appInicio('Titulo', 'admin', 'dashboard', '../../');
pageHeading('Area', 'Titulo', 'Descricao da pagina.');
?>

<section class="panel">
  <div class="panel-header"><h2>Conteudo</h2></div>
  <div class="panel-body">
    <p class="muted">Nova pagina.</p>
  </div>
</section>

<?php appFim('../../'); ?>
```

Depois:

- Adicionar link no menu, se for tela navegavel.
- Conferir se CSS e JS carregam.
- Conferir permissao.

## Como adicionar item ao menu

Arquivo:

```text
web-php/includes/layout.php
```

Funcao:

```php
menusDoSistema()
```

Exemplo:

```php
'nova_pagina' => [
    'texto' => 'Nova Pagina',
    'href' => 'pages/admin/nova_pagina.php',
],
```

## Como criar novo formulario

Padrao recomendado:

- Nome do arquivo: `entidade_form.php`.
- Listagem: `entidades.php`.
- Validar campos obrigatorios.
- Usar `post()` para ler formulario.
- Usar `executar()` para salvar.
- Usar `flash()` para mensagem.
- Usar `redirecionar()` quando necessario.

## Como criar nova consulta

Use `buscarUm()` quando espera apenas um registro:

```php
$aluno = buscarUm('SELECT * FROM alunos WHERE id_aluno = :id', [
    ':id' => $idAluno,
]);
```

Use `buscarTodos()` quando espera lista:

```php
$alunos = buscarTodos('SELECT * FROM alunos ORDER BY id_aluno DESC');
```

## Como imprimir dados com seguranca

Sempre use:

```php
<?= e($valor) ?>
```

Evite:

```php
<?= $valor ?>
```

## Como adicionar JavaScript

O sistema PHP usa Bootstrap 5.0.2 local como base de JavaScript:

```text
web-php/assets/bootstrap/js/bootstrap.bundle.min.js
```

Arquivo complementar recomendado:

```text
web-php/assets/js/app.js
```

Use `app.js` apenas para comportamentos especificos do projeto, como filtro de tabela, mascara e busca. Evite criar varios arquivos JS pequenos sem necessidade.

## Como adicionar CSS

O sistema PHP usa Bootstrap 5.0.2 local como base de CSS:

```text
web-php/assets/bootstrap/css/bootstrap.min.css
```

Arquivo complementar recomendado:

```text
web-php/assets/css/main.css
```

Use `main.css` apenas para identidade visual e ajustes especificos. Mantenha o Bootstrap separado em:

```text
web-php/assets/bootstrap
```

## Como adicionar imagem

Use:

```text
web-php/assets/img/
```

Subpastas sugeridas:

- `logos`
- `usuarios`
- `icones`
- `backgrounds`

## Como testar depois de alterar

Checklist minimo:

- Login.
- Logout.
- Dashboard do perfil alterado.
- Menu.
- Tela alterada.
- Salvamento no banco.
- Mensagens de erro e sucesso.
- Permissao de acesso.

## Erros comuns

### Caminho relativo quebrado

Sintoma:

- CSS nao carrega.
- Include falha.
- Imagem nao aparece.

Solucao:

- Conferir o prefixo usado em `appInicio()` e `appFim()`.
- Em paginas dentro de `pages/modulo`, normalmente o prefixo e `../../`.

### Funcao duplicada

Sintoma:

- Erro `Cannot redeclare function`.

Solucao:

- Usar `require_once`.
- Evitar declarar a mesma funcao em mais de um include.

### Classe nao encontrada

Sintoma:

- Erro `Class not found`.

Solucao:

- Incluir o model ou service com `require_once`.
- Conferir se o arquivo esta em `classes/models` ou `classes/services`.

### Banco nao conecta

Sintoma:

- Mensagem `Erro ao conectar com o banco de dados`.

Solucao:

- Conferir MySQL.
- Conferir `config.php`.
- Conferir se o banco foi importado.
