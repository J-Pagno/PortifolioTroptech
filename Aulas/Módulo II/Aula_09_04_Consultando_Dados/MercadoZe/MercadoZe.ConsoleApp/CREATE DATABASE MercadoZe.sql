CREATE DATABASE MercadoZe;

GO

USE MercadoZe;

GO

CREATE TABLE Produtos
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome VARCHAR(100),
    Descricao VARCHAR(255),

    CONSTRAINT PK_IdProduto PRIMARY KEY(Id),
);


CREATE TABLE Clientes
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome VARCHAR(100),

    CONSTRAINT PK_IdCliente PRIMARY KEY(Id),
);