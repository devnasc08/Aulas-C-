# 07 - Manual do Usuario

## Acesso ao sistema

1. Abra o navegador.
2. Acesse:

   ```text
   http://localhost/FlowAcademy_php/web-php/login.php
   ```

3. Informe e-mail e senha.
4. Clique em entrar.

Depois do login, o sistema abre automaticamente o dashboard correto para o perfil.

## Logout

Para sair:

1. Clique no item de sessao ou no menu do usuario.
2. Selecione `Sair`.

O sistema encerra a sessao e retorna para o login.

## Aluno

### Dashboard

Mostra resumo academico do aluno.

### Boletim

Mostra notas por unidade curricular:

- Prova 1.
- Prova 2.
- Trabalho.
- Comportamental.
- Media.
- Status.

### Frequencia

Mostra frequencia por unidade curricular:

- Total de aulas.
- Presencas.
- Percentual.
- Situacao.

## Professor

### Dashboard

Mostra dados relacionados as turmas e alunos do professor.

### Lancar notas

Permite registrar notas de alunos por turma e unidade curricular.

Campos:

- Turma.
- Aluno matriculado.
- Unidade curricular.
- Prova 1.
- Prova 2.
- Trabalho.
- Comportamental.

Ao salvar, o sistema calcula a media automaticamente.

### Registrar frequencia

Permite registrar total de aulas e presencas por aluno e unidade curricular.

## Coordenacao

### Dashboard

Mostra indicadores de cursos, turmas e alertas academicos.

### Cursos

Permite consultar cursos cadastrados.

### Cadastro de curso

Permite criar ou editar:

- Nome.
- Descricao.
- Carga horaria.
- Status.
- Unidades curriculares.

### Turmas

Permite consultar turmas cadastradas.

### Cadastro de turma

Permite criar ou editar:

- Curso.
- Professor.
- Codigo da turma.
- Turno.
- Periodo letivo.
- Capacidade maxima.
- Status.

## Administrativo

### Dashboard

Mostra indicadores administrativos, alunos e pagamentos.

### Alunos

Permite consultar alunos cadastrados.

### Cadastro de aluno

Permite criar ou editar:

- Nome.
- E-mail.
- Senha inicial ou nova senha.
- Matricula.
- CPF.
- Telefone.
- Data de nascimento.
- Endereco.
- Status academico.

### Matricula

Permite matricular aluno em uma turma ativa.

### Pagamentos

Permite consultar pagamentos por turma e aluno.

### Cadastro de pagamento

Permite registrar ou editar:

- Aluno.
- Valor.
- Vencimento.
- Status.

## Admin

### Dashboard

Mostra resumo geral do sistema.

### Cadastrar coordenacao

Cria usuario com perfil `coordenacao`.

### Cadastrar administrativo

Cria usuario com perfil `administrativo`.

### Logs

Permite consultar acoes registradas no sistema.

