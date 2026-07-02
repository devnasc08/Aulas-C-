# 10 - Plano de Testes

## Objetivo

Este plano orienta a validacao manual do Flow Academy PHP antes da entrega. O foco e confirmar que login, navegacao, permissoes, cadastros e principais regras academicas funcionam sem quebrar a estrutura reorganizada.

## Ambiente de teste

- Apache iniciado.
- MySQL ou MariaDB iniciado.
- Banco `flow_academy` importado.
- Arquivo `web-php/config/config.php` configurado.
- Navegador atualizado.

## Criterios de aceite

- O sistema abre sem erro fatal de PHP.
- O login funciona para usuario ativo.
- Cada perfil acessa apenas suas telas permitidas.
- Menus carregam com CSS e JavaScript.
- CRUDs principais carregam, salvam e consultam dados.
- Notas calculam media corretamente.
- Frequencia salva total de aulas e presencas.
- Pagamentos exibem status correto.
- Logout encerra a sessao.

## Casos de teste

### CT01 - Abrir pagina inicial

Pre-condicao:

- Servidor local iniciado.

Passos:

1. Acessar `http://localhost/FlowAcademy_php/web-php/index.php`.
2. Conferir se a landing page carrega.
3. Clicar em `Entrar`.

Resultado esperado:

- A pagina inicial carrega com logo, textos, estilo e link para login.
- O clique leva para `login.php`.

### CT02 - Login valido

Pre-condicao:

- Usuario ativo cadastrado na tabela `usuarios`.

Passos:

1. Abrir `login.php`.
2. Informar e-mail e senha validos.
3. Enviar formulario.

Resultado esperado:

- O sistema cria sessao.
- O usuario e redirecionado para o dashboard do seu perfil.

### CT03 - Login invalido

Passos:

1. Abrir `login.php`.
2. Informar e-mail inexistente ou senha incorreta.
3. Enviar formulario.

Resultado esperado:

- O sistema permanece no login.
- Exibe mensagem de erro.
- Nao cria sessao valida.

### CT04 - Controle de permissao

Passos:

1. Entrar como aluno.
2. Tentar acessar uma pagina de admin diretamente pela URL.

Resultado esperado:

- O sistema bloqueia o acesso.
- O usuario volta ao painel permitido.
- Uma mensagem informa falta de permissao.

### CT05 - Logout

Passos:

1. Entrar com qualquer perfil.
2. Clicar em sair.
3. Tentar voltar para uma pagina interna.

Resultado esperado:

- A sessao e encerrada.
- O usuario e redirecionado ao login.

### CT06 - Dashboard do aluno

Passos:

1. Entrar como aluno.
2. Abrir dashboard.
3. Acessar boletim.
4. Acessar frequencia.

Resultado esperado:

- As tres telas carregam.
- Boletim exibe notas quando existirem.
- Frequencia exibe registros quando existirem.

### CT07 - Lancamento de notas

Pre-condicao:

- Professor vinculado a turma.
- Aluno matriculado.
- Curso com unidade curricular.

Passos:

1. Entrar como professor.
2. Abrir `Lancar Notas`.
3. Selecionar turma, aluno e unidade curricular.
4. Informar notas entre 0 e 10.
5. Salvar.

Resultado esperado:

- A nota e salva.
- A media e calculada com pesos 30%, 30%, 30% e 10%.
- O status fica aprovado ou reprovado conforme a media.

### CT08 - Validacao de nota invalida

Passos:

1. Entrar como professor.
2. Abrir `Lancar Notas`.
3. Informar nota menor que 0 ou maior que 10.
4. Salvar.

Resultado esperado:

- O sistema bloqueia o salvamento.
- Uma mensagem de validacao aparece.

### CT09 - Registro de frequencia

Passos:

1. Entrar como professor.
2. Abrir `Registrar Frequencia`.
3. Selecionar turma, aluno e unidade curricular.
4. Informar total de aulas e presencas.
5. Salvar.

Resultado esperado:

- Frequencia e salva.
- Percentual e exibido corretamente.

### CT10 - Cadastro de aluno

Passos:

1. Entrar como administrativo ou admin.
2. Abrir cadastro de aluno.
3. Preencher dados obrigatorios.
4. Salvar.

Resultado esperado:

- Usuario e aluno sao criados.
- Aluno aparece na listagem.

### CT11 - Matricula

Passos:

1. Entrar como administrativo ou admin.
2. Abrir matricula.
3. Selecionar aluno e turma ativa.
4. Salvar.

Resultado esperado:

- Matricula e criada.
- O sistema impede matricula duplicada na mesma turma.
- O sistema respeita a capacidade da turma.

### CT12 - Cadastro de curso e UCs

Passos:

1. Entrar como coordenacao ou admin.
2. Criar curso.
3. Adicionar unidade curricular.
4. Salvar.

Resultado esperado:

- Curso aparece na listagem.
- Unidade curricular fica vinculada ao curso.

### CT13 - Cadastro de turma

Passos:

1. Entrar como coordenacao ou admin.
2. Abrir cadastro de turma.
3. Selecionar curso e professor.
4. Preencher codigo, turno, periodo e capacidade.
5. Salvar.

Resultado esperado:

- Turma aparece na listagem.
- Dados ficam vinculados ao curso e professor corretos.

### CT14 - Pagamentos

Passos:

1. Entrar como administrativo ou admin.
2. Abrir pagamentos.
3. Criar ou editar pagamento.
4. Conferir listagem.

Resultado esperado:

- Pagamento e salvo.
- Status e exibido corretamente.

### CT15 - Logs

Passos:

1. Entrar como admin.
2. Abrir logs.

Resultado esperado:

- A tela carrega registros de acoes, se existirem.

## Registro de resultados

Use a tabela abaixo durante a homologacao.

| Caso | Resultado | Observacao |
| --- | --- | --- |
| CT01 | Pendente |  |
| CT02 | Pendente |  |
| CT03 | Pendente |  |
| CT04 | Pendente |  |
| CT05 | Pendente |  |
| CT06 | Pendente |  |
| CT07 | Pendente |  |
| CT08 | Pendente |  |
| CT09 | Pendente |  |
| CT10 | Pendente |  |
| CT11 | Pendente |  |
| CT12 | Pendente |  |
| CT13 | Pendente |  |
| CT14 | Pendente |  |
| CT15 | Pendente |  |

