-- ============================================================================
-- MIGRACAO: PERFIL FINANCEIRO PARA ADMINISTRATIVO
-- Execute este arquivo uma unica vez em um banco flow_academy ja existente.
-- A sequencia conserva os usuarios cadastrados antes da troca de perfil.
-- ============================================================================

USE flow_academy;

-- 1. Inclui administrativo antes de converter os registros que ainda usam financeiro.
ALTER TABLE usuarios
    MODIFY COLUMN perfil ENUM('aluno', 'professor', 'coordenacao', 'financeiro', 'administrativo', 'admin') NOT NULL;

-- 2. Atualiza o valor salvo por todos os funcionarios administrativos antigos.
UPDATE usuarios
SET perfil = 'administrativo'
WHERE perfil = 'financeiro';

-- 3. Remove financeiro da lista final de perfis aceitos no banco.
ALTER TABLE usuarios
    MODIFY COLUMN perfil ENUM('aluno', 'professor', 'coordenacao', 'administrativo', 'admin') NOT NULL;

-- 4. Conferencia opcional: o resultado nao deve conter financeiro.
SELECT perfil, COUNT(*) AS total_usuarios
FROM usuarios
GROUP BY perfil
ORDER BY perfil;
