-- a
CREATE DATABASE TropTech;

-- b
USE TropTech;

CREATE TABLE Alunos
(
    Nome VARCHAR NOT NULL,
    Sobrenome VARCHAR NOT NULL,
    Idade INT NOT NULL,
    Turma VARCHAR NOT NULL,
    DataNascimento DATETIME NOT NULL,
    PorcentagemFaltas INT NOT NULL,
)

-- c
CREATE TABLE Professor
(
    NomeCompleto VARCHAR NOT NULL,
    DataNascimento DATETIME NOT NULL,
    CargaHoraria INT NOT NULL,
    ProfessorAutor BIT NOT NULL,
    Endereco VARCHAR NOT NULL,
    ValorHora FLOAT NOT NULL,
);