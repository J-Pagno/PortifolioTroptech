using System;
using System.Data.SqlClient;

namespace MercadoZe.ConsoleApp
{
    class Program
    {
        public static string ConnectionString =
            @"data source=localhost\SQLEXPRESS;initial catalog=INTEGRACAO_CSHARP;uid=sa;pwd=123;";

        static void Main(string[] args)
        {
            //     try
            //     {
            //         AdicionarProduto();

            //         ConsultarTodosOsProdutos();
            //         Console.ReadKey();
            //         Console.Clear();

            //         ConsultarProdutoPeloId(1);
            //         Console.ReadKey();
            //         Console.Clear();

            //         ConsultarProdutoPelaDescricao("Descricao");
            //         Console.ReadKey();
            //         Console.Clear();

            //         ExibirTodosOsProdutosEClientes();
            //         Console.ReadKey();
            //         Console.Clear();
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(e.Message);
            //     }


            try
            {
                ExercicioPDF ex = new ExercicioPDF();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsultarTodosOsProdutos()
        {
            SqlConnection conexao = new SqlConnection(ConnectionString);

            conexao.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM Produtos;", conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(leitor["Nome"]);
            }

            conexao.Close();
        }

        static void ConsultarProdutoPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection(ConnectionString);

            conexao.Open();

            SqlCommand comando = new SqlCommand(
                $"SELECT * FROM Produtos WHERE Id = {id};",
                conexao
            );

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(leitor["Nome"]);
            }

            conexao.Close();
        }

        static void ConsultarProdutoPelaDescricao(string descricao)
        {
            SqlConnection conexao = new SqlConnection(ConnectionString);

            conexao.Open();

            SqlCommand comando = new SqlCommand(
                $"SELECT * FROM Produtos WHERE Descricao LIKE '{descricao}';",
                conexao
            );

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(leitor["Nome"]);
            }

            conexao.Close();
        }

        static void AdicionarProduto()
        {
            Console.WriteLine("Digite o nome do produto:");
            string descricao = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Digite a descrição do produto:");
            string nome = Console.ReadLine();

            SqlConnection conexao = new SqlConnection(ConnectionString);

            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand(
                    $"INSERT INTO Produtos(Nome, Descricao) VALUES('{nome}','{descricao}');",
                    conexao
                );

                comando.ExecuteNonQuery();

                conexao.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ExibirTodosOsProdutosEClientes()
        {
            SqlConnection conexao = new SqlConnection(ConnectionString);

            conexao.Open();

            SqlCommand comandoProdutos = new SqlCommand($"SELECT * FROM Produtos;", conexao);

            SqlDataReader leitorProdutos = comandoProdutos.ExecuteReader();

            Console.WriteLine("Produtos: ");
            Console.WriteLine();

            while (leitorProdutos.Read())
            {
                Console.Write("Nome do Produto: ");
                Console.WriteLine(leitorProdutos["Nome"]);
            }

            Console.WriteLine("\nClientes: ");
            Console.WriteLine();

            conexao.Close();

            conexao.Open();

            SqlCommand comandoClientes = new SqlCommand($"SELECT * FROM Clientes;", conexao);

            SqlDataReader leitorClientes = comandoClientes.ExecuteReader();

            while (leitorClientes.Read())
            {
                Console.Write("Nome do Cliente: ");
                Console.WriteLine(leitorClientes["Nome"]);
            }

            conexao.Close();
        }
    }
}
