<?php

function notaValida($valor)
{
    // Notas aceitas precisam ser numericas e ficar entre 0 e 10.
    return is_numeric($valor) && $valor >= 0 && $valor <= 10;
}
