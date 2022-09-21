using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o tamanho do Vetor ");
            int N = Convert.ToInt16(Console.ReadLine()),
                pairQuantity = 0;

            int[] vetor = new int[N],
                pairNumbers = new int[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Número {i + 1}: ");
                vetor[i] = Convert.ToInt16(Console.ReadLine());
                if (vetor[i]%2 == 0)
                {
                    pairNumbers[pairQuantity] = vetor[i];
                    pairQuantity++;
                }
            }

            Console.Write("O números pares são: ");
            for (int i = 0; i < pairQuantity; i++)
            {
                Console.Write($"{pairNumbers[i]} ");    
            }

            Console.WriteLine($"\nA quantidade é: {pairQuantity}");
        }
    }
}
