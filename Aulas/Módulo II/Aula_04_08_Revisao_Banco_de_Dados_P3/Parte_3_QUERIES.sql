USE TropTechModasDB;

-- 1)

SELECT SUM(Valor) AS MediaValorDeVendas
FROM VENDA;

-- 2)

SELECT COUNT(DISTINCT V.CadastroUnicoCliente) AS QtdClientesComVendas
FROM CLIENTES C RIGHT JOIN VENDA V ON (C.CadastroUnico = V.CadastroUnicoCliente);

-- 3)

SELECT COUNT(C.CadastroUnico) AS QtdClientesSemVenda
FROM CLIENTES C LEFT JOIN VENDA V ON (C.CadastroUnico = V.CadastroUnicoCliente)
WHERE V.CadastroUnicoCliente IS NULL;

-- 4)

SELECT MAX(Valor)
FROM VENDA;

-- 5)

SELECT Nome, Telefone
FROM CLIENTES
WHERE EnderecoId IS NULL;

-- 6)

SELECT CONCAT('R$ ', SUM(Valor)) AS TotalDoFaturamento
FROM VENDA;

-- 7)

SELECT COUNT(C.CadastroUnico) AS QtdVendaDoCliente
FROM CLIENTES C LEFT JOIN VENDA V ON (C.CadastroUnico = V.CadastroUnicoCliente)
WHERE V.CadastroUnicoCliente LIKE '27446351038';

-- 8)

SELECT CONCAT('Fisica: ', COUNT(TipoPessoa)) AS QtdPessoa FROM CLIENTES WHERE TipoPessoa = 1
UNION ALL
SELECT CONCAT('Juridica: ', COUNT(TipoPessoa)) FROM CLIENTES WHERE TipoPessoa = 2;