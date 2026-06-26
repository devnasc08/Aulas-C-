# Contexto C# - Desktop

## Tecnologias

O modulo Desktop foi desenvolvido com:

- Windows Forms
- C#
- .NET Framework
- MySql.Data

## Organizacao

O projeto C# esta dividido em:

- `FlowAcademy`: formularios Windows Forms.
- `FlowAcademyClasses`: classes de entidade, regras simples e acesso ao banco.

## Fluxo padrao

O fluxo adotado no Desktop e:

Forms

Classes

Banco.cs

MySQL

Nenhum formulario deve acessar o banco diretamente. O acesso deve passar pelas classes.

## Padrao das classes

O padrao definido para as entidades e:

- Construtores
- `Inserir()`
- `Atualizar()`
- `Excluir()`
- `ObterLista()`
- `ObterPorId()`
- `MontarObjeto()`

O metodo `MontarObjeto()` deve ser privado e usado internamente para montar objetos a partir do `MySqlDataReader`.

## Padrao de banco no C#

- INSERT usa procedure.
- UPDATE usa procedure.
- DELETE usa procedure.
- SELECT usa SQL direto.
- SELECT POR ID usa SQL direto.

Esse padrao aparece na maior parte das classes, mas ainda ha pontos a corrigir em etapa posterior.

## Classes identificadas

Foram identificadas classes para:

- Usuario
- Aluno
- Professor
- Curso
- Disciplina
- Turma
- Matricula
- Frequencia
- Nota
- Pagamento
- AlertaRisco
- AuthService
- Sessao
- Banco

## Pontos importantes

- `Banco.cs` centraliza a conexao MySQL.
- `Sessao.cs` guarda usuario logado e nivel de acesso.
- `AuthService.cs` trata login, logout e hash de senha.
- Algumas classes ainda possuem `MontarObjeto()` publico ou ausente.
- Pagamento e AlertaRisco usam nomes antigos de procedures.
- O build anterior nao confirmou erros de C#, mas houve falha relacionada a consulta de vulnerabilidades do NuGet.

