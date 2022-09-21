using System;

namespace e05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o tamanho do Vetor ");
            int N = Convert.ToInt16(Console.ReadLine()),
                total = 0,
                pairQuatity = 0;

            int[] vetor = new int[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Número {i + 1}: ");
                vetor[i] = Convert.ToInt16(Console.ReadLine());

                if (vetor[i] % 2 == 0)
                {
                    total += vetor[i];
                    pairQuatity++;
                }
            }

            Console.WriteLine($"A média aritmética dos números pares é: {total / pairQuatity}");
        }
    }
}
