using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using SeuZeCRUD.Classes.DAO.DB_Settings;
using SeuZeCRUD.Classes.Struct;

namespace SeuZeCRUD.Classes.DAO
{
    public class ClienteDAO
    {
        public bool AdicionarCliente(Cliente cliente)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    if (!CpfExiste(cliente.Cpf))
                    {
                        string sql =
                            @"INSERT INTO Clientes VALUES(@Nome, @Cpf, @Data_Nascimento, @Rua, @Numero, @Bairro, @Cep, @Complemento, @Pontos_Fidelidade);";

                        ConverterObjetoParaSql(cliente, comando);

                        comando.CommandText = sql;

                        try
                        {
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public Cliente AtualizarCliente(Cliente clienteAtualizado)
        {
            Cliente clienteAntigo = BuscarClienteEspecifico(clienteAtualizado.Cpf);

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText =
                        $"UPDATE Clientes SET Nome = @Nome, Data_Nascimento = @Data_Nascimento, Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cep = @Cep, Complemento = @Complemento, Pontos_Fidelidade = @Pontos_Fidelidade WHERE Cpf = @Cpf;";

                    ConverterObjetoParaSql(clienteAtualizado, comando);

                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadKey();
                    }
                }
            }

            return clienteAntigo;
        }

        public Cliente DeletarCliente(string cpf)
        {
            Cliente clienteDeletado = BuscarClienteEspecifico(cpf);

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"DELETE FROM Clientes WHERE Cpf LIKE @Cpf;";

                    comando.Parameters.AddWithValue("@Cpf", cpf);

                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadKey();
                    }
                }
            }

            return clienteDeletado;
        }

        public List<Cliente> BuscarTodosOsClientes()
        {
            List<Cliente> listaDeClientes = new List<Cliente>();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    string sql = @"SELECT * FROM Clientes;";

                    comando.Connection = conexao;

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    try
                    {
                        while (leitor.Read())
                        {
                            listaDeClientes.Add(
                                new Cliente
                                {
                                    Cpf = leitor["Cpf"].ToString(),
                                    Nome = leitor["Nome"].ToString(),
                                    DataNascimento = DateTime.Parse(
                                        leitor["Data_Nascimento"].ToString()
                                    ),
                                    PontosDeFidelidade = int.Parse(
                                        leitor["Pontos_Fidelidade"].ToString()
                                    ),
                                    Endereco = new Endereco
                                    {
                                        Rua = leitor["Rua"].ToString(),
                                        Numero = int.Parse(leitor["Numero"].ToString()),
                                        Bairro = leitor["Bairro"].ToString(),
                                        Cep = leitor["Cep"].ToString(),
                                        Complemento = leitor["Complemento"].ToString(),
                                    }
                                }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return listaDeClientes;
        }

        public List<Cliente> BuscarClientePeoNome(string nome)
        {
            List<Cliente> listaDeClientes = new List<Cliente>();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Clientes WHERE Nome LIKE @Nome;";

                    comando.Parameters.AddWithValue("@Nome", $"%{nome}%");

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    try
                    {
                        while (leitor.Read())
                        {
                            listaDeClientes.Add(
                                new Cliente
                                {
                                    Cpf = leitor["Cpf"].ToString(),
                                    Nome = leitor["Nome"].ToString(),
                                    DataNascimento = DateTime.Parse(
                                        leitor["Data_Nascimento"].ToString()
                                    ),
                                    PontosDeFidelidade = int.Parse(
                                        leitor["Pontos_Fidelidade"].ToString()
                                    ),
                                    Endereco = new Endereco
                                    {
                                        Rua = leitor["Rua"].ToString(),
                                        Numero = int.Parse(leitor["Numero"].ToString()),
                                        Bairro = leitor["Bairro"].ToString(),
                                        Cep = leitor["Cep"].ToString(),
                                        Complemento = leitor["Complemento"].ToString(),
                                    }
                                }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return listaDeClientes;
        }

        public Cliente BuscarClientePeloCpf(string cpf)
        {
            Cliente cliente = null;

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Clientes WHERE Cpf LIKE @Cpf;";

                    comando.Parameters.AddWithValue("@Cpf", cpf);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    cliente = ConverterSqlParaObjeto(leitor);
                }
            }

            return cliente;
        }

        private void ConverterObjetoParaSql(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            comando.Parameters.AddWithValue("@Nome", cliente.Nome);
            comando.Parameters.AddWithValue("@Data_Nascimento", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@Pontos_Fidelidade", cliente.PontosDeFidelidade);
            comando.Parameters.AddWithValue("@Rua", cliente.Endereco.Rua);
            comando.Parameters.AddWithValue("@Numero", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@Bairro", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@Cep", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@Complemento", cliente.Endereco.Complemento);
        }

        private Cliente ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();

            while (leitor.Read())
            {
                cliente.Cpf = leitor["Cpf"].ToString();
                cliente.Nome = leitor["Nome"].ToString();
                cliente.DataNascimento = DateTime.Parse(leitor["Data_Nascimento"].ToString());
                cliente.PontosDeFidelidade = int.Parse(leitor["Pontos_Fidelidade"].ToString());

                endereco.Rua = leitor["Rua"].ToString();
                endereco.Numero = int.Parse(leitor["Numero"].ToString());
                endereco.Bairro = leitor["Bairro"].ToString();
                endereco.Cep = leitor["Cep"].ToString();
                endereco.Complemento = leitor["Complemento"].ToString();

                cliente.Endereco = endereco;
            }

            return cliente;
        }

        public bool CpfExiste(string cpf)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Clientes WHERE Cpf = @Cpf;";

                    comando.Parameters.AddWithValue("@Cpf", cpf);

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        return leitor.HasRows;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                        Console.ReadKey();

                        return false;
                    }
                }
            }

            return false;
        }

        private Cliente BuscarClienteEspecifico(string cpf)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    if (CpfExiste(cpf))
                    {
                        string sql = @"SELECT * FROM Clientes WHERE Cpf LIKE @Cpf;";

                        comando.Connection = conexao;

                        comando.Parameters.AddWithValue("@Cpf", cpf);

                        comando.CommandText = sql;

                        SqlDataReader leitor = comando.ExecuteReader();

                        Cliente cliente = ConverterSqlParaObjeto(leitor);

                        return cliente;
                    }

                    var vazio = new Cliente();

                    vazio.Nome = "Nenhum produto encontrado";

                    return vazio;
                }
            }
        }
    }
}
