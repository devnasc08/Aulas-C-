# 03 - Relatorio Tecnico Geral

## Resumo executivo

O Flow Academy e um projeto integrado composto por um sistema web em PHP, um sistema desktop em C# e um banco de dados MySQL compartilhado. O projeto atende rotinas academicas e administrativas de uma escola tecnica presencial.

## Escopo entregue

- Modulo PHP organizado.
- Modulo C# desktop funcional.
- Banco MySQL oficial.
- Scripts auxiliares.
- Documentacao PHP.
- Documentacao C#.
- Documentacao geral.
- Relatorios tecnicos.
- Planos de teste.
- Checklists de entrega.

## Tecnologias

| Area | Tecnologia |
| --- | --- |
| Web | PHP puro |
| Frontend web | HTML, Bootstrap local, CSS complementar e JavaScript complementar |
| Desktop | C# Windows Forms |
| Framework desktop | .NET 8 |
| Banco | MySQL/MariaDB |
| Acesso PHP | PDO |
| Acesso C# | MySql.Data |
| Hash de senha | SHA256 |

## Estrutura final

```text
Projeto/
+-- FlowAcademy_php/
+-- FlowAcademy_cs/
+-- docs/
+-- procedures_para_Atual_conforme_CSharp.sql
```

## Regras centrais

- Usuario precisa estar ativo para logar.
- Perfil define permissao.
- Aluno consulta boletim e frequencia.
- Professor lanca notas e frequencia.
- Coordenacao gerencia cursos e turmas.
- Administrativo gerencia alunos, matriculas e pagamentos.
- Admin possui acesso amplo.
- Media da UC usa pesos 30%, 30%, 30% e 10%.
- Frequencia abaixo de 75% indica risco.

## Pontos fortes

- Dois modulos integrados pelo mesmo banco.
- Projeto sem frameworks pesados.
- Estrutura compreensivel para curso tecnico.
- Documentacao de apoio para entrega.
- Controle de perfil nos dois modulos.
- Banco com tabelas e procedures.

## Pontos de atencao

- Connection strings estao fixas nos codigos.
- SHA256 puro foi mantido por compatibilidade, mas nao e ideal para producao.
- Alteracoes no banco devem ser testadas nos dois modulos.
- O C# depende de procedures especificas.
- O PHP depende de caminhos relativos corretos.

## Conclusao

O projeto esta estruturado como solucao academica integrada, com modulo web e desktop, banco compartilhado e documentacao suficiente para apresentacao, manutencao e testes.
