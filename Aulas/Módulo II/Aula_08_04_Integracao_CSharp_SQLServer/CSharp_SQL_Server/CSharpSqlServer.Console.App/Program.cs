using System;
using System.Data.SqlClient;

namespace CSharpSqlServer.Console.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"data source=localhost\SQLEXPRESS;initial catalog=Escola;uid=sa;pwd=123;";

            SqlConnection conexao = new SqlConnection(connectionString);

            //Ou

            //SqlConnection conexao = new SqlConnection(connectionString);
            //conexao.ConnectionString = connectionString;

            conexao.Open();

            SqlCommand comando = new SqlCommand(
                "INSERT Aluno VALUES(12312, 'Aluno 1', 23)",
                conexao
            );

            //Ou

            //SqlCommand comando = new SqlCommand();
            //comando.Connection = conexao;
            //comando.CommandText = @"INSERT Aluno VALUES(12312, 'Aluno 1', 23)";


            //Executa um comando que altera dados no banco de dados como uma aatualização, exclusão ou inserção. Retorna um INT => Total de linhas afetadas
            comando.ExecuteNonQuery();

            conexao.Close();

            
        }
    }
}
