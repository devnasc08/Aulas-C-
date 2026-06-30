# Flow Academy integrado

Projeto PHP simples usando Bootstrap 5 local, um tema visual reduzido do Flow Academy e o banco `flow_academy` do arquivo `database/flow 3.0.sql`.

## Como instalar

1. Copie a pasta `web-php` para o `htdocs` do XAMPP ou para a pasta publica do seu servidor PHP.
2. Abra o phpMyAdmin e importe `database/flow_academy_banco_limpo.sql` para criar o banco do zero com apenas as contas iniciais.
3. Execute `database/criar_usuario_aplicacao.sql` no MySQL Workbench ou phpMyAdmin conectado como administrador.
4. Confira os dados de conexao em `config/config.php`.
5. Acesse `http://localhost/web-php/login.php`.

## Usuarios iniciais

Existe uma conta de cada perfil, todas com a senha inicial `123456`. No primeiro login,
o sistema exige que a senha seja alterada porque `ultimo_login` esta como `NULL`.

- `admin@flowacademy.com`
- `coordenacao@flowacademy.com`
- `administrativo@flowacademy.com`
- `professor@flowacademy.com`
- `aluno@flowacademy.com`

O banco inicia sem cursos, turmas, UCs, matriculas, notas, frequencias, pagamentos,
alertas e logs. Ele mantem somente os cadastros basicos do usuario aluno na tabela
`alunos` e do usuario professor na tabela `professores`, para ambos poderem acessar
seus dashboards. Para limpar um banco que ja possui dados sem recriar as tabelas, execute
`database/limpar_dados_e_criar_usuarios.sql`.

## O que explicar

- `config/config.php`: cria a conexao PDO com o MySQL.
- `includes/auth.php`: controla login, sessao, permissao por perfil e logout.
- `includes/funcoes.php`: guarda funcoes pequenas de consulta, escape HTML, datas e dinheiro.
- `includes/layout.php`: monta sidebar, topbar e carrega Bootstrap + o tema `assets/css/main.css`.
- `assets/vendor/bootstrap`: guarda os arquivos locais do Bootstrap, sem depender de CDN.
- `assets/css/main.css`: personaliza cores, sidebar, cards e formularios mantendo a identidade visual do Flow.
- `assets/js/app.js`: guarda apenas comportamentos proprios, como filtro de turma/aluno, mascara e busca na tabela.
- `login.php`: consulta a tabela `usuarios` e valida a senha usando SHA256.
- Formulario de aluno: cria primeiro `usuarios`, depois `alunos`, usando transacao.
- Edicao de aluno: atualiza `usuarios` e `alunos` juntos, tambem usando transacao.
- Cadastro de professor: somente `admin`, cria `usuarios` com perfil `professor` e depois `professores`.
- Lancamento de notas: valida notas de 0 a 10, calcula a media no PHP e usa `INSERT ... ON DUPLICATE KEY UPDATE` para salvar.
- Matricula: usa uma transacao, confere a capacidade da turma e faz o `INSERT` diretamente pelo PHP.
- O projeto nao usa procedures nem functions armazenadas: as regras de negocio ficam comentadas nas classes e paginas PHP.
- Cadastro de curso: cada UC possui nome e carga horaria propria, gravada em `disciplinas.carga_horaria`.
- Edicao de curso: UCs sem notas ou frequencias podem ser alteradas ou removidas pela lista de unidades cadastradas.

## Perfis

O banco oficial possui os perfis `aluno`, `professor`, `coordenacao`, `administrativo` e `admin`.
O perfil `administrativo` abre diretamente o dashboard administrativo, que concentra cadastros, matriculas e pagamentos.

## Atualizar um banco ja existente

Caso o banco ja tenha sido importado antes desta versao, execute uma unica vez o arquivo
`database/migrar_perfil_financeiro_para_administrativo.sql` no phpMyAdmin. Ele converte os
usuarios existentes de `financeiro` para `administrativo` e remove o perfil antigo do ENUM.
