using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSharpSqlServer.Classes.DAO
{
    public class AlunoDao
    {
        private const string _connectionString =
                @"data source=.\SQLEXPRESS;initial catalog=MercadoZe;uid=sa;pwd=123;";
        public AlunoDao() { }

        public void AdicionarAluno(Aluno novoAluno)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT ALUNO VALUES (@MATRICULA, @NOME, @IDADE);";

                    ConverteObjetoParaSql(novoAluno, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Aluno> BuscarTodos()
        {
            var listaAlunos = new List<Aluno>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ALUNO";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Aluno alunoBuscado = ConverterSqlParaObejto(leitor);

                        listaAlunos.Add(alunoBuscado);
                    }
                }
            }

            return listaAlunos;
        }

        public void AtualizarAluno(Aluno alunoEditado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql =
                        @"UPDATE ALUNO SET NOME = @NOME, IDADE = @IDADE WHERE MATRICULA = @MATRICULA_ALUNO";

                    comando.Parameters.AddWithValue("@MATRICULA_ALUNO", alunoEditado.Matricula);

                    ConverteObjetoParaSql(alunoEditado, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarAluno(Aluno aluno)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM ALUNO WHERE MATRICULA = @MATRICULA_ALUNO";

                    comando.Parameters.AddWithValue("@MATRICULA_ALUNO", aluno.Matricula);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public Aluno BuscarAlunoPorMatricula(int matricula)
        {
            Aluno alunoBuscado = null;

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql =
                        @"SELECT MATRICULA, NOME, IDADE FROM ALUNO WHERE MATRICULA = @MATRICULA_ALUNO";

                    comando.Parameters.AddWithValue("@MATRICULA_ALUNO", matricula);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        alunoBuscado = ConverterSqlParaObejto(leitor);
                    }
                }
            }

            return alunoBuscado;
        }

        public List<Aluno> BuscarAlunoPorNome(string texto)
        {
            var listaAlunos = new List<Aluno>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ALUNO WHERE NOME LIKE @TEXTO";

                    comando.Parameters.AddWithValue("@TEXTO", $"%{texto}%");

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Aluno alunoBuscado = ConverterSqlParaObejto(leitor);

                        listaAlunos.Add(alunoBuscado);
                    }
                }
            }

            return listaAlunos;
        }

        private void ConverteObjetoParaSql(Aluno aluno, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@MATRICULA", aluno.Matricula);
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@IDADE", aluno.Idade);
        }

        private Aluno ConverterSqlParaObejto(SqlDataReader leitor)
        {
            Aluno alunoBuscado = new Aluno();

            alunoBuscado.Nome = leitor["NOME"].ToString();
            alunoBuscado.Matricula = int.Parse(leitor["MATRICULA"].ToString());
            alunoBuscado.Idade = int.Parse(leitor["IDADE"].ToString());

            return alunoBuscado;
        }
    }
}
