# Contexto de Regras de Negocio

## Regras identificadas

As regras abaixo foram identificadas pela leitura dos arquivos C#, PHP e SQL.

## Login

- Usuario faz login com email e senha.
- Senha usa hash SHA256.
- Usuario precisa estar ativo.
- No PHP, primeiro acesso e identificado por `ultimo_login` nulo.
- `Sessao.cs` armazena dados do usuario logado no Desktop.

## Notas

- As notas possuem campos de avaliacao como prova 1, prova 2, trabalho e comportamento.
- A media e calculada no codigo.
- A aprovacao usa media minima 6,0 em regras identificadas.
- Ha risco quando a media fica abaixo do limite definido pelo sistema.

## Frequencia

- Frequencia considera total de aulas, presencas e faltas.
- O percentual e calculado no codigo.
- Percentual abaixo de 75 pode gerar alerta de risco.

## Matricula

- A matricula liga aluno e turma.
- O banco possui restricao unica para evitar duplicidade de aluno na mesma turma.
- A classe `Matricula` possui metodo de matricula com verificacao de vaga.

## Turma

- Turma possui capacidade maxima.
- A classe `Turma` possui metodo para verificar vaga.

## Pagamento

- Pagamento pertence a um aluno.
- Status identificados no banco: pendente, pago, atrasado e cancelado.
- No PHP existem regras para situacao financeira e vencimento.

## Alerta de risco

- Alerta esta ligado a matricula.
- O banco possui tipos: nota, frequencia e ambos.
- O status pode ser pendente, analisado ou arquivado.

## Risco de duplicidade de regra

Algumas regras aparecem tanto no Desktop quanto no PHP, principalmente nota, frequencia, pagamento e alerta de risco. Isso pode gerar resultados diferentes se os calculos nao forem padronizados na proxima etapa.

