
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoZe.Classes;
using MercadoZe.Classes.DAO;

namespace MercadoZe.ConsoleApp
{
    class Program
    {
        static ProdutoDAO _produtoDao = new ProdutoDAO();
        static string _opcao = "";
        static int _idProduto = 0;
        static Produto _produtoEncontrado = new Produto();
        static List<Produto> _listaProdutos = new List<Produto>();

        static void Main(string[] args)
        {
            EscolherUmaOpcao();
        }

        //MENU
        public static void EscolherUmaOpcao()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU PRODUTO       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar produto");
            Console.WriteLine(" 2 - Editar produto");
            Console.WriteLine(" 3 - Deletar produto");
            Console.WriteLine(" 4 - Buscar produto por indentificador");
            Console.WriteLine(" 5 - Buscar produto por texto");
            Console.WriteLine(" 6 - Buscar todos os produtos");
            Console.WriteLine(" 7 - Entrada de produtos");
            Console.WriteLine(" 8 - Saída de produtos");
            Console.Write("=> ");
            _opcao = Console.ReadLine();

            AtribuirFuncionalidades();
        }
        //MENU

        //VOLTAR
        public static void Voltar()
        {
            EscolherUmaOpcao();
        }
        //VOLTAR

        //FUNCIONALIDADES
        public static void AtribuirFuncionalidades()
        {
            switch (_opcao)
            {
                case "1":
                    Console.Clear();
                    AdicionarProduto();
                    Voltar();
                    break;
                case "2":
                    Console.Clear();
                    AtualizarProduto();
                    Voltar();
                    break;
                case "3":
                    Console.Clear();
                    DeletarProduto();
                    Voltar();
                    break;
                case "4":
                    Console.Clear();
                    BuscarProdutoPorId();
                    Voltar();
                    break;
                case "5":
                    Console.Clear();
                    BuscarProdutoPorTexto();
                    Voltar();
                    break;
                case "6":
                    Console.Clear();
                    BuscaTodosProdutos();
                    Voltar();
                    break;
                case "7":
                    Console.Clear();
                    EntradaEstoque();
                    Console.ReadKey();
                    Voltar();
                    break;
                case "8":
                    Console.Clear();
                    SaidaEstoque();
                    Console.ReadKey();
                    Voltar();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    Voltar();
                    break;
            }

        }
        //FUNCIONALIDADES

        public static void AdicionarProduto()
        {

            Produto novoProduto = new Produto();
            Console.WriteLine("--                   CADASTRO DE PRODUTO                -- ");

            Console.WriteLine("Digite o nome do produto:");
            novoProduto.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição:");
            novoProduto.Descricao = Console.ReadLine();

            Console.WriteLine("Digite a data de vencimento:(DD/MM/YYYY)");
            novoProduto.DataVencimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o preço unitário:");
            novoProduto.PrecoUnitario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a unidade:");
            novoProduto.Unidade = Console.ReadLine();

            _produtoDao.AdicionarProduto(novoProduto);

        }
        
        public static void AtualizarProduto()
        {
            Console.Clear();
            Console.WriteLine(" --          EDITAR PRODUTO         -- \n");

            Console.WriteLine("Digite o id do produto que será editado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                Voltar();
            }

            Console.WriteLine($" Produto que será editado:\n {_produtoEncontrado}");

            Console.ReadKey();

           Console.WriteLine("Digite o nome do produto:");
            _produtoEncontrado.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição:");
            _produtoEncontrado.Descricao = Console.ReadLine();

            Console.WriteLine("Digite a data de vencimento:(DD/MM/YYYY)");
            _produtoEncontrado.DataVencimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o preço unitário:");
            _produtoEncontrado.PrecoUnitario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a unidade:");
            _produtoEncontrado.Unidade = Console.ReadLine();

            _produtoDao.AtualizarProduto(_produtoEncontrado);
        }

        public static void DeletarProduto()
        {
            Console.WriteLine(" --          DELETAR PRODUTO          -- \n");

            Console.WriteLine("Digite o id do produto que será editado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                Voltar();
            }

            Console.WriteLine($" Produto que será deletado:\n {_produtoEncontrado}");
            Console.ReadKey();
            _produtoDao.DeletarProduto(_produtoEncontrado);

        }

        public static void BuscarProdutoPorId()
        {
            Console.WriteLine("--           PRODUTO         -- \n");

            Console.WriteLine("Digite o id do produto que será editado:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);
            Console.WriteLine("Produto encontrado:");
            Console.WriteLine("--------------------------------------");
            if (_produtoEncontrado.Id != 0)
            {
                Console.WriteLine(_produtoEncontrado);
            }
            Console.ReadKey();
        }

        public static void BuscarProdutoPorTexto()
        {
            Console.WriteLine("--           LISTA PRODUTOS         -- \n");
            Console.WriteLine("Digite o texto do produto:");
            var texto = Console.ReadLine();
            _listaProdutos = _produtoDao.BuscaPorTexto(texto);

            Console.WriteLine("Produtos encontrados:");
            Console.WriteLine("--------------------------------------");
            foreach (var item in _listaProdutos)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }
            Console.ReadKey();
        }

        public static void BuscaTodosProdutos()
        {
            Console.WriteLine("--           LISTA PRODUTOS         -- \n");
            _listaProdutos = _produtoDao.BuscaTodos();

            foreach (var item in _listaProdutos)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }
            Console.ReadKey();
        }

        public static void EntradaEstoque()
        {
            Console.Clear();
            Console.WriteLine(" --          ENTRADA ESTOQUE         -- \n");

            Console.WriteLine("Digite o id do produto:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                Voltar();
            }

            Console.WriteLine($"Quantidade atual no estoque: {_produtoEncontrado.QuantidadeEstoque}");

            Console.ReadKey();

            Console.WriteLine("Digite a quantidade de entrada no estoque:");
            var quantidade = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado.EntradaEstoque(quantidade);
            _produtoDao.EntradaESaidaEstoque(_produtoEncontrado);
        }

        public static void SaidaEstoque()
        {
            Console.Clear();
            Console.WriteLine(" --          SAIDA ESTOQUE         -- \n");

            Console.WriteLine("Digite o id do produto:");
            _idProduto = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado = _produtoDao.BuscarPorId(_idProduto);

            if (_produtoEncontrado.Id == 0)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                Voltar();
            }

            Console.WriteLine($"Quantidade atual no estoque: {_produtoEncontrado.QuantidadeEstoque}");

            Console.ReadKey();

            Console.WriteLine("Digite a quantidade de saída no estoque:");
            var quantidade = Convert.ToInt32(Console.ReadLine());

            _produtoEncontrado.SaidaEstoque(quantidade);
            _produtoDao.EntradaESaidaEstoque(_produtoEncontrado);
        }
    }
}
