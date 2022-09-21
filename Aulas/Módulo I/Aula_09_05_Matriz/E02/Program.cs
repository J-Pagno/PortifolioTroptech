using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0,
                media = 0;

            int[,] numbers = new int[3, 6];

            for (int line = 0; line < 3; line++)
            {
                for (int colomn = 0; colomn < 6; colomn++)
                {
                    Console.WriteLine(
                        $"Digite o número da linha {line + 1} e da coluna {colomn + 1}"
                    );
                    numbers[line, colomn] = Convert.ToInt16(Console.ReadLine());

                    if (colomn % 2 != 0)
                    {
                        sum += numbers[line, colomn];
                    }
                }
                media += (numbers[line, 1] + numbers[line, 3]);
                numbers[line, 5] = numbers[line, 0] + numbers[line, 2];
            }

            Console.Write("Linhas/Colunas");
            Console.CursorLeft = 20;
            Console.Write("Coluna 1");
            Console.CursorLeft = 35;
            Console.Write("Coluna 2");
            Console.CursorLeft = 50;
            Console.Write("Coluna 3");
            Console.CursorLeft = 65;
            Console.Write("Coluna 4");
            Console.CursorLeft = 80;
            Console.Write("Coluna 5");
            Console.CursorLeft = 95;
            Console.WriteLine("Coluna 6");

            for (int line = 0; line < 3; line++)
            {
                Console.Write($"Linha {line + 1}");
                int cursorPosition = 20;

                for (int colomn = 0; colomn < 6; colomn++)
                {
                    Console.CursorLeft = cursorPosition;
                    Console.Write(numbers[line, colomn]);
                    cursorPosition += 15;
                }
                Console.WriteLine();
            }
        }
    }
}
