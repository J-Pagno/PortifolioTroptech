using System;
using System.Data.SqlClient;

namespace MercadoZe.ConsoleApp
{
    public class ExercicioPDF
    {
        public static SqlConnection conexao = new SqlConnection(Program.ConnectionString);

        public ExercicioPDF()
        {
            // InsertData();

            // ReadDataInitialL();
            // Console.ReadKey();
            // Console.Clear();

            // ReadDataBiggerThenTwenty();
            // Console.ReadKey();
            // Console.Clear();

            // ReadData15214();
            // Console.ReadKey();
            // Console.Clear();

            InserirAluno();

            ExibirTudo();
            Console.ReadKey();
            Console.Clear();
        }

        public static void InsertData()
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(
                "INSERT INTO Aluno VALUES (12574,'MARCOS SILVA', 19), (32411,'THIAGO SARTOR', 32), (12549,'MARCOS LIMA', 17),(15214,'ALINE SOUZA', 22), (16542,'LORENA MARQUES', 21), (12322,'RUBENS SOUZA',22), (12323,'LEO LINHARES',34), (16541,'HUMBERTO SOUZA',12), (13254,'LUIZA LINHARES',23);",
                conexao
            );

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public static void ReadDataInitialL()
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(
                "SELECT * FROM Aluno WHERE Nome LIKE 'L%'",
                conexao
            );

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(leitor["Nome"]);
            }

            conexao.Close();
        }

        public static void ReadDataBiggerThenTwenty()
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM Aluno WHERE Idade > 20", conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(leitor["Nome"]);
            }

            conexao.Close();
        }

        public static void ReadData15214()
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(
                "SELECT * FROM Aluno WHERE Codigo = 15214",
                conexao
            );

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(leitor["Nome"]);
            }

            conexao.Close();
        }

        public static void ExibirTudo()
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM Aluno", conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.Write("Nome: " + leitor["Nome"]);
                Console.CursorLeft = 30;
                Console.WriteLine("Idade: " + leitor["Idade"]);
            }

            conexao.Close();
        }

        public static void InserirAluno()
        {
            Console.WriteLine("Código: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            SqlParameter parametroCodigo = new SqlParameter();
            parametroCodigo.ParameterName = "@codigo";
            parametroCodigo.Value = codigo;

            SqlParameter parametroNome = new SqlParameter();
            parametroNome.ParameterName = "@nome";
            parametroNome.Value = nome;

            SqlParameter parametroIdade = new SqlParameter();
            parametroIdade.ParameterName = "@idade";
            parametroIdade.Value = idade;

            conexao.Open();

            SqlCommand comando = new SqlCommand(
                @"INSERT INTO Aluno VALUES(@codigo, @nome, @idade)",
                conexao
            );

            comando.Parameters.Add(parametroCodigo);
            comando.Parameters.Add(parametroNome);
            comando.Parameters.Add(parametroIdade);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}
