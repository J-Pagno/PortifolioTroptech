USE Hospital;

-- 1)

INSERT INTO Pacientes
VALUES('Fabiano Souza', 08525566899, 'Rua Ceará, 589, Bairro São Cristóvão, Lages-SC', 1, 'unimed', '49 8895-8854', 'Maria de Souza');

-- 2)

INSERT INTO Pacientes
VALUES('Marizete Pereira', 08525578988, 'Rua Pernambuco, 789, Bairro São Cristóvão, Lages-SC', 0, NULL, '49 9985-9966', 'Maria Alzete Pereira');

-- 3)

UPDATE Pacientes SET EnderecoCompleto = 'Rua Acre, 888, Bairro São Cristóvão, Lages-SC' WHERE Cpf = 08525566899;

-- 4)

DELETE FROM Pacientes WHERE Cpf = 08525578988;

-- 5)

SELECT *
FROM Pacientes;

-- 6)

SELECT Cpf, PossuiPlanoSaude
FROM Pacientes;

-- 7)

INSERT INTO Cirurgias
    (NomePaciente, NomeMedico, DataAgendada, SalaCirurgia, NomeCirurgia, RequerAcompanhante)
VALUES
    ('Fabiano Souza', 'José Amaral', '2022-08-24T00:00:00.000', 'Sala 04', 'amigdalectomia', 1);

-- 8)

ALTER TABLE Cirurgias ADD
                NomeAcompanhante NVARCHAR(100);

-- 9)

INSERT INTO Cirurgias
    (NomeMedico, DataAgendada, SalaCirurgia, NomeCirurgia, RequerAcompanhante)
VALUES
    ('Adair Silva', '2022-08-27T00:00:00.000', 'Sala 5', 'vasectomia', 0);

-- 10)

ALTER TABLE Cirurgias ALTER COLUMN NomePaciente NVARCHAR(100);