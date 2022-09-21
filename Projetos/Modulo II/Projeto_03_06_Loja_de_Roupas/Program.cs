using System;
using System.Collections.Generic;

namespace Projeto_03_06_Loja_de_Roupas
{
    class Program
    {
        public static List<NaturalPerson> naturalPersonList = new List<NaturalPerson>();
        public static List<LegalPerson> legalPersonList = new List<LegalPerson>();
        public static List<Purchase> PurchaseList = new List<Purchase>();

        static void Main(string[] args)
        {
            StartShop();
        }

        static void StartShop()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("[ 1 ] - Cadastrar Cliente");
                Console.WriteLine("[ 2 ] - Exibir todos os clientes");
                Console.WriteLine("[ 3 ] - Pesquisar clientes");
                Console.WriteLine("[ 4 ] - Remover cliente");
                Console.WriteLine("[ 5 ] - Cadastrar venda");
                Console.WriteLine("[ 6 ] - Exibir todas as vendas");
                Console.WriteLine("[ 0 ] - Sair");

                bool isNumber = int.TryParse(Console.ReadLine(), out int chosenOption);

                if (isNumber)
                {
                    if (chosenOption > 0 && chosenOption < 7)
                    {
                        if (SelectOption(chosenOption))
                        {
                            SuccesAlert("Execução finalizada!");
                        }
                        else
                        {
                            ErrorAlert("Erro na execução!");
                        }
                    }
                    else if (chosenOption == 0)
                        return;
                    else
                    {
                        WarningAlert("Valor inválido!");
                    }
                }
                else
                {
                    WarningAlert("Formato inválido!");
                }
            } while (true);
        }

        static bool SelectOption(int item) =>
            item switch
            {
                1 => ClientActions.RegisterClient(),
                2 => ClientActions.ShowAllClients(),
                3 => ClientActions.SearchClientByName(),
                4 => ClientActions.RemoveClientById(),
                5 => PurchaseActions.AddPurcharse(),
                6 => PurchaseActions.ShowAllPurchase(),
                0 => false,
                _ => WarningAlert("Opção inválida")
            };

        public static bool WarningAlert(string message)
        {
            Console.ForegroundColor = ConsoleColor.Black;

            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();

            return false;
        }

        public static bool ErrorAlert(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();

            return false;
        }

        public static bool SuccesAlert(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();

            return true;
        }
    }
}
