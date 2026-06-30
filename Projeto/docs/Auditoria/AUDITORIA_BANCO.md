# Auditoria Banco

## O que esta correto

- O banco possui tabelas principais do dominio escolar.
- Existem chaves estrangeiras ligando usuarios, alunos, professores, cursos, turmas, matriculas, notas, frequencia, pagamentos e alertas.
- Existem chaves unicas importantes, como email de usuario, CPF e matricula.
- O banco possui enums para status e perfis.
- Procedures usadas pelo Desktop foram validadas na homologacao tecnica.

## O que esta incompleto

- O projeto ainda precisa de um arquivo SQL mestre unico para a banca.
- O perfil `financeiro` nao aparece no enum de usuarios e e tratado como `administrativo`.
- Existe necessidade de demonstrar ou documentar Alerta de Risco, mas nao ha Form Desktop.
- A conta `administrativo@flowacademy.com` nao usa a senha padrao esperada.

## O que precisa ser removido ou revisado

- Scripts SQL duplicados ou antigos devem ser identificados para evitar uso incorreto.
- Nao se deve alterar tabelas sem decisao formal, pois o usuario pediu foco em procedures em solicitacoes anteriores.
- O banco final de demonstracao deve ser exportado sem dados temporarios da homologacao.

## O que esta duplicado

- Existem scripts SQL diferentes no projeto.
- Existem procedures em padroes diferentes: `sp_inserir_*` e `sp_entidade_insert`.

## O que nao segue o padrao

- O padrao definido para procedures e `sp_entidade_insert`, `sp_entidade_update` e `sp_entidade_delete`, mas Pagamento e AlertaRisco ainda usam nomes antigos no C#.

## Registro de correcao - Procedures

Problema encontrado:

- Scripts anteriores possuiam procedures em padrao antigo e nao cobriam todas as chamadas das classes C#.

Causa:

- O banco e o Desktop evoluiram com nomes diferentes de procedures.

Correcao aplicada:

- Atualizado o script `procedures_para_Atual_conforme_CSharp.sql`.
- Adicionado bloco de limpeza de procedures antigas.
- Mantidas e recriadas as procedures chamadas pelo C#.

Arquivos alterados:

- `procedures_para_Atual_conforme_CSharp.sql`
- `docs/Banco/BANCO_E_PROCEDURES.md`
- `docs/Auditoria/AUDITORIA_BANCO.md`
- `docs/Status/STATUS_GERAL.md`
- `docs/Checklist/CHECKLIST_BANCO.md`
- `docs/Decisoes/DECISOES_ARQUITETURA.md`

Resultado:

- Validacao estatica sem divergencia entre procedures chamadas e script auxiliar.
- Validacao em banco real aprovada durante CRUDs principais.
- Compilacao final da solution: 0 erros e 0 warnings.

## Registro de homologacao

- Banco `flow_academy` acessivel no servidor configurado.
- FKs principais conferidas.
- Inserts, updates, selects, selects por ID e deletes foram executados por classes C#.
- Dados temporarios da homologacao foram removidos ao final do fluxo.

## Pendencias para proxima etapa

- Consolidar/exportar script SQL mestre unico.
- Decidir senha oficial da conta administrativa de demonstracao.
- Testar PHP contra o banco final.
