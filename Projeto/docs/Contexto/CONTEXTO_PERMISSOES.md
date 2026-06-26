# Contexto de Permissoes

## Perfis confirmados no banco

O banco `Atual.sql` possui os perfis:

- aluno
- professor
- coordenacao
- administrativo
- admin

## Perfil financeiro

O perfil financeiro foi solicitado como perfil do projeto, mas nao aparece no enum `usuarios.perfil` do banco analisado. No PHP, a area financeira parece ser acessada por usuarios administrativos e admin.

Por isso, antes de implementar permissao financeira no Desktop, e necessario decidir se:

- financeiro sera um perfil real no banco; ou
- financeiro sera uma area acessada por administrativo e admin.

Como esta etapa nao altera banco nem codigo, a decisao fica registrada como pendencia.

## Permissoes atuais no Desktop

O `FrmPrincipal` deve ser o dashboard unico e controlar menus por perfil.

Na implementacao atual do C#, o valor antigo `financeiro` e tratado como `administrativo`, seguindo a regra do PHP.

### Aluno

- Notas
- Frequencia

### Professor

- Notas
- Frequencia

### Coordenacao

- Alunos
- Cursos
- Disciplinas
- Turmas
- Matriculas

### Administrativo

- Alunos
- Matriculas
- Pagamentos

### Financeiro

- Tratado como administrativo no C# e no PHP.

### Admin

- Usuarios
- Alunos
- Professores
- Cursos
- Disciplinas
- Turmas
- Matriculas
- Pagamentos

## Estado atual

O login Desktop abre o `FrmPrincipal`, que ja possui a regra inicial de exibicao de menus conforme perfil. Ainda falta validar o fluxo completo com usuarios reais e revisar os formularios abertos por cada botao.
