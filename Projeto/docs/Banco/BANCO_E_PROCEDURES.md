# Banco e Procedures

## Tabelas identificadas

O arquivo `Atual.sql` contem as seguintes tabelas principais:

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
- `alerta_risco`
- `logs`

## Ordem recomendada de criacao

1. `usuarios`
2. `cursos`
3. `alunos`
4. `professores`
5. `disciplinas`
6. `turmas`
7. `matriculas`
8. `notas`
9. `frequencia`
10. `pagamentos`
11. `alerta_risco`
12. `logs`

## Ordem recomendada de uso

1. Cadastrar usuario.
2. Cadastrar aluno ou professor vinculado ao usuario.
3. Cadastrar curso.
4. Cadastrar disciplina vinculada ao curso.
5. Cadastrar turma vinculada ao curso e professor.
6. Matricular aluno em turma.
7. Lancar notas e frequencias.
8. Registrar pagamentos.
9. Gerar ou analisar alertas de risco.
10. Consultar logs.

## Procedures chamadas pelo C#

Foram identificadas chamadas C# para procedures como:

- `sp_usuario_insert`
- `sp_usuario_update`
- `sp_usuario_delete`
- `sp_usuario_autenticar`
- `sp_aluno_insert`
- `sp_aluno_update`
- `sp_aluno_delete`
- `sp_professor_insert`
- `sp_professor_update`
- `sp_professor_delete`
- `sp_curso_insert`
- `sp_curso_update`
- `sp_curso_delete`
- `sp_disciplina_insert`
- `sp_disciplina_update`
- `sp_disciplina_delete`
- `sp_turma_insert`
- `sp_turma_update`
- `sp_turma_delete`
- `sp_matricula_insert`
- `sp_matricula_update`
- `sp_matricula_delete`
- `sp_nota_insert`
- `sp_nota_update`
- `sp_nota_delete`
- `sp_frequencia_insert`
- `sp_frequencia_update`
- `sp_frequencia_delete`
- `sp_inserir_pagamento`
- `sp_atualizar_pagamento`
- `sp_excluir_pagamento`
- `sp_inserir_alerta_risco`
- `sp_atualizar_alerta_risco`
- `sp_excluir_alerta_risco`

## Divergencia encontrada na auditoria

O arquivo `Atual.sql` possui varias procedures em padrao antigo, como:

- `sp_inserir_*`
- `sp_atualizar_*`
- `sp_excluir_*`

O Desktop chama varias procedures no padrao novo:

- `sp_entidade_insert`
- `sp_entidade_update`
- `sp_entidade_delete`

Por isso, o banco e o C# ainda nao estao totalmente alinhados.

## Correcao aplicada na Etapa 5

O arquivo `procedures_para_Atual_conforme_CSharp.sql` foi revisado para ser o script de ajuste das procedures do banco conforme o projeto C#.

O script agora:

- nao altera tabelas;
- nao altera relacionamentos;
- nao altera dados;
- remove procedures antigas do `Atual.sql` que nao sao usadas pelo Desktop;
- recria as 34 procedures chamadas pelas classes C#;
- mantem os parametros usados pelos metodos `AddWithValue` das classes.

Validacao estatica realizada:

- 34 procedures chamadas pelo C#.
- 34 procedures criadas no script auxiliar.
- Nenhuma procedure chamada pelo C# ficou ausente no script.

## Procedures que faltavam em `Atual.sql` para o C#

Foram identificadas como faltantes no script analisado:

- Procedures de usuario no padrao do C#.
- Procedures de aluno no padrao do C#.
- Procedures de professor no padrao do C#.
- Procedures de curso no padrao do C#.
- Procedures de disciplina no padrao do C#.
- Procedures de turma no padrao do C#.
- Procedures de matricula no padrao do C#.
- Procedures de nota no padrao do C#.
- Procedures de frequencia no padrao do C#.

## Observacao sobre script auxiliar

Existe no projeto um arquivo chamado `procedures_para_Atual_conforme_CSharp.sql`, que foi revisado na Etapa 5 para alinhar procedures ao C#.

Ainda falta aplicar esse script em um banco MySQL de teste para validar execucao real. Ate esta etapa, a validacao foi estatica, por leitura dos arquivos e comparacao entre C# e SQL.
