using System;
using System.Data.SqlClient;

namespace SeuZeCRUD
{
    public static class MenuProduto
    {
        private static SqlConnection _connection = new SqlConnection();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Gerenciamento de Produtos:");

                Console.WriteLine("a. Adicionar Produto");
                Console.WriteLine("b. Editar Produto");
                Console.WriteLine("c. Deletar");
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
                        DeletarProduto();
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
                        Aviso("Opção Inválida!");
                        break;
                }
            } while (true);
        }

        public static void Aviso(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(msg);

            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
        }

        public static void AbrirConexao()
        {
            var connectionString =
                @"data source=.\SQLEXPRESS;initial catalog=MercadoZe;uid=sa;pwd=123;";

            _connection.ConnectionString = connectionString;

            _connection.Open();
        }

        public static void FecharConexao()
        {
            _connection.Close();
        }

        public static void AdicionarProduto()
        {
            Console.Clear();

            Console.WriteLine("--- CADASTRO DE PRODUTO ---");

            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a decrição do produto: ");
            string descricao = Console.ReadLine();

            AbrirConexao();

            SqlCommand comando = new SqlCommand();

            comando.Parameters.AddWithValue("@Nome", nome);
            comando.Parameters.AddWithValue("@Descricao", descricao);

            comando.Connection = _connection;

            try
            {
                AbrirConexao();

                SqlCommand comandoReader = new SqlCommand();

                comandoReader.Parameters.AddWithValue("@Nome", nome);
                comandoReader.Parameters.AddWithValue("@Descricao", descricao);

                comandoReader.Connection = _connection;

                comando.CommandText = $"SELECT Max(Id) FROM Produtos;";

                SqlDataReader dadoAtualizado = comando.ExecuteReader();

                while (dadoAtualizado.Read())
                {
                    Console.WriteLine($"O produto {dadoAtualizado[nome]} foi inserido com sucesso!");
                }
                comando.CommandText =
                    $"UPDATE Produtos SET Quantidade = ((SELECT TOP 1 Quantidade FROM Produtos WHERE Nome LIKE @Nome) + 1) WHERE Nome LIKE @Nome;";

                comando.ExecuteNonQuery();

                FecharConexao();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                comando.CommandText = $"INSERT INTO Produtos VALUES (@Nome, @Descricao, 1);";

                comando.ExecuteNonQuery();

                FecharConexao();

                AbrirConexao();

                SqlCommand comandoReader = new SqlCommand();

                comandoReader.Parameters.AddWithValue("@Nome", nome);
                comandoReader.Parameters.AddWithValue("@Descricao", descricao);

                comandoReader.Connection = _connection;

                comandoReader.CommandText = $"SELECT Max(Id) FROM Produtos;";

                SqlDataReader dados = comandoReader.ExecuteReader();

                while (dados.Read())
                {
                    Console.WriteLine($"O produto {dados[nome]} foi inserido com sucesso!");
                }

                Console.WriteLine(e.Message);

                Console.ReadKey();
            }
            finally
            {
                FecharConexao();
            }
        }

        public static void AtualizarProduto()
        {
            Console.Clear();

            Console.WriteLine("--- ATUALIZAÇÃO DE PRODUTO ---");

            bool idProduto;
            int id;

            do
            {
                Console.WriteLine("Digite a identificação do produto: ");
                idProduto = int.TryParse(Console.ReadLine(), out id);
            } while (!idProduto);

            Console.WriteLine("Digite o novo nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a nova decrição do produto: ");
            string descricao = Console.ReadLine();

            AbrirConexao();

            SqlCommand comando = new SqlCommand();

            comando.Connection = _connection;
            comando.CommandText =
                $"UPDATE Produtos SET Nome = @nome, Descricao = @descricao WHERE Id = @Id;";

            comando.Parameters.AddWithValue("@Nome", nome);
            comando.Parameters.AddWithValue("@Descricao", descricao);
            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            FecharConexao();
        }

        public static void DeletarProduto()
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

            AbrirConexao();

            SqlCommand comando = new SqlCommand();

            comando.Connection = _connection;
            comando.CommandText = $"DELETE FROM Produtos WHERE Id = @Id;";

            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            FecharConexao();
        }

        public static void BuscarProdutoPelaDescricao()
        {
            Console.Clear();

            Console.WriteLine("--- BUSCA DE PRODUTO PELA DESCRIÇÃO ---");

            Console.WriteLine("Digite a descrição do produto: ");
            string descricaoProduto = Console.ReadLine();

            AbrirConexao();

            SqlCommand comando = new SqlCommand();

            comando.Connection = _connection;
            comando.CommandText = $"SELECT * FROM Produtos WHERE Descricao = @Descricao;";

            comando.Parameters.AddWithValue("@Descricao", descricaoProduto);

            SqlDataReader dados = comando.ExecuteReader();

            while (dados.Read())
            {
                Console.Write(dados["Nome"]);
                Console.CursorLeft = 20;
                Console.WriteLine(dados["Descricao"]);
            }

            FecharConexao();

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

            AbrirConexao();

            SqlCommand comando = new SqlCommand();

            comando.Connection = _connection;
            comando.CommandText = $"SELECT * FROM Produtos WHERE Id = @Id;";

            comando.Parameters.AddWithValue("@Id", idProduto);

            SqlDataReader dados = comando.ExecuteReader();

            while (dados.Read())
            {
                Console.Write(dados["Nome"]);
                Console.CursorLeft = 20;
                Console.Write(dados["Descricao"]);
            }

            FecharConexao();

            Console.ReadKey();
        }

        public static void BuscarTodosOsProdutos()
        {
            Console.Clear();

            AbrirConexao();

            SqlCommand comando = new SqlCommand();

            comando.Connection = _connection;

            comando.CommandText = $"SELECT * FROM Produtos;";

            SqlDataReader dados = comando.ExecuteReader();

            Console.Write("Id");

            Console.CursorLeft = 5;

            Console.Write(" | Nome");

            Console.CursorLeft = 30;

            Console.Write(" | Descricao");

            Console.CursorLeft = 45;

            Console.WriteLine(" | Quantidade");

            Console.WriteLine("—————————————————————————————————————————————————————————————————");

            while (dados.Read())
            {
                Console.Write(dados["Id"]);

                Console.CursorLeft = 5;

                Console.Write(" | ");

                Console.Write(dados["Nome"]);

                Console.CursorLeft = 30;

                Console.Write(" | ");

                Console.Write(dados["Descricao"]);

                Console.CursorLeft = 45;

                Console.Write(" | ");

                Console.WriteLine(dados["Quantidade"]);
            }

            FecharConexao();

            Console.ReadKey();
        }
    }
}
