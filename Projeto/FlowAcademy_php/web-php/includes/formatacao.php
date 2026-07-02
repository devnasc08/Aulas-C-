<?php

function dataBr($data)
{
    // Converte datas do banco para o formato brasileiro.
    if (!$data) {
        return '-';
    }

    return date('d/m/Y', strtotime($data));
}

function numeroBr($numero, $casas = 1)
{
    // Formata numeros com virgula decimal, como e comum no Brasil.
    if ($numero === null || $numero === '') {
        return '-';
    }

    return number_format((float) $numero, $casas, ',', '.');
}

function moedaBr($numero)
{
    // Formata valores monetarios em reais.
    return 'R$ ' . number_format((float) $numero, 2, ',', '.');
}

function statusBadge($status)
{
    $status = strtolower((string) $status);

    // Converte status do banco em classe CSS para colorir os badges.
    if (in_array($status, ['ativo', 'ativa', 'regular', 'aprovado', 'pago'], true)) {
        return 'success';
    }

    if (in_array($status, ['pendente', 'em_andamento', 'atrasado'], true)) {
        return 'warning';
    }

    if (in_array($status, ['inativo', 'cancelado', 'cancelada', 'reprovado', 'evadido', 'jubilado'], true)) {
        return 'danger';
    }

    return '';
}

function nomePerfil($perfil)
{
    // Nomes amigaveis para mostrar perfis na tela.
    $nomes = [
        'aluno' => 'Aluno',
        'professor' => 'Professor',
        'coordenacao' => 'Coordenacao',
        'administrativo' => 'Administrativo',
        'admin' => 'Admin',
    ];

    return $nomes[$perfil] ?? ucfirst((string) $perfil);
}

function iniciais($nome)
{
    // Gera as letras do avatar a partir do nome do usuario.
    $partes = preg_split('/\s+/', trim((string) $nome));
    $primeira = $partes[0][0] ?? 'F';
    $segunda = $partes[1][0] ?? 'A';
    return strtoupper($primeira . $segunda);
}

function textoStatus($status)
{
    // Troca underline por espaco e deixa status mais bonito para mostrar na tela.
    return ucwords(str_replace('_', ' ', (string) $status));
}
