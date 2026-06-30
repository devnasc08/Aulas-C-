# Preparacao da Banca

## Objetivo

Organizar as atividades finais da equipe para apresentar o Flow Academy com seguranca e rastreabilidade.

## Roteiro recomendado

1. Introducao do problema e objetivo do Flow Academy.
2. Arquitetura geral: Desktop, PHP e banco MySQL compartilhado.
3. Banco de dados: tabelas principais, relacionamentos e procedures.
4. Desktop: login, Dashboard e CRUDs principais.
5. Fluxo integrado: usuario, professor, curso, disciplina, turma, aluno, matricula, nota, frequencia e pagamento.
6. Web: login e dashboards por perfil, se ja homologados.
7. Homologacao: plano de testes, bugs encontrados e situacao atual.
8. Encerramento: aprendizados, pendencias e proximos passos.

## Demonstracao ao vivo

Usar preferencialmente um banco limpo de demonstracao.

Fluxo sugerido:

1. Entrar como admin.
2. Mostrar Dashboard.
3. Cadastrar usuario.
4. Cadastrar professor.
5. Cadastrar curso.
6. Cadastrar disciplina.
7. Cadastrar turma.
8. Cadastrar aluno.
9. Realizar matricula.
10. Lancar nota.
11. Registrar frequencia.
12. Registrar pagamento.
13. Fazer logout.

## Pontos que devem ser ensaiados

- Senha correta da conta usada na banca.
- Tempo de execucao do fluxo.
- Mensagens de validacao.
- Atualizacao dos grids.
- Retorno ao login apos sair.
- Banco inicial sem dados temporarios de homologacao.

## Evidencias recomendadas

- Print do build sem erros.
- Print do Dashboard admin.
- Print de um CRUD funcionando.
- Print do relatorio de homologacao.
- Print do registro de bugs.
- Script SQL mestre ou ordem oficial de aplicacao dos scripts.

## Divisao de falas

A equipe deve preencher:

| Parte | Integrante |
|---|---|
| Introducao | A definir |
| Arquitetura | A definir |
| Banco | A definir |
| Desktop | A definir |
| PHP | A definir |
| Homologacao | A definir |
| Encerramento | A definir |

## Perguntas provaveis

- Por que Desktop e PHP nao se comunicam diretamente?
- Por que o Desktop usa procedures para escrita?
- Por que o PHP usa SQL direto?
- Como as permissoes sao controladas?
- Como o banco garante integridade?
- Quais bugs foram encontrados na homologacao?
- O que ficou como melhoria futura?

## Respostas tecnicas esperadas

- A integracao entre Desktop e PHP ocorre pelo banco MySQL compartilhado.
- O Desktop segue o padrao Forms -> Classes -> Banco.cs -> MySQL.
- INSERT, UPDATE e DELETE do Desktop usam procedures.
- SELECT e SELECT por ID usam SQL direto nas classes.
- O PHP usa PDO e SQL direto por simplicidade.
- O Dashboard Desktop usa `Sessao.NivelAcesso` para ocultar menus.
- Bugs e pendencias estao documentados em `docs/Homologacao/REGISTRO_DE_BUGS.md`.
