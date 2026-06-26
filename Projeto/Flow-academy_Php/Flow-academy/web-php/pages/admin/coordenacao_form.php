<?php

// Esta pagina define os dados fixos do cadastro de coordenacao.
$perfilFuncionario = 'coordenacao';
$ativoMenu = 'coordenacao_form';
$tituloPagina = 'Cadastro de Coordenacao';
$subtituloPagina = 'Cria o usuario de acesso para funcionarios da coordenacao.';
$rotuloFuncionario = 'Funcionario da coordenacao';
$acaoLog = 'Cadastrou funcionario da coordenacao';

// O formulario comum evita duplicar a mesma validacao em duas paginas.
require __DIR__ . '/_funcionario_form.php';
