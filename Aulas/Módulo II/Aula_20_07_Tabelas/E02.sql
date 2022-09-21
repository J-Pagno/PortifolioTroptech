-- a
CREATE DATABASE Locadora;

-- b
USE Locadora;

CREATE TABLE Filmes
(
    Id INT IDENTITY(1,1) NOT NULL,
    Titutlo VARCHAR NOT NULL,
    Ano VARCHAR(4) NOT NULL,
    CategoriaID VARCHAR NOT NULL,
    Locado BIT NOT NULL,
    LocatarioID INT,
);

-- c

CREATE TABLE Categoria
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome VARCHAR NOT NULL,
);

-- d

CREATE TABLE Locatario
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome VARCHAR NOT NULL,
    EnderecoCompleto VARCHAR NOT NULL,
    DataDeNacimento DATETIME NOT NULL,
);