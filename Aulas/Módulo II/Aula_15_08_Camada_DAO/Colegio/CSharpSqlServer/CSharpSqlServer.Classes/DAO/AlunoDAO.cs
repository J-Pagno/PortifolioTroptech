using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSharpSqlServer.Classes.DAO
{
    public class AlunoDAO
    {
        private const string _connectionString =
            @"data source=.\SQLEXPRESS;initial catalog=Colegio;uid=sa;pwd=123;";

        public AlunoDAO() { }

        public void AdicionarAluno(Aluno aluno)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql = @"INSERT INTO ALUNO VALUES(@Matricula, @Nome, @Idade);";

                    comando.Connection = conexao;

                    ConverteObjetoParaParametrosSql(aluno, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarAluno(Aluno alunoAtualizado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql =
                        @"UPDATE ALUNO SET NOME = @Nome, IDADE = @Idade WHERE MATRICULA = @Matricula_Para_Atualizar;";

                    comando.Connection = conexao;

                    comando.Parameters.AddWithValue(
                        "@Matricula_Para_Atualizar",
                        alunoAtualizado.Matricula
                    );

                    ConverteObjetoParaParametrosSql(alunoAtualizado, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarAluno(Aluno alunoDeletado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql = @"DELETE FROM ALUNO WHERE MATRICULA = @Matricula_Para_Deletar;";

                    comando.Connection = conexao;

                    comando.Parameters.AddWithValue(
                        "@Matricula_Para_Deletar",
                        alunoDeletado.Matricula
                    );

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Aluno> BuscarTodosOsAlunos()
        {
            var listaAlunos = new List<Aluno>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql = @"SELECT * FROM ALUNO";

                    comando.Connection = conexao;

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Aluno alunoBuscado = ConverterSqlParaObjeto(leitor);

                        listaAlunos.Add(alunoBuscado);
                    }
                }
            }

            return listaAlunos;
        }

        public List<Aluno> BuscarAlunoPorNome(string nomeBuscado)
        {
            var listaAlunos = new List<Aluno>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql = @"SELECT * FROM ALUNO WHERE NOME LIKE @Nome_Buscado";

                    comando.Connection = conexao;

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@Nome_Buscado", $"%{nomeBuscado}%");

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Aluno alunoBuscado = ConverterSqlParaObjeto(leitor);

                        listaAlunos.Add(alunoBuscado);
                    }
                }
            }

            return listaAlunos;
        }

        public Aluno BuscarAlunoPelaMatricula(Aluno alunoDeletado)
        {
            Aluno alunoBuscado = null;

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql = @"SELECT * FROM ALUNO WHERE MATRICULA = @Matricula_Para_Deletar;";

                    comando.Connection = conexao;

                    comando.Parameters.AddWithValue(
                        "@Matricula_Para_Deletar",
                        alunoDeletado.Matricula
                    );

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    alunoBuscado = ConverterSqlParaObjeto(leitor);
                }
            }
            
            return alunoBuscado;
        }

        private Aluno ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            Aluno alunoBuscado = new Aluno();

            alunoBuscado.Nome = leitor["NOME"].ToString();
            alunoBuscado.Matricula = int.Parse(leitor["MATRICULA"].ToString());
            alunoBuscado.Idade = int.Parse(leitor["IDADE"].ToString());

            return alunoBuscado;
        }

        private void ConverteObjetoParaParametrosSql(Aluno aluno, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@Matricula", aluno.Matricula);
            comando.Parameters.AddWithValue("@Nome", aluno.Nome);
            comando.Parameters.AddWithValue("@Idade", aluno.Idade);
        }
    }
}
