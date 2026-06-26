# Roadmap Tecnico

## Fase 1 - Banco e Procedures

Objetivo: estabilizar a base usada pelo Desktop e pelo PHP.

Atividades:

- Confirmar script SQL oficial.
- Alinhar procedures chamadas pelo C#.
- Nao alterar tabelas sem decisao formal.
- Validar parametros e compatibilidade.

Justificativa: sem procedures alinhadas, os CRUDs do Desktop podem falhar.

## Fase 2 - Classes C#

Objetivo: padronizar as entidades.

Atividades:

- Revisar uma classe por vez.
- Garantir metodos obrigatorios.
- Padronizar `MontarObjeto()` privado.
- Validar objetos relacionados.
- Compilar apos cada entidade.

Justificativa: as classes sao o centro das regras e do acesso ao banco no Desktop.

## Fase 3 - Forms

Objetivo: garantir que os formularios consumam corretamente as classes.

Atividades:

- Revisar botoes e eventos.
- Validar DataGridView.
- Validar ComboBox.
- Validar limpeza de tela.
- Validar mensagens.
- Remover ou isolar telas de teste se confirmado.

Justificativa: os forms sao a camada usada na apresentacao e nos testes funcionais.

## Fase 4 - Dashboard Desktop

Objetivo: finalizar o `FrmPrincipal` como painel principal por perfil.

Atividades:

- Usar dados de `Sessao`.
- Ocultar menus nao permitidos.
- Abrir formularios filhos.
- Validar perfil aluno, professor, coordenacao, administrativo, financeiro e admin conforme decisao de banco.

Justificativa: o dashboard controla a navegacao e a seguranca visual do Desktop.

## Fase 5 - PHP e Landing Page

Objetivo: validar o modulo Web contra o banco final.

Atividades:

- Revisar consultas SQL.
- Validar login e permissoes.
- Revisar landing page.
- Validar dashboards Web.

Justificativa: o PHP depende do banco estabilizado.

## Fase 6 - Testes, Documentacao e Apresentacao

Objetivo: preparar entrega final.

Atividades:

- Testar fluxo completo.
- Atualizar documentacao.
- Preparar roteiro de apresentacao.
- Ensaiar demonstracao.

Justificativa: reduz risco de falhas durante a avaliacao.

