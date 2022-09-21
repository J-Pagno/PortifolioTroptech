CREATE DATABASE Hospital;

GO

USE Hospital;

-- a

CREATE TABLE Pacientes
(
    Nome NVARCHAR NOT NULL,
    Sobrenome NVARCHAR,
    Cpf BIGINT,
    Endereco NVARCHAR,
    TemPlanoDeSaude BIT,
    NomePlanoDeSaude NVARCHAR,
    Telefone NVARCHAR,
    NomeMae NVARCHAR NOT NULL,
);

-- b

ALTER TABLE Pacientes ALTER COLUMN Sobrenome NVARCHAR NOT NULL;
ALTER TABLE Pacientes ALTER COLUMN Cpf BIGINT NOT NULL;
ALTER TABLE Pacientes ALTER COLUMN Endereco NVARCHAR NOT NULL;
ALTER TABLE Pacientes ALTER COLUMN TemPlanoDeSaude BIT NOT NULL;
ALTER TABLE Pacientes ALTER COLUMN Telefone NVARCHAR NOT NULL;

-- c

EXEC sp_rename 'Pacientes.Nome', 'NomeCompleto', 'COLUMN';
EXEC sp_rename 'Pacientes.Endereco', 'EnderecoCompleto', 'COLUMN';
EXEC sp_rename 'Pacientes.TemPlanoDeSaude', 'PossuiPlanoSaude', 'COLUMN';
EXEC sp_rename 'Pacientes.NomeMae', 'NomeCompletoMae', 'COLUMN';

-- d

ALTER TABLE Pacientes DROP COLUMN Sobrenome;

-- e

ALTER TABLE Pacientes ALTER COLUMN NomeCompleto NVARCHAR(255) NOT NULL;
ALTER TABLE Pacientes ALTER COLUMN NomeCompletoMae NVARCHAR(255) NOT NULL;