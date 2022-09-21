using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using SeuZeCRUD.Classes.DAO.DB_Settings;

namespace SeuZeCRUD.Classes.DAO
{
    public class ProdutoDAO
    {
        public void AdicionarProduto(Produto produto)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    if (ProdutoExiste(produto.Nome))
                    {
                        try
                        {
                            produto = BuscarProdutoEspecifico(produto.Nome);

                            EntradaDeEstoque(produto, 1);

                            return;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        string sql = @"INSERT INTO Produtos VALUES(@Nome, @Descricao, 1, @Preco);";

                        ObjetoParaSql(produto, comando);

                        comando.CommandText = sql;

                        try
                        {
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erro no ProdutoDAO");
                            Console.WriteLine(e);
                        }
                    }
                }
            }
        }

        public Produto AtualizarProduto(Produto produtoAtualizado)
        {
            Produto produtoAntigo = BuscarProdutoEspecifico(produtoAtualizado.Id);

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText =
                        $"UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao, Quantidade = @Quantidade, Preco = @Preco WHERE Id = @Id;";

                    ObjetoParaSql(produtoAtualizado, comando);

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

            return produtoAntigo;
        }

        public Produto DeletarProduto(int id)
        {
            Produto produtoDeletado = BuscarProdutoEspecifico(id);

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText =
                        @"
                                DELETE FROM Pedidos WHERE Id_Produto = @Id;
                                DELETE FROM Produtos WHERE Id = @id;";

                    comando.Parameters.AddWithValue("@Id", id);

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

            return produtoDeletado;
        }

        public List<Produto> BuscarTodosOsProdutos()
        {
            List<Produto> listaDeProdutos = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Produtos;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produto =
                            new()
                            {
                                Id = int.Parse(leitor["Id"].ToString()),
                                Nome = leitor["Nome"].ToString(),
                                Descricao = leitor["Descricao"].ToString(),
                                Quantidade = int.Parse(leitor["Quantidade"].ToString()),
                                Preco = int.Parse(leitor["Preco"].ToString()),
                            };

                        listaDeProdutos.Add(produto);
                    }
                }
            }

            return listaDeProdutos;
        }

        public List<Produto> BuscarProdutosPorDescricao(string descricao)
        {
            List<Produto> listaDeProdutos = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Produtos WHERE Descricao LIKE @Descricao;";

                    comando.Parameters.AddWithValue("@Descricao", descricao);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produto =
                            new()
                            {
                                Id = int.Parse(leitor["Id"].ToString()),
                                Nome = leitor["Nome"].ToString(),
                                Descricao = leitor["Descricao"].ToString(),
                                Quantidade = int.Parse(leitor["Quantidade"].ToString()),
                                Preco = int.Parse(leitor["Preco"].ToString()),
                            };

                        listaDeProdutos.Add(produto);
                    }
                }
            }

            return listaDeProdutos;
        }

        public Produto BuscarProdutosPorIdentificador(int id)
        {
            Produto produto = new();

            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Produtos WHERE Id = @Id;";

                    comando.Parameters.AddWithValue("@Id", id);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    produto = ConverterSqlParaObjeto(leitor);
                }
            }

            return produto;
        }

        private void EntradaDeEstoque(Produto produto, int quantidade)
        {
            produto.Quantidade += quantidade;

            AtualizarProduto(produto);
        }

        public void SaidaDeEstoque(Produto produto, int quantidade)
        {
            produto.Quantidade -= quantidade;

            AtualizarProduto(produto);
        }

        private void ObjetoParaSql(Produto produto, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@Id", produto.Id);
            comando.Parameters.AddWithValue("@Nome", produto.Nome);
            comando.Parameters.AddWithValue("@Descricao", produto.Descricao);
            comando.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
            comando.Parameters.AddWithValue("@Preco", produto.Preco);
        }

        private Produto ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            Produto produto = new();

            while (leitor.Read())
            {
                produto.Id = int.Parse(leitor["Id"].ToString());
                produto.Nome = leitor["Nome"].ToString();
                produto.Descricao = leitor["Descricao"].ToString();
                produto.Quantidade = int.Parse(leitor["Quantidade"].ToString());
                produto.Preco = decimal.Parse(leitor["Preco"].ToString());
            }

            return produto;
        }

        private void CabecalhoTabelaProdutos()
        {
            Console.Write("Id");

            Console.CursorLeft = 5;

            Console.Write(" | Nome");

            Console.CursorLeft = 30;

            Console.Write(" | Descricao");

            Console.CursorLeft = 55;

            Console.WriteLine(" | Quantidade");

            Console.WriteLine("—————————————————————————————————————————————————————————————————");
        }

        private bool ProdutoExiste(string nomeProduto)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = $"SELECT * FROM Produtos WHERE Nome LIKE @Nome;";

                    comando.Parameters.AddWithValue("@Nome", nomeProduto);

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
        }

        private Produto BuscarProdutoEspecifico(string nome)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    if (ProdutoExiste(nome))
                    {
                        string sql = @"SELECT * FROM Produtos WHERE Nome LIKE @Nome;";

                        comando.Connection = conexao;

                        comando.Parameters.AddWithValue("@Nome", nome);

                        comando.CommandText = sql;

                        SqlDataReader leitor = comando.ExecuteReader();

                        Produto produto = ConverterSqlParaObjeto(leitor);

                        return produto;
                    }

                    var vazio = new Produto();

                    vazio.Nome = "Nenhum produto encontrado";

                    return vazio;
                }
            }
        }

        private Produto BuscarProdutoEspecifico(int id)
        {
            using (var conexao = DBSettings.Conexao())
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM Produtos WHERE Id = @Id;";

                    comando.Parameters.AddWithValue("@Id", id);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    Produto produto = ConverterSqlParaObjeto(leitor);

                    return produto;
                }
            }
        }
    }
}
