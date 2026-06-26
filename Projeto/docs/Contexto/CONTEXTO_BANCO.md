# Contexto Banco de Dados

## Banco compartilhado

O banco MySQL e compartilhado entre Desktop e PHP.

O arquivo externo analisado como referencia atual foi `Atual.sql`. Tambem existe no projeto um script auxiliar chamado `procedures_para_Atual_conforme_CSharp.sql`.

## Tabelas identificadas em `Atual.sql`

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

## Relacionamentos principais

- `alunos.id_usuario` referencia `usuarios.id_usuario`
- `professores.id_usuario` referencia `usuarios.id_usuario`
- `disciplinas.id_curso` referencia `cursos.id_curso`
- `turmas.id_curso` referencia `cursos.id_curso`
- `turmas.id_professor` referencia `professores.id_professor`
- `matriculas.id_aluno` referencia `alunos.id_aluno`
- `matriculas.id_turma` referencia `turmas.id_turma`
- `notas.id_matricula` referencia `matriculas.id_matricula`
- `notas.id_disciplina` referencia `disciplinas.id_disciplina`
- `frequencia.id_matricula` referencia `matriculas.id_matricula`
- `frequencia.id_disciplina` referencia `disciplinas.id_disciplina`
- `pagamentos.id_aluno` referencia `alunos.id_aluno`
- `alerta_risco.id_matricula` referencia `matriculas.id_matricula`
- `logs.id_usuario` referencia `usuarios.id_usuario`

## Perfis no banco

O campo `usuarios.perfil` possui os perfis:

- `aluno`
- `professor`
- `coordenacao`
- `administrativo`
- `admin`

O perfil `financeiro` aparece como necessidade do projeto, mas nao foi identificado como valor do enum em `Atual.sql`.

## Procedures

O arquivo `Atual.sql` possui procedures, porem a maioria usa nomes antigos como `sp_inserir_*`, `sp_atualizar_*` e `sp_excluir_*`.

O C# chama principalmente procedures no padrao:

- `sp_entidade_insert`
- `sp_entidade_update`
- `sp_entidade_delete`

Por isso existe divergencia entre o banco analisado e o Desktop.

Na Etapa 5, o script `procedures_para_Atual_conforme_CSharp.sql` foi revisado para alinhar o banco ao Desktop sem alterar tabelas ou dados.

Estado atual:

- `Atual.sql` continua sendo a referencia de estrutura das tabelas.
- `procedures_para_Atual_conforme_CSharp.sql` e o script de ajuste das procedures para o C#.
- O script cria as 34 procedures chamadas pelas classes.
- O script tambem remove procedures antigas do `Atual.sql` que nao sao usadas pelo Desktop.
- A aplicacao em banco MySQL de teste ainda esta pendente.

## Observacao

Nesta etapa nao foram alteradas tabelas ou dados. A alteracao realizada foi somente no script SQL auxiliar de procedures.
