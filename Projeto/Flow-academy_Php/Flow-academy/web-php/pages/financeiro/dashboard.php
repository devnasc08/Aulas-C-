<?php

require_once __DIR__ . '/../../includes/auth.php';

// O financeiro foi integrado ao dashboard administrativo.
// Este arquivo fica apenas para redirecionar links antigos para o painel unico.
exigirPerfil(['administrativo', 'admin'], '../../');
redirecionar('../administrativo/dashboard.php');
