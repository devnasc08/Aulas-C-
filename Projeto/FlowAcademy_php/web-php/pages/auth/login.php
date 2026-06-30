<?php

require_once __DIR__ . '/../../includes/funcoes.php';

// Mantem compatibilidade com a pasta pages/auth, mas o login real fica na raiz.
redirecionar('../../login.php');
