USE ClubeDaLeitura;

-- 2) 

INSERT INTO Amigos
VALUES
    ('Jorge', 'Juliana', '49988776655', 0),
    ('Helena', 'Marina', '49977665544', 0),
    ('Maria', 'Jorjana', '49966554433', 0),
    ('Luiz', 'Maria', '49955443322', 0),
    ('Evelin', 'Marialucia', '49944332211', 0),
    ('Janete', 'Lúcia', '49933221100', 1);

GO

INSERT INTO Caixas
VALUES
    ('Caixa 1', 'MARVEL'),
    ('Caixa 2', 'DC Comics');

GO

INSERT INTO Revistas
VALUES
    ('Vingadores', 123, '2000/01/01', 1),
    ('Quarteto Fantástico', 234, '2001/01/01', 1),
    ('Batman', 135, '1999/01/01', 2),
    ('X-Men', 163, '1979/01/01', 1),
    ('Homem-Aranha', 145, '2010/01/01', 1),
    ('Capitão América', 245, '1992/01/01', 1),
    ('Homem de Ferro', 156, '2008/01/01', 1),
    ('Superman', 212, '1980/01/01', 2),
    ('Homem-Formiga', 195, '1969/01/01', 1),
    ('Mulher-Maravilha', 158, '2018/01/01', 2);

GO

INSERT INTO Emprestimos
VALUES
    (1, 1, '2022/01/01', '2022/01/12', NULL),
    (2, 2, '2022/01/02', '2022/01/13', NULL),
    (3, 3, '2022/01/03', '2022/01/14', NULL),
    (4, 4, '2022/01/04', '2022/01/15', NULL),
    (5, 5, '2022/01/05', '2022/01/16', NULL),
    (6, 6, '2022/01/06', '2022/01/17', NULL),
    (5, 7, '2022/01/05', '2022/01/16', NULL),
    (4, 8, '2022/01/04', '2022/01/15', NULL),
    (3, 9, '2022/01/03', '2022/01/14', NULL),
    (2, 10, '2022/01/02', '2022/01/13', NULL);

GO

-- 3)

UPDATE Emprestimos SET Preco = 18.25 WHERE Id = 1;
UPDATE Emprestimos SET Preco = 15.25 WHERE Id = 2;
UPDATE Emprestimos SET Preco = 11.25 WHERE Id = 3;
UPDATE Emprestimos SET Preco = 12.25 WHERE Id = 4;
UPDATE Emprestimos SET Preco = 14.25 WHERE Id = 5;
UPDATE Emprestimos SET Preco = 15.25 WHERE Id = 6;
UPDATE Emprestimos SET Preco = 17.25 WHERE Id = 7;
UPDATE Emprestimos SET Preco = 21.25 WHERE Id = 8;
UPDATE Emprestimos SET Preco = 8.25 WHERE Id = 9;
UPDATE Emprestimos SET Preco = 5.25 WHERE Id = 10;

GO

-- 10)

USE ClubeDaLeitura;

DELETE FROM Emprestimos;
DBCC CHECKIDENT('Emprestimos', RESEED, 0);
GO

DELETE FROM Revistas;
DBCC CHECKIDENT('Revistas', RESEED, 0);
GO

DELETE FROM Caixas;
DBCC CHECKIDENT('Caixas', RESEED, 0);
GO

DELETE FROM Amigos;
DBCC CHECKIDENT('Amigos', RESEED, 0);
GO