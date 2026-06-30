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

Motivo: o arquivo-base de banco possui tabelas compativeis com o projeto, mas varias procedures usam nomes antigos e nao batem com todas as chamadas das classes C#.

Vantagem: corrige procedures sem alterar tabelas, relacionamentos ou dados.

Impacto: antes dos testes funcionais, o script precisa ser aplicado em um banco MySQL de teste para validar execucao real.

## 10. Consolidacao dos Forms existentes

Data: 30/06/2026.

Decisao: na Etapa 4 foram corrigidos apenas problemas dos formularios existentes, sem criar novas telas e sem alterar regras de negocio.

Motivo: a etapa tinha como objetivo estabilizar os CRUDs antes do Dashboard.

Vantagem: mantem a evolucao controlada e rastreavel, com baixo risco de quebrar a arquitetura.

Impacto: `FrmAlertaRisco` continua registrado como pendencia porque criar essa tela seria nova funcionalidade.

## 11. FrmPrincipal como Dashboard Desktop

Data: 30/06/2026.

Decisao: o `FrmPrincipal` foi mantido como unico Dashboard Desktop, com menu lateral, topo, tela inicial, painel central e controle de permissoes por perfil.

Motivo: a arquitetura definida proibe criar outro dashboard e exige que a navegacao seja centralizada no formulario principal.

Vantagem: mantem o Desktop simples, visualmente mais organizado e alinhado ao PHP.

Impacto: `FormLogin` abre o Dashboard com `ShowDialog()` e volta ao login quando o usuario sai. As permissoes continuam baseadas em `Sessao.NivelAcesso`.

## 12. Homologacao antes da entrega

Data: 30/06/2026.

Decisao: criar documentos formais de homologacao antes de executar os testes finais.

Motivo: o projeto precisa demonstrar processo de validacao, nao apenas codigo implementado.

Vantagem: facilita apresentacao, rastreia bugs e mostra criterios claros de aceite.

Impacto: os testes finais devem seguir os documentos em `docs/Homologacao` e o relatorio deve ser preenchido com resultados reais.

## 13. Correcao do perfil admin

Data: 30/06/2026.

Decisao: liberar Notas e Frequencia para o perfil `admin` no Dashboard Desktop.

Motivo: o fluxo integrado da banca passa por lancar nota e registrar frequencia; o admin precisa conseguir demonstrar o fluxo completo.

Vantagem: simplifica a apresentacao e mantem o admin como perfil de acesso total.

Impacto: `FrmPrincipal` foi corrigido e os testes de Dashboard/Forms foram reexecutados.

## 14. Remocao do FrmTeste no congelamento

Data: 30/06/2026.

Decisao: remover `FrmTeste` do projeto Desktop.

Motivo: o formulario era tela de teste/orfa, sem fluxo funcional confirmado.

Vantagem: reduz codigo morto e evita confusao durante a apresentacao.

Impacto: foram removidos `FrmTeste.cs`, `FrmTeste.Designer.cs` e `FrmTeste.resx`; o build final continuou com 0 erros e 0 warnings.

## 15. Alerta de Risco fora do escopo de correcao rapida

Data: 30/06/2026.

Decisao: nao criar `FrmAlertaRisco` durante a Etapa 7.

Motivo: a etapa permite corrigir bugs e pequenos ajustes, mas criar um CRUD novo seria funcionalidade nova.

Vantagem: preserva o congelamento e evita mudanca estrutural perto da banca.

Impacto: BUG-003 permanece aberto e deve ser explicado como pendencia documentada.
