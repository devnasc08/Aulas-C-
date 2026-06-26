# Contexto PHP - Web

## Tecnologias

O modulo Web usa:

- PHP puro
- PDO
- HTML
- CSS
- Bootstrap
- JavaScript

## Estrutura identificada

O PHP esta em:

`Flow-academy_Php/Flow-academy/web-php`

Foram identificados arquivos como:

- `index.php`
- `login.php`
- `logout.php`
- `alterar_senha.php`
- `includes/auth.php`
- `includes/layout.php`
- paginas separadas por perfil
- assets CSS, JS e imagens

## Padrao de acesso ao banco

O PHP usa SQL direto com PDO.

Nao foram identificadas chamadas de procedures no PHP. Isso esta de acordo com a decisao do projeto: procedures sao usadas pelo Desktop para INSERT, UPDATE e DELETE; o PHP usa SQL direto.

## Login e sessao

O PHP possui controle de sessao em `includes/auth.php`.

Foram identificadas regras de:

- login por email e senha
- senha em SHA256
- usuario ativo
- primeiro acesso com `ultimo_login` nulo
- troca de senha
- verificacao de perfil

## Perfis e paginas

Foram identificados perfis principais no PHP:

- aluno
- professor
- coordenacao
- administrativo
- admin

Tambem existe area financeira no PHP, mas ela parece ser acessada por `administrativo` e `admin`, pois o banco nao possui o perfil `financeiro` no enum analisado.

## Estado atual

O PHP esta funcional em estrutura, mas precisa ser revisado apos a estabilizacao do banco e do Desktop para garantir compatibilidade final.

