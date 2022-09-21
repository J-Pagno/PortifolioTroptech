using System;

namespace AgenciaBancaria.ConsoleApp.Messages
{
    public static class Message
    {
        public static void Sucesso(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Green;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(msg);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void Falha(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(msg);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void Atencao(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(msg);

            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
