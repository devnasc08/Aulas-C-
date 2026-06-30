<?php

// Configuracao central da conexao com o MySQL.
// O MySQL roda no mesmo computador do Apache/XAMPP, por isso usamos localhost.
// A aplicacao usa uma conta propria, sem depender do usuario root do MySQL.
$host = '10.91.47.67';
$dbname = 'flow_academy';
$usuario = 'root';
$senha = 'P@';
$charset = 'utf8mb4';

$dsn = "mysql:host=$host;dbname=$dbname;charset=$charset";

try {
    // O PDO e a biblioteca do PHP usada para conversar com o banco MySQL.
    // ERRMODE_EXCEPTION faz o PHP mostrar erros de banco como excecoes, facilitando o tratamento.
    $pdo = new PDO($dsn, $usuario, $senha, [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    ]);
} catch (PDOException $erro) {
    die('Erro ao conectar com o banco de dados: ' . $erro->getMessage());
}
