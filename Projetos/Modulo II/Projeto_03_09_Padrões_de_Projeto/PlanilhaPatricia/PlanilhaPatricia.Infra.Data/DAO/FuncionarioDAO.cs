using System;
using System.Data.SqlClient;
using PlanilhaPatricia.Domain.Entidades;
using PlanilhaPatricia.Infra.Data.Database.DBSettings;

namespace PlanilhaPatricia.Infra.Data.DAO
{
    public class FuncionarioDAO
    {
        public int CadastrarFuncionario(Funcionario funcionario)
        {
            int maxId = 0;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT INTO FUNCIONARIO VALUES(@Nome, @Cargo, @Ramal);";

                    ConverterObjetoEmSql(comando, funcionario);

                    comando.CommandText = sql;

                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }

            maxId = SelecionarUltimoId();

            return maxId;
        }

        public int SelecionarUltimoId()
        {
            int ultimoId = 0;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT MAX(ID) AS ULTIMO_ID FROM FUNCIONARIO;";

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            ultimoId = int.Parse(leitor["ULTIMO_ID"].ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }

            return ultimoId;
        }

        private Funcionario ConverterSqlEmObjeto(SqlDataReader leitor)
        {
            Funcionario funcionario = new();

            while (leitor.Read())
            {
                funcionario.Id = int.Parse(leitor["ID"].ToString());
                funcionario.Nome = leitor["NOME"].ToString();
                funcionario.Cargo = leitor["CARGO"].ToString();
                funcionario.Ramal = int.Parse(leitor["RAMAL"].ToString());
            }

            return funcionario;
        }

        private void ConverterObjetoEmSql(SqlCommand comando, Funcionario funcionario)
        {
            comando.Parameters.AddWithValue("@Id", funcionario.Id);
            comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
            comando.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
            comando.Parameters.AddWithValue("@Ramal", funcionario.Ramal);
        }
    }
}