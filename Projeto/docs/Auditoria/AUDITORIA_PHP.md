# Auditoria PHP

## O que esta correto

- PHP usa SQL direto, conforme padrao definido para o modulo Web.
- Existe controle de sessao e autenticacao em `includes/auth.php`.
- Existe layout centralizado em `includes/layout.php`.
- As paginas estao separadas por perfil.
- O PHP usa PDO para conexao com MySQL.

## O que esta incompleto

- A compatibilidade final com o banco precisa ser validada apos a estabilizacao do Desktop.
- A area financeira precisa ser alinhada com os perfis reais do banco.
- A landing page precisa ser validada como parte da apresentacao final.

## O que precisa ser removido ou revisado

- Scripts de instalacao e dados de teste devem ser avaliados antes da entrega.
- Paginas ou assets nao utilizados devem ser revisados apenas depois da estabilizacao do Desktop.

## O que esta duplicado

- Regras de nota, frequencia, alerta e pagamento aparecem no PHP e tambem no Desktop.
- Essa duplicidade pode gerar diferencas se os calculos forem alterados em apenas um modulo.

## O que nao segue o padrao

- O PHP esta de acordo com o padrao de SQL direto, mas depende de validacao fina contra o banco final.
- A existencia de area financeira sem perfil `financeiro` no banco precisa de decisao.

## Pendencias para proxima etapa

- Revisar consultas SQL do PHP contra `Atual.sql`.
- Confirmar perfis e permissoes.
- Validar fluxo de login e primeiro acesso.

