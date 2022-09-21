using System;

namespace Estrutura_de_Repetição
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)========================================

            Console.WriteLine("Digite o número que deseja ver a tabuada: ");
            int num = Convert.ToInt16(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int calc = num * i;
                Console.WriteLine($"O valor de {num} * {i} é igual à {calc}");
            }

            //2)========================================
            // Console.WriteLine("Digite o número que deseja ver a tabuada: ");
            // int num = Convert.ToInt16(Console.ReadLine());

            // Console.Write("A tabuada deverá começar em: ");
            // int min = Convert.ToInt16(Console.ReadLine());

            // Console.Write("E deverá ir até ");
            // int max = Convert.ToInt16(Console.ReadLine());

            // for (int i = min; i <= max; i++)
            // {
            //     int calc = num * i;
            //     Console.WriteLine($"O valor de {num} * {i} é igual à {calc}");
            // }

            //3)=======================================
            // Console.WriteLine("Digite 50 números maiores que 0");
            // int maxNum = 0;
            // int minNum = 0;
            // for (int i = 1; i <= 3; i++)
            // {
            //     int newNum = Convert.ToInt16(Console.ReadLine());
            //     if (newNum > maxNum)
            //     {
            //         maxNum = newNum;
            //     }

            //     if (newNum < minNum)
            //     {
            //         minNum = newNum;
            //     }
            //     else if (minNum == 0)
            //     {
            //         minNum = newNum;
            //     }
            // }
            // Console.WriteLine($"O maior valor digitado foi {maxNum} e o menor foi {minNum}");

            //4)=======================================
            // int maxSonValue = 0,
            //     maxWage = 0,
            //     sumWage = 0,
            //     sumSon = 0,
            //     wageBiggerThanUndred = 0,
            //     i = 0,
            //     currentWage = 0;

            // do
            // {
            //     i++;
            //     Console.WriteLine($"Habitante {i}:");

            //     Console.WriteLine($"Valor do salário: ");
            //     int newWage = Convert.ToInt16(Console.ReadLine());

            //     Console.WriteLine($"Número de filhos: ");
            //     int newSonValue = Convert.ToInt16(Console.ReadLine());

            //     sumWage += newWage;
            //     sumSon += newSonValue;

            //     if (newSonValue > maxSonValue || newSonValue == 0)
            //     {
            //         maxSonValue = newSonValue;
            //     }

            //     if (newWage > maxWage)
            //     {
            //         maxWage = newWage;
            //     }

            //     if (newWage > 100)
            //     {
            //         wageBiggerThanUndred++;
            //     }
            //     currentWage = newWage;
            // } while (currentWage >= 0);
            // Console.WriteLine($"Media salarial dos entrevistados: {sumWage / i}");
            // Console.WriteLine($"Media de filhos dos entrevistados: {(sumSon / i)}");
            // Console.WriteLine($"Maior salário entre os entrevistados: {maxWage}");
            // Console.WriteLine($"Salário maiores que R$100: {wageBiggerThanUndred}");

            //5)=======================================
            // Console.WriteLine("Quantas linhas a àrvore deve ter?");
            // int treeLines = Convert.ToInt16(Console.ReadLine()),
            //     spaceQtd = (treeLines - 1),
            //     symbolQtd = 1;
            // string symbol = "*";

            // if (treeLines < 5)
            //     treeLines = 5;

            // for (int i = 1; i <= treeLines; i++)
            // {
            //     for (int e = spaceQtd; e != 0; e--)
            //     {
            //         Console.Write(" ");
            //     }
            //     for (int u = 1; u <= symbolQtd; u++)
            //     {
            //         Console.Write(symbol);
            //     }
            //     spaceQtd--;
            //     symbolQtd += 2;
            //     Console.Write("\n");
            // }
        }
    }
}
