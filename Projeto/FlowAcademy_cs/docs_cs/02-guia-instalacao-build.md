# 02 - Guia de Instalacao e Build

## Requisitos

- Windows.
- Visual Studio 2022 ou superior.
- .NET 8 SDK.
- MySQL ou MariaDB.
- Banco `flow_academy` importado.
- Pacote NuGet `MySql.Data` versao 8.4.0.

## Abrir o projeto

1. Abrir o Visual Studio.
2. Selecionar `Open a project or solution`.
3. Abrir:

   ```text
   FlowAcademy_cs/FlowAcademy.sln
   ```

## Restaurar pacotes

O Visual Studio deve restaurar automaticamente o pacote:

```text
MySql.Data 8.4.0
```

Se necessario, executar:

```powershell
dotnet restore FlowAcademy_cs/FlowAcademy.sln
```

## Compilar

Pelo Visual Studio:

1. Menu `Build`.
2. `Build Solution`.

Pelo terminal:

```powershell
dotnet build FlowAcademy_cs/FlowAcademy.sln
```

## Executar

Projeto inicial:

```text
FlowAcademy
```

Ponto de entrada:

```text
FlowAcademy/Program.cs
```

Tela inicial:

```text
FormLogin
```

## Configurar banco

A conexao fica em:

```text
FlowAcademy_cs/FlowAcademyClasses/Banco.cs
```

Trecho principal:

```csharp
host=10.91.47.67;database=flow_academy;user=root;password=P@ssw0rd
```

Para rodar em outro computador, ajuste:

- Host.
- Database.
- User.
- Password.

Exemplo local XAMPP:

```text
host=localhost;database=flow_academy;user=root;password=
```

## Banco necessario

Importar o SQL oficial:

```text
FlowAcademy_php/banco/Banco_oficial.sql
```

Se necessario, aplicar tambem o script de procedures compatibilizadas com C#:

```text
procedures_para_Atual_conforme_CSharp.sql
```

## Problemas comuns

### Erro de pacote MySql.Data

Solucao:

```powershell
dotnet restore FlowAcademy_cs/FlowAcademy.sln
```

### Erro de conexao

Conferir:

- MySQL ativo.
- Banco importado.
- Connection string em `Banco.cs`.

### Formulario abre sem dados

Conferir:

- Procedures existentes no banco.
- Tabelas com dados.
- Permissao do usuario do banco.

