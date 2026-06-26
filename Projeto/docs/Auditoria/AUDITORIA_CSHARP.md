# Auditoria C# - Desktop

## O que esta correto

- O projeto possui separacao entre Forms e classes.
- As classes estao concentradas em `FlowAcademyClasses`.
- A maioria das entidades possui metodos de CRUD.
- O acesso ao banco passa por `Banco.cs`.
- Os formularios analisados nao apresentaram SQL direto em verificacao estatica.
- `Sessao.cs` centraliza dados basicos do usuario logado.
- `AuthService.cs` concentra login, logout e senha.

## O que esta incompleto

- `FrmPrincipal` ainda precisa funcionar como dashboard por perfil.
- Alguns botoes de formularios precisam ter eventos confirmados no Designer.
- Pagamento e AlertaRisco nao seguem totalmente o padrao novo de nomes de procedures.
- Nem todas as classes seguem o padrao de `MontarObjeto()` privado.
- Nem todas as entidades aparentam ter formulario completo.

## O que precisa ser removido ou revisado

- `FrmTeste` indica tela de teste e deve ser avaliada antes da entrega.
- Existe arquivo `AlertaRisco.cs` dentro do projeto de Forms, separado da classe de entidade em `FlowAcademyClasses`.
- Arquivos compactados dentro de pastas do projeto devem ser avaliados para nao entrarem na entrega final.

## O que esta duplicado

- Algumas regras de negocio aparecem tambem no PHP, como notas, frequencia, pagamentos e alerta de risco.
- Existem nomes de procedures em padroes diferentes entre banco e C#.

## O que nao segue o padrao

- `MontarObjeto()` aparece publico em algumas classes.
- Pagamento e AlertaRisco usam procedures com nomes antigos.
- Dashboard ainda nao aplica permissoes por perfil.
- Alguns eventos de clique nao foram confirmados nos arquivos Designer.

## Pendencias para proxima etapa

- Corrigir procedures do banco conforme chamadas do C#.
- Padronizar classes uma por vez.
- Revisar formularios uma por vez.
- Compilar apos cada ajuste.

