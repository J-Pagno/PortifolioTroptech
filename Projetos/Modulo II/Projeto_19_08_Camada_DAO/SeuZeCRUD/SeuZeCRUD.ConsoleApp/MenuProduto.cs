using System;
using System.Collections.Generic;
using SeuZeCRUD.Classes;
using System.Data.SqlClient;
using SeuZeCRUD.Classes.DAO;
using SeuZeCRUD.ConsoleApp.Messages;

namespace SeuZeCRUD
{
    public static class MenuProduto
    {
        private static ProdutoDAO _produtoDAO = new ProdutoDAO();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Gerenciamento de Produtos:");

                Console.WriteLine(
                    "a. Adicionar Produto (Caso o produto já exista, o estoque receberá +1 do item em questão)"
                );
                Console.WriteLine("b. Atualizar Produto");
                Console.WriteLine("c. Deletar pelo identificador");
                Console.WriteLine("d. Buscar todos os produtos");
                Console.WriteLine("e. Buscar produto por descrição");
                Console.WriteLine("f. Buscar produto pelo identificador");
                Console.WriteLine("g. Sair");

                var opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida.ToLower())
                {
                    case "a":
                        AdicionarProduto();
                        break;

                    case "b":
                        AtualizarProduto();
                        break;

                    case "c":
                        DeletarProdutoPeloIdentificador();
                        break;

                    case "d":
                        BuscarTodosOsProdutos();
                        break;

                    case "e":
                        BuscarProdutoPelaDescricao();
                        break;

                    case "f":
                        BuscarProdutoPeloIdentificador();
                        break;

                    case "g":
                        return;

                    default:
                        Messages.Falha("Opção Inválida!");
                        break;
                }
            } while (true);
        }

        public static void AdicionarProduto()
        {
            Console.Clear();

            Produto produto = new();

            Console.WriteLine("--- CADASTRO DE PRODUTO ---");

            Console.WriteLine("Digite o nome do produto: ");
            produto.Nome = Console.ReadLine();

            Console.WriteLine("Digite a decrição do produto: ");
            produto.Descricao = Console.ReadLine();

            try
            {
                _produtoDAO.AdicionarProduto(produto);

                Messages.Sucesso("Produto adicionado com sucesso!");
            }
            catch (Exception e)
            {
                Messages.Falha("Erro no menu");
            }
        }

        public static void AtualizarProduto()
        {
            Console.Clear();

            Produto produto = new();

            Console.WriteLine("--- ATUALIZAÇÃO DE PRODUTO ---");

            bool idProduto = false;

            do
            {
                Console.WriteLine("Digite a identificação do produto: ");
                try
                {
                    produto.Id = int.Parse(Console.ReadLine());
                    idProduto = true;
                }
                catch (Exception e)
                {
                    Messages.Falha(e.Message);
                }
            } while (!idProduto);

            Console.WriteLine("Digite o novo nome do produto: ");
            produto.Nome = Console.ReadLine();

            Console.WriteLine("Digite a nova decrição do produto: ");
            produto.Descricao = Console.ReadLine();

            try
            {
                Produto produtoAntigo = _produtoDAO.AtualizarProduto(produto);

                Messages.Sucesso(
                    "O produto \"" + produtoAntigo.Nome + "\" foi atualizado com sucesso!"
                );
            }
            catch (Exception e)
            {
                Messages.Falha(e.Message);
            }
        }

        public static void DeletarProdutoPeloIdentificador()
        {
            Console.Clear();

            Console.WriteLine("--- EXCLUSÃO DE PRODUTO ---");

            bool idProduto;
            int id;

            do
            {
                Console.WriteLine("Digite a identificação do produto: ");
                idProduto = int.TryParse(Console.ReadLine(), out id);
            } while (!idProduto);

            try
            {
                Produto produtoDeletado = _produtoDAO.DeletarProduto(id);

                Messages.Sucesso(
                    "O produto \"" + produtoDeletado.Nome + "\" foi deletado com sucesso!"
                );
            }
            catch (Exception e)
            {
                Messages.Falha(e.Message);
            }
        }

        public static void BuscarProdutoPelaDescricao()
        {
            Console.Clear();

            Console.WriteLine("--- BUSCA DE PRODUTO PELA DESCRIÇÃO ---");

            Console.WriteLine("Digite a descrição do produto: ");
            string descricaoProduto = Console.ReadLine();

            List<Produto> llistaDeProdutos = _produtoDAO.BuscarProdutosPorDescricao(
                descricaoProduto
            );

            TabelaProduto(listaDeProdutos);

            Console.ReadKey();
        }

        public static void BuscarProdutoPeloIdentificador()
        {
            Console.Clear();

            bool validIdProduto;
            int idProduto;

            do
            {
                Console.WriteLine("--- BUSCA DE PRODUTO PELO IDENTIFICADOR   ---");

                Console.WriteLine("Digite a descrição do produto: ");
                validIdProduto = int.TryParse(Console.ReadLine(), out idProduto);
            } while (!validIdProduto);

            Produto produto = _produtoDAO.BuscarProdutosPorIdentificador(idProduto);

            CabecalhoTabelaProdutos();

            Console.Write(produto.Id);

            Console.CursorLeft = 5;

            Console.Write(" | ");

            Console.Write(produto.Nome);

            Console.CursorLeft = 30;

            Console.Write(" | ");

            Console.Write(produto.Descricao);

            Console.CursorLeft = 55;

            Console.Write(" | ");

            Console.WriteLine(produto.Quantidade);

            Console.ReadKey();
        }

        public static void BuscarTodosOsProdutos()
        {
            Console.Clear();

            List<Produto> listaDeProdutos = _produtoDAO.BuscarTodosOsProdutos();

            TabelaProduto(listaDeProdutos);

            Console.ReadKey();
        }

        private static void CabecalhoTabelaProdutos()
        {
            Console.Write("Id");

            Console.CursorLeft = 5;

            Console.Write(" | Nome");

            Console.CursorLeft = 30;

            Console.Write(" | Descricao");

            Console.CursorLeft = 55;

            Console.WriteLine(" | Quantidade");

            Console.WriteLine("—————————————————————————————————————————————————————————————————");
        }

        private static void TabelaProduto(List<Produto> listaDeProdutos)
        {
            CabecalhoTabelaProdutos();

            foreach (var produto in listaDeProdutos)
            {
                Console.Write(produto.Id);

                Console.CursorLeft = 5;

                Console.Write(" | ");

                Console.Write(produto.Nome);

                Console.CursorLeft = 30;

                Console.Write(" | ");

                Console.Write(produto.Descricao);

                Console.CursorLeft = 55;

                Console.Write(" | ");

                Console.WriteLine(produto.Quantidade);
            }
        }
    }
}
