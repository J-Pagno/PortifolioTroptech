USE ClubeDaLeitura;

-- 4)

SELECT *
FROM Emprestimos
WHERE Preco > 11 AND Preco < 17;

-- 5)

SELECT E.Id, E.DataDevolucao, E.Preco, R.TipoDaColecao
FROM Emprestimos E LEFT JOIN Revistas R ON (E.IdRevista = R.Id)
WHERE R.TipoDaColecao LIKE 'Homem-Aranha' OR R.TipoDaColecao LIKE 'Batman';

-- 6)

SELECT *
FROM Amigos
WHERE Nome LIKE '%A%';
SELECT *
FROM Amigos
WHERE Nome LIKE '%A';
SELECT *
FROM Amigos
WHERE Nome LIKE 'A%';

-- 7)

SELECT AVG(Preco) AS Media, SUM(Preco) AS Soma, MIN(Preco) AS Preço
FROM Emprestimos
WHERE year(DataEmprestimo) = 2022;

-- 8)

SELECT (SELECT COUNT(Id)
    FROM Amigos) AS QtdAmigos, (SELECT COUNT(Id)
    FROM Revistas) AS QtdRevistas,
    (SELECT COUNT(Id)
    FROM Emprestimos) AS QtdEmprestimos;

-- 9)

SELECT E.Id, E.DataEmprestimo, E.DataDevolucao, E.Preco, R.TipoDaColecao, A.Nome
FROM Emprestimos E INNER JOIN Revistas R ON (E.IdRevista = R.Id) INNER JOIN Amigos A ON (E.IdAmigo = A.Id)
ORDER BY E.DataDevolucao;