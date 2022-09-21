using System;

namespace SeuZeCRUD.ConsoleApp.Messages
{
    public class Messages
    {
        public static void Sucesso(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void Falha(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void Atencao(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
