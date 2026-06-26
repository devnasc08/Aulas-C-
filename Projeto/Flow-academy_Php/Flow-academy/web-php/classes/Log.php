<?php

// Classe usada para registrar auditoria das principais acoes do sistema.
class Log
{
    // Campos da tabela logs.
    private $id_log;
    private $id_usuario;
    private $acao;
    private $ip;
    private $data_evento;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para um log ainda nao salvo.
        $this->id_log = null;
        $this->id_usuario = null;
        $this->acao = '';
        $this->ip = '';
        $this->data_evento = null;

        preencherObjeto($this, $dados);
    }

    // Getters e setters para acessar os dados privados do log.
    public function getIdLog() { return $this->id_log; }
    public function setIdLog($id_log) { $this->id_log = $id_log; }

    public function getIdUsuario() { return $this->id_usuario; }
    public function setIdUsuario($id_usuario) { $this->id_usuario = $id_usuario; }

    public function getAcao() { return $this->acao; }
    public function setAcao($acao) { $this->acao = $acao; }

    public function getIp() { return $this->ip; }
    public function setIp($ip) { $this->ip = $ip; }

    public function getDataEvento() { return $this->data_evento; }
    public function setDataEvento($data_evento) { $this->data_evento = $data_evento; }

    public function registrar($acao, $ip)
    {
        global $pdo;

        // Salva quem fez a acao, qual foi a acao e o IP de origem.
        $stmt = $pdo->prepare('INSERT INTO logs (id_usuario, acao, ip) VALUES (:id_usuario, :acao, :ip)');
        $stmt->execute([
            ':id_usuario' => $this->id_usuario,
            ':acao' => $acao,
            ':ip' => $ip,
        ]);
    }
}
