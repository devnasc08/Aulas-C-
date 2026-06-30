# Registro de Bugs

## Objetivo

Controlar problemas encontrados durante a homologacao.

## Classificacao

- Critico: impede apresentacao ou fluxo principal.
- Alto: quebra funcionalidade importante.
- Medio: causa erro em situacao especifica.
- Baixo: ajuste visual, texto ou melhoria pequena.

## Status possiveis

- Aberto
- Em correcao
- Corrigido
- Reprovado no reteste
- Fechado
- Nao sera corrigido nesta entrega

## Bugs registrados

| ID | Data | Modulo | Descricao | Passos para reproduzir | Resultado esperado | Resultado obtido | Criticidade | Status | Responsavel |
|---|---|---|---|---|---|---|---|---|---|
| BUG-001 | 30/06/2026 | Login/Banco | A conta documentada `administrativo@flowacademy.com` nao autentica com a senha padrao `123456`. | Tentar login com `administrativo@flowacademy.com` e senha `123456`. | Dashboard abrir com perfil administrativo. | Login invalido; comparacao de hash confirmou que a senha da conta nao corresponde ao padrao. | Medio | Aberto | Grupo Flow Academy |
| BUG-002 | 30/06/2026 | Dashboard Desktop | Perfil `admin` nao exibia os menus Notas e Frequencia, bloqueando parte do fluxo integrado. | Entrar como admin e validar os menus liberados no `FrmPrincipal`. | Admin visualizar Usuarios, Alunos, Professores, Cursos, Disciplinas, Turmas, Matriculas, Notas, Frequencia e Pagamentos. | Notas e Frequencia ficavam ocultos antes da correcao. | Alto | Fechado | Codex |
| BUG-003 | 30/06/2026 | Alerta de Risco/Desktop | Nao existe `FrmAlertaRisco` no projeto Desktop para demonstrar alertas no Dashboard. | Executar o fluxo integrado ate "Verificar alertas". | Abrir tela ou consulta Desktop de alertas, ou registrar regra claramente. | O Form Desktop nao existe. Existe apenas a classe de entidade em `FlowAcademyClasses`. | Medio | Aberto | Grupo Flow Academy |

## Retestes executados

| Bug | Reteste | Resultado |
|---|---|---|
| BUG-001 | Perfil administrativo validado com usuario temporario criado e removido na homologacao. | Perfil aprovado, mas a conta documentada continua aberta para decisao do grupo. |
| BUG-002 | Reexecutados testes de permissao do Dashboard e abertura de Forms. | Aprovado. Admin agora abre `FrmNota` e `FrmFrequencia`. |
| BUG-003 | Revalidada existencia de Forms no projeto Desktop. | Continua aberto; corrigir exigiria criar funcionalidade nova. |

## Observacoes

- O reset da senha de uma conta real nao foi aplicado automaticamente por seguranca. Essa acao deve ser decidida pelo grupo antes da banca.
- BUG-003 nao foi corrigido nesta etapa porque a regra recebida permite apenas bugs, inconsistencias, validacoes e pequenos ajustes; criar um CRUD novo para alertas seria nova funcionalidade.
