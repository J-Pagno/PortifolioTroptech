using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Domain.IRepositorios;
using AgenciaBancaria.Infra.Data.Repositorios;

namespace AgenciaBancaria.ConsoleApp.InteracaoComUsuario
{
    internal static class Menu
    {
        private static IClientesRepositorio s_clienteRepositorio = new ClienteRepositorio();

        private static IContaRepositorio s_contaRepositorio = new ContaRepositorio();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Agencia Bancaria Aline");

                Console.WriteLine("a. Listar todos os clientes");
                Console.WriteLine("b. Listar cliente por CPF");
                Console.WriteLine("c. Cadastrar uma nova conta");
                Console.WriteLine("d. Mostrar todas as contas");
                Console.WriteLine("e. Buscar conta por cliente");
                Console.WriteLine("f. Sair");

                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        ListarTodosOsClientes();
                        break;

                    case "b":
                        BuscarClientePorCPF();
                        break;

                    case "c":
                        CadastrarUmaNovaConta();
                        break;

                    case "d":
                        MostrarTodasAsContas();
                        break;

                    case "e":
                        BuscarContaPorCliente();
                        break;

                    case "f":
                        return;

                    default:
                        break;
                }
            } while (true);

        }

        private static void ListarTodosOsClientes()
        {
            Console.Clear();

            List<Cliente> listaDeClientes = s_clienteRepositorio.ListarTodosOsClientes();

            if (listaDeClientes.Count > 0)
            {
                CabecalhoCliente();
                foreach (var cliente in listaDeClientes)
                {
                    ImprimirCliente(cliente);
                }
            }
            else
            {
                Messages.Message.Atencao("Nenhum cliente encontrado!");
            }
            Console.ReadKey();
        }

        private static void BuscarClientePorCPF()
        {
            Console.Clear();

            Console.WriteLine("Digite o CPF do cliente buscado: ");
            long cpf = long.Parse(Console.ReadLine());

            Cliente cliente = s_clienteRepositorio.BuscarClientePorCPF(cpf);

            Console.Clear();

            if (cliente != null)
            {
                CabecalhoCliente();
                ImprimirCliente(cliente);
            }
            else
            {
                Messages.Message.Atencao("Nenhum cliente encontrado!");
            }
            Console.ReadKey();
        }

        private static void MostrarTodasAsContas()
        {
            Console.Clear();

            List<Conta> listaDeContas = s_contaRepositorio.MostrarTodasAsContas();

            if (listaDeContas.Count > 0)
            {
                CabecalhoConta();
                foreach (var conta in listaDeContas)
                {
                    ImprimirConta(conta);
                }

                Console.ReadKey();
            }
            else
                Messages.Message.Atencao("Nenhuma conta encontrada!");
        }

        private static void CadastrarUmaNovaConta()
        {
            Conta conta = new();

            Console.WriteLine("Digite o numero da conta: ");
            conta.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o digito da conta: ");
            conta.Digito = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite numero da agencia da conta: ");
            conta.Agencia = Console.ReadLine();

            Console.WriteLine("Digite o tipo de conta da conta: ");
            conta.TipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o saldo da conta: ");
            conta.Saldo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o limite da conta: ");
            conta.Limite = int.Parse(Console.ReadLine());

            Console.WriteLine("Digitea data da abertura da conta: ");
            conta.DataAbertura = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite a cesta da conta: ");
            conta.Cesta = (Conta.TipoDeCesta)int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o CPF do titular da conta: ");
            conta.CpfCliente = long.Parse(Console.ReadLine());

            s_contaRepositorio.CadastrarUmaNovaConta(conta);
        }

        private static void BuscarContaPorCliente()
        {
            Console.Clear();

            Console.WriteLine("Digite o CPF do cliente buscado: ");
            long cpf = long.Parse(Console.ReadLine());

            List<Conta> listaDeContas = s_contaRepositorio.BuscarContaPorCliente(cpf);

            if (listaDeContas.Count > 0)
            {
                Console.Clear();

                CabecalhoConta();

                foreach (var conta in listaDeContas)
                {
                    ImprimirConta(conta);
                }

                Console.ReadKey();
            }
            else
                Messages.Message.Atencao("Nenhuma conta encontrada!");
        }

        private static void ImprimirCliente(Cliente cliente)
        {
            Console.Write(cliente.Nome);
            Console.CursorLeft = 30;

            Console.Write("| " + cliente.Cpf);
            Console.CursorLeft = 45;

            Console.WriteLine("| " + cliente.DataNascimento.ToShortDateString());
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private static void ImprimirConta(Conta conta)
        {
            Console.Write(conta.Numero);

            Console.CursorLeft = 10;
            Console.Write(" | " + conta.Digito);

            Console.CursorLeft = 20;
            Console.Write(" | " + conta.Agencia);

            Console.CursorLeft = 30;
            Console.Write(" | " + conta.TipoConta);

            Console.CursorLeft = 50;
            Console.Write(" | R$ " + conta.Saldo);

            Console.CursorLeft = 60;
            Console.Write(" | R$ " + conta.Limite);

            Console.CursorLeft = 70;
            Console.Write(" | " + conta.DataAbertura.ToShortDateString());

            Console.CursorLeft = 90;
            Console.Write(" | " + conta.Cesta);

            Console.CursorLeft = 100;
            Console.WriteLine(" | " + conta.CpfCliente);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }

        private static void CabecalhoConta()
        {
            Console.Write("Numero");

            Console.CursorLeft = 10;
            Console.Write(" | Digito");

            Console.CursorLeft = 20;
            Console.Write(" | Agencia");

            Console.CursorLeft = 30;
            Console.Write(" | Tipo de Conta");

            Console.CursorLeft = 50;
            Console.Write("| Saldo");

            Console.CursorLeft = 60;
            Console.Write(" | Limite");

            Console.CursorLeft = 70;
            Console.Write(" | Data de Abertura");

            Console.CursorLeft = 90;
            Console.Write(" | Cesta");

            Console.CursorLeft = 100;
            Console.WriteLine(" | CPF do Cliente");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }

        private static void CabecalhoCliente()
        {
            Console.Write("CPF");

            Console.CursorLeft = 30;

            Console.Write("| Nome");

            Console.CursorLeft = 45;

            Console.WriteLine("| Data de Nacimento");

            Console.WriteLine("-----------------------------------------------------------------");
        }
    }

}
