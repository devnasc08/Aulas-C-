# 05 - Banco e Procedures

## Banco compartilhado

O modulo C# usa o mesmo banco do modulo PHP:

```text
flow_academy
```

Script oficial:

```text
FlowAcademy_php/banco/Banco_oficial.sql
```

Script auxiliar de procedures para o C#:

```text
procedures_para_Atual_conforme_CSharp.sql
```

## Conexao

Classe:

```text
FlowAcademyClasses/Banco.cs
```

Metodo:

```csharp
Banco.Abrir()
```

Responsabilidade:

- Criar conexao MySQL.
- Abrir conexao.
- Retornar `MySqlCommand`.

## Uso de procedures

As classes do projeto C# usam stored procedures para operacoes de CRUD em varias entidades.

Exemplos:

- `sp_usuario_insert`
- `sp_usuario_update`
- `sp_usuario_delete`
- `sp_usuario_autenticar`
- `sp_aluno_insert`
- `sp_aluno_update`
- `sp_aluno_delete`
- `sp_professor_insert`
- `sp_curso_insert`
- `sp_disciplina_insert`
- `sp_turma_insert`
- `sp_matricula_insert`
- `sp_nota_insert`
- `sp_frequencia_insert`
- `sp_inserir_pagamento`

## Tabelas principais usadas

- `usuarios`
- `alunos`
- `professores`
- `cursos`
- `disciplinas`
- `turmas`
- `matriculas`
- `notas`
- `frequencia`
- `pagamentos`
- `logs`
- `alerta_risco`

## Compatibilidade com PHP

O PHP executa muitas operacoes com SQL direto via PDO. O C# usa classes e procedures para operacoes equivalentes.

Ambos compartilham:

- Mesmo banco.
- Mesmas tabelas.
- Mesmos perfis.
- Mesmo hash SHA256 de senha.
- Mesmas regras principais de notas, frequencia e matricula.

## Cuidados

- O banco precisa conter as procedures chamadas pelo C#.
- A connection string do C# precisa apontar para o mesmo banco importado.
- Alteracoes no esquema do banco podem exigir ajuste nas classes e formularios.
- Alteracoes nas procedures podem afetar diretamente as telas desktop.

