# Plano de Testes - Flow Academy

## Objetivo

Validar o Flow Academy antes da apresentacao final, confirmando que Desktop, Banco e PHP estao coerentes e que o fluxo principal do sistema funciona ponta a ponta.

## Escopo

Este plano cobre:

- Login Desktop.
- Logout e retorno ao Login.
- Sessao.
- Dashboard Desktop por perfil.
- CRUDs Desktop.
- Banco de dados.
- Procedures usadas pelo Desktop.
- Fluxo integrado de negocio.

## Fora do escopo nesta rodada

- Criacao de novas funcionalidades.
- Alteracao de tabelas.
- Alteracao de regras de negocio.
- Refatoracao visual do PHP.
- Testes automatizados permanentes no projeto.

## Ambiente necessario

- Windows.
- Projeto `FlowAcademy_cs` compilando.
- Banco MySQL criado a partir do script oficial definido pelo grupo.
- Procedures aplicadas no banco de teste.
- Usuarios de teste para os perfis:
  - admin
  - coordenacao
  - administrativo
  - professor
  - aluno

## Ordem de execucao

1. Teste do Login.
2. Teste do Dashboard.
3. Teste dos CRUDs.
4. Teste do Banco.
5. Teste Integrado.
6. Registro de bugs.
7. Relatorio de homologacao.

## Tipos de teste

### Teste funcional

Confirma se a funcionalidade executa o que foi planejado.

### Teste de permissao

Confirma se cada perfil acessa apenas o que deve acessar.

### Teste de integracao

Confirma se Form, Classe, Banco e Procedures funcionam juntos.

### Teste de regressao

Confirma se uma correcao nao quebrou algo que ja funcionava.

## Criterios gerais de aprovacao

- Login funciona para todos os perfis.
- Senha incorreta nao permite acesso.
- Usuario inexistente nao permite acesso.
- Logout limpa a sessao e retorna ao Login.
- Dashboard mostra os menus corretos por perfil.
- Forms abrem no painel central do Dashboard.
- CRUDs principais inserem, alteram, excluem e consultam dados.
- Grids atualizam apos operacoes.
- Mensagens sao claras.
- Banco mantem integridade das FKs.
- Procedures executam sem erro.
- Fluxo integrado completo pode ser apresentado ou ter pendencia formalmente documentada.

## Evidencias esperadas

Durante a homologacao, registrar:

- Data do teste.
- Nome de quem executou.
- Perfil usado.
- Resultado esperado.
- Resultado obtido.
- Print ou descricao do erro, se ocorrer.
- Bug relacionado, se existir.

## Status da homologacao

Status atual: executada parcialmente.

Resultado:

- Desktop e banco foram testados tecnicamente com banco real.
- Dashboard por perfil aprovado.
- CRUDs principais aprovados via classes/procedures.
- Fluxo integrado aprovado ate pagamento.
- BUG-002 corrigido e retestado.
- Alguns testes visuais ficaram bloqueados para validacao manual.
- PHP permanece fora da execucao desta rodada.
