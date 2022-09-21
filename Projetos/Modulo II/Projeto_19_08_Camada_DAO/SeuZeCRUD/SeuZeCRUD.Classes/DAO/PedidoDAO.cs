using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using SeuZeCRUD.Classes.DAO.DB_Settings;

namespace SeuZeCRUD.Classes.DAO
{
    public class PedidoDAO
    {
        private ClienteDAO _clienteDAO = new();

        private ProdutoDAO _produtoDAO = new();

        public void AdicionarPedido(Pedido pedido)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql;

                    if (String.IsNullOrEmpty(pedido.CpfCliente))
                    {
                        sql =
                            @"INSERT INTO Pedidos(Data_Criacao, Id_Produto, Quantidade_Produto, Valor_Total) VALUES(@Data_Criacao, @Id_Produto, @Quantidade_Produto, @Valor_Total);";
                    }
                    else
                    {
                        sql =
                            @"INSERT INTO Pedidos VALUES(@Data_Criacao, @Id_Produto, @Quantidade_Produto, @Valor_Total, @Cpf_Cliente);";
                    }

                    ConverterObjetoParaSql(pedido, comando);

                    comando.CommandText = sql;

                    try
                    {
                        comando.ExecuteNonQuery();

                        AtualizarEstoque(pedido);

                        AtualizarCliente(pedido);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public List<Pedido> BuscarPedidos()
        {
            List<Pedido> listaDePedidos = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Pedidos;";

                    comando.CommandText = sql;

                    try
                    {
                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                Id = int.Parse(leitor["Id"].ToString()),
                                DataCriacao = DateTime.Parse(leitor["Data_Criacao"].ToString()),
                                IdProduto = int.Parse(leitor["Id_Produto"].ToString()),
                                Quantidade = int.Parse(leitor["Quantidade_Produto"].ToString()),
                                ValorTotal = decimal.Parse(leitor["Valor_Total"].ToString()),
                                CpfCliente = leitor["Cpf_Cliente"].ToString(),
                            };

                            listaDePedidos.Add(pedido);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return listaDePedidos;
        }

        public Cliente BuscarClientePeloCpf(string cpf)
        {
            Cliente cliente = new();

            cliente = _clienteDAO.BuscarClientePeloCpf(cpf);

            return cliente;
        }

        public Produto BuscarProdutoPeloId(int id)
        {
            Produto produto = new();

            produto = _produtoDAO.BuscarProdutosPorIdentificador(id);

            return produto;
        }

        private void ConverterObjetoParaSql(Pedido pedido, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@Id", pedido.Id);
            comando.Parameters.AddWithValue("@Data_Criacao", pedido.DataCriacao);
            comando.Parameters.AddWithValue("@Id_Produto", pedido.IdProduto);
            comando.Parameters.AddWithValue("@Quantidade_Produto", pedido.Quantidade);
            comando.Parameters.AddWithValue("@Valor_Total", pedido.ValorTotal);

            if (String.IsNullOrEmpty(pedido.CpfCliente))
                comando.Parameters.AddWithValue("@Cpf_Cliente", "NULL");
            else
                comando.Parameters.AddWithValue("@Cpf_Cliente", pedido.CpfCliente);
        }

        private Pedido ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            Pedido pedido = new Pedido();

            while (leitor.Read())
            {
                pedido.Id = int.Parse(leitor["Id"].ToString());
                pedido.DataCriacao = DateTime.Parse(leitor["Data_Criacao"].ToString());
                pedido.IdProduto = int.Parse(leitor["Id_Produto"].ToString());
                pedido.Quantidade = int.Parse(leitor["Quantidade_Produto"].ToString());
                pedido.ValorTotal = decimal.Parse(leitor["Valor_Total"].ToString());
                pedido.CpfCliente = leitor["Cpf_Cliente"].ToString();
            }

            return pedido;
        }

        public int VerificarEstoqueDisponível(int id)
        {
            Produto produto = _produtoDAO.BuscarProdutosPorIdentificador(id);

            int estoqueAtual = produto.Quantidade;

            return estoqueAtual;
        }

        private void AtualizarEstoque(Pedido pedido)
        {
            try
            {
                Produto produto = _produtoDAO.BuscarProdutosPorIdentificador(pedido.IdProduto);

                produto.Quantidade -= pedido.Quantidade;

                _produtoDAO.AtualizarProduto(produto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AtualizarCliente(Pedido pedido)
        {
            Cliente cliente = _clienteDAO.BuscarClientePeloCpf(pedido.CpfCliente);

            decimal pontosDeFidelidade = pedido.ValorTotal * 2m;

            cliente.PontosDeFidelidade += pontosDeFidelidade;

            _clienteDAO.AtualizarCliente(cliente);
        }

        public bool ClienteExite(string cpf)
        {
            bool clienteExiste = false;

            clienteExiste = _clienteDAO.CpfExiste(cpf);

            return clienteExiste;
        }
    }
}
