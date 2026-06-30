# Banco e Procedures

## Tabelas identificadas

Os scripts SQL disponiveis no workspace contem as seguintes tabelas principais:

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

Alguns scripts possuem procedures em padrao antigo, como:

- `sp_inserir_*`
- `sp_atualizar_*`
- `sp_excluir_*`

O Desktop chama varias procedures no padrao novo:

- `sp_entidade_insert`
- `sp_entidade_update`
- `sp_entidade_delete`

Por isso, o projeto manteve um script auxiliar de procedures alinhado ao C#.

## Correcao aplicada

O arquivo `procedures_para_Atual_conforme_CSharp.sql` foi revisado para ser o script de ajuste das procedures do banco conforme o projeto C#.

O script:

- nao altera tabelas;
- nao altera relacionamentos;
- nao altera dados;
- remove procedures antigas que nao sao usadas pelo Desktop;
- recria as procedures chamadas pelas classes C#;
- mantem os parametros usados pelos metodos `AddWithValue` das classes.

Validacao realizada:

- Procedures encontradas no banco real da homologacao.
- CRUDs principais executaram sem erro de procedure.
- Insert, update, select, select por ID e delete foram testados tecnicamente via classes.

## Script SQL mestre

Durante o congelamento foi definido que o projeto possui duas fontes SQL oficiais no workspace:

1. Estrutura e dados base: `FlowAcademy_php/web-php/database/flow_academy_banco_limpo.sql`
2. Procedures alinhadas ao C#: `procedures_para_Atual_conforme_CSharp.sql`

Ainda falta o grupo exportar ou consolidar um arquivo SQL unico para a banca, contendo estrutura final, dados de demonstracao e procedures alinhadas. Esse ponto permanece como pendencia de congelamento porque nao ha `mysqldump`/cliente MySQL disponivel neste ambiente para gerar automaticamente um dump completo do banco real.

Documento de apoio: `docs/Banco/SCRIPT_SQL_MESTRE.md`.

## Observacoes de homologacao

- Banco usado: `flow_academy`.
- Servidor configurado no Desktop: `10.91.47.67`.
- FKs principais foram conferidas.
- Procedures do Desktop foram validadas por execucao dos CRUDs principais.
- A conta `administrativo@flowacademy.com` nao possui a senha padrao `123456`; isso foi registrado no BUG-001.
