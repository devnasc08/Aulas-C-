-- ============================================================================
-- USUARIO DO SISTEMA FLOW ACADEMY
-- Execute uma unica vez no MySQL Workbench ou phpMyAdmin conectado como admin.
-- Esta conta e usada pelo PHP e nao possui permissoes administrativas do MySQL.
-- ============================================================================

CREATE USER IF NOT EXISTS 'flow_academy_app'@'localhost'
IDENTIFIED BY 'FlowAcademy@2026';

-- Garante a senha definida para o usuario da aplicacao.
ALTER USER 'flow_academy_app'@'localhost'
IDENTIFIED BY 'FlowAcademy@2026';

-- Permite as consultas e alteracoes executadas diretamente pelo PHP.
GRANT SELECT, INSERT, UPDATE, DELETE
ON flow_academy.*
TO 'flow_academy_app'@'localhost';

FLUSH PRIVILEGES;

-- Conferencia opcional: deve retornar o novo usuario.
SELECT User, Host
FROM mysql.user
WHERE User = 'flow_academy_app';
