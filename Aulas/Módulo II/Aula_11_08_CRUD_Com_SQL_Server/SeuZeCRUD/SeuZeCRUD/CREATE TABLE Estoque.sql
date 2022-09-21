DECLARE @Nome VARCHAR

SET @Nome = 'a'

UPDATE Produtos SET Quantidade = ((SELECT TOP 1 Quantidade FROM Produtos WHERE Nome LIKE @Nome) + 1) WHERE Nome LIKE '@Nome';