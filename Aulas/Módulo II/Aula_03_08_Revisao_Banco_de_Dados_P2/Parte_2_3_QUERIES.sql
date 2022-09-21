USE TropTechModasDB;

-- 1)

SELECT C.Nome, C.Telefone, V.* FROM VENDA V INNER JOIN CLIENTES C ON (V.CadastroUnicoCliente = C.CadastroUnico);

-- 2)

SELECT * FROM VENDA WHERE CadastroUnicoCliente LIKE '93260976093';

-- 3)

SELECT V.Valor, C.Nome, CONCAT(E.Rua, ', ', E.Numero, ', ',E.Cidade, ', ', E.Estado, ', ', E.Pais ) AS EndereçoCompleto FROM VENDA V LEFT JOIN CLIENTES C ON (V.CadastroUnicoCliente = C.CadastroUnico)
LEFT JOIN ENDERECO E ON (C.EnderecoId = E.Id);