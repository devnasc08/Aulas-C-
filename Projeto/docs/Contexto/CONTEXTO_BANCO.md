# Contexto Banco de Dados

## Banco compartilhado

O banco MySQL e compartilhado entre Desktop e PHP.

No workspace atual, as referencias SQL principais sao:

- `FlowAcademy_php/web-php/database/flow_academy_banco_limpo.sql`
- `procedures_para_Atual_conforme_CSharp.sql`

O arquivo `Atual.sql` foi usado em etapas anteriores como referencia externa, mas nao esta dentro do workspace atual.

## Tabelas identificadas

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

O perfil `financeiro` aparece como necessidade do projeto, mas nao foi identificado como valor do enum. Desktop e PHP tratam `financeiro` antigo como `administrativo`.

## Procedures

O C# chama procedures no padrao:

- `sp_entidade_insert`
- `sp_entidade_update`
- `sp_entidade_delete`

Tambem existem nomes antigos usados por Pagamento e AlertaRisco:

- `sp_inserir_*`
- `sp_atualizar_*`
- `sp_excluir_*`

Na Etapa 5, o script `procedures_para_Atual_conforme_CSharp.sql` foi revisado para alinhar o banco ao Desktop sem alterar tabelas ou dados.

Estado atual:

- `FlowAcademy_php/web-php/database/flow_academy_banco_limpo.sql` e a referencia de estrutura/dados base disponivel no workspace.
- `procedures_para_Atual_conforme_CSharp.sql` e o script de ajuste das procedures para o C#.
- As procedures foram validadas tecnicamente em banco real durante a homologacao.
- Falta consolidar/exportar um script SQL mestre unico para a banca.

## Observacao

Nesta etapa nao foram alteradas tabelas ou dados. As correcoes de banco ficaram restritas a procedures e documentacao.
