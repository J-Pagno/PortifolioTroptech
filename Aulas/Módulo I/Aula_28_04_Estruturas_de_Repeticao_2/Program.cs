using System;

namespace Estruturas_de_Decisão_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)================================================
            Random randomNum = new Random();
            int points = 0;
            bool repeat = true;

            while (repeat)
            {
                for (int i = 1; i <= 10; i++)
                {
                    int x = randomNum.Next(1, 10),
                        y = randomNum.Next(1, 10);

                    Console.WriteLine($"Pergunta {i}: {x} * {y} = ");
                    int awnser = Convert.ToInt16(Console.ReadLine());

                    if ((awnser) == (x * y))
                    {
                        Console.WriteLine("Resposta Correta!");
                        points++;
                    }
                    else
                    {
                        Console.WriteLine($"A resposta correta é {x * y}");
                    }
                }
                if (points == 10)
                {
                    repeat = false;
                }
                else
                {
                    points = 0;
                    Console.WriteLine("Reiniciando teste...");
                }
            }

            //2)================================================

            // int weekNumber = 0,
            //     daysNumber = 0;

            // Console.WriteLine("Informe o número de semanas estudadas:");
            // weekNumber = Convert.ToInt16(Console.ReadLine());

            // Console.WriteLine("Informe o número de dias estudados por semana:");
            // daysNumber = Convert.ToInt16(Console.ReadLine());

            // for (int week = 1; week <= weekNumber; week++)
            // {
            //     Console.WriteLine($"Semana {week}");
            //     for (int day = 1; day <= daysNumber; day++)
            //     {
            //         Console.WriteLine($"Dia: {week}");
            //     }
            // }
            // Console.WriteLine($"Você estudou {weekNumber * daysNumber} dia(s).");

            //3)==================================================

            // for (int i = 1; i <= 10; i++)
            // {
            //     int espaco = 0;
            //     for (int u = 1; u <= 10; u++)
            //     {
            //         Console.Write($"{u} * {i} = {u * i}");
            //         Console.CursorLeft = espaco;
            //         espaco += 15;
            //     }
            //     Console.WriteLine();
            // }
        }
    }
}
