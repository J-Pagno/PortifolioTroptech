USE AgenciaBancaria;

GO

-- 3)

SELECT Cliente.Nome, Conta.Numero, Conta.Agencia, Conta.Saldo
FROM CLIENTES Cliente
    INNER JOIN CONTAS Conta ON (Conta.Cpf = Cliente.Cpf);

-- 4)


SELECT Cliente.Nome, Con.Tipo, Con.ValorTotal, Con.QtdParcelas
FROM CLIENTES Cliente
    INNER JOIN CONTRATOS Con ON (Con.CPF = Cliente.Cpf)
    INNER JOIN CONTAS Conta ON (Conta.Cpf = Cliente.Cpf);

-- 5)

SELECT *
FROM CONTAS
WHERE Tipo = '001';

-- 6)

SELECT *
FROM CONTAS
WHERE Tipo != '001';

-- 7)


SELECT COUNT(DISTINCT Cpf) NumeroClientesPorCpf
FROM CLIENTES;

SELECT COUNT(Numero) NumeroContasPorNumero
FROM CONTAS;

SELECT COUNT(Id) NumeroContratosPorId
FROM CONTRATOS;

-- 8)

SELECT *
FROM CONTAS
WHERE year(DataAbertura) > 2021;

-- 9)

SELECT AVG(ValorTotal) MediaDosValorTotal
FROM CONTRATOS;

SELECT MAX(ValorTotal) MaiorValorTotal
FROM CONTRATOS;

SELECT SUM(ValorTotal) SomaValorTotalHabitacionais
FROM CONTRATOS WHERE Tipo = 'Habitacional';

-- 10)

DELETE FROM CONTAS;
GO

DELETE FROM CONTRATOS;
DBCC CHECKIDENT ('dbo.CONTRATOS', RESEED, 0);
GO

DELETE FROM CESTAS;
DBCC CHECKIDENT ('dbo.CESTAS', RESEED, 0);
GO

DELETE FROM CLIENTES;