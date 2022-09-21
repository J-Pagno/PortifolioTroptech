using System;
using System.Threading;

namespace Aula_26_05
{
    public static class StackSystemOptions
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

        public static bool UserChoice(string option, MyStack myQueue)
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine("Qual item deseja inserir?");
                    myQueue.StackIn(Console.ReadLine());

                    Console.WriteLine($"Sua fila tem {myQueue.GetLenghtOfMyStack} item(s) agora");

                    Console.ReadKey();
                    break;

                case "2":
                    if (myQueue.GetLenghtOfMyStack > 0)
                    {
                        Console.WriteLine($"O valor {myQueue.GetFirstItemStack} foi removido");
                        myQueue.StackOut();
                        Console.WriteLine(
                            $"Sua fila tem {myQueue.GetLenghtOfMyStack} item(s) agora"
                        );
                    }
                    else
                        Console.WriteLine("Impossível desemfilar, a fila já está vazia!");

                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine(myQueue.GetFirstItemStack);

                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("Qual item deseja buscar?");
                    string existsInMyStack =
                        (myQueue.ContainInMyStack(Console.ReadLine())) ? " " : " não ";

                    Console.WriteLine($"O item{existsInMyStack}existe na sua fila");

                    Console.ReadKey();
                    break;

                case "5":
                    myQueue.ClearMyStack();
                    Console.WriteLine($"Sua fila tem {myQueue.GetLenghtOfMyStack} item(s) agora");

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
