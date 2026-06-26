# Visao de Arquitetura

## Modelo adotado

O Flow Academy usa arquitetura simples e didatica, adequada ao curso tecnico:

- Desktop Windows Forms para administracao.
- PHP puro para acesso Web.
- Banco MySQL compartilhado.

## Separacao de responsabilidades

Desktop:

- Forms controlam interface.
- Classes concentram regras e acesso ao banco.
- `Banco.cs` centraliza conexao.

PHP:

- Includes centralizam conexao, autenticacao e layout.
- Paginas executam consultas SQL diretas.

Banco:

- Guarda dados compartilhados.
- Possui tabelas, relacionamentos, constraints e procedures.

## Restricoes arquiteturais

Nao usar:

- Repository
- Dependency Injection
- Entity Framework
- Dapper
- Padroes avancados

## Direcao

A arquitetura deve continuar simples, consistente e facil de apresentar.

