# 02 - Guia de Instalacao

## Requisitos

- Servidor local com Apache e PHP, como XAMPP.
- MySQL ou MariaDB.
- Navegador web.
- phpMyAdmin ou MySQL Workbench para importar o banco.

## Passo a passo

1. Copie a pasta `FlowAcademy_php` para o diretorio publico do servidor.

   Exemplo no XAMPP:

   ```text
   C:\xampp\htdocs\FlowAcademy_php
   ```

2. Importe o banco de dados.

   Arquivo:

   ```text
   FlowAcademy_php/banco/Banco_oficial.sql
   ```

3. Confira a configuracao da conexao.

   Arquivo:

   ```text
   FlowAcademy_php/web-php/config/config.php
   ```

   Campos principais:

   ```php
   $host = 'localhost';
   $dbname = 'flow_academy';
   $usuario = 'root';
   $senha = '';
   ```

   Ajuste esses valores conforme o computador onde o projeto sera executado.

4. Acesse o sistema no navegador.

   ```text
   http://localhost/FlowAcademy_php/web-php/login.php
   ```

## Arquivo inicial

A tela publica de apresentacao fica em:

```text
FlowAcademy_php/web-php/index.php
```

O login unico do sistema fica em:

```text
FlowAcademy_php/web-php/login.php
```

## Dados iniciais

O arquivo `Banco_oficial.sql` ja possui estrutura de tabelas e alguns registros de exemplo.

Os perfis usados pelo sistema sao:

- `aluno`
- `professor`
- `coordenacao`
- `administrativo`
- `admin`

## Problemas comuns

### Erro de conexao com banco

Verifique:

- Se o MySQL esta iniciado.
- Se o banco `flow_academy` foi importado.
- Se usuario, senha e host em `config.php` estao corretos.

### Tela sem estilo

Verifique se a pasta `assets` existe em:

```text
FlowAcademy_php/web-php/assets
```

O Bootstrap local 5.0.2 fica em:

```text
FlowAcademy_php/web-php/assets/bootstrap
```

Essa pasta deve conter os diretorios `css` e `js` da distribuicao `bootstrap-5.0.2-dist`.

### Login nao entra

Verifique:

- Se a tabela `usuarios` possui registros.
- Se o usuario esta com `status = ativo`.
- Se a senha digitada corresponde ao hash salvo em `senha_hash`.
