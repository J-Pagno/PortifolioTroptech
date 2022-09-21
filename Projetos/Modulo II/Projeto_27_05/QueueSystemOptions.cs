using System;
using System.Threading;

namespace Aula_26_05
{
    public static class QueueSystemOptions
    {
        public static void PrintSystemMenu()
        {
            Console.WriteLine("O que deseja fazer com sua fila?");
            Console.WriteLine("[1] Entrar na fila");
            Console.WriteLine("[2] Remover da fila");
            Console.WriteLine("[3] Ver quem está na vez");
            Console.WriteLine("[4] Checar item");
            Console.WriteLine("[5] Limpar");
            Console.WriteLine("[6] Sair");
        }

        public static bool UserChoice(string option, MyQueue myQueue)
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine("Qual item deseja inserir?");
                    bool isNumber = int.TryParse(Console.ReadLine(), out int value);
                    if (isNumber)
                    {
                        myQueue.QueueIn(value);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("O valor precisa ser do tipo inteiro!");
                        Console.ResetColor();
                        Thread.Sleep(2500);
                    }

                    Console.WriteLine($"Sua fila tem {myQueue.GetLenghtOfMyQueue} item(s) agora");

                    Console.ReadKey();
                    break;

                case "2":
                    if (myQueue.GetLenghtOfMyQueue > 0)
                    {
                        Console.WriteLine($"O valor {myQueue.GetFirstItemQueue} foi removido");
                        myQueue.QueueOut();
                        Console.WriteLine(
                            $"Sua fila tem {myQueue.GetLenghtOfMyQueue} item(s) agora"
                        );
                    }
                    else
                        Console.WriteLine("Impossível desemfilar, a fila já está vazia!");

                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine(myQueue.GetFirstItemQueue);

                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("Qual item deseja buscar?");
                    string existsInMyStack =
                        (myQueue.ContainInMyQueue(Console.ReadLine())) ? " " : " não ";

                    Console.WriteLine($"O item{existsInMyStack}existe na sua fila");

                    Console.ReadKey();
                    break;

                case "5":
                    myQueue.ClearMyQueue();
                    Console.WriteLine($"Sua fila tem {myQueue.GetLenghtOfMyQueue} item(s) agora");

                    Console.ReadKey();
                    break;

                case "6":
                    return false;

                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Opção inválida!!");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

            return true;
        }
    }
}
