USE `flow_academy`;

DELIMITER $$

-- Etapa 5: bloco de limpeza de procedures antigas do Atual.sql.
-- Este script nao altera tabelas, relacionamentos ou dados.

DROP PROCEDURE IF EXISTS `sp_alerta_risco_delete`$$
DROP PROCEDURE IF EXISTS `sp_alerta_risco_insert`$$
DROP PROCEDURE IF EXISTS `sp_alerta_risco_select`$$
DROP PROCEDURE IF EXISTS `sp_alerta_risco_select_id`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_aluno`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_curso`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_disciplina`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_frequencia`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_matricula`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_nota`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_professor`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_turma`$$
DROP PROCEDURE IF EXISTS `sp_atualizar_usuario`$$
DROP PROCEDURE IF EXISTS `sp_excluir_aluno`$$
DROP PROCEDURE IF EXISTS `sp_excluir_curso`$$
DROP PROCEDURE IF EXISTS `sp_excluir_disciplina`$$
DROP PROCEDURE IF EXISTS `sp_excluir_frequencia`$$
DROP PROCEDURE IF EXISTS `sp_excluir_matricula`$$
DROP PROCEDURE IF EXISTS `sp_excluir_nota`$$
DROP PROCEDURE IF EXISTS `sp_excluir_professor`$$
DROP PROCEDURE IF EXISTS `sp_excluir_turma`$$
DROP PROCEDURE IF EXISTS `sp_excluir_usuario`$$
DROP PROCEDURE IF EXISTS `sp_inserir_aluno`$$
DROP PROCEDURE IF EXISTS `sp_inserir_curso`$$
DROP PROCEDURE IF EXISTS `sp_inserir_disciplina`$$
DROP PROCEDURE IF EXISTS `sp_inserir_feedback`$$
DROP PROCEDURE IF EXISTS `sp_inserir_frequencia`$$
DROP PROCEDURE IF EXISTS `sp_inserir_matricula`$$
DROP PROCEDURE IF EXISTS `sp_inserir_nota`$$
DROP PROCEDURE IF EXISTS `sp_inserir_professor`$$
DROP PROCEDURE IF EXISTS `sp_inserir_turma`$$
DROP PROCEDURE IF EXISTS `sp_inserir_usuario`$$
DROP PROCEDURE IF EXISTS `sp_usuario_login`$$

DROP PROCEDURE IF EXISTS `sp_usuario_insert`$$
CREATE PROCEDURE `sp_usuario_insert`(
    IN p_nome VARCHAR(150),
    IN p_email VARCHAR(150),
    IN p_senha_hash VARCHAR(255),
    IN p_perfil VARCHAR(30),
    IN p_status VARCHAR(20)
)
BEGIN
    INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
    VALUES (p_nome, p_email, p_senha_hash, p_perfil, p_status);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_update`$$
CREATE PROCEDURE `sp_usuario_update`(
    IN p_id INT,
    IN p_nome VARCHAR(150),
    IN p_email VARCHAR(150),
    IN p_senha_hash VARCHAR(255),
    IN p_perfil VARCHAR(30),
    IN p_status VARCHAR(20)
)
BEGIN
    UPDATE usuarios
    SET nome = p_nome,
        email = p_email,
        senha_hash = p_senha_hash,
        perfil = p_perfil,
        status = p_status
    WHERE id_usuario = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_delete`$$
CREATE PROCEDURE `sp_usuario_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM usuarios
    WHERE id_usuario = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_autenticar`$$
CREATE PROCEDURE `sp_usuario_autenticar`(
    IN p_email VARCHAR(150),
    IN p_senha_hash VARCHAR(255)
)
BEGIN
    SELECT id_usuario, nome, email, senha_hash, perfil, status, ultimo_login, created_at
    FROM usuarios
    WHERE email = p_email
      AND senha_hash = p_senha_hash
      AND status = 'ativo';
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_insert`$$
CREATE PROCEDURE `sp_aluno_insert`(
    IN p_id_usuario INT,
    IN p_matricula VARCHAR(30),
    IN p_cpf VARCHAR(14),
    IN p_telefone VARCHAR(20),
    IN p_data_nascimento DATE,
    IN p_endereco VARCHAR(255),
    IN p_status_academico VARCHAR(30)
)
BEGIN
    INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
    VALUES (p_id_usuario, p_matricula, p_cpf, p_telefone, p_data_nascimento, p_endereco, p_status_academico);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_update`$$
CREATE PROCEDURE `sp_aluno_update`(
    IN p_id INT,
    IN p_id_usuario INT,
    IN p_matricula VARCHAR(30),
    IN p_cpf VARCHAR(14),
    IN p_telefone VARCHAR(20),
    IN p_data_nascimento DATE,
    IN p_endereco VARCHAR(255),
    IN p_status_academico VARCHAR(30)
)
BEGIN
    UPDATE alunos
    SET id_usuario = p_id_usuario,
        matricula = p_matricula,
        cpf = p_cpf,
        telefone = p_telefone,
        data_nascimento = p_data_nascimento,
        endereco = p_endereco,
        status_academico = p_status_academico
    WHERE id_aluno = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_delete`$$
CREATE PROCEDURE `sp_aluno_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM alunos
    WHERE id_aluno = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_insert`$$
CREATE PROCEDURE `sp_professor_insert`(
    IN p_id_usuario INT,
    IN p_cpf VARCHAR(14),
    IN p_especialidade VARCHAR(120)
)
BEGIN
    INSERT INTO professores (id_usuario, cpf, especialidade)
    VALUES (p_id_usuario, p_cpf, p_especialidade);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_professor_update`$$
CREATE PROCEDURE `sp_professor_update`(
    IN p_id INT,
    IN p_id_usuario INT,
    IN p_cpf VARCHAR(14),
    IN p_especialidade VARCHAR(120)
)
BEGIN
    UPDATE professores
    SET id_usuario = p_id_usuario,
        cpf = p_cpf,
        especialidade = p_especialidade
    WHERE id_professor = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_delete`$$
CREATE PROCEDURE `sp_professor_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM professores
    WHERE id_professor = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_insert`$$
CREATE PROCEDURE `sp_curso_insert`(
    IN p_nome VARCHAR(120),
    IN p_descricao TEXT,
    IN p_carga_horaria INT,
    IN p_status VARCHAR(20)
)
BEGIN
    INSERT INTO cursos (nome, descricao, carga_horaria, status)
    VALUES (p_nome, p_descricao, p_carga_horaria, p_status);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_curso_update`$$
CREATE PROCEDURE `sp_curso_update`(
    IN p_id INT,
    IN p_nome VARCHAR(120),
    IN p_descricao TEXT,
    IN p_carga_horaria INT,
    IN p_status VARCHAR(20)
)
BEGIN
    UPDATE cursos
    SET nome = p_nome,
        descricao = p_descricao,
        carga_horaria = p_carga_horaria,
        status = p_status
    WHERE id_curso = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_delete`$$
CREATE PROCEDURE `sp_curso_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM cursos
    WHERE id_curso = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_insert`$$
CREATE PROCEDURE `sp_disciplina_insert`(
    IN p_id_curso INT,
    IN p_nome VARCHAR(120),
    IN p_carga_horaria INT
)
BEGIN
    INSERT INTO disciplinas (id_curso, nome, carga_horaria)
    VALUES (p_id_curso, p_nome, p_carga_horaria);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_update`$$
CREATE PROCEDURE `sp_disciplina_update`(
    IN p_id INT,
    IN p_id_curso INT,
    IN p_nome VARCHAR(120),
    IN p_carga_horaria INT
)
BEGIN
    UPDATE disciplinas
    SET id_curso = p_id_curso,
        nome = p_nome,
        carga_horaria = p_carga_horaria
    WHERE id_disciplina = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_delete`$$
CREATE PROCEDURE `sp_disciplina_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM disciplinas
    WHERE id_disciplina = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_insert`$$
CREATE PROCEDURE `sp_turma_insert`(
    IN p_id_curso INT,
    IN p_id_professor INT,
    IN p_codigo_turma VARCHAR(50),
    IN p_turno VARCHAR(20),
    IN p_periodo_letivo VARCHAR(20),
    IN p_capacidade_maxima INT,
    IN p_status VARCHAR(20)
)
BEGIN
    INSERT INTO turmas (id_curso, id_professor, codigo_turma, turno, periodo_letivo, capacidade_maxima, status)
    VALUES (p_id_curso, p_id_professor, p_codigo_turma, p_turno, p_periodo_letivo, p_capacidade_maxima, p_status);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_turma_update`$$
CREATE PROCEDURE `sp_turma_update`(
    IN p_id INT,
    IN p_id_curso INT,
    IN p_id_professor INT,
    IN p_codigo_turma VARCHAR(50),
    IN p_turno VARCHAR(20),
    IN p_periodo_letivo VARCHAR(20),
    IN p_capacidade_maxima INT,
    IN p_status VARCHAR(20)
)
BEGIN
    UPDATE turmas
    SET id_curso = p_id_curso,
        id_professor = p_id_professor,
        codigo_turma = p_codigo_turma,
        turno = p_turno,
        periodo_letivo = p_periodo_letivo,
        capacidade_maxima = p_capacidade_maxima,
        status = p_status
    WHERE id_turma = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_delete`$$
CREATE PROCEDURE `sp_turma_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM turmas
    WHERE id_turma = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_insert`$$
CREATE PROCEDURE `sp_matricula_insert`(
    IN p_id_aluno INT,
    IN p_id_turma INT,
    IN p_data_matricula DATE,
    IN p_status VARCHAR(20)
)
BEGIN
    INSERT INTO matriculas (id_aluno, id_turma, data_matricula, status)
    VALUES (p_id_aluno, p_id_turma, p_data_matricula, p_status);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_update`$$
CREATE PROCEDURE `sp_matricula_update`(
    IN p_id INT,
    IN p_id_aluno INT,
    IN p_id_turma INT,
    IN p_data_matricula DATE,
    IN p_status VARCHAR(20)
)
BEGIN
    UPDATE matriculas
    SET id_aluno = p_id_aluno,
        id_turma = p_id_turma,
        data_matricula = p_data_matricula,
        status = p_status
    WHERE id_matricula = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_delete`$$
CREATE PROCEDURE `sp_matricula_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM matriculas
    WHERE id_matricula = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_insert`$$
CREATE PROCEDURE `sp_frequencia_insert`(
    IN p_id_matricula INT,
    IN p_id_disciplina INT,
    IN p_total_aulas INT,
    IN p_presencas INT
)
BEGIN
    INSERT INTO frequencia (id_matricula, id_disciplina, total_aulas, presencas)
    VALUES (p_id_matricula, p_id_disciplina, p_total_aulas, p_presencas);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_update`$$
CREATE PROCEDURE `sp_frequencia_update`(
    IN p_id INT,
    IN p_id_matricula INT,
    IN p_id_disciplina INT,
    IN p_total_aulas INT,
    IN p_presencas INT
)
BEGIN
    UPDATE frequencia
    SET id_matricula = p_id_matricula,
        id_disciplina = p_id_disciplina,
        total_aulas = p_total_aulas,
        presencas = p_presencas
    WHERE id_frequencia = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_delete`$$
CREATE PROCEDURE `sp_frequencia_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM frequencia
    WHERE id_frequencia = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_nota_insert`$$
CREATE PROCEDURE `sp_nota_insert`(
    IN p_id_matricula INT,
    IN p_id_disciplina INT,
    IN p_prova_1 DECIMAL(4,2),
    IN p_prova_2 DECIMAL(4,2),
    IN p_trabalho DECIMAL(4,2),
    IN p_comportamental DECIMAL(4,2),
    IN p_media_uc DECIMAL(4,2),
    IN p_status VARCHAR(20),
    IN p_data_lancamento DATETIME
)
BEGIN
    INSERT INTO notas (id_matricula, id_disciplina, prova_1, prova_2, trabalho, comportamental, media_uc, status, data_lancamento)
    VALUES (p_id_matricula, p_id_disciplina, p_prova_1, p_prova_2, p_trabalho, p_comportamental, p_media_uc, p_status, p_data_lancamento);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_nota_update`$$
CREATE PROCEDURE `sp_nota_update`(
    IN p_id INT,
    IN p_id_matricula INT,
    IN p_id_disciplina INT,
    IN p_prova_1 DECIMAL(4,2),
    IN p_prova_2 DECIMAL(4,2),
    IN p_trabalho DECIMAL(4,2),
    IN p_comportamental DECIMAL(4,2),
    IN p_media_uc DECIMAL(4,2),
    IN p_status VARCHAR(20),
    IN p_data_lancamento DATETIME
)
BEGIN
    UPDATE notas
    SET id_matricula = p_id_matricula,
        id_disciplina = p_id_disciplina,
        prova_1 = p_prova_1,
        prova_2 = p_prova_2,
        trabalho = p_trabalho,
        comportamental = p_comportamental,
        media_uc = p_media_uc,
        status = p_status,
        data_lancamento = p_data_lancamento
    WHERE id_nota = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_nota_delete`$$
CREATE PROCEDURE `sp_nota_delete`(
    IN p_id INT
)
BEGIN
    DELETE FROM notas
    WHERE id_nota = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_inserir_pagamento`$$
CREATE PROCEDURE `sp_inserir_pagamento`(
    IN p_id_aluno INT,
    IN p_valor DECIMAL(10,2),
    IN p_vencimento DATE,
    IN p_status VARCHAR(20)
)
BEGIN
    INSERT INTO pagamentos (id_aluno, valor, vencimento, status)
    VALUES (p_id_aluno, p_valor, p_vencimento, p_status);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_atualizar_pagamento`$$
CREATE PROCEDURE `sp_atualizar_pagamento`(
    IN p_id_pagamento INT,
    IN p_id_aluno INT,
    IN p_valor DECIMAL(10,2),
    IN p_vencimento DATE,
    IN p_status VARCHAR(20)
)
BEGIN
    UPDATE pagamentos
    SET id_aluno = p_id_aluno,
        valor = p_valor,
        vencimento = p_vencimento,
        status = p_status
    WHERE id_pagamento = p_id_pagamento;
END$$

DROP PROCEDURE IF EXISTS `sp_excluir_pagamento`$$
CREATE PROCEDURE `sp_excluir_pagamento`(
    IN p_id_pagamento INT
)
BEGIN
    DELETE FROM pagamentos
    WHERE id_pagamento = p_id_pagamento;
END$$

DROP PROCEDURE IF EXISTS `sp_inserir_alerta_risco`$$
CREATE PROCEDURE `sp_inserir_alerta_risco`(
    IN p_id_matricula INT,
    IN p_tipo_risco VARCHAR(20),
    IN p_score DECIMAL(5,2),
    IN p_status VARCHAR(20)
)
BEGIN
    INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status)
    VALUES (p_id_matricula, p_tipo_risco, p_score, p_status);

    SELECT LAST_INSERT_ID();
END$$

DROP PROCEDURE IF EXISTS `sp_atualizar_alerta_risco`$$
CREATE PROCEDURE `sp_atualizar_alerta_risco`(
    IN p_id INT,
    IN p_id_matricula INT,
    IN p_tipo_risco VARCHAR(20),
    IN p_score DECIMAL(5,2),
    IN p_status VARCHAR(20)
)
BEGIN
    UPDATE alerta_risco
    SET id_matricula = p_id_matricula,
        tipo_risco = p_tipo_risco,
        score = p_score,
        status = p_status
    WHERE id_alerta = p_id;
END$$

DROP PROCEDURE IF EXISTS `sp_excluir_alerta_risco`$$
CREATE PROCEDURE `sp_excluir_alerta_risco`(
    IN p_id INT
)
BEGIN
    DELETE FROM alerta_risco
    WHERE id_alerta = p_id;
END$$

DELIMITER ;
-- Script de procedures do Flow Academy conforme o projeto C#.
-- Nao altera tabelas, relacionamentos ou dados.
-- Remove procedures antigas do Atual.sql e recria as procedures usadas pelo Desktop.
