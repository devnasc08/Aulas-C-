# Auditoria C# - Desktop

## O que esta correto

- O projeto possui separacao entre Forms e classes.
- As classes estao concentradas em `FlowAcademyClasses`.
- A maioria das entidades possui metodos de CRUD.
- O acesso ao banco passa por `Banco.cs`.
- Os formularios analisados nao apresentaram SQL direto em verificacao estatica.
- Na Etapa 4, os eventos principais dos formularios CRUD foram conferidos contra os arquivos Designer.
- `FormLogin`, `FrmFeedback`, `FrmPagamento` e `FrmTeste` foram ajustados sem alterar regras de negocio.
- Na Etapa 5, `FrmPrincipal` foi transformado no Dashboard Desktop com menu por perfil.
- `Sessao.cs` centraliza dados basicos do usuario logado.
- `AuthService.cs` concentra login, logout e senha.
- Na homologacao, os CRUDs principais executaram contra banco real pelas classes.

## O que esta incompleto

- Pagamento e AlertaRisco ainda usam nomes de procedures antigos em algumas partes do codigo.
- Nem todas as classes seguem o padrao de `MontarObjeto()` privado.
- Nao existe `FrmAlertaRisco` no projeto de Forms.
- `FrmPagamento` ainda usa campo de texto para informar o ID do aluno; futuramente pode ser avaliado ComboBox, sem alterar regra nesta etapa.
- Testes visuais de mensagens, limpeza de tela, logout e refresh de grid ainda precisam ser feitos manualmente.

## O que foi removido ou revisado

- `FrmTeste` foi removido na etapa de congelamento.
- O arquivo vazio `FlowAcademy/AlertaRisco.cs` foi removido para evitar confusao com a entidade `FlowAcademyClasses/AlertaRisco.cs`.
- A pasta temporaria de runner de homologacao foi removida.
- Arquivos compactados dentro de pastas do projeto ainda devem ser avaliados antes da entrega final.

## O que esta duplicado

- Algumas regras de negocio aparecem tambem no PHP, como notas, frequencia, pagamentos e alerta de risco.
- Existem nomes de procedures em padroes diferentes entre banco e C#.

## O que nao segue o padrao

- `MontarObjeto()` aparece publico em algumas classes.
- Pagamento e AlertaRisco usam procedures com nomes antigos.

## Etapa 4 - Consolidacao dos Forms

### Problemas encontrados

- `FormLogin` possuia eventos `TextChanged` vazios ligados no Designer.
- `FrmFeedback` possuia botoes visiveis sem eventos de clique ligados.
- `FrmFeedback` gerava warnings de nulidade ao ler `cmbTipoFeedback.SelectedItem`.
- `FrmPagamento` possuia metodos de CRUD no arquivo `.cs`, mas os botoes do Designer nao estavam ligados.
- `FrmPagamento` nao possuia duplo clique no `DataGridView` para carregar registro.
- `FrmPagamento` usava botoes com nomes genericos `button4` e `button5`.
- `FrmTeste` possuia eventos vazios e nao tinha funcao para a entrega.
- Nao foi encontrado formulario `FrmAlertaRisco`.

### Correcoes realizadas

- Removidos os eventos vazios de `FormLogin`.
- Ligados os botoes Enviar, Limpar e Cancelar do `FrmFeedback`.
- Corrigida leitura nula do ComboBox de feedback.
- Ligados os botoes Salvar, Editar, Excluir e Cancelar do `FrmPagamento`.
- Adicionado duplo clique no grid de pagamentos para editar o registro selecionado.
- Renomeados botoes genericos de pagamento para `btnCancelar` e `btnExcluir`.
- Removidos eventos vazios do `FrmTeste`.

### Resultado

- Build executado apos cada formulario alterado.
- Ultima compilacao: 0 erros e 0 warnings.
- Nenhum SQL direto foi encontrado nos Forms durante a verificacao estatica da etapa.
- Relatorio por formulario registrado em `docs/Desktop/RELATORIO_FORMS_ETAPA4.md`.

## Etapa 5 - Dashboard Desktop

### Problemas encontrados

- `FrmPrincipal` possuia botoes soltos e pouca organizacao visual.
- Nao havia tela inicial clara para o usuario logado.
- Nao havia barra lateral profissional para navegacao.
- Nao havia botao de sair no Dashboard.
- O login abria o Dashboard com `Show()`, deixando o fluxo de retorno ao login pouco controlado.
- Na homologacao, o perfil admin nao exibia Notas e Frequencia.

### Correcoes realizadas

- Criado layout com menu lateral, topo, area central e barra de status.
- Criada tela inicial com resumo de perfil, acessos liberados, sessao e modulo.
- Mantida a matriz de permissoes alinhada ao PHP.
- `financeiro` continua normalizado como `administrativo`.
- Forms filhos continuam abrindo no painel central.
- `FormLogin` passou a abrir o Dashboard com `ShowDialog()` e reaparecer ao sair.
- Admin passou a visualizar Notas e Frequencia.

### Resultado

- Build executado apos a alteracao.
- Ultima compilacao: 0 erros e 0 warnings.
- Relatorio registrado em `docs/Desktop/RELATORIO_DASHBOARD_ETAPA5.md`.

## Etapa 6/7 - Homologacao e correcao

### Problemas encontrados

- A conta `administrativo@flowacademy.com` nao autentica com a senha padrao documentada.
- Perfil admin nao exibia Notas e Frequencia.
- `FrmAlertaRisco` nao existe no Desktop.

### Correcoes realizadas

- Corrigida a matriz de permissoes do admin no `FrmPrincipal`.
- Retestados Dashboard e abertura de Forms.
- Registrados BUG-001, BUG-002 e BUG-003 em `docs/Homologacao/REGISTRO_DE_BUGS.md`.

### Resultado

- BUG-002 fechado.
- BUG-001 e BUG-003 permanecem abertos por dependerem de decisao do grupo.
- Compilacao final: 0 erros e 0 warnings.

## Pendencias para proxima etapa

- Executar testes manuais bloqueados.
- Decidir reset ou troca da conta administrativa de demonstracao.
- Definir se Alerta de Risco tera tela Desktop em escopo futuro.
- Fechar script SQL mestre unico para a banca.
