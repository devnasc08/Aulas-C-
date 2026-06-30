# Criterios de Aceite

## Objetivo

Definir quando o Flow Academy pode ser considerado pronto para apresentacao funcional.

## Criterios obrigatorios

### Login

- Todos os perfis oficiais conseguem logar com senha correta.
- Senha incorreta bloqueia acesso.
- Usuario inexistente bloqueia acesso.
- Logout limpa a sessao.
- Apos logout, o sistema retorna ao Login.

### Dashboard Desktop

- `FrmPrincipal` abre apos login.
- Nome e perfil do usuario aparecem no Dashboard.
- Cada perfil visualiza somente seus menus.
- Menus nao permitidos ficam ocultos.
- Forms abrem dentro do painel central.
- O botao Sair funciona.

### CRUDs Desktop

Para cada entidade principal:

- Inserir funciona.
- Alterar funciona.
- Excluir funciona ou mostra erro claro quando houver dependencia.
- Consultar funciona.
- Buscar por ID funciona.
- Campos obrigatorios sao validados.
- Mensagens sao claras.
- Grid atualiza apos operacoes.

### Banco

- FKs impedem dados incoerentes.
- Procedures do Desktop existem e executam.
- INSERT, UPDATE e DELETE gravam dados corretamente.
- SELECT e SELECT POR ID retornam dados esperados.
- Exclusoes respeitam relacionamentos.

### Fluxo integrado

O sistema deve permitir demonstrar:

1. Login como admin.
2. Cadastro de usuario.
3. Cadastro de professor.
4. Cadastro de curso.
5. Cadastro de disciplina.
6. Cadastro de turma.
7. Cadastro de aluno.
8. Matricula do aluno.
9. Lancamento de nota.
10. Registro de frequencia.
11. Registro de pagamento.
12. Verificacao de alertas ou registro da pendencia.
13. Logout.

## Criterios para aprovar a entrega

- Nenhum bug critico aberto.
- Nenhum bug alto bloqueando fluxo principal.
- Login e Dashboard aprovados.
- Fluxo integrado aprovado ou com pendencias documentadas.
- Documentacao sincronizada com o estado real.
- Projeto compila sem erros.

## Situacao apos homologacao

- Login aprovado com ressalva: a conta `administrativo@flowacademy.com` nao usa a senha padrao, mas o perfil administrativo foi validado com usuario temporario.
- Dashboard aprovado por perfil.
- CRUDs principais aprovados tecnicamente via classes/procedures.
- Fluxo integrado aprovado ate pagamento.
- Verificacao de alertas reprovada no Desktop por ausencia de `FrmAlertaRisco`.
- Logout, campos vazios, mensagens e refresh visual dos grids ainda exigem validacao manual.

## Criterios para reprovar a entrega

- Sistema nao compila.
- Login nao funciona.
- Dashboard nao respeita perfil.
- CRUDs principais nao gravam no banco.
- Banco nao possui procedures necessarias para o Desktop.
- Fluxo integrado nao pode ser demonstrado.
