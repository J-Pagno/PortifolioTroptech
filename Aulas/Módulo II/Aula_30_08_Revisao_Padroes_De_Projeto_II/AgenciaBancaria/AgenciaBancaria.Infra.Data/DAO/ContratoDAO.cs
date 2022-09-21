using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Infra.Data.DataBase.DBSettings;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ContratoDAO
    {
        public bool InserirContrato(Contrato contrato)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT INTO CONTRATO VALUES(@Numero, @TipoContrato, @QuantidadeParcelas, @DataInicial, @DataFinal, @ValorTotal, @CpfCliente);";

                    ConverterObjetorEmSql(comando, contrato);

                    comando.CommandText = sql;

                    try
                    {
                        comando.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();

                        return false;
                    }
                }
            }
        }

        public List<Contrato> ListarContratosPorCliente(long cpf)
        {
            List<Contrato> listaDeContratos = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CONTRATO WHERE CPF_CLIENTE = @CpfCliente";

                    comando.Parameters.AddWithValue("@CpfCliente", cpf);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            Contrato contrato = new Contrato()
                            {
                                Numero = int.Parse(leitor["NUMERO"].ToString()),
                                TipoContrato = (Contrato.Contratos)(int.Parse(leitor["TIPO_CONTRATO"].ToString())),
                                QuantidadeParcelas = int.Parse(leitor["QUANTIDADE_PARCELAS"].ToString()),
                                DataInicial = DateTime.Parse(leitor["DATA_INICIAL"].ToString()),
                                DataFinal = DateTime.Parse(leitor["DATA_FINAL"].ToString()),
                                ValorTotal = decimal.Parse(leitor["VALOR_TOTAL"].ToString()),
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                            };

                            listaDeContratos.Add(contrato);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.ToString());
                        Console.ReadKey();
                    }
                }
            }

            return listaDeContratos;
        }

        public string ObterNomeDoCliente(long cpf)
        {
            string nomeDoCliente = String.Empty;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT NOME FROM CLIENTE WHERE CPF = @CpfCliente";

                    comando.Parameters.AddWithValue("@CpfCliente", cpf);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            nomeDoCliente = leitor["NOME"].ToString();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }

            return nomeDoCliente;
        }

        private Contrato ConverterSqlEmObjeto(SqlDataReader leitor)
        {
            Contrato contrato = new();

            while (leitor.Read())
            {
                contrato.Numero = int.Parse(leitor["NUMERO"].ToString());
                contrato.TipoContrato = (Contrato.Contratos)(int.Parse(leitor["TIPO_CONTRATO"].ToString()));
                contrato.QuantidadeParcelas = int.Parse(leitor["QUANTIDADE_PARCELAS"].ToString());
                contrato.DataInicial = DateTime.Parse(leitor["DATA_INICIAL"].ToString());
                contrato.ValorTotal = decimal.Parse(leitor["DATA_FINAL"].ToString());
                contrato.CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString());
            }

            return contrato;
        }

        private void ConverterObjetorEmSql(SqlCommand comando, Contrato contrato)
        {
            comando.Parameters.AddWithValue("@Numero", contrato.Numero);
            comando.Parameters.AddWithValue("@TipoContrato", contrato.TipoContrato);
            comando.Parameters.AddWithValue("@QuantidadeParcelas", contrato.QuantidadeParcelas);
            comando.Parameters.AddWithValue("@DataInicial", contrato.DataInicial);
            comando.Parameters.AddWithValue("@DataFinal", contrato.DataFinal);
            comando.Parameters.AddWithValue("@ValorTotal", contrato.ValorTotal);
            comando.Parameters.AddWithValue("@CpfCliente", contrato.CpfCliente);
        }
    }
}
