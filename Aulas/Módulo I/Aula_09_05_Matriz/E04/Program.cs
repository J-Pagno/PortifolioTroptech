using System;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz1 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 1, 4, 5 }, { 1, 5, 2, 7 } };

            int biggestVal = 0,
                minVal = 0;

            bool isFirstExec = true;

            for (int i = 0; i < 4; i++)
            {
                for (int u = 0; u < 4; u++)
                {
                    if (isFirstExec && minVal == 0)
                    {
                        minVal = matriz1[i, u];
                        isFirstExec = false;
                    }

                    if (minVal > matriz1[i, u])
                        minVal = matriz1[i, u];

                    if (biggestVal < matriz1[i, u])
                        biggestVal = matriz1[i, u];
                }
            }
            Console.WriteLine($"Omaior número da matriz é {biggestVal} e o menor é {minVal}");
        }
    }
}
