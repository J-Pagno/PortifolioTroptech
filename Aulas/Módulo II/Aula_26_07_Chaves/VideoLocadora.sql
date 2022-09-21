CREATE DATABASE VideoLocadora;

GO

USE VideoLocadora;

CREATE TABLE Locatario
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(255) NOT NULL,
    EnderecoCompleto NVARCHAR(255) NOT NULL,
    DataDeNascimento DATETIME NOT NULL,
    CONSTRAINT PK_IdLocatario PRIMARY KEY (Id),
);

INSERT INTO Locatario
VALUES
    ('Jorge Silva', '', '1982-03-18T00:00:00.000'),
    ('Mellissa Oliveira', '', '1985-05-10T00:00:00.000'),
    ('João Da Silva', '', '2003-10-05T00:00:00.000'),
    ('Evelin Pagno', '', '1999-03-18T00:00:00.000'),
    ('Raquel Souza', '', '1972-01-02T00:00:00.000'),
    ('Vicente Menegazzo', '', '2000-03-18T00:00:00.000'),
    ('Mario Rambusch', '', '2004-12-24T00:00:00.000'),
    ('Yuri Martins', '', '1992-09-18T00:00:00.000'),
    ('Maquele Dos Santos', '', '2002-03-18T00:00:00.000'),
    ('Beatriz Scain', '', '1998-03-12T00:00:00.000');

CREATE TABLE Categoria
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(255) NOT NULL,
    CONSTRAINT PK_IdCategoria PRIMARY KEY (Id),
);

INSERT INTO Categoria
VALUES
    ('Ficção'),
    ('Fantasia'),
    ('Drama'),
    ('Ação'),
    ('Terror'),
    ('Bang Bang'),
    ('Ficção Científica'),
    ('Aventura'),
    ('Comédia'),
    ('Documentário');

CREATE TABLE Filme
(
    Id INT IDENTITY(1,1) NOT NULL,
    Titulo NVARCHAR(255) NOT NULL,
    Ano NVARCHAR(4) NOT NULL,
    CategoriaId INT NOT NULL,
    Locado BIT NOT NULL,
    LocatarioId INT NULL,

    CONSTRAINT PK_IdFilme PRIMARY KEY (Id),
    CONSTRAINT FK_CategoriaIdFilme FOREIGN KEY (CategoriaId) REFERENCES Categoria (Id),
    CONSTRAINT FK_LocatarioIdFilme FOREIGN KEY (LocatarioId) REFERENCES Locatario (Id),
);


INSERT INTO Filme
VALUES
    ('Homem de Ferro', '2008', 1, 1, 1),
    ('Alice no País das Maravilhas', '2010', 2, 1, 2),
    ('Um Olhar do Paraíso', '2009', 3, 1, 3),
    ('O Menino do Pijama Listrado', '2008', 3, 1, 4),
    ('Caçador de Pipas', '2007', 3, 1, 5),
    ('O Céu é de Verdade', '2014', 3, 1, 6),
    ('Capitão América: O Primeiro Vingador', '2011', 1, 1, 7),
    ('Tropa de Elite', '2007', 4, 1, 8),
    ('Bright', '2017', 5, 1, 9),
    ('Sempre Ao Seu Lado', '2009', 3, 1, 10);

    -- SELECT * FROM Filme;
    -- SELECT * FROM Categoria;
    -- SELECT * FROM Locatario;