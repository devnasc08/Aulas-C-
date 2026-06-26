<?php

require_once __DIR__ . '/includes/auth.php';

// Encerra a sessao atual e volta para o login.
fazerLogout();
redirecionar('login.php');
