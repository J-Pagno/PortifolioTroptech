using System;

namespace e03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o tamanho do Vetor ");
            int N = Convert.ToInt16(Console.ReadLine());

            int[] vetorA = new int[N],
                vetorB = new int[N],
                vetorC = new int[N];

            Console.WriteLine("Vetor A:");

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Número {i + 1}: ");
                vetorA[i] = Convert.ToInt16(Console.ReadLine());
            }

            Console.WriteLine("Vetor B:");

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Número {i + 1}: ");
                vetorB[i] = Convert.ToInt16(Console.ReadLine());
                vetorC[i] = vetorA[i] + vetorB[i];
            }

            Console.Write("O números do vetor C são: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{vetorC[i]} ");
            }
        }
    }
}
