using System;
using System.Collections;
using System.Collections.Generic;
using SeuZeCRUD.ConsoleApp.Messages;
using SeuZeCRUD.Classes;
using SeuZeCRUD.Classes.DAO;

namespace SeuZeCRUD
{
    public static class MenuPedido
    {
        private static PedidoDAO _pedidoDAO = new PedidoDAO();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Gerenciamento de Clientes:");

                Console.WriteLine("a. Adicionar Pedido");
                Console.WriteLine("b. Listar todos os pedidos");
                Console.WriteLine("c. Voltar");

                var opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida.ToLower())
                {
                    case "a":
                        AdicionarPedido();
                        break;

                    case "b":
                        ListarPedidos();
                        break;

                    case "c":
                        return;

                    default:
                        Messages.Falha("Opção Inválida!");
                        break;
                }
            } while (true);
        }

        public static void AdicionarPedido()
        {
            Pedido pedido = new();
            Cliente cliente = new();
            Produto produto = new();

            int quantidadeDoProdutoDisponivel;

            bool isInt,
                produtoExiste;

            do
            {
                Console.WriteLine("Digite o id do produto a ser comprado: ");

                isInt = int.TryParse(Console.ReadLine(), out int valor);

                if (!isInt)
                    continue;

                pedido.IdProduto = valor;

                produto = _pedidoDAO.BuscarProdutoPeloId(pedido.IdProduto);
            } while (isInt && String.IsNullOrEmpty(produto.Id.ToString()));

            isInt = false;

            quantidadeDoProdutoDisponivel = _pedidoDAO.VerificarEstoqueDisponível(pedido.IdProduto);

            do
            {
                Console.Clear();

                Console.WriteLine(
                    $"Digite a quantidade do produto a ser comprada: (Quantidade disponível: {quantidadeDoProdutoDisponivel})"
                );

                isInt = int.TryParse(Console.ReadLine(), out int quantidade);

                if (!isInt)
                    continue;

                pedido.Quantidade = quantidade;
            } while (isInt && (quantidadeDoProdutoDisponivel < pedido.Quantidade));

            pedido.ValorTotal = pedido.Quantidade * produto.Preco;

            pedido.DataCriacao = DateTime.Now;

            do
            {
                Console.Clear();

                Console.WriteLine("Digite o cpf do comprador (Opcional)");
                string cpf = Console.ReadLine();

                if (!_pedidoDAO.ClienteExite(cpf))
                {
                    Messages.Atencao(
                        "CPF não encontrado! Digite um CPF válido ou cadastre o CPF em questão"
                    );

                    Console.Clear();

                    continue;
                }
                else
                {
                    cliente = _pedidoDAO.BuscarClientePeloCpf(cpf);
                    pedido.CpfCliente = cliente.Cpf;
                }

                break;
            } while (true);

            try
            {
                _pedidoDAO.AdicionarPedido(pedido);

                Messages.Sucesso("Pedido adicionado com sucesso!");
            }
            catch (Exception e)
            {
                Messages.Falha(e.Message);
            }
        }

        public static void ListarPedidos()
        {
            Console.Clear();

            List<Pedido> listaDePedido = new();

            listaDePedido = _pedidoDAO.BuscarPedidos();

            Console.WriteLine("Quantidade de Pedidos Encontrados: " + listaDePedido.Count);

            foreach (var pedido in listaDePedido)
            {
                Produto produto = new();

                produto = _pedidoDAO.BuscarProdutoPeloId(pedido.IdProduto);

                Console.Write(pedido.Id);
                Console.CursorLeft = 15;

                Console.Write(" | " + pedido.DataCriacao.ToString());
                Console.CursorLeft = 30;

                Console.Write(" | " + produto.Nome);
                Console.CursorLeft = 45;

                Console.Write(" | " + pedido.Quantidade.ToString());
                Console.CursorLeft = 60;

                Console.Write(" | " + pedido.ValorTotal.ToString());
                Console.CursorLeft = 75;

                if (pedido.CpfCliente != null)
                {
                    Cliente cliente = new Cliente();
                    cliente = _pedidoDAO.BuscarClientePeloCpf(pedido.CpfCliente);

                    Console.WriteLine(" | " + cliente.Nome);
                }
                else
                    Console.WriteLine("Não cadastrado");
            }

            Console.ReadKey();
        }
    }
}
