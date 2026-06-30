# Dashboard Desktop - FrmPrincipal

## Objetivo

O `FrmPrincipal` e o dashboard principal do modulo Desktop. Ele abre apos o login e controla a navegacao conforme o perfil do usuario logado.

Nenhum novo formulario de dashboard foi criado.

## Estado atual

- O login Desktop abre o `FrmPrincipal`.
- O `FrmPrincipal` usa os dados de `Sessao`.
- A interface possui menu lateral, topo, area central e barra de status.
- A tela inicial mostra resumo do perfil, quantidade de acessos liberados, sessao e modulo.
- Os formularios filhos abrem dentro do painel central.
- O botao Sair limpa a sessao e retorna para o login.
- O perfil `financeiro` continua sendo normalizado como `administrativo`, seguindo o PHP.
- O admin acessa tambem Notas e Frequencia.

## Fluxo

1. Usuario faz login.
2. `FormLogin` grava `Sessao.IdUsuario`, `Sessao.Nome` e `Sessao.NivelAcesso`.
3. `FormLogin` abre `FrmPrincipal` com `ShowDialog()`.
4. `FrmPrincipal` normaliza o perfil.
5. Menus nao permitidos sao ocultados.
6. O usuario abre apenas formularios liberados.
7. Ao sair, a sessao e limpa e o login aparece novamente.

## Perfis e menus

### Aluno

- Notas
- Frequencia

Observacao: o Desktop ainda usa os formularios gerais `FrmNota` e `FrmFrequencia`.

### Professor

- Notas
- Frequencia

Forms relacionados:

- `FrmNota`
- `FrmFrequencia`

### Coordenacao

- Alunos
- Cursos
- Disciplinas
- Turmas
- Matriculas

Forms relacionados:

- `FrmAluno`
- `FrmCurso`
- `FrmDisciplina`
- `FrmTurma`
- `FrmMatricula`

### Administrativo

- Alunos
- Matriculas
- Pagamentos

Forms relacionados:

- `FrmAluno`
- `FrmMatricula`
- `FrmPagamento`

### Financeiro

O banco oficial nao possui `financeiro` no enum de perfil. O PHP converte `financeiro` antigo para `administrativo`.

No Desktop, `financeiro` tambem e tratado como `administrativo`.

### Admin

- Usuarios
- Alunos
- Professores
- Cursos
- Disciplinas
- Turmas
- Matriculas
- Notas
- Frequencia
- Pagamentos

Forms relacionados:

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

## Regras

- O Dashboard nao possui SQL direto.
- O Dashboard nao chama procedures.
- O Dashboard apenas controla a interface, sessao e abertura de Forms.
- As regras de CRUD continuam nas classes.
- Menus nao permitidos ficam ocultos.
- Tentativa de acesso indevido por codigo exibe mensagem simples de permissao.

## Homologacao

- Menus por perfil aprovados.
- Abertura de Forms aprovada.
- BUG-002 corrigido: admin passou a visualizar Notas e Frequencia.
- Build final apos correcao: 0 erros e 0 warnings.

## Pendencias

- Validar manualmente logout e retorno ao login.
- Definir em etapa futura se `FrmFeedback` entrara em algum perfil.
- Definir em etapa futura se `FrmAlertaRisco` sera criado.
