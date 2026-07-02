# 06 - Regras de Negocio

## Autenticacao

- O login usa a tabela `usuarios`.
- Apenas usuarios com `status = ativo` conseguem acessar.
- A senha digitada e convertida em SHA256 e comparada com `usuarios.senha_hash`.
- A sessao armazena apenas dados necessarios, nunca a senha.
- O usuario e redirecionado conforme o perfil.

## Perfis

Cada perfil acessa apenas suas paginas permitidas:

- Aluno acessa boletim, frequencia e dashboard.
- Professor acessa turmas, notas e frequencia.
- Coordenacao acessa cursos e turmas.
- Administrativo acessa alunos, matriculas e pagamentos.
- Admin acessa area administrativa, logs, coordenacao e administrativo.

## Primeiro acesso

Quando o usuario esta com `ultimo_login` nulo, o sistema pode exigir troca de senha em `alterar_senha.php`.

Depois da troca:

- A senha e salva novamente com SHA256.
- `ultimo_login` e atualizado.
- O usuario e liberado para navegar.

## Cadastro de aluno

O cadastro de aluno envolve:

1. Criar ou atualizar registro em `usuarios`.
2. Criar ou atualizar registro em `alunos`.
3. Manter vinculo por `id_usuario`.

O aluno precisa de usuario para conseguir fazer login.

## Cadastro de professor

O professor tambem precisa de usuario vinculado.

O cadastro envolve:

1. Criar ou atualizar registro em `usuarios`.
2. Criar ou atualizar registro em `professores`.
3. Manter vinculo por `id_usuario`.

## Cursos e unidades curriculares

- Um curso pode ter varias unidades curriculares.
- As unidades curriculares ficam na tabela `disciplinas`.
- Cada unidade curricular possui carga horaria propria.
- A edicao deve respeitar vinculos com notas e frequencias existentes.

## Turmas

Uma turma pertence a:

- Um curso.
- Um professor.

Cada turma possui:

- Codigo.
- Turno.
- Periodo letivo.
- Capacidade maxima.
- Status.

## Matriculas

Uma matricula vincula:

- Um aluno.
- Uma turma.

Antes de matricular, o sistema deve validar:

- Se o aluno existe.
- Se a turma existe.
- Se a turma esta ativa.
- Se a capacidade maxima nao foi atingida.
- Se o aluno ainda nao esta matriculado na mesma turma.

## Notas

O sistema calcula media ponderada por unidade curricular.

Formula:

```text
media = (prova_1 * 0.30) + (prova_2 * 0.30) + (trabalho * 0.30) + (comportamental * 0.10)
```

Criterio:

- Media maior ou igual a 6: aprovado.
- Media menor que 6: reprovado.

As notas precisam estar entre 0 e 10.

## Frequencia

O professor registra:

- Total de aulas.
- Presencas.

O percentual e calculado a partir desses valores.

Regra academica usada:

- Frequencia menor que 75% indica risco academico.

## Pagamentos

Cada pagamento pertence a um aluno.

Status possiveis:

- Pendente.
- Pago.
- Atrasado.
- Cancelado.

O sistema pode marcar pagamentos pendentes como atrasados quando a data de vencimento ja passou.

## Logs

O sistema registra acoes importantes na tabela `logs`, como:

- Login.
- Logout.
- Cadastro.
- Edicao.
- Lancamento de nota.
- Registro de frequencia.

O log nao deve impedir a acao principal se falhar.
