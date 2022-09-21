CREATE DATABASE SistemaDeEstacionamento;

GO

USE SistemaDeEstacionamento;

CREATE TABLE Cliente
(
    Cpf NVARCHAR(11) NOT NULL,
    Nome NVARCHAR(255) NOT NULL,
    DataNascimento DATETIME NOT NULL,

    CONSTRAINT PK_IdCliente PRIMARY KEY (Cpf),
);

CREATE TABLE Modelo
(
    Id INT IDENTITY(1,1) NOT NULL,
    Descricao NVARCHAR(255) NOT NULL,

    CONSTRAINT PK_IdModelo PRIMARY KEY (Id),
);

CREATE TABLE Patio
(
    Id INT IDENTITY(1,1) NOT NULL,
    Endereco NVARCHAR(255) NOT NULL,
    Capacidade INT NOT NULL,

    CONSTRAINT PK_IdPatio PRIMARY KEY (Id),
);

CREATE TABLE Veiculo
(
    Placa NVARCHAR(8) NOT NULL,
    ModeloId INT NOT NULL,
    Cor NVARCHAR(255) NOT NULL,
    Ano INT NOT NULL,
    CpfCliente NVARCHAR(11) NOT NULL,

    CONSTRAINT PK_IdVeiculo PRIMARY KEY (Placa),
    CONSTRAINT FK_ModeloId FOREIGN KEY (ModeloId) REFERENCES Modelo (Id),
    CONSTRAINT FK_ClienteId FOREIGN KEY (CpfCliente) REFERENCES Cliente (Cpf),
);

CREATE TABLE Estacionamento
(
    Id INT IDENTITY(1,1) NOT NULL,
    PatioId INT NOT NULL,
    PlacaVeiculo NVARCHAR(8) NOT NULL,
    DataEntrada DATETIME NOT NULL,
    DataSaida DATETIME NOT NULL,

    CONSTRAINT PK_IdEstacionamento PRIMARY KEY (Id),
    CONSTRAINT FK_PatioId FOREIGN KEY (PatioId) REFERENCES Patio (Id),
    CONSTRAINT FK_PlacaVeiculo FOREIGN KEY (PlacaVeiculo) REFERENCES Veiculo (Placa),
);