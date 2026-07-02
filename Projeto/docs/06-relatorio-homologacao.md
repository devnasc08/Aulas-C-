# 06 - Relatorio de Homologacao

## Objetivo

Registrar a estrategia de homologacao do projeto Flow Academy completo.

## Escopo

Modulos avaliados:

- PHP Web.
- CSharp Desktop.
- Banco MySQL.
- Integracao entre modulos.

## Criterios de aceite gerais

- Banco importa sem erro critico.
- PHP conecta ao banco.
- C# conecta ao banco.
- Login funciona nos dois modulos.
- Perfis funcionam nos dois modulos.
- Dados cadastrados em um modulo aparecem no outro.
- Notas e frequencia seguem a mesma regra.
- Matriculas usam as mesmas tabelas.
- Pagamentos usam as mesmas tabelas.

## Testes integrados

### HT01 - Cadastro no PHP e consulta no CSharp

1. Cadastrar aluno no PHP.
2. Abrir C#.
3. Consultar alunos.

Resultado esperado:

- Aluno aparece no C#.

### HT02 - Cadastro no CSharp e consulta no PHP

1. Cadastrar curso no C#.
2. Abrir PHP.
3. Consultar cursos.

Resultado esperado:

- Curso aparece no PHP.

### HT03 - Login com mesmo usuario

1. Logar no PHP.
2. Logar no C# com o mesmo usuario.

Resultado esperado:

- O usuario e reconhecido nos dois modulos.

### HT04 - Nota lancada e boletim

1. Lancar nota como professor.
2. Consultar boletim do aluno.

Resultado esperado:

- Nota e media aparecem corretamente.

### HT05 - Frequencia registrada e consulta

1. Registrar frequencia.
2. Consultar frequencia do aluno.

Resultado esperado:

- Frequencia aparece com percentual correto.

## Tabela de homologacao

| Teste | Resultado | Observacao |
| --- | --- | --- |
| HT01 | Pendente |  |
| HT02 | Pendente |  |
| HT03 | Pendente |  |
| HT04 | Pendente |  |
| HT05 | Pendente |  |

## Pendencias tecnicas conhecidas

- Ajustar connection strings conforme ambiente.
- Confirmar se procedures do C# foram importadas.
- Validar todos os perfis com dados reais.
- Rodar build do C# no computador de apresentacao.
- Rodar PHP com servidor local configurado.

## Conclusao

A homologacao deve priorizar os fluxos compartilhados entre PHP, C# e banco, pois eles demonstram a integracao real do projeto.

