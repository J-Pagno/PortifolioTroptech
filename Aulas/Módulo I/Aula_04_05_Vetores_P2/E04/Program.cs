using System;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma frase: ");
            string phrase = Console.ReadLine();


            string[] words = phrase.Split(' '),
            wordsToVerify = {"Olá", "bem-vindo", "programador"};

            int wordsRepeted = 0;

            for (int i = 0; i < words.Length; i++)
            {
                for (int u = 0; u < wordsToVerify.Length; u++)
                {
                    if(words[i] == wordsToVerify[u])
                    {
                        wordsRepeted++;
                    }
                }
            }

            Console.Write($"Palavras: {wordsRepeted}");
        }
    }
}
