-- ============================================================================
-- RETORNO DE VERSAO: PERFIL ADMINISTRATIVO PARA FINANCEIRO
-- Execute este arquivo UMA vez apenas se o banco ja usou a versao posterior.
-- A sequencia preserva todos os usuarios cadastrados.
-- ============================================================================

USE flow_academy;

-- 1. Inclui financeiro temporariamente para aceitar a conversao dos registros.
ALTER TABLE usuarios
    MODIFY COLUMN perfil ENUM('aluno', 'professor', 'coordenacao', 'administrativo', 'financeiro', 'admin') NOT NULL;

-- 2. Retorna os funcionarios administrativos para o perfil financeiro desta etapa.
UPDATE usuarios
SET perfil = 'financeiro'
WHERE perfil = 'administrativo';

-- 3. Remove administrativo da lista final de perfis aceitos pelo banco.
ALTER TABLE usuarios
    MODIFY COLUMN perfil ENUM('aluno', 'professor', 'coordenacao', 'financeiro', 'admin') NOT NULL;

-- 4. Conferencia opcional dos perfis restantes.
SELECT perfil, COUNT(*) AS total_usuarios
FROM usuarios
GROUP BY perfil
ORDER BY perfil;
