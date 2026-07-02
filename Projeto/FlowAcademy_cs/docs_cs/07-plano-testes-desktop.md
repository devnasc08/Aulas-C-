# 07 - Plano de Testes Desktop

## Objetivo

Validar manualmente o modulo desktop C# do Flow Academy antes da apresentacao.

## Ambiente

- Windows.
- Visual Studio.
- .NET 8 SDK.
- MySQL/MariaDB ativo.
- Banco `flow_academy` importado.
- Procedures do C# aplicadas, se necessario.

## Casos de teste

### CTD01 - Build da solucao

Passos:

1. Abrir `FlowAcademy.sln`.
2. Executar build.

Resultado esperado:

- Solucao compila sem erro.

### CTD02 - Login valido

Passos:

1. Abrir sistema.
2. Informar usuario e senha validos.
3. Clicar em entrar.

Resultado esperado:

- Login realizado.
- `FrmPrincipal` abre.
- Nome e perfil aparecem no dashboard.

### CTD03 - Login invalido

Passos:

1. Informar senha incorreta.
2. Clicar em entrar.

Resultado esperado:

- Sistema exibe mensagem de erro.
- Dashboard nao abre.

### CTD04 - Primeiro acesso

Passos:

1. Entrar com usuario cujo `ultimo_login` esteja nulo.
2. Trocar senha.

Resultado esperado:

- `FrmPrimeiroAcesso` abre.
- Senha e salva.
- Usuario entra no sistema.

### CTD05 - Permissoes por perfil

Passos:

1. Entrar com aluno.
2. Conferir menus.
3. Entrar com professor.
4. Conferir menus.
5. Repetir com coordenacao, administrativo e admin.

Resultado esperado:

- Cada perfil visualiza apenas os menus permitidos.

### CTD06 - CRUD de aluno

Passos:

1. Abrir Alunos.
2. Cadastrar aluno.
3. Editar aluno.
4. Pesquisar aluno.
5. Excluir ou inativar conforme fluxo da tela.

Resultado esperado:

- Operacoes funcionam e grid atualiza.

### CTD07 - CRUD de professor

Resultado esperado:

- Professor e usuario vinculado sao mantidos corretamente.

### CTD08 - Cursos e disciplinas

Resultado esperado:

- Curso pode ser cadastrado.
- Disciplina pode ser vinculada ao curso.
- Listagens exibem nomes legiveis.

### CTD09 - Turmas

Resultado esperado:

- Turma e cadastrada com curso, professor, turno, periodo e capacidade.
- Pesquisa por codigo funciona.

### CTD10 - Matriculas

Resultado esperado:

- Aluno e matriculado em turma.
- Grid mostra aluno e codigo da turma.

### CTD11 - Notas

Resultado esperado:

- Professor visualiza apenas turmas permitidas.
- Nota e salva.
- Media e calculada corretamente.

### CTD12 - Frequencia

Resultado esperado:

- Frequencia e salva.
- Percentual e calculado.
- Grid mostra aluno, disciplina e turma.

### CTD13 - Pagamentos

Resultado esperado:

- Pagamento e salvo.
- Pesquisa por aluno funciona.

## Tabela de homologacao

| Caso | Resultado | Observacao |
| --- | --- | --- |
| CTD01 | Pendente |  |
| CTD02 | Pendente |  |
| CTD03 | Pendente |  |
| CTD04 | Pendente |  |
| CTD05 | Pendente |  |
| CTD06 | Pendente |  |
| CTD07 | Pendente |  |
| CTD08 | Pendente |  |
| CTD09 | Pendente |  |
| CTD10 | Pendente |  |
| CTD11 | Pendente |  |
| CTD12 | Pendente |  |
| CTD13 | Pendente |  |

