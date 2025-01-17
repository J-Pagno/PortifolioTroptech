﻿CREATE DATABASE PlanilhaPatricia;

GO

USE PlanilhaPatricia;

GO

CREATE TABLE FUNCIONARIO 
(
	NOME VARCHAR(250) NOT NULL,
	CARGO VARCHAR(100) NOT NULL,
	RAMAL INT NOT NULL,
);

GO

CREATE TABLE SALA
(
	ID INT IDENTITY(1,1) NOT NULL,
	NOME VARCHAR(250) NOT NULL,
	QUANTIDADE_LUGARES INT NOT NULL,

	CONSTRAINT PK_IdSala PRIMARY KEY(ID),
);

GO

INSERT INTO SALA 
VALUES
	('Sala 101', 20),
	('Sala 102', 20),
	('Sala 203', 25);

GO

CREATE TABLE RESERVA
(
	ID INT IDENTITY(1,1) NOT NULL,
	HORARIO_INICIO DATETIME NOT NULL,
	HORARIO_FIM DATETIME NOT NULL,
	ID_SALA INT NOT NULL,
	NOME_FUNCIONARIO VARCHAR(250) NOT NULL,

	CONSTRAINT PK_IdReserva PRIMARY KEY(ID),
);

GO

ALTER TABLE FUNCIONARIO ADD ID INT IDENTITY(1,1) NOT NULL,
							CONSTRAINT PK_IdFuncionario PRIMARY KEY(ID);

GO

DELETE FROM RESERVA;

GO

ALTER TABLE RESERVA DROP COLUMN NOME_FUNCIONARIO;

ALTER TABLE RESERVA ADD ID_FUNCIONARIO INT NOT NULL,
						CONSTRAINT FK_IdFuncionario FOREIGN KEY(ID_FUNCIONARIO) REFERENCES FUNCIONARIO;

GO