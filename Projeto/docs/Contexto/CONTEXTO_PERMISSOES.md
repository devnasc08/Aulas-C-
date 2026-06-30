# Contexto de Permissoes

## Perfis confirmados no banco

O banco analisado possui os perfis:

- aluno
- professor
- coordenacao
- administrativo
- admin

## Perfil financeiro

O perfil financeiro foi solicitado durante o projeto, mas nao aparece no enum `usuarios.perfil` do banco analisado.

No PHP, registros antigos com `financeiro` sao normalizados para `administrativo`.

No Desktop, o `FrmPrincipal` segue a mesma regra: se `Sessao.NivelAcesso` vier como `financeiro`, o sistema trata como `administrativo`.

## Permissoes no Desktop

O `FrmPrincipal` e o dashboard unico do Desktop e controla menus por perfil.

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

- Tratado como administrativo.

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

## Permissoes no PHP

O PHP usa `exigirPerfil()` para proteger paginas internas.

Regras observadas:

- aluno acessa dashboard, boletim e frequencia.
- professor acessa dashboard, lancamento de notas e registro de frequencia.
- coordenacao acessa cursos, turmas, alunos e matriculas conforme paginas permitidas.
- administrativo acessa alunos, matriculas e pagamentos.
- admin acessa dashboard admin, logs, cadastros administrativos e tambem areas de coordenacao/administrativo.

## Estado atual

O Desktop e o PHP estao alinhados na regra principal de perfil:

- `financeiro` antigo vira `administrativo`.
- Menus nao permitidos ficam ocultos.
- Cada perfil entra em uma area compativel com sua funcao.
- O admin tambem acessa Notas e Frequencia no Desktop, permitindo demonstrar o fluxo integrado completo.

## Validacao de homologacao

Foram aprovados os testes de Dashboard para:

- aluno
- professor
- coordenacao
- administrativo
- financeiro antigo
- admin

Ressalva: a conta `administrativo@flowacademy.com` nao usa a senha padrao `123456`. O perfil administrativo foi validado com usuario temporario criado e removido na homologacao.

## Pendencias

- Validar manualmente logout e retorno ao login.
- Confirmar se `FrmFeedback` tera permissao propria em etapa futura.
- Confirmar se `FrmAlertaRisco` sera criado no Desktop.
