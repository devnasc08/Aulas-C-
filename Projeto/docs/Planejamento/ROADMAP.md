# Roadmap Tecnico

## Fase 1 - Banco e Procedures

Objetivo: estabilizar a base usada pelo Desktop e pelo PHP.

Atividades:

- Confirmar script SQL oficial. Status: parcialmente concluido; estrutura base identificada e script de procedures definido.
- Alinhar procedures chamadas pelo C#. Status: concluido na validacao tecnica.
- Nao alterar tabelas sem decisao formal. Status: mantido.
- Validar parametros e compatibilidade. Status: aprovado nos testes de CRUD com banco real.

Justificativa: sem procedures alinhadas, os CRUDs do Desktop falham.

## Fase 2 - Classes C#

Objetivo: padronizar as entidades.

Atividades:

- Revisar uma classe por vez.
- Garantir metodos obrigatorios.
- Padronizar `MontarObjeto()` privado.
- Validar objetos relacionados.
- Compilar apos cada entidade.
- Executar CRUDs principais no banco real. Status: aprovado tecnicamente na homologacao.

Justificativa: as classes sao o centro das regras e do acesso ao banco no Desktop.

## Fase 3 - Forms

Objetivo: garantir que os formularios consumam corretamente as classes.

Atividades:

- Revisar botoes e eventos. Status: concluido na verificacao estatica da Etapa 4.
- Validar DataGridView. Status: parcialmente validado; refresh visual ainda precisa de teste manual.
- Validar ComboBox. Status: parcialmente validado pelo fluxo com banco.
- Validar limpeza de tela. Status: pendente de teste manual.
- Validar mensagens. Status: pendente de teste manual.
- Remover telas de teste se confirmado. Status: `FrmTeste` removido na etapa de congelamento.
- Testar os CRUDs com banco MySQL disponivel. Status: aprovado tecnicamente.
- Definir se `FrmAlertaRisco` sera criado em etapa propria. Status: pendente; nao criar nesta entrega sem decisao do grupo.

Justificativa: os Forms sao a camada usada na apresentacao e nos testes funcionais.

## Fase 4 - Dashboard Desktop

Objetivo: finalizar o `FrmPrincipal` como painel principal por perfil.

Atividades:

- Usar dados de `Sessao`. Status: concluido.
- Ocultar menus nao permitidos. Status: concluido e homologado.
- Abrir formularios filhos. Status: concluido e homologado.
- Normalizar `financeiro` como `administrativo`. Status: concluido e homologado.
- Validar perfil aluno, professor, coordenacao, administrativo, financeiro e admin. Status: aprovado com ressalva na conta administrativa padrao.
- Corrigir admin sem Notas/Frequencia. Status: concluido no BUG-002.

Justificativa: o dashboard controla a navegacao e a seguranca visual do Desktop.

## Fase 5 - PHP e Landing Page

Objetivo: validar o modulo Web contra o banco final.

Atividades:

- Revisar consultas SQL.
- Validar login e permissoes.
- Revisar landing page.
- Validar dashboards Web.

Justificativa: o PHP depende do banco estabilizado e deve manter regras compativeis com Desktop.

## Fase 6 - Testes, Documentacao e Apresentacao

Objetivo: preparar entrega final.

Atividades:

- Criar documentos de homologacao. Status: concluido.
- Testar fluxo completo. Status: aprovado ate pagamento; alerta reprovado por ausencia de Form Desktop; logout visual bloqueado para teste manual.
- Atualizar documentacao. Status: concluido nesta etapa.
- Preparar roteiro de apresentacao. Status: iniciado.
- Ensaiar demonstracao. Status: pendente.

Justificativa: reduz risco de falhas durante a avaliacao.

## Proximas acoes recomendadas

1. Decidir se a conta `administrativo@flowacademy.com` sera resetada para a senha padrao usada na apresentacao.
2. Exportar ou montar um SQL mestre unico contendo estrutura final, dados de demonstracao e procedures alinhadas.
3. Executar os testes manuais bloqueados: campos vazios, MessageBox, logout, retorno ao login e refresh visual dos grids.
4. Ensaiar o fluxo de banca com banco limpo de demonstracao.
5. Revisar PHP e Landing Page somente depois do Desktop estar congelado.

Documentos de apoio:

- `docs/Homologacao/PLANO_DE_TESTES.md`
- `docs/Homologacao/CASOS_DE_TESTE.md`
- `docs/Homologacao/MATRIZ_RASTREABILIDADE.md`
- `docs/Homologacao/RELATORIO_HOMOLOGACAO.md`
- `docs/Homologacao/REGISTRO_DE_BUGS.md`
- `docs/Homologacao/CRITERIOS_DE_ACEITE.md`
- `docs/Homologacao/CHECKLIST_FINAL_ENTREGA.md`
