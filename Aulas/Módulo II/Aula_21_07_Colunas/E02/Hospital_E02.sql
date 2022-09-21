DROP TABLE Cirurgias;

GO

-- a

CREATE TABLE Cirurgias
(
    Paciente VARCHAR(100) NOT NULL,
    Medico VARCHAR(100) NOT NULL,
    Data DATETIME NOT NULL,
);

-- b

EXEC sp_rename 'Cirurgias.Paciente','NomePaciente','COLUMN';
EXEC sp_rename 'Cirurgias.Medico','NomeMedico','COLUMN';
EXEC sp_rename 'Cirurgias.Data','DataAgendada','COLUMN';

-- c

ALTER TABLE Cirurgias ADD
                    SalaCirurgia VARCHAR NOT NULL,
                    NomeCirurgia VARCHAR NOT NULL,
                    RequerAcompanhante BIT NOT NULL;

-- d

ALTER TABLE Cirurgias ALTER COLUMN NomePaciente NVARCHAR(100) NOT NULL;
ALTER TABLE Cirurgias ALTER COLUMN NomeMedico NVARCHAR(100) NOT NULL;