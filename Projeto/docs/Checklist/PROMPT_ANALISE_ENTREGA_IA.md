# Prompt para IA avaliar a entrega do projeto

Use este prompt em uma IA com acesso ao repositorio do projeto.

```text
Voce e um avaliador tecnico senior de software. Analise este projeto da Flow Academy Platform, que ja esta em andamento e proximo da entrega.

IMPORTANTE:
- Nao implemente alteracoes.
- Nao corrija codigo.
- Nao refatore arquivos.
- Nao apague, mova ou renomeie nada.
- Sua tarefa e somente avaliar, analisar e documentar achados.
- Toda documentacao, contexto, relatorios e arquivos gerados por voce devem ficar dentro da pasta docs do projeto.
- Se a pasta docs ja existir, preserve o conteudo atual e adicione apenas novos arquivos de analise.
- Se precisar criar subpastas, use nomes claros dentro de docs, por exemplo docs/Auditoria, docs/Contexto, docs/Checklist ou docs/Entrega.

Contexto do produto:
O projeto e a Flow Academy Platform, uma plataforma academica para cursos tecnicos e livres. A visao documentada espera uma solucao integrada para gestao academica, matriculas, notas, frequencia, portal do aluno, portal do professor, coordenacao, financeiro, EAD e analytics.

Documentacao base esperada:
- 01_Doc_Visao: define objetivo de negocio, escopo, stakeholders, modulos e criterios de sucesso.
- 02_Doc_Requisitos_RN: define requisitos funcionais, regras de negocio e requisitos nao funcionais.
- 03_Casos_de_Uso: define fluxos principais, excecoes e vinculos com requisitos.
- 04_Arquitetura_do_Sistema: define MVC, camadas, modularizacao por dominio, PHP 8+, MySQL, Bootstrap, Apache e evolucao futura com C#.
- 05_Rastreabilidade_e_Versoes: define matriz RF -> UC -> modulo -> entidade BD -> endpoint/rota -> tela -> teste.
- 06_Modelagem_de_Dados: define entidades, relacionamentos, integridade e evolucao do banco.
- 07_DER_Diagrama_Entidade-Relacionamento: define o mapa relacional oficial para SQL, migrations, models, repositories e services.

Pontos centrais que a documentacao exige:
- Perfis: visitante, aluno, professor, coordenacao, administrativo, financeiro e sistema.
- Controle de acesso por perfil.
- Aluno so visualiza as proprias informacoes.
- Professor so visualiza turmas sob sua responsabilidade.
- Turma com no maximo 35 alunos.
- Um aluno nao pode ter matricula duplicada na mesma turma/curso.
- Frequencia minima de 75%.
- Notas devem estar em intervalo valido.
- Apenas professores lancam notas e frequencia.
- Feedback docente restrito a coordenacao.
- Arquitetura em camadas: rota/controller -> service -> repository -> tabela.
- Banco relacional MySQL com chaves, indices, integridade e auditoria.
- Testes minimos para login, senha invalida, turma lotada, nota invalida e frequencia abaixo de 75%.

Escopo de analise:
1. Analise a estrutura geral do repositorio.
2. Identifique quais tecnologias estao realmente presentes, como PHP, C#, WinForms, MySQL, Bootstrap ou outras.
3. Compare a implementacao real com a documentacao de visao, requisitos, casos de uso, arquitetura, rastreabilidade, modelagem e DER.
4. Avalie se as regras de negocio estao implementadas no codigo, no banco ou em ambos.
5. Avalie se a seguranca esta adequada para uma entrega academica/profissional:
   - autenticacao;
   - controle de sessao;
   - controle de permissoes;
   - hash de senha;
   - protecao contra SQL Injection;
   - protecao contra CSRF quando aplicavel;
   - validacao server-side;
   - exposicao de dados sensiveis.
6. Avalie a arquitetura:
   - separacao de responsabilidades;
   - controllers/pages;
   - services;
   - repositories ou acesso a dados;
   - models/classes;
   - duplicacao entre PHP e C#;
   - coerencia com MVC/camadas.
7. Avalie o banco de dados:
   - tabelas existentes vs entidades documentadas;
   - chaves primarias e estrangeiras;
   - constraints;
   - indices;
   - procedures;
   - dados de teste;
   - compatibilidade com os fluxos do sistema.
8. Avalie a interface e fluxos principais:
   - login;
   - dashboards por perfil;
   - cadastro de alunos;
   - cadastro de professores;
   - cursos;
   - turmas;
   - matriculas;
   - notas;
   - frequencia;
   - financeiro;
   - coordenacao/analytics;
   - portal do aluno;
   - portal do professor.
9. Avalie prontidao para entrega:
   - funcionalidades completas;
   - funcionalidades parciais;
   - funcionalidades ausentes;
   - bugs provaveis;
   - riscos altos;
   - pontos que podem prejudicar apresentacao;
   - pendencias obrigatorias antes da entrega.

Formato de saida obrigatorio:
Crie ou atualize arquivos dentro de docs com os seguintes relatorios:

1. docs/Auditoria/ANALISE_ENTREGA_GERAL.md
   - resumo executivo;
   - status geral da entrega;
   - principais riscos;
   - pontos fortes;
   - pendencias criticas.

2. docs/Auditoria/MATRIZ_DOCUMENTACAO_IMPLEMENTACAO.md
   - tabela comparando documentacao vs implementacao;
   - colunas: item documentado, onde deveria aparecer, evidencia encontrada, status, observacao.
   - use status: OK, PARCIAL, AUSENTE, RISCO.

3. docs/Auditoria/REGRAS_NEGOCIO_E_SEGURANCA.md
   - analise das regras de negocio;
   - analise de autenticacao e permissoes;
   - riscos de seguranca;
   - evidencias por arquivo.

4. docs/Auditoria/ANALISE_BANCO_DADOS.md
   - comparacao entre modelagem/DER e SQL real;
   - tabelas, campos, chaves, constraints e procedures;
   - divergencias e recomendacoes.

5. docs/Auditoria/PRONTIDAO_ENTREGA.md
   - checklist final de entrega;
   - o que esta pronto;
   - o que precisa ajuste;
   - o que pode ser apresentado mesmo com ressalvas;
   - ordem de prioridade para ultimos ajustes.

Regras para escrever os relatorios:
- Seja objetivo, tecnico e direto.
- Cite caminhos de arquivos e, quando possivel, nomes de funcoes/classes/tabelas.
- Separe achados por severidade: Critico, Alto, Medio, Baixo.
- Nao invente evidencia: se nao encontrou, marque como AUSENTE ou NAO LOCALIZADO.
- Diferencie claramente documentacao ideal, implementacao real e recomendacao.
- Evite sugerir grandes refatoracoes se a entrega estiver proxima; priorize correcoes de alto impacto e baixo risco.
- Ao final, gere uma lista de prioridades para a equipe executar antes da apresentacao.
```

