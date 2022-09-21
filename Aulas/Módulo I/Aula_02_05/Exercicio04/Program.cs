using System;

namespace Exercicio04
{
    class Program
    {
        /*
            ============ Correções do Código ================
            1. Existia uma chave de fechamento a mais no final do código
            2. A variavel a não existia
            3. As variaveis foram renomeadas
            4.
        */
        static void Main(string[] args)
        {
            Console.Write("Digite a medida em cm da base do triângulo: ");
            var triangleBase = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite a medida em cm da altura do triângulo: ");
            var triangleHeight = Convert.ToDouble(Console.ReadLine());

            var triangleArea = (triangleBase * triangleHeight) / 2;

            Console.WriteLine("A área do triângulo é: " + triangleArea);
        }
    }
}
