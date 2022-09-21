using System;
using System.Collections.Generic;
using PlanilhaPatricia.Domain.Entidades;
using PlanilhaPatricia.Domain.IRepositorios;
using PlanilhaPatricia.Infra.Data.Repositorios;

namespace PlanilhaPatricia.ConsoleApp.IntercaoUsuario
{
    public static class Menu
    {
        private static IReservaRepositorio s_reservaRepositorio = new ReservaRepositorio();

        private static IFuncionarioRepositorio s_funcionarioRepositorio = new FuncionarioRepositorio();

        public static void MenuPrincipal()
        {
            bool continuar;

            do
            {
                Console.Clear();

                continuar = false;

                Console.WriteLine("Planilha Patricia");
                Console.WriteLine("a. Inserir Reserva");
                Console.WriteLine("b. Cadastrar Funcionario");
                Console.WriteLine("c. Sair");

                string opcao = Console.ReadLine();

                continuar = Opcoes(opcao);
            } while (continuar);
        }

        public static void InserirReserva()
        {
            Console.Clear();

            Reserva reserva = new();

            List<Reserva> listaDeReservas = new();

            do
            {
                Console.WriteLine("Digite a identificação da sala: ");
                reserva.IdSala = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o horario de inicio da reserva: ");
                reserva.HorarioInicio = DateTime.Parse(Console.ReadLine());

                if (DateTime.Compare(reserva.HorarioInicio, DateTime.Now) > 0)
                {
                    listaDeReservas = s_reservaRepositorio.ValidarReserva(reserva);

                    if (listaDeReservas != null)
                    {
                        if (listaDeReservas.Count > 0)
                        {
                            Console.WriteLine("Data inválida!");
                            Console.WriteLine("Datas ocupadas: ");

                            foreach (var reservas in listaDeReservas)
                            {
                                Console.WriteLine(reservas.Id);
                                Console.WriteLine(reservas.HorarioInicio);
                                Console.WriteLine(reservas.HorarioFim);
                                Console.WriteLine(reservas.NomeFuncionario);
                                Console.WriteLine(reservas.IdSala);
                            }
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                else
                    Console.WriteLine("A data de inicio deve ser posterior à data atual!");

            } while (true);

            do
            {
                Console.WriteLine("Digite o horario de fim da reserva: ");
                reserva.HorarioFim = DateTime.Parse(Console.ReadLine());

                if (DateTime.Compare(reserva.HorarioFim, reserva.HorarioInicio) > 0)
                    break;
                else
                    Console.WriteLine("A data de inicio deve ser posterior à data de inicio!");
            } while (true);


            Console.WriteLine("Digite o identificador do funcionario: ");
            reserva.IdFuncionario = int.Parse(Console.ReadLine());

            Console.Write(s_reservaRepositorio.ReservarHorario(reserva));
            Console.ReadKey();
        }

        public static void CadastrarFuncionario()
        {
            Console.Clear();

            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Digite o nome do funcionario: ");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do funcionario: ");
            funcionario.Cargo = Console.ReadLine();

            Console.WriteLine("Digite o ramal do funcionario: ");
            funcionario.Ramal = int.Parse(Console.ReadLine());

            int idFuncionario = s_funcionarioRepositorio.CadastrarFuncionario(funcionario);

            Console.Clear();

            Console.WriteLine(((idFuncionario > 0) ? "Identificador do funcionario: " + idFuncionario : "Funcionario não cadastrado!"));

            Console.ReadKey();
        }

        private static bool Opcoes(string opcao)
        {
            switch (opcao)
            {
                case "a":
                    InserirReserva();
                    break;

                case "b":
                    CadastrarFuncionario();
                    break;

                case "c":
                    return false;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            return true;
        }
    }
}
