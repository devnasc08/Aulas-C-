# 11 - Roteiro de Apresentacao

## Objetivo da apresentacao

Demonstrar que o Flow Academy PHP atende a uma necessidade real de gestao academica, possui organizacao tecnica coerente, separa perfis de acesso e aplica regras de negocio importantes para um ambiente escolar.

## Tempo sugerido

Entre 8 e 12 minutos.

## Divisao sugerida

### 1. Abertura

Tempo: 1 minuto.

Falar:

- Nome do projeto.
- Problema resolvido.
- Publico-alvo.

Exemplo:

> O Flow Academy e um sistema web para gestao academica de uma escola tecnica presencial. Ele organiza rotinas de alunos, professores, coordenacao, administrativo e admin em uma unica plataforma.

### 2. Tecnologias usadas

Tempo: 1 minuto.

Falar:

- PHP puro.
- MySQL/MariaDB.
- PDO.
- Bootstrap local.
- HTML, CSS e JavaScript.

Enfatizar:

- O projeto nao depende de framework.
- A estrutura foi organizada para ser compreensivel em curso tecnico.

### 3. Estrutura do projeto

Tempo: 1 minuto.

Mostrar:

```text
FlowAcademy_php/
+-- banco/
+-- docs/
+-- scripts/
+-- web-php/
```

Explicar:

- `banco`: script SQL.
- `docs`: documentacao.
- `scripts`: dados auxiliares.
- `web-php`: aplicacao.

### 4. Login e perfis

Tempo: 2 minutos.

Demonstrar:

1. Abrir `login.php`.
2. Fazer login.
3. Mostrar redirecionamento por perfil.
4. Explicar permissao por `exigirPerfil()`.

Falar:

- Cada usuario possui um perfil.
- O menu muda conforme o perfil.
- O sistema bloqueia acesso indevido.

### 5. Demonstracao por perfil

Tempo: 4 minutos.

#### Aluno

Mostrar:

- Dashboard.
- Boletim.
- Frequencia.

#### Professor

Mostrar:

- Dashboard.
- Lancamento de notas.
- Registro de frequencia.

#### Coordenacao

Mostrar:

- Cursos.
- Turmas.

#### Administrativo

Mostrar:

- Alunos.
- Matricula.
- Pagamentos.

#### Admin

Mostrar:

- Cadastro de coordenacao/administrativo.
- Logs.

### 6. Banco de dados

Tempo: 1 minuto.

Mostrar:

- `Banco_oficial.sql`.
- Tabelas principais.
- Relacionamento entre usuario, aluno, professor, curso, turma, matricula, notas e frequencia.

Falar:

- O banco possui chaves estrangeiras.
- O sistema usa consultas preparadas via PDO.

### 7. Regras de negocio

Tempo: 1 minuto.

Explicar:

- Senha validada por SHA256.
- Matricula respeita turma e capacidade.
- Nota usa media ponderada.
- Frequencia acompanha percentual.
- Pagamento possui status.
- Logs registram acoes.

### 8. Encerramento

Tempo: 1 minuto.

Falar:

- O projeto atende aos perfis principais da escola.
- A arquitetura permite manutencao.
- A documentacao ajuda na continuidade.

## Ordem recomendada de telas para demonstrar

1. `index.php`
2. `login.php`
3. Dashboard admin
4. Logs
5. Cursos
6. Turmas
7. Alunos
8. Matricula
9. Lancar notas
10. Frequencia
11. Boletim do aluno
12. Logout

## Perguntas provaveis da banca

### Por que PHP puro?

Porque o objetivo e manter compatibilidade com o nivel do curso tecnico e demonstrar dominio da base da linguagem, sem depender de frameworks.

### Como o sistema controla permissoes?

Cada usuario possui um perfil salvo na tabela `usuarios`. As paginas internas chamam `exigirPerfil()` para validar se o perfil logado pode acessar aquela tela.

### Como a senha e validada?

A senha digitada e convertida em SHA256 e comparada com o hash salvo no banco.

### Como a media e calculada?

Pela formula:

```text
prova_1 * 0.30 + prova_2 * 0.30 + trabalho * 0.30 + comportamental * 0.10
```

### Como evitar SQL Injection?

O projeto usa PDO com consultas preparadas e parametros separados do SQL.

### O que pode evoluir depois?

- Recuperacao de senha por e-mail.
- Relatorios em PDF.
- Exportacao de dados.
- Painel mais completo de indicadores.
- Melhor separacao de camadas com autoload.

