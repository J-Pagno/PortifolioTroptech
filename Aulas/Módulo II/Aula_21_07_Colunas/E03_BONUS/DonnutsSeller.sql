CREATE DATABASE DonnutSeller;

GO

USE DonnutSeller;

CREATE TABLE DonnutOptions
(
    Nome NVARCHAR(100) NOT NULL,
    Preco MONEY NOT NULL,
    TemRecheio BIT NOT NULL,
    TemCobertura BIT NOT NULL,
);

ALTER TABLE DonnutOptions ADD 
                        Sabor NVARCHAR(50) NOT NULL;

EXEC sp_rename 'DonnutOptions.Nome','NomeDoDonnut','COLUMN';
EXEC sp_rename 'DonnutOptions.TemRecheio', 'ComRecheio', 'COLUMN';
EXEC sp_rename 'DonnutOptions.TemCobertura', 'ComCobertura', 'COLUMN';