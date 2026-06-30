# Script SQL Mestre

## Estado atual

Nesta etapa, nao foi gerado automaticamente um dump unico do banco real porque o ambiente nao possui cliente `mysql`/`mysqldump` disponivel.

Para a banca, o projeto deve considerar como base oficial temporaria:

1. `FlowAcademy_php/web-php/database/flow_academy_banco_limpo.sql`
2. `procedures_para_Atual_conforme_CSharp.sql`

## Ordem de aplicacao recomendada

1. Aplicar `FlowAcademy_php/web-php/database/flow_academy_banco_limpo.sql`.
2. Aplicar `procedures_para_Atual_conforme_CSharp.sql`.
3. Conferir se os usuarios de demonstracao possuem as senhas definidas pelo grupo.
4. Executar login Desktop.
5. Executar fluxo integrado ate pagamento.

## Pontos de atencao

- O script de procedures nao altera tabelas, relacionamentos ou dados.
- A estrutura base deve ser confirmada pelo grupo antes da entrega final.
- A conta `administrativo@flowacademy.com` precisa de decisao sobre senha.
- O banco final de demonstracao deve evitar dados temporarios de homologacao.

## Pendencia para congelamento final

Gerar um arquivo unico, por exemplo `FlowAcademy_SQL_Mestre_Final.sql`, juntando:

- criacao do banco;
- criacao das tabelas;
- dados minimos de demonstracao;
- procedures alinhadas ao Desktop;
- usuarios finais da apresentacao.
