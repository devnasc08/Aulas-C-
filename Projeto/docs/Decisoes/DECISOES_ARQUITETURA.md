# Decisoes de Arquitetura

## 1. Banco compartilhado

O Desktop e o PHP usam o mesmo banco MySQL.

Vantagem: evita integracao direta entre aplicacoes e mantem os dados centralizados.

Impacto: qualquer alteracao no banco precisa ser validada nos dois modulos.

## 2. Desktop com Forms, Classes e Banco

O Desktop segue o fluxo:

Forms -> Classes -> Banco.cs -> MySQL

Vantagem: mantem os formularios simples e o acesso ao banco concentrado.

Impacto: formularios nao devem conter SQL nem regras de negocio.

## 3. Procedures apenas para escrita no Desktop

No Desktop:

- INSERT usa procedure.
- UPDATE usa procedure.
- DELETE usa procedure.
- SELECT usa SQL direto.
- SELECT POR ID usa SQL direto.

Vantagem: mantem padrao didatico e previsivel.

Impacto: procedures precisam estar alinhadas com as classes.

## 4. PHP com SQL direto

O PHP usa SQL direto com PDO.

Vantagem: simplicidade para o modulo Web.

Impacto: as consultas PHP precisam ser revisadas contra o banco final.

## 5. Classes no padrao ServiceHub

As classes devem manter estrutura simples, semelhante a projeto tecnico:

- Construtores
- Inserir
- Atualizar
- Excluir
- ObterLista
- ObterPorId
- MontarObjeto privado

Vantagem: codigo didatico, facil de revisar e apresentar.

Impacto: nao usar Repository, DI, Entity Framework ou padroes avancados.

## 6. Relacionamentos por objeto

Quando uma entidade depende de outra, o relacionamento deve ser representado por objeto simples.

Vantagem: facilita uso nos formularios e combos.

Impacto: consultas precisam trazer dados suficientes para montar objetos relacionados.

## 7. Um CRUD por formulario

Cada entidade deve possuir um formulario CRUD unico.

Vantagem: reduz telas duplicadas e facilita apresentacao.

Impacto: forms de teste ou duplicados devem ser removidos ou ignorados na entrega final, apos decisao.

## 8. Dashboard unico

O `FrmPrincipal` sera o dashboard principal do Desktop.

Vantagem: centraliza navegacao e permissoes.

Impacto: nao criar outro dashboard; a logica deve ser implementada no formulario existente.

## 9. Script auxiliar para procedures

Data: 26/06/2026.

Decisao: manter o arquivo `procedures_para_Atual_conforme_CSharp.sql` como script de ajuste das procedures do banco usado pelo Desktop.

Motivo: o arquivo `Atual.sql` possui tabelas compativeis com o projeto, mas varias procedures usam nomes antigos e nao batem com todas as chamadas das classes C#.

Vantagem: corrige procedures sem alterar tabelas, relacionamentos ou dados.

Impacto: antes dos testes funcionais, o script precisa ser aplicado em um banco MySQL de teste para validar execucao real.
