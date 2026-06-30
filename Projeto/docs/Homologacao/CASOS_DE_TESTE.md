# Casos de Teste - Flow Academy

## Legenda de status

- Nao executado
- Aprovado
- Aprovado com ressalva
- Reprovado
- Bloqueado

## 1. Login

| ID | Caso de teste | Passos | Resultado esperado | Status |
|---|---|---|---|---|
| CT-LOGIN-001 | Login admin | Entrar com usuario admin e senha correta | Abrir `FrmPrincipal` com menus de admin | Aprovado |
| CT-LOGIN-002 | Login coordenacao | Entrar com usuario coordenacao e senha correta | Abrir Dashboard com menus de coordenacao | Aprovado |
| CT-LOGIN-003 | Login administrativo | Entrar com usuario administrativo e senha correta | Abrir Dashboard com menus administrativo | Aprovado com ressalva: perfil validado com usuario temporario; conta `administrativo@flowacademy.com` esta no BUG-001 |
| CT-LOGIN-004 | Login professor | Entrar com usuario professor e senha correta | Abrir Dashboard com menus de professor | Aprovado |
| CT-LOGIN-005 | Login aluno | Entrar com usuario aluno e senha correta | Abrir Dashboard com menus de aluno | Aprovado |
| CT-LOGIN-006 | Senha incorreta | Informar email existente e senha errada | Exibir mensagem de login invalido e nao abrir Dashboard | Aprovado |
| CT-LOGIN-007 | Usuario inexistente | Informar email nao cadastrado | Exibir mensagem de login invalido e nao abrir Dashboard | Aprovado |
| CT-LOGIN-008 | Campos vazios | Clicar Entrar sem email ou senha | Exibir mensagem de campo obrigatorio | Bloqueado: requer validacao visual/manual |
| CT-LOGIN-009 | Logout | Logar e clicar Sair no Dashboard | Limpar sessao e voltar ao Login | Bloqueado: requer validacao visual/manual |
| CT-LOGIN-010 | Retorno ao Login | Fazer logout e tentar novo login | Permitir novo login normalmente | Bloqueado: requer validacao visual/manual |

## 2. Dashboard por perfil

| ID | Perfil | Menus esperados | Menus que devem ficar ocultos | Status |
|---|---|---|---|---|
| CT-DASH-001 | aluno | Notas, Frequencia | Usuarios, Alunos, Professores, Cursos, Disciplinas, Turmas, Matriculas, Pagamentos | Aprovado |
| CT-DASH-002 | professor | Notas, Frequencia | Usuarios, Alunos, Professores, Cursos, Disciplinas, Turmas, Matriculas, Pagamentos | Aprovado |
| CT-DASH-003 | coordenacao | Alunos, Cursos, Disciplinas, Turmas, Matriculas | Usuarios, Professores, Notas, Frequencia, Pagamentos | Aprovado |
| CT-DASH-004 | administrativo | Alunos, Matriculas, Pagamentos | Usuarios, Professores, Cursos, Disciplinas, Turmas, Notas, Frequencia | Aprovado |
| CT-DASH-005 | admin | Usuarios, Alunos, Professores, Cursos, Disciplinas, Turmas, Matriculas, Notas, Frequencia, Pagamentos | Menus nao utilizados no Desktop | Aprovado apos correcao do BUG-002 |
| CT-DASH-006 | financeiro antigo | Alunos, Matriculas, Pagamentos | Mesma regra de administrativo | Aprovado |

## 3. Abertura dos Forms pelo Dashboard

| ID | Menu | Form esperado | Resultado esperado | Status |
|---|---|---|---|---|
| CT-FORM-001 | Usuarios | `FrmUsuario` | Abrir dentro do painel central | Aprovado |
| CT-FORM-002 | Alunos | `FrmAluno` | Abrir dentro do painel central | Aprovado |
| CT-FORM-003 | Professores | `FrmProfessor` | Abrir dentro do painel central | Aprovado |
| CT-FORM-004 | Cursos | `FrmCurso` | Abrir dentro do painel central | Aprovado |
| CT-FORM-005 | Disciplinas | `FrmDisciplina` | Abrir dentro do painel central | Aprovado |
| CT-FORM-006 | Turmas | `FrmTurma` | Abrir dentro do painel central | Aprovado |
| CT-FORM-007 | Matriculas | `FrmMatricula` | Abrir dentro do painel central | Aprovado |
| CT-FORM-008 | Notas | `FrmNota` | Abrir dentro do painel central | Aprovado |
| CT-FORM-009 | Frequencia | `FrmFrequencia` | Abrir dentro do painel central | Aprovado |
| CT-FORM-010 | Pagamentos | `FrmPagamento` | Abrir dentro do painel central | Aprovado |

## 4. CRUDs

Entidades testadas via classes e banco real:

- Usuario
- Aluno
- Professor
- Curso
- Disciplina
- Turma
- Matricula
- Nota
- Frequencia
- Pagamento

| ID | Operacao | Passos | Resultado esperado | Status |
|---|---|---|---|---|
| CT-CRUD-001 | Inserir | Preencher campos obrigatorios e salvar | Registro gravado no banco e exibido no grid | Aprovado via classes/procedures |
| CT-CRUD-002 | Alterar | Selecionar registro, alterar campos e salvar | Registro atualizado no banco e no grid | Aprovado via classes/procedures |
| CT-CRUD-003 | Excluir | Selecionar registro e confirmar exclusao | Registro removido ou bloqueado por FK com mensagem adequada | Aprovado para limpeza dos dados criados; bloqueio por FK exige teste manual dirigido |
| CT-CRUD-004 | Consultar | Abrir Form e carregar grid | Dados exibidos sem erro | Aprovado via `ObterLista()` |
| CT-CRUD-005 | Buscar por ID | Selecionar registro no grid ou editar | Dados carregados corretamente no formulario | Aprovado via `ObterPorId()` |
| CT-CRUD-006 | Validacao | Tentar salvar com campos obrigatorios vazios | Sistema impede e mostra mensagem | Aprovado nas validacoes de classe; validacao visual manual ainda recomendada |
| CT-CRUD-007 | Mensagens | Executar salvar, alterar, excluir e cancelar | Mensagens claras para o usuario | Bloqueado: requer validacao visual/manual |
| CT-CRUD-008 | Atualizacao do Grid | Salvar, alterar ou excluir | Grid recarrega depois da operacao | Bloqueado: dados foram validados no banco, mas refresh visual precisa ser conferido em tela |

## 5. Banco

| ID | Caso de teste | Passos | Resultado esperado | Status |
|---|---|---|---|---|
| CT-BD-001 | Integridade FK usuario/aluno | Cadastrar aluno vinculado a usuario | FK valida e registro grava corretamente | Aprovado |
| CT-BD-002 | Integridade FK usuario/professor | Cadastrar professor vinculado a usuario | FK valida e registro grava corretamente | Aprovado |
| CT-BD-003 | Integridade FK curso/disciplina | Cadastrar disciplina vinculada a curso | FK valida e registro grava corretamente | Aprovado |
| CT-BD-004 | Integridade FK turma | Cadastrar turma vinculada a curso e professor | FK valida e registro grava corretamente | Aprovado |
| CT-BD-005 | Integridade FK matricula | Matricular aluno em turma | FK valida e registro grava corretamente | Aprovado |
| CT-BD-006 | Procedures insert/update/delete | Executar CRUD Desktop | Procedures executam sem erro | Aprovado |
| CT-BD-007 | Exclusao com dependencia | Tentar excluir registro usado por outro | Banco protege integridade ou sistema mostra erro claro | Bloqueado: requer massa de dados especifica e validacao manual |
| CT-BD-008 | Atualizacao | Alterar dados em Form | Banco reflete os dados atualizados | Aprovado |

## 6. Fluxo integrado de negocio

| ID | Passo | Resultado esperado | Status |
|---|---|---|---|
| CT-FLUXO-001 | Login como admin | Dashboard admin aberto | Aprovado |
| CT-FLUXO-002 | Cadastrar usuario | Usuario gravado e visivel no grid | Aprovado |
| CT-FLUXO-003 | Cadastrar professor | Professor vinculado a usuario | Aprovado |
| CT-FLUXO-004 | Cadastrar curso | Curso gravado | Aprovado |
| CT-FLUXO-005 | Cadastrar disciplina | Disciplina vinculada ao curso | Aprovado |
| CT-FLUXO-006 | Cadastrar turma | Turma vinculada a curso e professor | Aprovado |
| CT-FLUXO-007 | Cadastrar aluno | Aluno vinculado a usuario | Aprovado |
| CT-FLUXO-008 | Realizar matricula | Matricula vinculada a aluno e turma | Aprovado |
| CT-FLUXO-009 | Lancar nota | Nota gravada e media calculada | Aprovado |
| CT-FLUXO-010 | Registrar frequencia | Frequencia gravada e percentual calculado | Aprovado |
| CT-FLUXO-011 | Registrar pagamento | Pagamento vinculado ao aluno | Aprovado |
| CT-FLUXO-012 | Verificar alertas | Confirmar se regra de alerta existe ou registrar pendencia | Reprovado: nao existe `FrmAlertaRisco` no Desktop |
| CT-FLUXO-013 | Logout | Sessao limpa e Login exibido | Bloqueado: requer validacao visual/manual |
