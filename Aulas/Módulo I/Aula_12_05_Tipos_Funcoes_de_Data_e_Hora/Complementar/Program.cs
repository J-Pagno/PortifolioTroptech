using System.Drawing;
using System;
using System.Collections;

namespace Complementar
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack exits = new Stack(),
                enters = new Stack(),
                registers = new Stack();

            while (exits.Count < 2)
            {
                Console.Clear();

                Console.WriteLine(
                    "Digite (E) para registrar a entrada e (S) para registrar a saída:"
                );
                char userAwnser = Convert.ToChar(Console.ReadLine());

                if ((userAwnser == 'E' || userAwnser == 'e') && enters.Count == exits.Count)
                {
                    enters.Push($"Entrada Registrada: {DateTime.Now.ToLongTimeString()}");
                    registers.Push(enters.Peek());
                }
                else if ((userAwnser == 'S' || userAwnser == 's') && enters.Count > exits.Count)
                {
                    exits.Push($"Saída Registrada: {DateTime.Now.ToLongTimeString()}");
                    registers.Push(exits.Peek());
                }
                else
                {
                    if (
                        userAwnser != 'E'
                        && userAwnser != 'e'
                        && userAwnser != 'S'
                        && userAwnser != 's'
                    )
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor inválido!!");
                        Console.ResetColor();
                    }
                    else if (enters.Count > exits.Count && (userAwnser == 'E' || userAwnser == 'e'))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Você já tem uma entrada em aberto!!");
                        Console.ResetColor();
                    }
                    else if (
                        enters.Count == exits.Count && (userAwnser == 'S' || userAwnser == 's')
                    )
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(
                            "Você precisa registrar uma entrada para poder registrar uma saída!!"
                        );
                        Console.ResetColor();
                    }
                    Console.Write("Pressione uma tecla para continuar...");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            foreach (var register in registers)
                Console.WriteLine(register);
        }
    }
}
