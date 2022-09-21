using System;

namespace CSharp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n1)");

            Console.WriteLine("      *");
            Console.WriteLine("     ***");
            Console.WriteLine("    *****");
            Console.WriteLine("   *******");
            Console.WriteLine("  *********");
            Console.WriteLine(" ***********");
            Console.WriteLine("*************");

            //========================================================================================

            Console.WriteLine("\n2)");

            Console.WriteLine(
                "      *\n     ***\n    *****\n   *******\n  *********\n ***********\n*************"
            );

            //========================================================================================

            Console.WriteLine("\n3)");

            Console.WriteLine("Qual o seu nome?");
            var nome = Console.ReadLine();
            Console.WriteLine("Olá " + nome);

            //========================================================================================

            Console.WriteLine("\n4)");

            Console.WriteLine("**********          **    **      ");
            Console.WriteLine("**********          **    **      ");
            Console.WriteLine("**           *********************");
            Console.WriteLine("**           *********************");
            Console.WriteLine("**                  **    **      ");
            Console.WriteLine("**           *********************");
            Console.WriteLine("**           *********************");
            Console.WriteLine("**********          **    **      ");
            Console.WriteLine("**********          **    **      ");

            //========================================================================================

            Console.WriteLine("\n5)");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       **    **      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       **    **      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*********************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*********************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       **    **      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*********************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*********************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       **    **      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("**********   ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       **    **      ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
