# Documentacao - Flow Academy CSharp

Esta pasta documenta o modulo desktop do Flow Academy, desenvolvido em C# com Windows Forms.

## Indice

- [01 - Visao Geral CSharp](01-visao-geral-csharp.md)
- [02 - Guia de Instalacao e Build](02-guia-instalacao-build.md)
- [03 - Arquitetura Desktop](03-arquitetura-desktop.md)
- [04 - Formularios e Modulos](04-formularios-modulos.md)
- [05 - Banco e Procedures](05-banco-procedures.md)
- [06 - Manual do Usuario Desktop](06-manual-usuario-desktop.md)
- [07 - Plano de Testes Desktop](07-plano-testes-desktop.md)
- [08 - Relatorio Tecnico CSharp](08-relatorio-tecnico-csharp.md)

## Resumo

O modulo C# e uma aplicacao desktop Windows Forms para acesso administrativo e operacional ao banco `flow_academy`.

Ele compartilha o mesmo banco do modulo PHP e usa:

- .NET 8.
- Windows Forms.
- MySql.Data 8.4.0.
- Projeto de classes separado em `FlowAcademyClasses`.
- Stored procedures e consultas SQL para operacoes no banco.

## Estrutura principal

```text
FlowAcademy_cs/
+-- FlowAcademy.sln
+-- FlowAcademy/
|   +-- Program.cs
|   +-- FormLogin.cs
|   +-- FrmPrincipal.cs
|   +-- FrmAluno.cs
|   +-- FrmProfessor.cs
|   +-- FrmCurso.cs
|   +-- FrmDisciplina.cs
|   +-- FrmTurma.cs
|   +-- FrmMatricula.cs
|   +-- FrmNota.cs
|   +-- FrmFrequencia.cs
|   +-- FrmPagamento.cs
|   +-- FrmBoletimAluno.cs
|   +-- FrmFrequenciaAluno.cs
|   +-- FrmFuncionarios.cs
|   +-- FrmPrimeiroAcesso.cs
+-- FlowAcademyClasses/
    +-- Banco.cs
    +-- AuthService.cs
    +-- Sessao.cs
    +-- Usuario.cs
    +-- Aluno.cs
    +-- Professor.cs
    +-- Curso.cs
    +-- Disciplina.cs
    +-- Turma.cs
    +-- Matricula.cs
    +-- Nota.cs
    +-- Frequencia.cs
    +-- Pagamento.cs
    +-- AlertaRisco.cs
```

