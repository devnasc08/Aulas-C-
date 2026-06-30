-- ============================================================================
-- LIMPEZA DO BANCO FLOW ACADEMY
-- Execute este arquivo no MySQL Workbench ou phpMyAdmin quando quiser apagar
-- todos os dados cadastrados e manter somente uma conta de cada perfil.
-- ============================================================================

USE flow_academy;

-- A transacao faz com que a limpeza ocorra por completo ou seja desfeita em caso de erro.
START TRANSACTION;

-- Remove primeiro as tabelas que dependem de outros registros por chaves estrangeiras.
DELETE FROM logs;
DELETE FROM pagamentos;
DELETE FROM frequencia;
DELETE FROM alerta_risco;
DELETE FROM notas;
DELETE FROM matriculas;
DELETE FROM turmas;
DELETE FROM disciplinas;
DELETE FROM cursos;
DELETE FROM professores;
DELETE FROM alunos;
DELETE FROM usuarios;

COMMIT;

-- Reinicia os contadores automaticos para os proximos cadastros comecarem pelo id 1.
ALTER TABLE logs AUTO_INCREMENT = 1;
ALTER TABLE pagamentos AUTO_INCREMENT = 1;
ALTER TABLE frequencia AUTO_INCREMENT = 1;
ALTER TABLE alerta_risco AUTO_INCREMENT = 1;
ALTER TABLE notas AUTO_INCREMENT = 1;
ALTER TABLE matriculas AUTO_INCREMENT = 1;
ALTER TABLE turmas AUTO_INCREMENT = 1;
ALTER TABLE disciplinas AUTO_INCREMENT = 1;
ALTER TABLE cursos AUTO_INCREMENT = 1;
ALTER TABLE professores AUTO_INCREMENT = 1;
ALTER TABLE alunos AUTO_INCREMENT = 1;
ALTER TABLE usuarios AUTO_INCREMENT = 1;

-- Cria uma conta ativa para cada perfil. A senha de todas e 123456.
-- ultimo_login permanece NULL para o sistema exigir uma nova senha no primeiro login.
INSERT INTO usuarios (nome, email, senha_hash, perfil, status, ultimo_login) VALUES
('Admin do Sistema', 'admin@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'admin', 'ativo', NULL),
('Coordenacao Flow', 'coordenacao@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'coordenacao', 'ativo', NULL),
('Administrativo Flow', 'administrativo@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'administrativo', 'ativo', NULL),
('Professor Flow', 'professor@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'professor', 'ativo', NULL),
('Aluno Flow', 'aluno@flowacademy.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'aluno', 'ativo', NULL);

-- Cria o cadastro profissional minimo para o professor conseguir acessar o painel.
INSERT INTO professores (id_usuario, cpf, especialidade)
SELECT id_usuario, '111.222.333-44', 'Sem turmas cadastradas'
FROM usuarios
WHERE email = 'professor@flowacademy.com';

-- Cria o cadastro academico minimo para o aluno conseguir acessar o painel.
INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
SELECT id_usuario, '2026-0001', '123.456.789-10', NULL, NULL, NULL, 'regular'
FROM usuarios
WHERE email = 'aluno@flowacademy.com';

-- Conferencia final: cinco usuarios, um aluno e um professor, sem historicos.
SELECT perfil, COUNT(*) AS total_usuarios, SUM(ultimo_login IS NULL) AS sem_ultimo_login
FROM usuarios
GROUP BY perfil
ORDER BY perfil;

SELECT
    (SELECT COUNT(*) FROM alunos) AS total_alunos,
    (SELECT COUNT(*) FROM professores) AS total_professores,
    (SELECT COUNT(*) FROM cursos) AS total_cursos,
    (SELECT COUNT(*) FROM turmas) AS total_turmas,
    (SELECT COUNT(*) FROM disciplinas) AS total_ucs,
    (SELECT COUNT(*) FROM matriculas) AS total_matriculas;
