using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] peoples = new string[10, 3];
            for (int person = 0; person < 10; person++)
            {
                Console.WriteLine($"Pessoa {person + 1}: ");
                for (int question = 0; question < 3; question++)
                {
                    switch (question)
                    {
                        case 0:
                            Console.WriteLine("Digite seu nome: ");
                            break;
                        case 1:
                            Console.WriteLine("Digite seu endereço: ");
                            break;
                        case 2:
                            Console.WriteLine("Digite profissão: ");
                            break;
                    }
                    peoples[person, question] = Console.ReadLine();
                }
            }

            Console.Write("Pessoa");
            Console.CursorLeft = 15;
            Console.Write("Nome");
            Console.CursorLeft = 30;
            Console.Write("Endereço");
            Console.CursorLeft = 45;
            Console.WriteLine("Profissão");

            for (int line = 0; line < 10; line++)
            {
                Console.Write($"Pessoa {line}");
                Console.CursorLeft = 15;
                Console.Write($"{peoples[line, 0]}");
                Console.CursorLeft = 30;
                Console.Write($"{peoples[line, 1]}");
                Console.CursorLeft = 45;
                Console.WriteLine($"{peoples[line, 2]}");
            }
        }
    }
}
