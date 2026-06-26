# Auditoria Banco

## O que esta correto

- O banco possui tabelas principais do dominio escolar.
- Existem chaves estrangeiras ligando usuarios, alunos, professores, cursos, turmas, matriculas, notas, frequencia, pagamentos e alertas.
- Existem chaves unicas importantes, como email de usuario, CPF e matricula.
- O banco possui enums para status e perfis.

## O que esta incompleto

- O arquivo `Atual.sql` original nao esta totalmente alinhado com as chamadas do C#.
- O script auxiliar `procedures_para_Atual_conforme_CSharp.sql` foi revisado para alinhar as procedures, mas ainda precisa ser aplicado em banco de teste.
- O perfil `financeiro` nao aparece no enum de usuarios.
- Existe procedure relacionada a feedback, mas a tabela correspondente nao foi confirmada em `Atual.sql`.

## O que precisa ser removido ou revisado

- Procedures antigas foram incluidas no bloco de limpeza do script auxiliar, sem alterar tabelas ou dados.
- Scripts SQL duplicados ou antigos devem ser identificados para evitar uso incorreto.
- Nao se deve alterar tabelas sem decisao formal, pois o usuario pediu foco em procedures em solicitacoes anteriores.

## O que esta duplicado

- Existem scripts SQL diferentes no projeto e fora dele.
- Existem procedures em padroes diferentes: `sp_inserir_*` e `sp_entidade_insert`.

## O que nao segue o padrao

- O padrao definido para procedures e `sp_entidade_insert`, `sp_entidade_update` e `sp_entidade_delete`.
- Em `Atual.sql`, varias procedures usam nomes antigos.
- O Desktop chama procedures que nao existem no `Atual.sql` original analisado.

## Pendencias para proxima etapa

- Definir oficialmente qual SQL e a base final.
- Aplicar `procedures_para_Atual_conforme_CSharp.sql` em banco MySQL de teste.
- Testar os CRUDs do Desktop contra as procedures revisadas.
- Nao alterar estrutura de tabelas sem autorizacao.

## Registro de correcao - Etapa 5

Problema encontrado:

- `Atual.sql` possuia procedures em padrao antigo e nao possuia todas as procedures chamadas pelas classes C#.

Causa:

- O banco e o Desktop evoluiram com nomes diferentes de procedures.

Correcao aplicada:

- Atualizado o script `procedures_para_Atual_conforme_CSharp.sql`.
- Adicionado bloco de limpeza de procedures antigas do `Atual.sql`.
- Mantidas e recriadas as 34 procedures chamadas pelo C#.

Arquivos alterados:

- `procedures_para_Atual_conforme_CSharp.sql`
- `docs/Banco/BANCO_E_PROCEDURES.md`
- `docs/Auditoria/AUDITORIA_BANCO.md`
- `docs/Status/STATUS_GERAL.md`
- `docs/Checklist/CHECKLIST_BANCO.md`
- `docs/Decisoes/DECISOES_ARQUITETURA.md`

Resultado:

- Validacao estatica sem divergencia: 34 procedures chamadas pelo C# e 34 procedures criadas no script.
- Validacao em MySQL real ainda pendente.
- Compilacao da solution concluida com 0 erros. Permanecem 2 warnings antigos em `FrmFeedback.cs`, sem relacao com Banco ou procedures.
