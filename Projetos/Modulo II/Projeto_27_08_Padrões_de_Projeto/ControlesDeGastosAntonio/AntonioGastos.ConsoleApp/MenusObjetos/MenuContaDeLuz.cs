using System;
using AntonioGastos.Domain;
using AntonioGastos.ConsoleApp.Messages;
using AntonioGastos.Domain.IRepositories;
using AntonioGastos.Infra.Data.Repositories;

namespace AntonioGastos.ConsoleApp.MenusObjetos
{
    public static class MenuContaDeLuz
    {
        private static IContaDeLuzRepository _contaDeLuzRepository = new ContaDeLuzRepository();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("------------------ CONTROLE DE GASTOS ------------------");

                Console.WriteLine("a - Inserir Conta");
                Console.WriteLine("b - Buscar Conta por Data");
                Console.WriteLine("c - Sair");
                string opcao = Console.ReadLine().ToLower();

                switch (opcao)
                {
                    case "a":
                        InserirContaDeLuz();
                        break;

                    case "b":
                        BuscarContaPorData();
                        break;

                    case "c":
                        return;

                    default:
                        Messages.Messages.Falha("Opção Inválida!");
                        break;
                }
            } while (true);
        }

        private static void InserirContaDeLuz()
        {
            ContaDeLuz contaDeLuz = null;

            do
            {
                Console.Clear();

                string codigoConta;

                Console.WriteLine("Digite o códgio da conta: (6 dígitos)");
                codigoConta = Console.ReadLine();

                contaDeLuz = new ContaDeLuz(codigoConta);

                if (codigoConta.Length == 6 && !ValorEVazio(codigoConta))
                    break;
                else
                {
                    Messages.Messages.Atencao("O código deve conter 6 dígitos!");
                    Console.ReadKey();
                }

            } while (true);

            bool validarData = false;

            do
            {
                Console.WriteLine("Digite a data da leitura: (dd/mm/aaaa)");
                contaDeLuz.DataDeLeitura = DateTime.Parse(Console.ReadLine());

                validarData = _contaDeLuzRepository.VerificarSeDataEValida(contaDeLuz.DataDeLeitura);

                if (!ValorEVazio(contaDeLuz.DataDeLeitura.ToString()))
                {
                    if (validarData)
                        Messages.Messages.Atencao("Data já cadastrada!");
                    else
                        break;
                }

            } while (true);

            do
            {
                Console.WriteLine("Digite o valor de KiloWatts gasto: ");
                contaDeLuz.KWGastos = int.Parse(Console.ReadLine());

                if (!ValorEVazio(contaDeLuz.KWGastos.ToString()))
                    break;

            } while (true);

            do
            {
                Console.WriteLine("Digite o valor da conta: ");
                contaDeLuz.Valor = Decimal.Parse(Console.ReadLine());

                if (!ValorEVazio(contaDeLuz.Valor.ToString()))
                    break;
            } while (true);


            do
            {
                Console.WriteLine("Digite a media de consumo conta: ");
                contaDeLuz.MediaDeConsumo = int.Parse(Console.ReadLine());
                if (!ValorEVazio(contaDeLuz.MediaDeConsumo.ToString()))
                    break;
            } while (true);


            do
            {
                Console.WriteLine("Digite a data de pagamento: (dd/mm/aaaa)");
                contaDeLuz.DataDePagamento = DateTime.Parse(Console.ReadLine());
                if (!ValorEVazio(contaDeLuz.DataDeLeitura.ToString()))
                    break;
            } while (true);


            _contaDeLuzRepository.Inserir(contaDeLuz);
        }

        private static void BuscarContaPorData()
        {
            Console.Clear();

            ContaDeLuz contaDeLuz = null;

            do
            {
                Console.WriteLine("Digite a data da conta buscada: (dd/mm/aaaa)");
                DateTime dataBuscada = DateTime.Parse(Console.ReadLine());

                if (!ValorEVazio(dataBuscada.ToString()))
                {
                    contaDeLuz = _contaDeLuzRepository.BuscarContaPorData(dataBuscada);

                    break;
                }
            } while (true);


            if (contaDeLuz is null)
            {
                Messages.Messages.Atencao("Nenhum resultado encontrado!");
            }
            else
            {
                Console.WriteLine("Numero da Leitura: " + contaDeLuz.NumeroDaLeitura);
                Console.WriteLine("Data da Leitura: " + contaDeLuz.DataDeLeitura.ToShortDateString());
                Console.WriteLine("KiloWatts Gastos" + contaDeLuz.KWGastos);
                Console.WriteLine("Valor: R$ " + contaDeLuz.Valor);
                Console.WriteLine("Media de Consumo: " + contaDeLuz.MediaDeConsumo);
                Console.WriteLine("Data de Pagamento: " + contaDeLuz.DataDePagamento.ToShortDateString());
            }

            Console.ReadKey();
        }

        private static bool ValorEVazio(string valor)
        {
            if (String.IsNullOrEmpty(valor))
            {
                Messages.Messages.Atencao("O valor não pode ser vazio!");

                return true;
            }

            return false;
        }
    }
}
