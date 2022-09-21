using System;

namespace Aula_02_05
{
    class Program
    {
        /*
            ========== Correções do Código ===========

            1. Os nomes das variáveis não eram auto explicativos, então foram alterados;
            2. O código não estava identado;
            3. Existia uma chave de fechamento a mais no código, ela foi removida;
            4. A variavel i do loop for, foi alterada para melhor entendimento do que o for significa

        */

        static void Main(string[] args)
        {
            var p = 0;
            while (p < 10)
            {
                for (int pergunta = 0; pergunta < 10; pergunta++)
                {
                    var n1 = new Random().Next(1, 10);
                    var n2 = new Random().Next(1, 10);

                    Console.WriteLine(n1 + " x " + n2 + "? ");

                    var r = Convert.ToInt32(Console.ReadLine());

                    if (r == n1 * n2)
                    {
                        Console.WriteLine("Resposta Correta!");
                        p++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorreto!!! A resposta é: {n1 * n2}");
                    }
                }
                Console.WriteLine("Sua pontuação é: " + p + "/10");

                if (p == 10)
                    Console.WriteLine("Parabéns, você sabe a tabuada decor e salteado!");
                else
                    Console.WriteLine("Você precisa estudar mais! Vamos tentar novamente!");
            }
        }
    }
}
