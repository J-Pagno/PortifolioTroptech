CREATE DATABASE ControleDeRemedios;

USE ControleDeRemedios;

CREATE TABLE Remedios
(
    id int IDENTITY(1,1) NOT NULL,
    nome_usuario VARCHAR (255) NOT NULL,
    data_de_inicio DATETIME NOT NULL,
    total_dias int NOT NULL,
    qtd_por_dia int NOT NULL,
    dosagem INT NOT NULL,
    nome_do_remedio VARCHAR (255) NOT NULL,
);

INSERT INTO dbo.Remedios
    (nome_usuario
    ,data_de_inicio
    ,total_dias
    ,qtd_por_dia
    ,dosagem
    ,nome_do_remedio)
VALUES
    ('Jorge'
           , '20220726 10:34:09 AM'
           , 8
           , 2
           , 5
           , 'Paracetamol')

EXEC sp_rename 'Remedios.dosagem', 'dose', 'COLUMN';

EXEC sp_rename 'Remedios.nome_usuario', 'usuario', 'COLUMN';

ALTER TABLE Remedios ALTER COLUMN
dose DECIMAL (5, 2);

ALTER TABLE Remedios ALTER COLUMN
qtd_por_dia DECIMAL (5, 2);

-- SELECT * FROM Remedios;
 