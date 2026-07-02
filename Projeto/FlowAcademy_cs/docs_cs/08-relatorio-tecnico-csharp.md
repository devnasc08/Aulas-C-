# 08 - Relatorio Tecnico CSharp

## Resumo

O modulo C# do Flow Academy e uma aplicacao desktop Windows Forms desenvolvida em .NET 8. Ele acessa o banco MySQL `flow_academy` por meio da biblioteca `MySql.Data`.

O sistema foi estruturado com uma aplicacao de interface (`FlowAcademy`) e uma biblioteca de classes (`FlowAcademyClasses`), mantendo separacao basica entre telas e regras/acesso a dados.

## Tecnologias

- C#.
- .NET 8.
- Windows Forms.
- MySql.Data 8.4.0.
- MySQL/MariaDB.

## Arquitetura

```text
FlowAcademy
    Formularios Windows Forms
    Login
    Dashboard
    Menus por perfil

FlowAcademyClasses
    Banco.cs
    AuthService.cs
    Sessao.cs
    Entidades
    Metodos de CRUD
```

## Pontos fortes

- Separacao entre projeto de telas e projeto de classes.
- Login centralizado.
- Sessao compartilhada via classe `Sessao`.
- Dashboard com menus conforme perfil.
- Uso de MySql.Data.
- Classes para entidades principais.
- Formularios cobrem os principais fluxos do projeto academico.

## Banco de dados

O C# depende do banco `flow_academy` e de procedures para operacoes de CRUD.

Script base:

```text
FlowAcademy_php/banco/Banco_oficial.sql
```

Script auxiliar:

```text
procedures_para_Atual_conforme_CSharp.sql
```

## Seguranca

Medidas existentes:

- Senhas comparadas por hash SHA256.
- Login exige usuario ativo.
- Menus sao filtrados por perfil.

Pontos de atencao:

- Connection string esta fixa no codigo.
- SHA256 puro funciona para compatibilidade com PHP/C#, mas nao e a estrategia ideal para producao.
- Controle de permissao e aplicado principalmente na interface.

## Manutencao

Para manter o projeto:

- Atualizar procedures junto com classes.
- Conferir connection string ao trocar de ambiente.
- Testar formularios apos alteracoes no banco.
- Manter nomes de perfis iguais aos do PHP.
- Evitar criar regras divergentes entre PHP e C#.

## Conclusao tecnica

O modulo C# atende ao objetivo de fornecer uma interface desktop para gestao academica, mantendo compatibilidade com o banco compartilhado e com as principais regras do modulo PHP.
