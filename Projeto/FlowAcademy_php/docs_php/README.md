# Documentacao - Flow Academy PHP

Esta pasta concentra a documentacao do sistema Flow Academy PHP, desenvolvida para apoiar a entrega, manutencao e apresentacao do Projeto Integrador.

## Indice

- [01 - Visao Geral](01-visao-geral.md)
- [02 - Guia de Instalacao](02-guia-instalacao.md)
- [03 - Arquitetura do Projeto](03-arquitetura.md)
- [04 - Modulos e Perfis de Acesso](04-modulos-perfis.md)
- [05 - Banco de Dados](05-banco-de-dados.md)
- [06 - Regras de Negocio](06-regras-negocio.md)
- [07 - Manual do Usuario](07-manual-usuario.md)
- [08 - Guia Tecnico](08-guia-tecnico.md)
- [09 - Checklist de Entrega](09-checklist-entrega.md)
- [10 - Plano de Testes](10-plano-testes.md)
- [11 - Roteiro de Apresentacao](11-roteiro-apresentacao.md)
- [12 - Guia de Manutencao](12-guia-manutencao.md)
- [13 - Glossario](13-glossario.md)
- [14 - Padrao Bootstrap no PHP](14-padrao-bootstrap.md)

## Resumo rapido

O Flow Academy PHP e um sistema web em PHP puro para gestao academica presencial. Ele organiza usuarios, alunos, professores, cursos, unidades curriculares, turmas, matriculas, notas, frequencia, pagamentos, logs e alertas academicos.

O sistema usa:

- PHP puro.
- MySQL/MariaDB.
- PDO para acesso ao banco.
- Bootstrap local como base obrigatoria de CSS e JavaScript no modulo PHP.
- CSS e JavaScript proprios apenas como complemento do Bootstrap.
- Controle de sessao por perfil.

## Estrutura principal

```text
FlowAcademy_php/
+-- banco/
+-- docs/
+-- scripts/
+-- web-php/
    +-- assets/
    +-- classes/
    +-- config/
    +-- includes/
    +-- pages/
    +-- index.php
    +-- login.php
    +-- logout.php
```
