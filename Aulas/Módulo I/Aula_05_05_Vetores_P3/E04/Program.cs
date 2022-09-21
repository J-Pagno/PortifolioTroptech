using System;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[1];
            int arrayMaxIndex = 0;

            bool isToContinue = true;

            while (isToContinue)
            {
                Console.WriteLine("Informe um número: ");
                int number = Convert.ToInt16(Console.ReadLine());

                if (number == 0)
                    break;

                if (arrayMaxIndex == numbers.Length)
                {
                    int[] doubleArray = new int[numbers.Length * 2];
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        doubleArray[i] = numbers[i];
                    }
                    numbers = doubleArray;
                }
                numbers[arrayMaxIndex] = number;
                arrayMaxIndex++;
                Console.WriteLine($"Tamanho: {numbers.Length} - Elementos: {arrayMaxIndex}");
            }
        }
    }
}
