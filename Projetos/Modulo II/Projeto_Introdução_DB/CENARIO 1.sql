CREATE DATABASE ContaDeLuz;

USE ContaDeLuz;

CREATE TABLE Contas_Emitidas
(
    id int IDENTITY(1,1) NOT NULL,
    data_de_criacao DATETIME NOT NULL,
    numero_da_leitura int NOT NULL,
    kw_gatos int NOT NULL,
    valor money NOT NULL,
    data_do_pagamento DATETIME,
    media_de_consumo int NOT NULL,
);

INSERT INTO dbo.Contas_Emitidas
    (
    data_de_criacao
    ,numero_da_leitura
    ,kw_gatos
    ,valor
    ,data_do_pagamento
    ,media_de_consumo
    )
VALUES(
        '20220726 10:34:09 AM'
           , 22
           , 32
           , 192.32
           , '20120618 10:34:09 AM'
           , 29
           );

EXEC sp_rename 'Contas_Emitidas.valor', 'preco', 'COLUMN';

EXEC sp_rename 'Contas_Emitidas.media_de_consumo', 'media_consumo', 'COLUMN';

ALTER TABLE Contas_Emitidas ALTER COLUMN
preco DECIMAL (5, 2);

ALTER TABLE Contas_Emitidas ALTER COLUMN
kw_gatos DECIMAL (5, 2);

-- SELECT * FROM Contas_Emitidas;
 