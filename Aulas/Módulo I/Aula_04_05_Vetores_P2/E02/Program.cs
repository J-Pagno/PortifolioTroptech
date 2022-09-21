using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma frase: ");
            string phrase = Console.ReadLine();

            char[] upperPhrase = new char[phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
            {
                char letter = phrase[i];
                if (letter >= 97 && letter <= 122)
                {
                    letter -= (char)32;
                    upperPhrase[i] = letter;
                }
                else
                    upperPhrase[i] = letter;
            }

            Console.Write("A frase digitada foi:(Versão 1): ");
            Console.Write(upperPhrase);

            Console.WriteLine($"\nA frase digitada foi (Vesão 2): {phrase.ToUpper()}");
        }
    }
}
