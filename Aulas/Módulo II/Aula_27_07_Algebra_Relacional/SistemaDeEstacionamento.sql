USE SistemaDeEstacionamento;

-- INSERT INTO Cliente VALUES ('12345678988', 'Luizão Da Silva', '2000-04-16T00:00:00.000');
-- INSERT INTO Modelo VALUES ('Jeep');
-- INSERT INTO Veiculo VALUES ('JOG-2222', 2, 'Verde', 1999, '12345678988');
-- INSERT INTO Patio VALUES ('Rua Josinei Da Silva, 123, Lages, SC', 10);
-- INSERT INTO Estacionamento VALUES (1, 'JJJ-2020', '2022-04-15T00:00:00.000', '2022-04-15T00:00:00.000');

-- SELECT * FROM Cliente;
-- SELECT * FROM Estacionamento;
-- SELECT * FROM Modelo;
-- SELECT * FROM Patio;
-- SELECT * FROM Veiculo;

-- 2)

SELECT V.Placa, C.Nome
FROM
    Veiculo V
    INNER JOIN
    Cliente C ON (V.CpfCliente = C.Cpf);

-- 3)

SELECT Nome, Cpf
FROM
    Veiculo V
    LEFT JOIN
    Cliente C ON (V.CpfCliente = C.Cpf);

-- 4)

SELECT V.Placa, V.Cor
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.Id = 1);

--5)

SELECT V.Placa, V.Ano
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.Id = 1);

-- 6)

SELECT V.Placa, V.Cor
FROM
    Modelo M
    INNER JOIN
    Veiculo V ON (M.Id = V.ModeloId AND V.Ano > 2000);

-- 7) 

SELECT P.Endereco, E.DataEntrada, E.DataSaida
FROM
    Estacionamento E
    INNER JOIN
    Patio P ON (E.PlacaVeiculo = 'JEG-1010');

-- 8)

SELECT COUNT(Cor)
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.PlacaVeiculo = V.Placa AND V.Cor = 'Verde');

-- 9)

SELECT C.Nome
FROM
    Veiculo V
    INNER JOIN
    Cliente C ON (V.CpfCliente = C.Cpf AND V.ModeloId = 1);

-- 10)

SELECT V.Placa, E.DataEntrada, E.DataSaida
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.PlacaVeiculo = V.Placa AND V.Cor = 'Verde');

-- 11)

SELECT *
FROM Estacionamento
WHERE PlacaVeiculo = 'JJJ-2020';

-- 12)

SELECT C.Nome
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.PlacaVeiculo = V.Placa AND E.Id = 2)
    INNER JOIN
    Cliente C ON (C.Cpf = V.CpfCliente);

-- 13)

SELECT C.Cpf
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.PlacaVeiculo = V.Placa AND E.Id = 3)
    INNER JOIN
    Cliente C ON (C.Cpf = V.CpfCliente);

--14) 

SELECT M.Descricao
FROM
    Estacionamento E
    INNER JOIN
    Veiculo V ON (E.PlacaVeiculo = V.Placa AND E.Id = 2)
    INNER JOIN
    Cliente C ON (C.Cpf = V.CpfCliente)
    INNER JOIN
    Modelo M ON (V.ModeloId = M.Id);

--15)

SELECT V.Placa, C.Nome, M.Descricao
FROM
    Modelo M
    INNER JOIN
    Veiculo V ON (V.ModeloId = M.Id)
    INNER JOIN
    Cliente C ON (C.Cpf = V.CpfCliente);