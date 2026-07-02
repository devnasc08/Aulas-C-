# 04 - Modulos e Perfis de Acesso

## Perfis do sistema

O sistema trabalha com os seguintes perfis:

- `aluno`
- `professor`
- `coordenacao`
- `administrativo`
- `admin`

O controle e feito em:

```text
web-php/includes/auth.php
```

As paginas chamam `exigirPerfil()` para limitar o acesso.

## Perfil Aluno

Pasta:

```text
web-php/pages/aluno/
```

Paginas:

- `dashboard.php`
- `boletim.php`
- `frequencia.php`

Permissoes:

- Consultar resumo academico.
- Consultar boletim.
- Consultar frequencia.

## Perfil Professor

Pasta:

```text
web-php/pages/professor/
```

Paginas:

- `dashboard.php`
- `lancar_notas.php`
- `registrar_frequencia.php`

Permissoes:

- Consultar suas turmas.
- Lancar notas.
- Registrar frequencia.

## Perfil Coordenacao

Pasta:

```text
web-php/pages/coordenacao/
```

Paginas:

- `dashboard.php`
- `cursos.php`
- `curso_form.php`
- `turmas.php`
- `turma_form.php`

Permissoes:

- Consultar indicadores academicos.
- Gerenciar cursos.
- Gerenciar unidades curriculares.
- Gerenciar turmas.
- Acessar cadastros academicos permitidos.

## Perfil Administrativo

Pastas:

```text
web-php/pages/administrativo/
web-php/pages/financeiro/
```

Paginas principais:

- `dashboard.php`
- `alunos.php`
- `aluno_form.php`
- `aluno_ver.php`
- `matricula_form.php`
- `pagamentos.php`
- `pagamento_form.php`

Permissoes:

- Consultar alunos.
- Cadastrar e editar alunos.
- Realizar matriculas.
- Consultar pagamentos.
- Registrar pagamentos.

## Perfil Admin

Pasta:

```text
web-php/pages/admin/
```

Paginas:

- `dashboard.php`
- `coordenacao_form.php`
- `administrativo_form.php`
- `logs.php`
- `_funcionario_form.php`

Permissoes:

- Acessar painel administrativo geral.
- Cadastrar usuarios de coordenacao.
- Cadastrar usuarios administrativos.
- Consultar logs.
- Acessar tambem areas de coordenacao e administrativo.

## Mapa de permissoes resumido

| Area | Aluno | Professor | Coordenacao | Administrativo | Admin |
| --- | --- | --- | --- | --- | --- |
| Dashboard aluno | Sim | Nao | Nao | Nao | Nao |
| Boletim | Sim | Nao | Nao | Nao | Nao |
| Frequencia do aluno | Sim | Nao | Nao | Nao | Nao |
| Dashboard professor | Nao | Sim | Nao | Nao | Nao |
| Lancar notas | Nao | Sim | Nao | Nao | Nao |
| Registrar frequencia | Nao | Sim | Nao | Nao | Nao |
| Cursos e turmas | Nao | Nao | Sim | Nao | Sim |
| Alunos e matriculas | Nao | Nao | Sim | Sim | Sim |
| Pagamentos | Nao | Nao | Nao | Sim | Sim |
| Logs | Nao | Nao | Nao | Nao | Sim |

