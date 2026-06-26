# Dashboard Desktop - Planejamento

## Objetivo

O `FrmPrincipal` deve ser o dashboard principal do modulo Desktop. Ele deve abrir apos o login e controlar a navegacao conforme o perfil do usuario logado.

Nenhum novo formulario de dashboard deve ser criado.

## Estado atual observado

- O login Desktop abre o `FrmPrincipal`.
- Existe `Sessao.cs` com dados do usuario logado.
- O `FrmPrincipal` possui botoes para abrir telas.
- A logica inicial de permissoes por perfil foi alinhada ao PHP.
- Os eventos de clique do `FrmPrincipal` foram conectados no proprio formulario.
- Ainda falta validar o fluxo visual completo com usuarios reais de cada perfil.

## Perfis

### Aluno

Menus previstos:

- Notas
- Frequencia

Observacao: o C# usa os formularios gerais `FrmNota` e `FrmFrequencia`, pois telas especificas de aluno nao foram confirmadas no Desktop.

### Professor

Menus previstos:

- Notas
- Frequencia

Forms relacionados:

- `FrmNota`
- `FrmFrequencia`

### Coordenacao

Menus previstos:

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

Menus previstos:

- Alunos
- Matriculas
- Pagamentos

Forms relacionados:

- `FrmAluno`
- `FrmMatricula`
- `FrmPagamento`

### Financeiro

Menus previstos:

- Pagamentos
- Situacao financeira
- Relatorios financeiros

Observacao: o perfil `financeiro` nao aparece no enum do banco `Atual.sql`. Antes da implementacao, deve ser definido se financeiro sera perfil real ou area de administrativo.

No C# atual, o valor `financeiro` e normalizado como `administrativo`, seguindo a mesma regra do PHP.

### Admin

Menus previstos:

- Todos os menus disponiveis.

No C# atual, admin visualiza usuarios, alunos, professores, cursos, disciplinas, turmas, matriculas e pagamentos.

## Regras esperadas

- Ler perfil em `Sessao.NivelAcesso`.
- Ocultar botoes ou menus nao permitidos.
- Abrir forms sem duplicar janelas desnecessariamente.
- Manter mensagens simples e didaticas.
- Nao colocar SQL no dashboard.

## Pendencias

- Validar situacao final do perfil financeiro no banco.
- Validar fluxo apos login.
- Testar abertura de cada formulario por perfil.
