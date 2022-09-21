using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Infra.Data.DataBase.DBSettings;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ContaDAO
    {
        public List<Conta> MostrarTodasAsContas()
        {
            List<Conta> listaContas = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CONTA";

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();
                        while (leitor.Read())
                        {
                            Conta conta = new()
                            {
                                Numero = int.Parse(leitor["NUMERO"].ToString()),
                                Digito = int.Parse(leitor["DIGITO"].ToString()),
                                Agencia = leitor["AGENCIA"].ToString(),
                                TipoConta = int.Parse(leitor["TIPO_DE_CONTA"].ToString()),
                                Saldo = decimal.Parse(leitor["SALDO"].ToString()),
                                Limite = decimal.Parse(leitor["LIMITE"].ToString()),
                                DataAbertura = DateTime.Parse(leitor["DATA_ABERTURA"].ToString()),
                                Cesta = (Conta.TipoDeCesta)int.Parse(leitor["CESTA"].ToString()),
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                            };

                            listaContas.Add(conta);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }
            return listaContas;
        }

        public void CadastrarUmaNovaConta(Conta conta)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT INTO CONTA VALUES (@Numero, @Digito, @Agencia, @TipoConta, @Saldo, @Limite, @DataAbertura, @Cesta, @CpfCliente);";

                    comando.CommandText = sql;

                    ConverterObjetoEmSql(comando, conta);

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

        public List<Conta> BuscarContaPorCliente(long cpf)
        {
            List<Conta> listaContas = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CONTA WHERE CPF_CLIENTE = @Cpf;";

                    comando.Parameters.AddWithValue("@Cpf", cpf);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();
                        while (leitor.Read())
                        {
                            Conta conta = new()
                            {
                                Numero = int.Parse(leitor["NUMERO"].ToString()),
                                Digito = int.Parse(leitor["DIGITO"].ToString()),
                                Agencia = leitor["AGENCIA"].ToString(),
                                TipoConta = int.Parse(leitor["TIPO_DE_CONTA"].ToString()),
                                Saldo = decimal.Parse(leitor["SALDO"].ToString()),
                                Limite = decimal.Parse(leitor["LIMITE"].ToString()),
                                DataAbertura = DateTime.Parse(leitor["DATA_ABERTURA"].ToString()),
                                Cesta = (Conta.TipoDeCesta)int.Parse(leitor["CESTA"].ToString()),
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                            };

                            listaContas.Add(conta);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }

            return listaContas;
        }

        public Conta BuscarContaPorNumero(int numero)
        {
            Conta conta = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CONTA WHERE NUMERO = @Numero;";

                    comando.Parameters.AddWithValue("@Numero", numero);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        if (leitor.HasRows)
                            conta = ConverterSqlEmObjeto(leitor);
                        else
                            conta = null;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }

            return conta;
        }

        private Conta ConverterSqlEmObjeto(SqlDataReader leitor)
        {
            Conta conta = new();

            while (leitor.Read())
            {
                conta.Numero = int.Parse(leitor["NUMERO"].ToString());
                conta.Digito = int.Parse(leitor["DIGITO"].ToString());
                conta.Agencia = leitor["AGENCIA"].ToString();
                conta.TipoConta = int.Parse(leitor["TIPO_CONTA"].ToString());
                conta.Saldo = decimal.Parse(leitor["SALDO"].ToString());
                conta.Limite = decimal.Parse(leitor["LIMITE"].ToString());
                conta.DataAbertura = DateTime.Parse(leitor["DATA_ABERTURA"].ToString());
                conta.Cesta = (Conta.TipoDeCesta)int.Parse(leitor["CESTA"].ToString());
                conta.CpfCliente = int.Parse(leitor["CPF_CLIENTE"].ToString());
            }

            return conta;
        }

        private void ConverterObjetoEmSql(SqlCommand comando, Conta conta)
        {
            comando.Parameters.AddWithValue("@Numero", conta.Numero);
            comando.Parameters.AddWithValue("@Digito", conta.Digito);
            comando.Parameters.AddWithValue("@Agencia", conta.Agencia);
            comando.Parameters.AddWithValue("@TipoConta", conta.TipoConta);
            comando.Parameters.AddWithValue("@Saldo", conta.Saldo);
            comando.Parameters.AddWithValue("@Limite", conta.Limite);
            comando.Parameters.AddWithValue("@DataAbertura", conta.DataAbertura);
            comando.Parameters.AddWithValue("@Cesta", (int)conta.Cesta);
            comando.Parameters.AddWithValue("@CpfCliente", conta.CpfCliente);
        }
    }
}
