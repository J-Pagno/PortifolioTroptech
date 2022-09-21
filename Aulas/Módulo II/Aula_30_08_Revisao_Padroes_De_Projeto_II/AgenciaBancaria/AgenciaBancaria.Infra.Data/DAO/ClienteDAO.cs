using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Infra.Data.DataBase.DBSettings;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ClienteDAO
    {
        public List<Cliente> ListarTodosOsClientes()
        {
            List<Cliente> listaClientes = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE";

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        Cliente cliente = null;

                        while (leitor.Read())
                        {
                            cliente = new Cliente()
                            {
                                Cpf = long.Parse(leitor["CPF"].ToString()),
                                Nome = leitor["NOME"].ToString(),
                                DataNascimento = DateTime.Parse(leitor["DATA_NASCIMENTO"].ToString())
                            };

                            listaClientes.Add(cliente);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }

            return listaClientes;
        }

        public Cliente BuscarClientePorCPF(long cpf)
        {
            Cliente cliente = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE WHERE CPF = @Cpf";

                    comando.Parameters.AddWithValue("@Cpf", cpf);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        if (leitor.HasRows)
                            cliente = ConverterSqlEmObjeto(leitor);
                        else
                            cliente = null;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }

            return cliente;
        }
        
        private Cliente ConverterSqlEmObjeto(SqlDataReader leitor)
        {
            Cliente cliente = new();

            while (leitor.Read())
            {
                cliente.Cpf = long.Parse(leitor["CPF"].ToString());
                cliente.Nome = leitor["NOME"].ToString();
                cliente.DataNascimento = DateTime.Parse(leitor["DATA_NASCIMENTO"].ToString());
            }

            return cliente;
        }

        private void ConverterObjetoEmSql(SqlCommand comando, Cliente cliente)
        {
            comando.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            comando.Parameters.AddWithValue("@Nome", cliente.Nome);
            comando.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
        }

    }
}
