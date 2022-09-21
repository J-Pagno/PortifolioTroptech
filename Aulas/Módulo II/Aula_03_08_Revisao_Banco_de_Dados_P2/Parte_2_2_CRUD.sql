USE TropTechModasDB;

-- 1) 

INSERT INTO VENDA
VALUES
    ('Venda 1', 22.03, '25520831025'),
    ('Venda 2', 2.30, '27446351038'),
    ('Venda 3', 2.30, '27446351039'),
    ('Venda 4', 2.30, '78014068008'),
    ('Venda 5', 2.30, '78014068009'),
    ('Venda 6', 2.30, '93260976093'),
    ('Venda 7', 2.30, '93260976094'),
    ('Venda 8', 2.30, '93260976093'),
    ('Venda 9', 2.30, '78014068009'),
    ('Venda 10', 2.30, '78014068008');

-- 2)

DELETE FROM VENDA WHERE CadastroUnicoCliente LIKE '25520831025';

-- 3)

DECLARE @CadastroUnicoCliente VARCHAR(20)

SELECT @CadastroUnicoCliente = CadastroUnico FROM CLIENTES WHERE CadastroUnico LIKE '78014068009';

DELETE FROM VENDA WHERE CadastroUnicoCliente LIKE @CadastroUnicoCliente;
DELETE FROM CLIENTES WHERE CadastroUnico LIKE @CadastroUnicoCliente;

-- 4)

UPDATE VENDA SET Descricao = 'Descrição Atualizada' WHERE CadastroUnicoCliente LIKE '93260976094';