CREATE DATABASE SalaDeReuniao;

USE SalaDeReuniao;

CREATE TABLE Salas
(
    id int IDENTITY(1,1) NOT NULL,
    horarios datetime NOT NULL,
    sala_1 INT NOT NULL,
    sala_2 INT NOT NULL,
    sala_3 INT NOT NULL,
);

CREATE TABLE Funcionario
(
    id int IDENTITY(1,1) NOT NULL,
    nome_do_funcionario VARCHAR (255) NOT NULL,
    cargo VARCHAR (255) NOT NULL,
    ramal INT NOT NULL,
);

ALTER TABLE Funcionario ALTER COLUMN
nome_funcionario NVARCHAR;

ALTER TABLE Salas ALTER COLUMN
hora smalldatetime;

EXEC sp_rename 'Salas.horarios', 'hora', 'COLUMN';

EXEC sp_rename 'Funcionario.nome_do_funcionario', 'nome_funcionario', 'COLUMN';

-- SELECT * FROM Salas;