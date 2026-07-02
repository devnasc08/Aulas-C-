# 07 - Roteiro Final de Entrega

## Antes da apresentacao

1. Iniciar MySQL.
2. Importar `Banco_oficial.sql`.
3. Aplicar `procedures_para_Atual_conforme_CSharp.sql`, se necessario.
4. Ajustar `FlowAcademy_php/web-php/config/config.php`.
5. Ajustar `FlowAcademy_cs/FlowAcademyClasses/Banco.cs`.
6. Testar login no PHP.
7. Testar login no C#.
8. Testar um fluxo integrado.

## Ordem sugerida de apresentacao

### 1. Contexto

Explicar:

- Problema: gestao academica distribuida.
- Solucao: Flow Academy integrado.
- Modulos: Web PHP e Desktop C#.

### 2. Banco de dados

Mostrar:

- `Banco_oficial.sql`.
- Tabelas principais.
- Relacionamento entre usuarios, alunos, cursos, turmas, matriculas, notas e frequencia.

### 3. Modulo PHP

Mostrar:

- Landing page.
- Login.
- Dashboard por perfil.
- Alunos.
- Cursos.
- Notas ou frequencia.

### 4. Modulo CSharp

Mostrar:

- Login desktop.
- Dashboard.
- Menus por perfil.
- Uma tela de cadastro.
- Uma tela academica, como notas ou frequencia.

### 5. Integracao

Demonstrar:

- Mesmo banco nos dois modulos.
- Mesmo usuario/perfil.
- Dados compartilhados.

### 6. Documentacao

Mostrar:

- `docs/README.md`.
- `FlowAcademy_php/docs/README.md`.
- `FlowAcademy_cs/docs/README.md`.

### 7. Encerramento

Concluir:

- O projeto atende perfis academicos.
- Possui arquitetura simples.
- Possui documentacao e plano de testes.
- Pode evoluir com relatorios, recuperacao de senha e melhorias de seguranca.

## Fala curta sugerida

> O Flow Academy foi desenvolvido como uma solucao integrada para gestao academica. O modulo PHP atende usuarios via navegador, o modulo C# oferece uma interface desktop administrativa, e ambos compartilham o mesmo banco MySQL. O sistema trabalha com perfis, matriculas, cursos, turmas, notas, frequencia, pagamentos e logs, mantendo regras compativeis entre os modulos.

