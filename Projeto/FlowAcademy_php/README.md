# Flow Academy integrado

Projeto PHP simples usando Bootstrap 5.0.2 local, um tema visual reduzido do Flow Academy e o banco `flow_academy` do arquivo `banco/Banco_oficial.sql`.

## Documentacao

A documentacao completa esta em:

```text
docs/README.md
```

Ela inclui guia de instalacao, arquitetura, modulos, banco de dados, regras de negocio, manual do usuario e checklist de entrega.

## Como instalar

1. Copie a pasta `FlowAcademy_php` para o `htdocs` do XAMPP ou para a pasta publica do seu servidor PHP.
2. Abra o phpMyAdmin e importe `banco/Banco_oficial.sql` para criar o banco.
3. Confira os dados de conexao em `web-php/config/config.php`.
4. Acesse `http://localhost/FlowAcademy_php/web-php/login.php`.

## Usuarios iniciais

O banco oficial possui contas iniciais para demonstracao. Algumas senhas importadas no SQL podem variar conforme o dump usado. Confira os registros da tabela `usuarios` depois da importacao.

- `admin@flowacademy.com`
- `coordenacao@flowacademy.com`
- `administrativo@flowacademy.com`
- `professor@flowacademy.com`
- `aluno@flowacademy.com`

O banco oficial ja possui estrutura, registros de exemplo e rotinas armazenadas. Use esses dados para testar os principais perfis e fluxos do sistema.

## O que explicar

- `web-php/config/config.php`: cria a conexao PDO com o MySQL.
- `web-php/classes/database/Conexao.php`: carrega a conexao usada pelas classes.
- `web-php/classes/models/`: guarda entidades como aluno, professor, curso, turma, nota e usuario.
- `web-php/classes/services/`: guarda servicos de autenticacao, notas, frequencia e matricula.
- `web-php/includes/auth.php`: controla login, sessao, permissao por perfil e logout.
- `web-php/includes/helpers.php`: guarda funcoes pequenas de consulta, escape HTML, flash e redirecionamento.
- `web-php/includes/formatacao.php`: concentra datas, moeda, badges e textos exibidos na tela.
- `web-php/includes/validacoes.php`: concentra validacoes simples usadas pelas paginas.
- `web-php/includes/layout.php`: monta sidebar, topbar e carrega primeiro o Bootstrap local.
- `web-php/assets/bootstrap`: guarda a distribuicao local do Bootstrap 5.0.2, sem depender de CDN.
- `web-php/assets/css/main.css`: complemento visual do projeto, carregado depois do Bootstrap.
- `web-php/assets/js/app.js`: complemento de comportamento, carregado depois do `bootstrap.bundle.min.js`.
- `web-php/assets/img/logos`: guarda os logos usados na landing page e no sistema.
- `login.php`: consulta a tabela `usuarios` e valida a senha usando SHA256.
- Formulario de aluno: cria primeiro `usuarios`, depois `alunos`, usando transacao.
- Edicao de aluno: atualiza `usuarios` e `alunos` juntos, tambem usando transacao.
- Cadastro de professor: somente `admin`, cria `usuarios` com perfil `professor` e depois `professores`.
- Lancamento de notas: valida notas de 0 a 10, calcula a media no PHP e usa `INSERT ... ON DUPLICATE KEY UPDATE` para salvar.
- Matricula: usa uma transacao, confere a capacidade da turma e faz o `INSERT` diretamente pelo PHP.
- O PHP executa as principais telas com SQL via PDO; o SQL oficial tambem possui procedures e functions para apoio e compatibilidade.
- Cadastro de curso: cada UC possui nome e carga horaria propria, gravada em `disciplinas.carga_horaria`.
- Edicao de curso: UCs sem notas ou frequencias podem ser alteradas ou removidas pela lista de unidades cadastradas.

## Perfis

O banco oficial possui os perfis `aluno`, `professor`, `coordenacao`, `administrativo` e `admin`.
O perfil `administrativo` abre diretamente o dashboard administrativo, que concentra cadastros, matriculas e pagamentos.

## Atualizar um banco ja existente

Caso o banco ja tenha sido importado antes desta versao, confira o script oficial em
`banco/Banco_oficial.sql` antes de executar alteracoes manuais.
