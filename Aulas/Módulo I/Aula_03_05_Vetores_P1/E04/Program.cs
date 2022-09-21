using System;

namespace e04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o tamanho do Vetor ");
            int N = Convert.ToInt16(Console.ReadLine()),
                total = 0,
                media = 0;

            int[] vetor = new int[N],
                belowAverage = new int[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Número {i + 1}: ");
                vetor[i] = Convert.ToInt16(Console.ReadLine());
                total += vetor[i];
            }

            media = total / N;

            Console.WriteLine($"O valor da média é: {media}");
            Console.Write("Os valores abaixo da média são: ");
            for (int i = 0; i < N; i++)
            {
                if (vetor[i] < media)
                {
                    Console.Write($"{vetor[i]} ");
                }
            }
        }
    }
}
