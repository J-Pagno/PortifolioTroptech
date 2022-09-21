CREATE DATABASE ClubeDaLeitura;

GO

USE ClubeDaLeitura;

GO

CREATE TABLE Amigos
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(255) NOT NULL,
    NomeDaMae NVARCHAR(255) NOT NULL,
    Telefone VARCHAR(14) NOT NULL,
    DeOndeE INT NOT NULL,

    CONSTRAINT PK_IdAmigo PRIMARY KEY(Id),
);

GO

CREATE TABLE Caixas
(
    Numero INT IDENTITY(1,1) NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    Estiqueta VARCHAR(100) NOT NULL,

    CONSTRAINT PK_IdCaixa PRIMARY KEY(Numero),
);

GO

CREATE TABLE Revistas
(
    Id INT IDENTITY(1,1) NOT NULL,
    TipoDaColecao NVARCHAR(255) NOT NULL,
    NumeroDaEdicao INT NOT NULL,
    Ano DATE NOT NULL,
    CaixaId INT NOT NULL,

    CONSTRAINT PK_IdRevista PRIMARY KEY(Id),
    CONSTRAINT FK_CaixaIdRevista FOREIGN KEY (CaixaId) REFERENCES Caixas,
);

GO

CREATE TABLE Emprestimos
(
    Id INT IDENTITY(1,1) NOT NULL,
    IdAmigo INT NOT NULL,
    IdRevista INT NOT NULL,
    DataEmprestimo DATE NOT NULL,
    DataDevolucao DATE NOT NULL,
    Preco MONEY NULL,

    CONSTRAINT FK_IdAmigoEmprestimo FOREIGN KEY (IdAmigo) REFERENCES Amigos,
    CONSTRAINT FK_IdRevistaEmprestimo FOREIGN KEY (IdRevista) REFERENCES Revistas,
);
