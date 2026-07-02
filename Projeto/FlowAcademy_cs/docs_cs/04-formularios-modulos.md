# 04 - Formularios e Modulos

## Login

Arquivo:

```text
FlowAcademy/FormLogin.cs
```

Responsabilidades:

- Validar campos obrigatorios.
- Chamar autenticacao.
- Abrir tela de primeiro acesso quando necessario.
- Criar sessao.
- Abrir dashboard principal.

## Dashboard principal

Arquivo:

```text
FlowAcademy/FrmPrincipal.cs
```

Responsabilidades:

- Montar menu lateral.
- Mostrar usuario logado.
- Mostrar perfil logado.
- Liberar menus conforme perfil.
- Abrir formularios no painel principal.
- Encerrar sessao ao sair.

## Alunos

Arquivo:

```text
FlowAcademy/FrmAluno.cs
```

Responsabilidades:

- Listar alunos.
- Pesquisar alunos.
- Cadastrar aluno e usuario vinculado.
- Editar aluno.
- Excluir aluno.
- Validar nome, e-mail, senha, matricula, CPF e telefone.

## Professores

Arquivo:

```text
FlowAcademy/FrmProfessor.cs
```

Responsabilidades:

- Listar professores.
- Pesquisar professores.
- Cadastrar professor e usuario vinculado.
- Editar professor.
- Excluir professor.

## Funcionarios

Arquivo:

```text
FlowAcademy/FrmFuncionarios.cs
```

Responsabilidades:

- Cadastrar funcionarios administrativos.
- Trabalhar com perfis de apoio, como coordenacao e administrativo.
- Evitar mistura indevida com aluno e professor.

## Usuarios

Arquivo:

```text
FlowAcademy/FrmUsuario.cs
```

Responsabilidades:

- CRUD generico de usuarios.
- Definir perfil.
- Definir status.

Observacao:

- O formulario existe no projeto, mas o acesso pelo dashboard pode ser controlado conforme decisao de permissao.

## Cursos

Arquivo:

```text
FlowAcademy/FrmCurso.cs
```

Responsabilidades:

- Cadastrar curso.
- Editar curso.
- Excluir curso.
- Consultar disciplinas vinculadas.

## Disciplinas

Arquivo:

```text
FlowAcademy/FrmDisciplina.cs
```

Responsabilidades:

- Cadastrar unidade curricular.
- Vincular unidade curricular a curso.
- Editar e excluir disciplina.
- Pesquisar por disciplina ou curso.

## Turmas

Arquivo:

```text
FlowAcademy/FrmTurma.cs
```

Responsabilidades:

- Cadastrar turma.
- Vincular curso.
- Vincular professor.
- Definir turno, periodo letivo, capacidade e status.
- Pesquisar turma.

## Matriculas

Arquivo:

```text
FlowAcademy/FrmMatricula.cs
```

Responsabilidades:

- Matricular aluno em turma.
- Listar matriculas.
- Pesquisar matriculas.
- Editar ou excluir matricula.

## Notas

Arquivo:

```text
FlowAcademy/FrmNota.cs
```

Responsabilidades:

- Lancar notas.
- Calcular media.
- Filtrar por turma.
- Restringir professor as suas turmas.
- Exibir matricula, aluno, disciplina e turma.

## Frequencia

Arquivo:

```text
FlowAcademy/FrmFrequencia.cs
```

Responsabilidades:

- Registrar frequencia.
- Filtrar por turma.
- Restringir professor as suas turmas.
- Calcular percentual.
- Pesquisar por aluno.

## Boletim do aluno

Arquivo:

```text
FlowAcademy/FrmBoletimAluno.cs
```

Responsabilidades:

- Permitir que aluno consulte suas notas.
- Mostrar boletim vinculado ao usuario logado.

## Frequencia do aluno

Arquivo:

```text
FlowAcademy/FrmFrequenciaAluno.cs
```

Responsabilidades:

- Permitir que aluno consulte sua frequencia.
- Mostrar percentual e situacao por unidade curricular.

## Pagamentos

Arquivo:

```text
FlowAcademy/FrmPagamento.cs
```

Responsabilidades:

- Registrar pagamento.
- Editar pagamento.
- Excluir pagamento.
- Pesquisar por aluno.
- Exibir valor, vencimento e status.

