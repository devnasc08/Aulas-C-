# 05 - Relatorio de Seguranca

## Objetivo

Registrar os mecanismos de seguranca existentes e os pontos de melhoria do Flow Academy.

## Autenticacao

O sistema usa:

- E-mail.
- Senha.
- Usuario ativo.
- Hash SHA256.

PHP:

- Usa `$_SESSION`.
- Redireciona conforme perfil.

CSharp:

- Usa `AuthService`.
- Usa classe `Sessao`.
- Abre dashboard conforme usuario logado.

## Autorizacao

PHP:

- Usa `exigirPerfil()` por pagina.
- Bloqueia acesso direto sem perfil adequado.

CSharp:

- Usa `FrmPrincipal.AplicarPermissoes()`.
- Mostra ou oculta botoes conforme perfil.

## Protecao contra SQL Injection

PHP:

- Usa PDO e parametros.

CSharp:

- Usa MySqlCommand e parametros em classes e procedures.

## Protecao de saida HTML

PHP:

- Usa funcao `e()` para escapar valores exibidos.

## Pontos de atencao

- Senha com SHA256 puro nao e recomendada para producao.
- Connection string fixa deve ser evitada em ambiente real.
- Permissao no C# e principalmente visual; regras sensiveis tambem deveriam ser validadas no banco ou servico.
- Exibir detalhes de erro de banco pode revelar informacoes tecnicas.

## Recomendacoes futuras

- Usar variaveis de ambiente para credenciais.
- Usar `password_hash()` no PHP e algoritmo equivalente no C# em versao futura.
- Criar tabela de permissoes mais granular.
- Registrar tentativas de login invalido.
- Adicionar CSRF em formularios PHP.
- Revisar mensagens de erro em ambiente de producao.

## Conclusao

O projeto possui controles basicos adequados ao contexto academico e ao curso tecnico, mas deve receber melhorias antes de uso em ambiente real de producao.

