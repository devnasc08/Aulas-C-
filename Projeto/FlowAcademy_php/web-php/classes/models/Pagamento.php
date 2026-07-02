<?php
// Classe que representa uma cobranca financeira de um aluno.
class Pagamento
{
    // Campos da tabela pagamentos.
    private $id_pagamento;
    private $id_aluno;
    private $valor;
    private $vencimento;
    private $status;

    public function __construct(array $dados = [])
    {
        // Valores iniciais para um pagamento novo.
        $this->id_pagamento = null;
        $this->id_aluno = null;
        $this->valor = 0;
        $this->vencimento = null;
        $this->status = 'pendente';

        preencherObjeto($this, $dados);
    }

    // Getters e setters usados para manipular dados do pagamento.
    public function getIdPagamento() { return $this->id_pagamento; }
    public function setIdPagamento($id_pagamento) { $this->id_pagamento = $id_pagamento; }

    public function getIdAluno() { return $this->id_aluno; }
    public function setIdAluno($id_aluno) { $this->id_aluno = $id_aluno; }

    public function getValor() { return $this->valor; }
    public function setValor($valor) { $this->valor = $valor; }

    public function getVencimento() { return $this->vencimento; }
    public function setVencimento($vencimento) { $this->vencimento = $vencimento; }

    public function getStatus() { return $this->status; }
    public function setStatus($status) { $this->status = $status; }

    public function registrar()
    {
        global $pdo;

        // Insere uma nova cobranca financeira no banco.
        $stmt = $pdo->prepare('INSERT INTO pagamentos (id_aluno, valor, vencimento, status) VALUES (:id_aluno, :valor, :vencimento, :status)');
        $stmt->execute([
            ':id_aluno' => $this->id_aluno,
            ':valor' => $this->valor,
            ':vencimento' => $this->vencimento,
            ':status' => $this->status,
        ]);
    }

    public function consultar()
    {
        global $pdo;

        // Busca um pagamento especifico pelo id.
        $stmt = $pdo->prepare('SELECT * FROM pagamentos WHERE id_pagamento = :id');
        $stmt->execute([':id' => $this->id_pagamento]);
        return $stmt->fetch();
    }

    public function consultarInadimplencia()
    {
        global $pdo;

        // Lista pagamentos em aberto do aluno: pendentes ou atrasados.
        $stmt = $pdo->prepare('SELECT * FROM pagamentos WHERE id_aluno = :id_aluno AND status IN ("pendente", "atrasado")');
        $stmt->execute([':id_aluno' => $this->id_aluno]);
        return $stmt->fetchAll();
    }
}
