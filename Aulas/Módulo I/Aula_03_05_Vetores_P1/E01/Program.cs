using System;

namespace Aula_03_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            Console.WriteLine("Digite o tamanho do Vetor ");
            int N = Convert.ToInt16(Console.ReadLine()),
                biggestValue = 0,
                indexBiggestValue = 0;

            int[] vetor = new int[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Número {i + 1}: ");
                vetor[i] = Convert.ToInt16(Console.ReadLine());
                if (biggestValue < vetor[i])
                {
                    biggestValue = vetor[i];
                    indexBiggestValue = i;
                }
            }
            Console.WriteLine($"O maior valor é: {biggestValue}");
            Console.WriteLine($"Posição no vetor é: {indexBiggestValue}");
        }
    }
}
