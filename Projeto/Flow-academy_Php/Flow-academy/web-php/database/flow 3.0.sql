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
    perfil ENUM('aluno', 'professor', 'coordenacao', 'administrativo', 'admin') NOT NULL,
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
-- DADOS INICIAIS MINIMOS
-- =========================================================================
-- O banco comeca sem cursos, turmas, UCs, matriculas, notas, frequencias,
-- pagamentos, alertas ou logs. Somente uma conta de cada perfil e criada.
-- As contas de aluno e professor tambem recebem seus cadastros basicos nas
-- tabelas alunos e professores, mas ainda nao possuem vinculo academico.
-- Todas usam a senha inicial 123456 e ultimo_login nulo para obrigar a troca
-- de senha no primeiro acesso ao sistema.
INSERT INTO usuarios (nome, email, senha_hash, perfil, status, ultimo_login) VALUES
('Admin do Sistema', 'admin@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'admin', 'ativo', NULL),
('Coordenacao Flow', 'coordenacao@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'coordenacao', 'ativo', NULL),
('Administrativo Flow', 'administrativo@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'administrativo', 'ativo', NULL),
('Professor Flow', 'professor@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'professor', 'ativo', NULL),
('Aluno Flow', 'aluno@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'aluno', 'ativo', NULL);

-- Cria o cadastro profissional para o usuario de perfil professor.
INSERT INTO professores (id_usuario, cpf, especialidade)
SELECT id_usuario, '111.222.333-44', 'Sem turmas cadastradas'
FROM usuarios
WHERE email = 'professor@flowacademy.com';

-- Cria o cadastro academico basico para o usuario de perfil aluno.
INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
SELECT id_usuario, '2026-0001', '123.456.789-10', NULL, NULL, NULL, 'regular'
FROM usuarios
WHERE email = 'aluno@flowacademy.com';

-- =========================================================================
-- REGRAS DE NEGOCIO
-- =========================================================================
-- Cadastro de aluno, matricula, calculo de notas e alertas sao executados
-- pelo PHP com consultas preparadas e transacoes. Nao ha procedures nem
-- functions armazenadas neste banco.
