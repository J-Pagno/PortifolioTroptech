using System;
using System.Collections.Generic;

namespace E01
{
    public class Program
    {
        public static List<BankAccount> accountList = new();

        static void Main(string[] args)
        {
            do
            {
                BankAccount bankAccount = new();
                accountList.Add(bankAccount);

                Console.Clear();

                do
                {
                    Console.WriteLine(
                        "Deseja continuar cadastrando? Digite 1 para continuar cadastrando, 2 para ver a lista de cadastros ou qualque outra tecla para sair do programa"
                    );
                    string userChoice = Console.ReadLine();

                    if (userChoice == "1")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        ShowList();

                        if (userChoice != "2")
                            return;
                    }
                } while (true);
            } while (true);
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void ShowList()
        {
            foreach (var item in accountList)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
