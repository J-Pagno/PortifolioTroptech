--CREATE DATABASE AntonioGastos;

--GO

--USE AntonioGastos;

--GO

--CREATE TABLE ContasDeLuz
--(
--	NumeroDaLeitura VARCHAR(6) NOT NULL,
--	DataDaLeitura DATE NOT NULL,
--	KWGastos INT NOT NULL,
--	Valor MONEY NOT NULL,
--	MediaDeConsumo INT NOT NULL,
--	DataDePagamento DATE NOT NULL,

--	CONSTRAINT PK_NumeroDaLeitura PRIMARY KEY(NumeroDaLeitura),
--)

--GO

INSERT INTO ContasDeLuz	
VALUES 
	('DEF123', '2022-09-02', 10, 190.52, 10, '2022-09-08'),
	('CDE123', '2022-09-02', 10, 220.12, 10, '2022-09-08'),
	('BCD123', '2022-06-02', 10, 180.42, 10, '2022-06-07');