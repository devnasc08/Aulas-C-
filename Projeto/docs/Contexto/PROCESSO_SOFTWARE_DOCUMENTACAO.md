# Processo de Software descrito pela documentacao

## Visao geral

A documentacao descreve a Flow Academy Platform como uma plataforma academica web integrada para substituir processos manuais, reduzir retrabalho, centralizar dados academicos e preparar a instituicao para crescimento presencial, EAD, multiunidades e analytics.

O processo de software documentado segue uma linha bem clara:

1. Entendimento do negocio e visao do produto.
2. Levantamento de requisitos e regras de negocio.
3. Descricao dos casos de uso por ator e modulo.
4. Definicao da arquitetura tecnica.
5. Rastreabilidade entre requisitos, casos de uso, banco, telas, rotas e testes.
6. Modelagem relacional do banco de dados.
7. DER como mapa tecnico para SQL, migrations, models, repositories e services.
8. Evolucao controlada por versoes, analise de impacto e roadmap.

## Produto e objetivo de negocio

O produto documentado e uma plataforma academica para cursos tecnicos e livres, com suporte a operacao presencial, EAD e expansao para novas unidades.

O problema principal identificado e a dependencia de planilhas e processos manuais para matriculas, acompanhamento academico, comunicacao entre setores, controle de turmas e expansao operacional.

O objetivo do sistema e integrar processos academicos, pedagogicos, administrativos e digitais, com foco em:

- Cadastro e gestao de alunos, professores, cursos e turmas.
- Matriculas e controle de vagas.
- Lancamento de notas e frequencia.
- Portal do aluno e portal do professor.
- Coordenacao academica com dashboards e relatorios.
- Financeiro basico.
- Base futura para EAD, BI, analytics, IA e APIs.

## Modulos previstos

A documentacao organiza o sistema em modulos de negocio:

- Portal Institucional.
- Autenticacao e Controle de Acesso.
- Gestao Academica.
- Matriculas.
- Gestao Pedagogica.
- Portal do Aluno.
- Portal do Professor.
- Coordenacao Academica.
- Financeiro.
- EAD / Conteudo Digital.
- Analytics e BI Academico.

Essa modularizacao aparece tambem na arquitetura, na modelagem de dados e na rastreabilidade.

## Atores do sistema

Os atores oficiais levantados sao:

- Visitante.
- Aluno.
- Professor.
- Coordenacao.
- Administrativo.
- Financeiro.
- Sistema, para servicos automaticos.

Cada ator tem permissoes e interacoes especificas. A regra central de acesso e que cada usuario so deve acessar recursos compativeis com seu perfil.

## Requisitos e regras de negocio

Os requisitos funcionais cobrem autenticacao, cadastros academicos, matriculas, notas, frequencia, portais, dashboards e relatorios.

Regras de negocio importantes:

- Cada usuario acessa apenas recursos do seu perfil.
- O aluno visualiza somente suas proprias informacoes.
- O professor visualiza somente turmas sob sua responsabilidade.
- Cada turma pode ter no maximo 35 alunos.
- Um aluno so pode ser matriculado uma vez em uma turma por curso.
- Apenas professores podem lancar notas e frequencia.
- Frequencia minima de 75% para aprovacao.
- A aprovacao por nota segue criterios institucionais.
- Feedbacks docentes sao restritos a coordenacao.

Os requisitos nao funcionais pedem compatibilidade com navegadores modernos, interface responsiva, resposta media de ate 3 segundos, usuarios simultaneos, autenticacao segura, protecao de dados sensiveis, sessoes seguras, controle de permissoes, usabilidade e disponibilidade no horario institucional.

## Casos de uso principais

Os casos de uso documentados representam os fluxos centrais do MVP:

- UC-001: Autenticar usuario.
- UC-002: Realizar matricula.
- UC-003: Lancar notas.
- UC-004: Registrar frequencia.
- UC-005: Consultar desempenho academico.
- UC-006: Monitorar turmas.

Cada caso de uso deve manter vinculo com requisito funcional, regra de negocio, modulo, endpoint, tabela de banco, tela e teste funcional.

## Arquitetura proposta

A arquitetura oficial proposta e MVC com arquitetura em camadas e modularizacao por dominio.

Camadas previstas:

- Apresentacao / frontend.
- Controllers.
- Services de negocio.
- Repositories / persistencia.
- Banco de dados.

Stack documentada:

- Frontend: HTML5, CSS3, JavaScript e Bootstrap.
- Backend web: PHP 8+.
- Banco: MySQL.
- Servidor: Apache em VM homologada.
- Versionamento: Git e GitHub privado.
- Evolucao futura: APIs em C# para microsservicos estrategicos, especialmente analytics e BI.

O projeto atual tambem possui implementacao C# desktop/WinForms, o que deve ser tratado na analise como uma entrega em andamento que precisa ser comparada com a visao web/PHP documentada.

## Seguranca e controle de acesso

A documentacao exige:

- Autenticacao por sessao segura.
- Hash de senha.
- Controle RBAC por perfil.
- Middleware de autorizacao.
- Protecao contra SQL Injection.
- Protecao contra CSRF.
- Validacao server-side.
- Logs de login e auditoria.

## Dados e DER

A modelagem de dados usa MySQL, modelo relacional normalizado e entidades separadas por dominios.

Entidades principais:

- usuarios.
- alunos.
- professores.
- cursos.
- turmas.
- matriculas.
- disciplinas.
- notas.
- frequencia.
- feedbacks.
- relatorios.
- alertas_risco.
- trilhas_ead.
- aulas_digitais.

Relacionamentos centrais:

- usuarios 1:1 alunos.
- usuarios 1:1 professores.
- cursos 1:N turmas.
- cursos 1:N disciplinas.
- turmas 1:N matriculas.
- alunos 1:N matriculas.
- matriculas 1:N notas.
- matriculas 1:N frequencia.
- cursos 1:N trilhas_ead.
- trilhas_ead 1:N aulas_digitais.

Regras de integridade documentadas:

- CPF unico por aluno e professor.
- E-mail unico por usuario.
- Uma matricula por aluno por turma.
- Nota entre 0 e 10.
- Frequencia minima de 75%.
- Capacidade maxima da turma.
- Bloqueio de exclusoes que comprometam registros ativos.

## Governanca, rastreabilidade e versoes

A rastreabilidade e tratada como obrigatoria. Toda funcionalidade deve conectar:

- Requisito funcional.
- Caso de uso.
- Modulo.
- Entidade de banco.
- Endpoint ou rota.
- Tela.
- Prioridade.
- Teste funcional.

O padrao tecnico esperado e:

Route -> Controller -> Service -> Repository -> Tabela

Toda mudanca deve responder:

- Qual requisito foi alterado?
- Qual caso de uso foi impactado?
- Quais telas mudam?
- Quais tabelas mudam?
- Ha impacto em API?
- Ha impacto em regra de negocio?
- Exige migracao de banco?
- Impacta a arquitetura futura?

O versionamento previsto e semantico:

- MAJOR para mudancas estruturais grandes.
- MINOR para novos modulos ou funcionalidades.
- PATCH para correcoes e ajustes.

## Qualidade e entrega

A documentacao pede testes para fluxos criticos, principalmente:

- Login valido.
- Senha invalida.
- Matricula em turma lotada.
- Nota fora do intervalo.
- Frequencia abaixo de 75%.

Tambem pede codigo limpo, padrao PSR no PHP, separacao de responsabilidades, logs de erro, auditoria e monitoramento de falhas de autenticacao.

## Leitura critica para a fase atual

Como o projeto esta em andamento e proximo da entrega, a analise deve verificar principalmente:

- Se o que foi implementado corresponde aos requisitos e casos de uso.
- Se as regras de negocio aparecem no codigo e no banco.
- Se os perfis de acesso estao protegidos corretamente.
- Se a estrutura real do projeto respeita a arquitetura em camadas.
- Se PHP, C# desktop, banco e documentacao estao coerentes entre si.
- Se existem funcionalidades documentadas mas ausentes na entrega.
- Se existem funcionalidades implementadas mas nao documentadas.
- Se ha riscos de seguranca, consistencia de dados ou apresentacao.
- Se ha evidencias minimas de teste para os fluxos criticos.

