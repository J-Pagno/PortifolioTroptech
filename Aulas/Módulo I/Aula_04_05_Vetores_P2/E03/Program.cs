using System;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma frase: ");
            string phrase = Console.ReadLine();
            
            int words = (phrase.Split(' ')).Length;

            Console.Write($"Palavras: {words}");
        }
    }
}
