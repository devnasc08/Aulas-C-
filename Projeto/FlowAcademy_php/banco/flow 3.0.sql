-- =========================================================================
-- SCRIPT SQL OFICIAL COMPLETO — FLOW ACADEMY PLATFORM
-- Versão 3.0.0 — Modelo Presencial Atualizado com Pesos e Unidades Curriculares (UCs)
-- Projeto Integrador — Técnico em Informática (Senac)
-- =========================================================================

CREATE DATABASE IF NOT EXISTS flow_academy;
USE flow_academy;

-- Limpeza prévia para evitar conflitos de tabelas antigas (na ordem correta de chaves estrangeiras)
DROP TABLE IF EXISTS logs;
DROP TABLE IF EXISTS pagamentos;
DROP TABLE IF EXISTS frequencia;
DROP TABLE IF EXISTS alerta_risco;
DROP TABLE IF EXISTS notas;
DROP TABLE IF EXISTS matriculas;
DROP TABLE IF EXISTS turmas;
DROP TABLE IF EXISTS disciplinas;
DROP TABLE IF EXISTS cursos;
DROP TABLE IF EXISTS professores;
DROP TABLE IF EXISTS alunos;
DROP TABLE IF EXISTS usuarios;

-- =========================================================================
-- 1) CAMADA DE AUTENTICAÇÃO E CONTROLE DE ACESSO
-- =========================================================================

CREATE TABLE usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    senha_hash VARCHAR(255) NOT NULL,
    perfil ENUM('aluno', 'professor', 'coordenacao', 'financeiro', 'admin') NOT NULL,
    status ENUM('ativo', 'inativo') DEFAULT 'ativo',
    ultimo_login DATETIME NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE logs (
    id_log INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    acao VARCHAR(255) NOT NULL,
    ip VARCHAR(45) NULL,
    data_evento DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) ON DELETE CASCADE
);

-- =========================================================================
-- 2) CAMADA DE GESTÃO INSTITUCIONAL (ATORES)
-- =========================================================================

CREATE TABLE alunos (
    id_aluno INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL UNIQUE,
    matricula VARCHAR(30) NOT NULL UNIQUE,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    telefone VARCHAR(20),
    data_nascimento DATE NULL,
    endereco VARCHAR(255),
    status_academico ENUM('regular', 'trancado', 'jubilado', 'evadido') DEFAULT 'regular',
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) ON DELETE CASCADE
);

CREATE TABLE professores (
    id_professor INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL UNIQUE,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    especialidade VARCHAR(120),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) ON DELETE CASCADE
);

-- =========================================================================
-- 3) CAMADA DE OFERTA ACADÊMICA
-- =========================================================================

CREATE TABLE cursos (
    id_curso INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(120) NOT NULL,
    descricao TEXT,
    carga_horaria INT NOT NULL,
    status ENUM('ativo', 'inativo') DEFAULT 'ativo'
);

CREATE TABLE disciplinas (
    id_disciplina INT AUTO_INCREMENT PRIMARY KEY,
    id_curso INT NOT NULL,
    nome VARCHAR(120) NOT NULL, -- Representa o nome da Unidade Curricular (UC)
    carga_horaria INT NOT NULL,
    FOREIGN KEY (id_curso) REFERENCES cursos(id_curso) ON DELETE CASCADE
);

CREATE TABLE turmas (
    id_turma INT AUTO_INCREMENT PRIMARY KEY,
    id_curso INT NOT NULL,
    id_professor INT NOT NULL,
    codigo_turma VARCHAR(50) NOT NULL UNIQUE,
    turno ENUM('manha', 'tarde', 'noite') NOT NULL,
    periodo_letivo VARCHAR(20) NOT NULL, 
    capacidade_maxima INT DEFAULT 35,
    status ENUM('ativa', 'encerrada') DEFAULT 'ativa',
    FOREIGN KEY (id_curso) REFERENCES cursos(id_curso),
    FOREIGN KEY (id_professor) REFERENCES professores(id_professor)
);

-- =========================================================================
-- 4) CAMADA DE REGISTRO ACADÊMICO E MATRÍCULAS
-- =========================================================================

CREATE TABLE matriculas (
    id_matricula INT AUTO_INCREMENT PRIMARY KEY,
    id_aluno INT NOT NULL,
    id_turma INT NOT NULL,
    data_matricula DATE NOT NULL,
    status ENUM('ativa', 'cancelada', 'concluida') DEFAULT 'ativa',
    FOREIGN KEY (id_aluno) REFERENCES alunos(id_aluno),
    FOREIGN KEY (id_turma) REFERENCES turmas(id_turma),
    UNIQUE KEY uq_aluno_turma (id_aluno, id_turma)
);

CREATE TABLE notas (
    id_nota INT AUTO_INCREMENT PRIMARY KEY,
    id_matricula INT NOT NULL,
    id_disciplina INT NOT NULL, -- Unidade Curricular (UC)
    
    -- Composições da Nova Metodologia de Avaliação Incorporada
    prova_1 DECIMAL(4,2) NULL,
    prova_2 DECIMAL(4,2) NULL,
    trabalho DECIMAL(4,2) NULL,
    comportamental DECIMAL(4,2) NULL, 
    
    media_uc DECIMAL(4,2) NULL, -- Resultado da média ponderada final da UC
    status ENUM('aprovado', 'reprovado', 'em_andamento') DEFAULT 'em_andamento',
    data_lancamento DATETIME DEFAULT CURRENT_TIMESTAMP,
    
    FOREIGN KEY (id_matricula) REFERENCES matriculas(id_matricula) ON DELETE CASCADE,
    FOREIGN KEY (id_disciplina) REFERENCES disciplinas(id_disciplina),
    UNIQUE KEY uq_matricula_disciplina (id_matricula, id_disciplina)
);

CREATE TABLE alerta_risco (
    id_alerta INT AUTO_INCREMENT PRIMARY KEY,
    id_matricula INT NOT NULL,
    tipo_risco ENUM('nota', 'frequencia', 'ambos') NOT NULL,
    score DECIMAL(5,2) NOT NULL,
    status ENUM('pendente', 'analisado', 'arquivado') DEFAULT 'pendente',
    FOREIGN KEY (id_matricula) REFERENCES matriculas(id_matricula) ON DELETE CASCADE
);

CREATE TABLE frequencia (
    id_frequencia INT AUTO_INCREMENT PRIMARY KEY,
    id_matricula INT NOT NULL,
    id_disciplina INT NOT NULL,
    total_aulas INT NOT NULL DEFAULT 0,
    presencas INT NOT NULL DEFAULT 0,
    percentual DECIMAL(5,2) GENERATED ALWAYS AS ((presencas / total_aulas) * 100) VIRTUAL,
    FOREIGN KEY (id_matricula) REFERENCES matriculas(id_matricula) ON DELETE CASCADE,
    FOREIGN KEY (id_disciplina) REFERENCES disciplinas(id_disciplina),
    UNIQUE KEY uq_matricula_frequencia (id_matricula, id_disciplina)
);

-- =========================================================================
-- 5) CAMADA DO NÚCLEO INSTITUCIONAL (FINANCEIRO)
-- =========================================================================

CREATE TABLE pagamentos (
    id_pagamento INT AUTO_INCREMENT PRIMARY KEY,
    id_aluno INT NOT NULL,
    valor DECIMAL(10,2) NOT NULL,
    vencimento DATE NOT NULL,
    status ENUM('pendente', 'pago', 'atrasado', 'cancelado') DEFAULT 'pendente',
    FOREIGN KEY (id_aluno) REFERENCES alunos(id_aluno) ON DELETE CASCADE
);


-- =========================================================================
-- PROCEDIMENTOS ARMAZENADOS (STORED PROCEDURES & FUNCTIONS)
-- =========================================================================

DELIMITER $$

-- PROCEDURE 1: Cadastro Unificado de Aluno (Transação Segura)
DROP PROCEDURE IF EXISTS sp_registrar_usuario_aluno$$
CREATE PROCEDURE sp_registrar_usuario_aluno(
    IN p_nome VARCHAR(150), IN p_email VARCHAR(150), IN p_senha_hash VARCHAR(255),
    IN p_matricula VARCHAR(30), IN p_cpf VARCHAR(14), IN p_telefone VARCHAR(20),
    IN p_data_nascimento DATE, IN p_endereco VARCHAR(255)
)
BEGIN
    DECLARE v_id_usuario INT;
    START TRANSACTION;
    
    INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
    VALUES (p_nome, p_email, p_senha_hash, 'aluno', 'ativo');
    
    SET v_id_usuario = LAST_INSERT_ID();
    
    INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
    VALUES (v_id_usuario, p_matricula, p_cpf, p_telefone, p_data_nascimento, p_endereco, 'regular');
    
    COMMIT;
END$$


-- PROCEDURE 2: Realizar Matrícula com Validação de Capacidade de Turma
DROP PROCEDURE IF EXISTS sp_realizar_matricula$$
CREATE PROCEDURE sp_realizar_matricula(
    IN p_id_aluno INT,
    IN p_id_turma INT
)
BEGIN
    DECLARE v_capacidade_max INT;
    DECLARE v_matriculados INT;
    
    SELECT capacidade_maxima INTO v_capacidade_max FROM turmas WHERE id_turma = p_id_turma;
    SELECT COUNT(*) INTO v_matriculados FROM matriculas WHERE id_turma = p_id_turma AND status = 'ativa';
    
    IF v_matriculados < v_capacidade_max THEN
        INSERT INTO matriculas (id_aluno, id_turma, data_matricula, status)
        VALUES (p_id_aluno, p_id_turma, CURDATE(), 'ativa');
        SELECT 'Matrícula efetuada com sucesso!' AS mensagem, TRUE AS sucesso;
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Erro: Limite de vagas da turma atingido.';
    END IF;
END$$


-- PROCEDURE 3: Lançamento de Notas com Pesos Combinados (60% Provas, 30% Trabalho, 10% Comportamental)
DROP PROCEDURE IF EXISTS sp_lancar_nota_e_avaliar$$
CREATE PROCEDURE sp_lancar_nota_e_avaliar(
    IN p_id_matricula INT,
    IN p_id_disciplina INT,
    IN p_prova_1 DECIMAL(4,2),
    IN p_prova_2 DECIMAL(4,2),
    IN p_trabalho DECIMAL(4,2),
    IN p_comportamental DECIMAL(4,2)
)
BEGIN
    DECLARE v_media_uc DECIMAL(4,2);
    DECLARE v_status_nota VARCHAR(20);
    
    -- Fórmula baseada na decisão do grupo:
    -- Prova 1 (30%) + Prova 2 (30%) = 60% Provas | Trabalho = 30% | Comportamental = 10%
    SET v_media_uc = (p_prova_1 * 0.30) + (p_prova_2 * 0.30) + (p_trabalho * 0.30) + (p_comportamental * 0.10);
    
    -- Condição para aprovação na Unidade Curricular específica
    IF v_media_uc >= 6.0 THEN
        SET v_status_nota = 'aprovado';
    ELSE
        SET v_status_nota = 'reprovado';
    END IF;
    
    INSERT INTO notas (id_matricula, id_disciplina, prova_1, prova_2, trabalho, comportamental, media_uc, status, data_lancamento)
    VALUES (p_id_matricula, p_id_disciplina, p_prova_1, p_prova_2, p_trabalho, p_comportamental, v_media_uc, v_status_nota, NOW())
    ON DUPLICATE KEY UPDATE 
        prova_1 = p_prova_1, prova_2 = p_prova_2, trabalho = p_trabalho, comportamental = p_comportamental, 
        media_uc = v_media_uc, status = v_status_nota, data_lancamento = NOW();
        
    -- Monitor de Risco Acadêmico (Gera alerta caso a média ponderada fique abaixo de 5.0)
    IF v_media_uc < 5.0 THEN
        INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status)
        VALUES (p_id_matricula, 'nota', (10.0 - v_media_uc), 'pendente')
        ON DUPLICATE KEY UPDATE score = (10.0 - v_media_uc), status = 'pendente';
    END IF;

    SELECT 'Notas e Média calculadas com sucesso!' AS log, v_media_uc AS media_calculada, v_status_nota AS status_uc;
END$$


-- FUNCTION 1: Regra de Aprovação Geral no Curso (Média superior a 6.0 em TODAS as UCs)
DROP FUNCTION IF EXISTS fn_verificar_aprovacao_geral$$
CREATE FUNCTION fn_verificar_aprovacao_geral(p_id_matricula INT) 
RETURNS VARCHAR(100)
DETERMINISTIC
BEGIN
    DECLARE v_total_ucs INT;
    DECLARE v_ucs_aprovadas INT;
    DECLARE v_possui_reprovacao INT;
    
    -- Busca a quantidade total de UCs que o curso daquela matrícula possui
    SELECT COUNT(d.id_disciplina) INTO v_total_ucs
    FROM matriculas m
    JOIN turmas t ON m.id_turma = t.id_turma
    JOIN disciplinas d ON t.id_curso = d.id_curso
    WHERE m.id_matricula = p_id_matricula;
    
    -- Conta em quantas UCs ele obteve o status 'aprovado'
    SELECT COUNT(*) INTO v_ucs_aprovadas FROM notas WHERE id_matricula = p_id_matricula AND status = 'aprovado';
    
    -- Conta se há algum registro de reprovação na grade
    SELECT COUNT(*) INTO v_possui_reprovacao FROM notas WHERE id_matricula = p_id_matricula AND status = 'reprovado';

    -- Avaliação final baseada no critério do grupo
    IF v_possui_reprovacao > 0 THEN
        RETURN 'Retido no Curso: Média inferior a 6.0 detectada em alguma UC.';
    ELSEIF v_ucs_aprovadas = v_total_ucs AND v_total_ucs > 0 THEN
        RETURN 'Aprovado no Curso: Obteve média superior a 6.0 em todas as UCs!';
    ELSE
        RETURN 'Cursando: O aluno possui UCs pendentes de fechamento.';
    END IF;
END$$

DELIMITER ;