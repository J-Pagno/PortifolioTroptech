using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AntonioGastos.Domain;
using AntonioGastos.Infra.Data.Database.Config;

namespace AntonioGastos.Infra.Data.DAO
{
    public class ContaDeLuzDAO
    {
        public void Inserir(ContaDeLuz contaDeLuz)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT INTO ContasDeLuz VALUES (@NumeroDaLeitura, @DataDeLeitura, @KWGastos, @Valor, @MediaDeConsumo, @DataDePagamento);";

                    ConverterObjetoEmSQL(comando, contaDeLuz);

                    comando.CommandText = sql;

                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }
        }

        public ContaDeLuz BuscarContaPorData(DateTime dataBuscada)
        {
            ContaDeLuz contaDeLuz = null;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ContasDeLuz WHERE DataDaLeitura = @DataDaLeitura;";

                    comando.Parameters.AddWithValue("@DataDaLeitura", dataBuscada);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        contaDeLuz = ConverterSqlEmObjeto(leitor);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }

            }

            return contaDeLuz;
        }

        public bool VerificarSeDataEValida(DateTime dataDaLeitura)
        {
            bool dataEValida = false;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ContasDeLuz WHERE DataDaLeitura = @DataDaLeitura;";

                    comando.Parameters.AddWithValue("@DataDaLeitura", dataDaLeitura);

                    comando.CommandText = sql;

                    SqlDataReader leitor = null;

                    try
                    {
                        leitor = comando.ExecuteReader();

                        dataEValida = leitor.HasRows;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }

            return dataEValida;
        }

        private ContaDeLuz ConverterSqlEmObjeto(SqlDataReader leitor)
        {
            ContaDeLuz contaDeLuz = new ContaDeLuz();


            while (leitor.Read())
            {
                contaDeLuz.NumeroDaLeitura = leitor["NumeroDaLeitura"].ToString();
                contaDeLuz.DataDeLeitura = DateTime.Parse(leitor["DataDaLeitura"].ToString());
                contaDeLuz.KWGastos = int.Parse(leitor["KWGastos"].ToString());
                contaDeLuz.Valor = decimal.Parse(leitor["Valor"].ToString());
                contaDeLuz.MediaDeConsumo = int.Parse(leitor["MediaDeConsumo"].ToString());
                contaDeLuz.DataDePagamento = DateTime.Parse(leitor["DataDePagamento"].ToString());
            }

            return contaDeLuz;
        }

        private void ConverterObjetoEmSQL(SqlCommand comando, ContaDeLuz contaDeLuz)
        {
            comando.Parameters.AddWithValue("@NumeroDaLeitura", contaDeLuz.NumeroDaLeitura);
            comando.Parameters.AddWithValue("@DataDeLeitura", contaDeLuz.DataDeLeitura);
            comando.Parameters.AddWithValue("@KWGastos", contaDeLuz.KWGastos);
            comando.Parameters.AddWithValue("@Valor", contaDeLuz.Valor);
            comando.Parameters.AddWithValue("@MediaDeConsumo", contaDeLuz.MediaDeConsumo);
            comando.Parameters.AddWithValue("@DataDePagamento", contaDeLuz.DataDePagamento);
        }
    }
}
