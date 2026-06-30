# Status Geral do Projeto

## Criterios de percentual

Os percentuais abaixo indicam maturidade tecnica observada, considerando existencia de codigo, alinhamento com banco, padronizacao, testes executados e risco para entrega. Eles nao representam tempo de desenvolvimento.

| Modulo | Situacao | Percentual | Pendencias | Dependencias | Prioridade |
|---|---:|---:|---|---|---|
| Login | Aprovado com ressalva | 88% | Validar manualmente campos vazios, logout e retorno visual ao login; decidir reset da conta `administrativo@flowacademy.com` | Usuarios, Banco | Alta |
| Usuario | Testado no fluxo integrado | 86% | Revisao fina de padrao `MontarObjeto()` em etapa futura | Banco, Procedures | Alta |
| Aluno | Testado no fluxo integrado | 86% | Validacao visual do grid e mensagens | Usuario, Banco | Alta |
| Professor | Testado no fluxo integrado | 86% | Validacao visual do grid e mensagens | Usuario, Banco | Alta |
| Curso | Testado no fluxo integrado | 88% | Validacao visual do grid e mensagens | Banco | Alta |
| Disciplina | Testado no fluxo integrado | 86% | Validacao visual do combo e grid | Curso | Alta |
| Turma | Testado no fluxo integrado | 84% | Validar manualmente mensagens de FK/vagas | Curso, Professor | Alta |
| Matricula | Testado no fluxo integrado | 84% | Validar manualmente mensagens de FK e grid | Aluno, Turma | Alta |
| Nota | Testado no fluxo integrado | 84% | Conferir visualmente calculo/mensagens no Form | Matricula, Disciplina | Media |
| Frequencia | Testado no fluxo integrado | 84% | Conferir visualmente calculo/mensagens no Form | Matricula, Disciplina | Media |
| Pagamento | Testado no fluxo integrado | 84% | Avaliar futuramente ComboBox de aluno; validar mensagens | Aluno | Media |
| Alerta | Pendente no Desktop | 55% | Nao existe `FrmAlertaRisco`; regra precisa de decisao de escopo | Matricula, Nota, Frequencia | Media |
| Dashboard | Testado por perfil | 92% | Validar manualmente aparencia e logout durante ensaio | Login, Sessao, Forms | Alta |
| Landing Page | Pendente de revisao | 50% | Revisar conteudo e fluxo | PHP | Baixa |
| Banco | Validado em homologacao | 90% | Definir/exportar script SQL mestre unico para a banca | Todos os modulos | Critica |
| Procedures | Validadas no banco real | 92% | Manter script oficial de procedures sincronizado | Banco, Classes | Critica |
| PHP | Funcional com revisao pendente | 65% | Validar SQL, permissoes e dashboards Web | Banco | Media |
| Forms Desktop | Homologados tecnicamente | 88% | Testes visuais manuais de mensagens, refresh de grid e logout | Classes, Banco | Alta |
| Homologacao | Executada parcialmente | 78% | Executar testes manuais bloqueados e preparar evidencias | Banco, Desktop, PHP | Alta |
| Documentacao | Sincronizada com homologacao | 80% | Completar manuais finais e evidencias para banca | Auditoria | Alta |
| Apresentacao | Em preparacao | 55% | Definir responsaveis, roteiro final, prints e ensaio | Homologacao | Media |

## Resumo

O Desktop passou na homologacao tecnica do fluxo principal: login, Dashboard por perfil, abertura dos Forms, CRUDs via classes/procedures, integridade de banco e fluxo integrado ate pagamento. O build final terminou com 0 erros e 0 warnings.

As principais ressalvas atuais sao: conta `administrativo@flowacademy.com` sem senha padrao, ausencia de `FrmAlertaRisco`, testes visuais manuais ainda pendentes e necessidade de definir/exportar um script SQL mestre unico para a banca.
