using System;
using System.Collections.Generic;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Client> clientList = new LinkedList<Client>();

            do
            {
                ProgramOptions.PrintMenu();
                bool isNumber = int.TryParse(Console.ReadLine(), out int userChoice);

                if (!isNumber)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Valor inválido!");
                    Console.ResetColor();
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        clientList = ProgramOptions.ClientRegister(clientList);
                        break;

                    case 2:
                        ProgramOptions.ShowAllClients(clientList);
                        break;

                    case 3:
                        return;

                    default:
                        break;
                }

                Console.Clear();
            } while (true);
        }
    }
}
