CREATE DATABASE TropTechModasDB;

GO

USE TropTechModasDB;

CREATE TABLE CESTAS
(
    Id INT IDENTITY(1,1) NOT NULL,
    Descricao NVARCHAR(255) NOT NULL,
    Valor MONEY NOT NULL,

    CONSTRAINT PK_IdCestas PRIMARY KEY(Id),
);


INSERT INTO CESTAS
VALUES
    ('Platina', 12.50),
    ('Prata', 25.50),
    ('Ouro', 40.50);

CREATE TABLE ENDERECO
(
    Id INT IDENTITY(1,1) NOT NULL,
    Rua VARCHAR(100) NOT NULL,
    Numero INT NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    Pais VARCHAR(50) NOT NULL,

    CONSTRAINT PK_IdEndereco PRIMARY KEY(Id),
);

INSERT INTO ENDERECO
VALUES
    ('Rua 1', 40, 'Lages', 'SC', 'Brasil'),
    ('Rua 2', 13, 'Correia Pinto', 'SC', 'Brasil'),
    ('Rua 3', 1535, 'São Joaquim', 'SC', 'Brasil'),
    ('Rua 4', 9835, 'Florianópolis', 'SC', 'Brasil'),
    ('Rua 5', 234, 'Rio de Janeiro', 'SC', 'Brasil'),
    ('Rua 6', 87, 'Lages', 'SC', 'Brasil'),
    ('Rua 7', 12, 'Lages', 'SC', 'Brasil'),
    ('Rua 8', 98, 'Lages', 'SC', 'Brasil'),
    ('Rua 9', 23, 'Lages', 'SC', 'Brasil'),
    ('Rua 10', 65, 'Lages', 'SC', 'Brasil');

CREATE TABLE CLIENTES
(
    CadastroUnico VARCHAR(18) NOT NULL,
    Nome NVARCHAR(150) NOT NULL,
    Telefone NVARCHAR(15) NOT NULL,
    EnderecoId INT NULL,
    TipoPessoa INT,

    CONSTRAINT PK_CpfCnpjClientes PRIMARY KEY(CadastroUnico),
    CONSTRAINT FK_EnderecoClientes FOREIGN KEY(EnderecoId) REFERENCES Endereco (Id),
);

CREATE TABLE CONTAS
(
    Numero INT NOT NULL,
    Digito VARCHAR(1) NOT NULL,
    Agencia VARCHAR(4) NOT NULL,
    Tipo VARCHAR(4) NOT NULL,
    Saldo MONEY NOT NULL,
    Limite MONEY NOT NULL,
    DataAbertura DATE NOT NULL,
    Cesta NVARCHAR(7),
    Cpf BIGINT NOT NULL,

    CONSTRAINT PK_NumeroContas PRIMARY KEY (Numero),
);

INSERT INTO CONTAS
VALUES
    (12345, '4', '0420', '001', 1500.00, 200.00, '2022-01-01', 'OURO', 97945506046),
    (12457, '0', '0420', '1288', 2400.00, 200.00, '2022-08-01', 'NÃO TEM', 78014068009),
    (15742, '1', '1665', '013', 3500.00, 200.00, '2012-01-12', 'NÃO TEM', 27446351039),
    (25412, '2', '0420', '001', 11500.00, 200.00, '2022-07-31', 'PLATINA', 93260976094),
    (35715, '5', '3885', '1288', 2500.00, 200.00, '1999-01-11', 'NÃO TEM', 25520831025),
    (78945, '4', '3285', '001', 15000.00, 200.00, '2022-01-01', 'PRATA', 78014068009),
    (89562, '0', '0420', '013', 500.00, 200.00, '2022-02-02', 'NÃO TEM', 97945506046);

CREATE TABLE CONTRATOS
(
    Id INT IDENTITY(1,1) NOT NULL,
    Tipo NVARCHAR(100) NOT NULL,
    ValorTotal MONEY NOT NULL,
    QtdParcelas INT NOT NULL,
    CPF BIGINT NOT NULL,

    CONSTRAINT PK_IdContratos PRIMARY KEY (id),
);

INSERT INTO CONTRATOS
VALUES
    ('Habitacional', 350000.00, 200, 25520831025),
    ('Consignado', 50000.00, 30, 27446351039),
    ('CDC', 2000.00, 10, 78014068009),
    ('Habitacional', 100000.00, 150, 93260976094),
    ('CDC', 3500.00, 7, 97945506046);

