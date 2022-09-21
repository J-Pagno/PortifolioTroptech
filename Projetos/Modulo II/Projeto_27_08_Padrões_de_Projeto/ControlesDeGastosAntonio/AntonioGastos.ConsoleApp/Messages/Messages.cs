using System;

namespace AntonioGastos.ConsoleApp.Messages
{
    public static class Messages
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
