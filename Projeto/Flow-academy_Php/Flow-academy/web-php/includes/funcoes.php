<?php

require_once __DIR__ . '/../config/config.php';

// Arquivo de funcoes auxiliares usadas em varias paginas do sistema.
// Centralizar essas funcoes evita repetir o mesmo codigo em todos os arquivos.

function e($valor)
{
    // Protege a tela contra HTML/JavaScript digitado pelo usuario.
    return htmlspecialchars((string) ($valor ?? ''), ENT_QUOTES, 'UTF-8');
}

function post($campo, $padrao = '')
{
    // Facilita pegar campos do formulario sem repetir $_POST em todas as paginas.
    return trim((string) ($_POST[$campo] ?? $padrao));
}

function getValor($campo, $padrao = '')
{
    // Parecido com post(), mas lendo parametros vindos pela URL com $_GET.
    return trim((string) ($_GET[$campo] ?? $padrao));
}

function redirecionar($caminho)
{
    // Envia o usuario para outra pagina e para a execucao do PHP atual.
    header('Location: ' . $caminho);
    exit;
}

function flash($tipo, $mensagem)
{
    // Flash e uma mensagem temporaria: aparece na proxima pagina e depois some.
    if (session_status() === PHP_SESSION_NONE) {
        session_start();
    }

    $_SESSION['flash'] = [
        'tipo' => $tipo,
        'mensagem' => $mensagem,
    ];
}

function pegarFlash()
{
    // Le a mensagem temporaria e remove para ela aparecer apenas uma vez.
    if (session_status() === PHP_SESSION_NONE) {
        session_start();
    }

    $mensagem = $_SESSION['flash'] ?? null;
    unset($_SESSION['flash']);
    return $mensagem;
}

function buscarUm($sql, array $parametros = [])
{
    global $pdo;

    // Consulta preparada: os parametros ficam separados do SQL.
    $stmt = $pdo->prepare($sql);
    $stmt->execute($parametros);
    $resultado = $stmt->fetch();
    return $resultado ?: null;
}

function buscarTodos($sql, array $parametros = [])
{
    global $pdo;

    // Retorna varias linhas, usado em listagens e tabelas.
    $stmt = $pdo->prepare($sql);
    $stmt->execute($parametros);
    return $stmt->fetchAll();
}

function executar($sql, array $parametros = [])
{
    global $pdo;

    // Usado para INSERT, UPDATE, DELETE e chamadas que nao precisam retornar tabela.
    $stmt = $pdo->prepare($sql);
    return $stmt->execute($parametros);
}

function gerarHashSenha($senha)
{
    // PHP e C# usam o mesmo calculo: SHA256 da senha digitada em UTF-8.
    // Assim os dois sistemas conseguem validar a mesma coluna usuarios.senha_hash.
    return hash('sha256', (string) $senha);
}

function senhaConfere($senhaDigitada, $hashBanco)
{
    // Gera o SHA256 da senha digitada e compara com seguranca com o valor do banco.
    return hash_equals((string) $hashBanco, gerarHashSenha($senhaDigitada));
}

function contarRegistros($tabela, $campo = '*', $where = '', array $parametros = [])
{
    // Monta um COUNT generico para dashboards e indicadores.
    $sql = "SELECT COUNT($campo) AS total FROM $tabela";

    if ($where !== '') {
        $sql .= ' WHERE ' . $where;
    }

    $linha = buscarUm($sql, $parametros);
    return (int) ($linha['total'] ?? 0);
}

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

function statusPagamentoPorVencimento($status, $vencimento)
{
    $status = strtolower((string) $status);
    $vencimento = (string) $vencimento;

    // Pagamentos quitados ou cancelados nao devem mudar so porque a data venceu.
    if (in_array($status, ['pago', 'cancelado'], true)) {
        return $status;
    }

    // Como o campo date salva no formato YYYY-MM-DD, a comparacao de texto funciona.
    if ($vencimento !== '' && $vencimento < date('Y-m-d')) {
        return 'atrasado';
    }

    return 'pendente';
}

function atualizarPagamentosAtrasados()
{
    // Atualiza registros antigos que ainda estejam pendentes mesmo depois do vencimento.
    executar(
        'UPDATE pagamentos
         SET status = "atrasado"
         WHERE vencimento < CURDATE()
           AND status = "pendente"'
    );
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

function notaValida($valor)
{
    // Notas aceitas precisam ser numericas e ficar entre 0 e 10.
    return is_numeric($valor) && $valor >= 0 && $valor <= 10;
}

function textoStatus($status)
{
    // Troca underline por espaco e deixa status mais bonito para mostrar na tela.
    return ucwords(str_replace('_', ' ', (string) $status));
}
