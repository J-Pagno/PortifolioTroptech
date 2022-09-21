using System;

namespace Exercicio02
{
    class Program
    {
        /*
            ======== Correções do Código =============
            1. A classe Main estava com o modificador de acesso parcialmente escrito antes da palavra static
            2. Nome de variável "in" não pode ser usado pois se trata de uma palavra reservada
            3. Identação errada
            4. Nomes de variaveis alterados pois não diziam nada sobre o código
            5.
        */
        static void Main()
        {
            Console.WriteLine("Descubra a tabuada!");
            Console.Write("Qual tabuada você gostaria de consultar (1 a 10): ");
            var multipliedNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Qual é o número de inicio: ");
            var startNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Qual é o número de fim: ");
            var endNumber = Convert.ToInt32(Console.ReadLine());

            if (multipliedNumber > 10 || multipliedNumber < 1)
            {
                Console.WriteLine("Valor inválido, tente novamente.");
                return;
            }

            for (var i = startNumber; i <= endNumber; i++)
            {
                Console.WriteLine(multipliedNumber + " x " + i + " = " + i * multipliedNumber);
            }
        }
    }
}
