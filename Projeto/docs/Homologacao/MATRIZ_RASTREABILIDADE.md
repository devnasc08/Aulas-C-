# Matriz de Rastreabilidade

## Objetivo

Relacionar requisitos, casos de uso, classes, Forms e testes de homologacao. Esta matriz ajuda a provar que o sistema foi validado de forma organizada.

## Matriz

| Requisito | Caso de uso | Classe C# | Form Desktop | Banco/Tabela | Caso de teste |
|---|---|---|---|---|---|
| Autenticar usuario | Login | `Usuario`, `Sessao` | `FormLogin` | `usuarios` | CT-LOGIN-001 a CT-LOGIN-010 |
| Controlar acesso por perfil | Dashboard por perfil | `Sessao` | `FrmPrincipal` | `usuarios.perfil` | CT-DASH-001 a CT-DASH-006 |
| Cadastrar usuarios | CRUD Usuario | `Usuario` | `FrmUsuario` | `usuarios` | CT-CRUD-001 a CT-CRUD-008 |
| Cadastrar alunos | CRUD Aluno | `Aluno`, `Usuario` | `FrmAluno` | `alunos`, `usuarios` | CT-CRUD-001 a CT-CRUD-008 |
| Cadastrar professores | CRUD Professor | `Professor`, `Usuario` | `FrmProfessor` | `professores`, `usuarios` | CT-CRUD-001 a CT-CRUD-008 |
| Cadastrar cursos | CRUD Curso | `Curso` | `FrmCurso` | `cursos` | CT-CRUD-001 a CT-CRUD-008 |
| Cadastrar disciplinas | CRUD Disciplina | `Disciplina`, `Curso` | `FrmDisciplina` | `disciplinas`, `cursos` | CT-CRUD-001 a CT-CRUD-008 |
| Cadastrar turmas | CRUD Turma | `Turma`, `Curso`, `Professor` | `FrmTurma` | `turmas`, `cursos`, `professores` | CT-CRUD-001 a CT-CRUD-008 |
| Realizar matricula | CRUD Matricula | `Matricula`, `Aluno`, `Turma` | `FrmMatricula` | `matriculas`, `alunos`, `turmas` | CT-CRUD-001 a CT-CRUD-008 |
| Lancar notas | CRUD Nota | `Nota`, `Matricula`, `Disciplina` | `FrmNota` | `notas`, `matriculas`, `disciplinas` | CT-CRUD-001 a CT-CRUD-008 |
| Registrar frequencia | CRUD Frequencia | `Frequencia`, `Matricula`, `Disciplina` | `FrmFrequencia` | `frequencia`, `matriculas`, `disciplinas` | CT-CRUD-001 a CT-CRUD-008 |
| Registrar pagamentos | CRUD Pagamento | `Pagamento`, `Aluno` | `FrmPagamento` | `pagamentos`, `alunos` | CT-CRUD-001 a CT-CRUD-008 |
| Controlar integridade | Banco e FKs | Classes de entidade | Forms CRUD | FKs do banco | CT-BD-001 a CT-BD-008 |
| Demonstrar fluxo completo | Fluxo ponta a ponta | Todas as classes principais | Forms principais | Banco completo | CT-FLUXO-001 a CT-FLUXO-013 |

## Observacoes

- `FrmAlertaRisco` nao existe no Desktop no estado atual.
- `FrmFeedback` existe, mas ainda nao foi ligado a regra completa de banco.
- PHP usa SQL direto e deve ser validado em etapa posterior contra o mesmo banco.
- Desktop usa procedures para INSERT, UPDATE e DELETE por meio das classes.
