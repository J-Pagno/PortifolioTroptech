using System;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz1 =  { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 1, 4, 5 }, { 1, 5, 2, 7 } },
                matriz2 =  { { 6, 4, 7, 3 }, { 4, 3, 6, 6 }, { 1, 2, 4, 5 }, { 7, 9, 3, 4 } };

            for (int i = 0; i < 4; i++)
            {
                for (int u = 0; u < 4; u++)
                {
                    Console.Write(matriz1[i, u] + matriz2[i, u] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
