<?php

// O perfil administrativo e salvo diretamente no banco de dados.
$perfilFuncionario = 'administrativo';
$ativoMenu = 'administrativo_form';
$tituloPagina = 'Cadastro Administrativo';
$subtituloPagina = 'Cria o usuario de acesso para funcionarios administrativos.';
$rotuloFuncionario = 'Funcionario administrativo';
$acaoLog = 'Cadastrou funcionario administrativo';

// O formulario comum evita duplicar a mesma validacao em duas paginas.
require __DIR__ . '/_funcionario_form.php';
