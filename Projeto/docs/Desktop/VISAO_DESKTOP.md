# Visao Desktop

## Papel do Desktop

O Desktop e o modulo administrativo do Flow Academy.

Ele permite gestao de usuarios, alunos, professores, cursos, disciplinas, turmas, matriculas, notas, frequencias e pagamentos.

## Estrutura

- Projeto de Forms: `FlowAcademy`
- Projeto de classes: `FlowAcademyClasses`

## Consolidacao dos Forms

Na Etapa 4 foram revisados os formularios existentes do modulo Desktop.

Relatorio detalhado: `docs/Desktop/RELATORIO_FORMS_ETAPA4.md`.

Forms ativos identificados apos congelamento:

- `FormLogin`
- `FrmPrincipal`
- `FrmUsuario`
- `FrmAluno`
- `FrmProfessor`
- `FrmCurso`
- `FrmDisciplina`
- `FrmTurma`
- `FrmMatricula`
- `FrmNota`
- `FrmFrequencia`
- `FrmPagamento`
- `FrmFeedback`

Resultado:

- Nao foi encontrado SQL direto nos Forms.
- Eventos de clique sem ligacao foram corrigidos em `FrmFeedback` e `FrmPagamento`.
- Eventos vazios foram removidos de `FormLogin`.
- `FrmPagamento` passou a carregar registro pelo duplo clique no grid.
- `FrmTeste` foi removido na etapa de congelamento.
- Nao existe `FrmAlertaRisco` no projeto Desktop.

## Dashboard

O `FrmPrincipal` foi consolidado como Dashboard Desktop.

Ele possui:

- Menu lateral por perfil.
- Topo com usuario/perfil.
- Painel central para Forms filhos.
- Tela inicial com resumo.
- Botao Sair.
- Normalizacao de `financeiro` para `administrativo`.

Perfis testados na homologacao:

- aluno
- professor
- coordenacao
- administrativo
- financeiro antigo
- admin

## Homologacao

Na homologacao funcional, o Desktop aprovou:

- Login dos perfis principais, com ressalva na conta administrativa documentada.
- Dashboard por perfil.
- Abertura dos Forms pelo painel central.
- CRUDs principais via classes e procedures.
- Fluxo integrado ate pagamento.
- Build final com 0 erros e 0 warnings.

Pendencias:

- Validacao manual de campos vazios, mensagens, logout e refresh visual dos grids.
- Decisao sobre a conta `administrativo@flowacademy.com`.
- Decisao futura sobre `FrmAlertaRisco`.

## Pontos de atencao

- Garantir que nenhum Form acesse banco diretamente.
- Manter documentacao sincronizada com novas correcoes.
- Usar o banco final definido para demonstracao.
- Nao criar novas funcionalidades durante o congelamento sem decisao do grupo.

## Prioridade

Alta. O Desktop e a prioridade principal da estabilizacao.
