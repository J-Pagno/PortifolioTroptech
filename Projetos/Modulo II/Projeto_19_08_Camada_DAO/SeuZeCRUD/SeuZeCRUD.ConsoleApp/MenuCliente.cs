using System;
using SeuZeCRUD.Classes;
using System.Data.SqlClient;
using SeuZeCRUD.Classes.DAO;
using SeuZeCRUD.Classes.Struct;
using System.Collections.Generic;
using SeuZeCRUD.ConsoleApp.Messages;

namespace SeuZeCRUD
{
    public static class MenuCliente
    {
        private static ClienteDAO _clienteDAO = new ClienteDAO();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Gerenciamento de Clientes:");

                Console.WriteLine("a. Adicionar Cliente");
                Console.WriteLine("b. Atualizar Cliente");
                Console.WriteLine("c. Deletar cliente pelo CPF");
                Console.WriteLine("d. Buscar todos os clientes");
                Console.WriteLine("e. Buscar cliente por CPF");
                Console.WriteLine("f. Buscar cliente pelo Nome");
                Console.WriteLine("g. Sair");

                var opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida.ToLower())
                {
                    case "a":
                        AdicionarCliente();
                        break;

                    case "b":
                        AtualizarCliente();
                        break;

                    case "c":
                        DeletarClientePeloCPF();
                        break;

                    case "d":
                        BuscarTodosOsClientes();
                        break;

                    case "e":
                        BuscarClientePeloCPF();
                        break;

                    case "f":
                        BuscarClientePeloNome();
                        break;

                    case "g":
                        return;

                    default:
                        Messages.Falha("Opção Inválida!");
                        break;
                }
            } while (true);
        }

        public static void AdicionarCliente()
        {
            Console.Clear();

            Cliente cliente = new();

            Console.WriteLine("--- CADASTRO DE CLIENTE ---");

            Console.WriteLine("Digite o nome do cliente:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Digite o Cpf do cliente: (Ex.: xxxxxxxxxxx)");
            cliente.Cpf = Console.ReadLine();

            Console.WriteLine("Digite data de nascimento do cliente: (Ex.: dd/mm/aaaa)");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("--- ENDERECO DO CLIENTE ---");

            Endereco endereco = new();

            Console.WriteLine("Digite rua do cliente:");
            endereco.Rua = Console.ReadLine();

            Console.WriteLine("Digite o numero do cliente:");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o bairro do cliente:");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Digite o CEP do cliente:");
            endereco.Cep = Console.ReadLine();

            Console.WriteLine("Complemento:");
            endereco.Complemento = Console.ReadLine();

            cliente.Endereco = endereco;

            try
            {
                if (_clienteDAO.AdicionarCliente(cliente))
                    Messages.Sucesso("Cliente adicionado com sucesso!");
                else
                    Messages.Falha("CPF já cadastrado ou inválido!");
            }
            catch (Exception e)
            {
                Messages.Falha(e.Message);
            }
        }

        public static void AtualizarCliente()
        {
            Console.Clear();

            Cliente cliente = new();

            Console.WriteLine("--- ATUALIZAÇÃO DE CLIENTE ---");

            Console.WriteLine("Digite o Cpf do cliente a ser atualizado: (Ex.: xxxxxxxxxxx)");
            cliente.Cpf = Console.ReadLine();

            Console.WriteLine("Digite o nome do cliente:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Digite data de nascimento do cliente: (Ex.: dd/mm/aaaa)");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("--- ENDERECO DO CLIENTE ---");

            Endereco endereco = new();

            Console.WriteLine("Digite rua do cliente:");
            endereco.Rua = Console.ReadLine();

            Console.WriteLine("Digite o numero do cliente:");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o bairro do cliente:");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Digite o CEP do cliente:");
            endereco.Cep = Console.ReadLine();

            Console.WriteLine("Complemento:");
            endereco.Complemento = Console.ReadLine();

            cliente.Endereco = endereco;

            Cliente ClienteAntigo = null;

            try
            {
                if (_clienteDAO.CpfExiste(cliente.Cpf))
                {
                    ClienteAntigo = _clienteDAO.AtualizarCliente(cliente);

                    Messages.Sucesso(
                        "O produto \"" + ClienteAntigo.Nome + "\" foi atualizado com sucesso!"
                    );
                }
                else
                {
                    Messages.Falha("CPF ainda não cadastrado!");
                }
            }
            catch (Exception e)
            {
                Messages.Falha(e.Message);
            }
        }

        public static void DeletarClientePeloCPF()
        {
            Console.Clear();

            Console.WriteLine("--- EXCLUSÃO DE CLIENTE ---");

            Console.WriteLine("Digite o CPF do cliente a ser deletado: ");
            string cpf = Console.ReadLine();

            try
            {
                Cliente clienteDeletado = _clienteDAO.DeletarCliente(cpf);

                Messages.Sucesso(
                    "O cliente \"" + clienteDeletado.Nome + "\" foi deletado com sucesso!"
                );
            }
            catch (Exception e)
            {
                Messages.Falha(e.Message);
            }
        }

        public static void BuscarClientePeloNome()
        {
            Console.Clear();

            Console.WriteLine("--- BUSCA DE CLIENTE PELO NOME ---");

            Console.WriteLine("Digite nome do cliente: ");
            string nomeDoCliente = Console.ReadLine();

            List<Cliente> listaDeClientes = _clienteDAO.BuscarClientePeoNome(nomeDoCliente);

            Cabecalho();

            TabelaCliente(listaDeClientes);

            Console.ReadKey();
        }

        public static void BuscarClientePeloCPF()
        {
            Console.Clear();

            Console.WriteLine("--- BUSCA DE CLIENTE PELO CPF   ---");

            Console.WriteLine("Digite o CPF do cliente buscado");
            string cpf = Console.ReadLine();

            Cliente cliente = _clienteDAO.BuscarClientePeloCpf(cpf);

            Cabecalho();

            Console.Write(cliente.Cpf);

            Console.CursorLeft = 15;

            Console.Write(" | " + cliente.Nome);

            Console.CursorLeft = 30;

            Console.Write(" | " + cliente.DataNascimento.ToShortDateString());

            Console.CursorLeft = 52;

            Console.WriteLine(" | " + cliente.PontosDeFidelidade);

            Console.ReadKey();
        }

        public static void BuscarTodosOsClientes()
        {
            Console.Clear();

            List<Cliente> listaDeClientes = _clienteDAO.BuscarTodosOsClientes();

            Cabecalho();

            TabelaCliente(listaDeClientes);

            Console.ReadKey();
        }

        private static void Cabecalho()
        {
            Console.Clear();

            Console.Write("CPF");

            Console.CursorLeft = 15;

            Console.Write(" | Nome");

            Console.CursorLeft = 30;

            Console.Write(" | Data de Nascimento");

            Console.CursorLeft = 52;

            Console.Write(" | Pontos De Fidelidade");

            Console.CursorLeft = 75;

            Console.WriteLine(" | Endereço");

            Console.WriteLine(
                "------------------------------------------------------------------------------------------------"
            );
        }

        private static void TabelaCliente(List<Cliente> listaDeClientes)
        {
            foreach (var cliente in listaDeClientes)
            {
                Console.Write(cliente.Cpf);

                Console.CursorLeft = 15;

                Console.Write(" | " + cliente.Nome);

                Console.CursorLeft = 30;

                Console.Write(" | " + cliente.DataNascimento.ToShortDateString());

                Console.CursorLeft = 52;

                Console.WriteLine(" | " + cliente.PontosDeFidelidade);
            }
        }
    }
}
