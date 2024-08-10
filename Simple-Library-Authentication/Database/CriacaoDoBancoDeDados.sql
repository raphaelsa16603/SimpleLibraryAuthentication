-- Verificar se o banco de dados j� existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SimpleLibraryAuthenticationDB')
BEGIN
    -- Criar o banco de dados
    CREATE DATABASE SimpleLibraryAuthenticationDB;
    PRINT 'Banco de dados SimpleLibraryAuthenticationDB criado com sucesso.';
END
ELSE
BEGIN
    PRINT 'Banco de dados SimpleLibraryAuthenticationDB j� existe.';
END
GO

-- Usar o banco de dados criado
USE SimpleLibraryAuthenticationDB;
GO

-- Verificar se a tabela Users j� existe
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    -- Criar a tabela Users
    CREATE TABLE Users (
        Username NVARCHAR(50) NOT NULL PRIMARY KEY,
        PasswordHash NVARCHAR(MAX) NOT NULL
    );
    PRINT 'Tabela Users criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'Tabela Users j� existe.';
END
GO
