using System;

namespace Exercicio03
{
    class Program
    {
        /*
            ============== Correções do Código =====================
            1. As variaveis estavam confusas, então foram renomeadas e suas declarações foram reorganizadas
            2. Existia um if que comparava se uma variável era maior que ela mesma, agora ela verifica o maior salário
            3. Alterado gatilho do while, pois acho que fica mais facil de leitura caso seja uma variavel booleana o gatilho
            4. A classe main estava com a visibilidade pública (public antes do static)
        */
        public static void Main()
        {
            bool newPerson = true;

            double wageSum = 0,
                higherSalary = 0,
                wage = 0;

            int population = 0,
                wageGreaterThan100 = 0,
                totalSonQuantity = 0,
                personId = 1;

            while (newPerson)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine($"Pessoa {personId}");
                Console.Write("Salário: ");
                wage = Convert.ToDouble(Console.ReadLine());

                if (wage >= 0)
                {
                    Console.Write("Quantidade de filhos: ");
                    var sonQuatity = Convert.ToInt32(Console.ReadLine());

                    wageSum += wage;
                    totalSonQuantity += sonQuatity;
                    population++;

                    if (wage > higherSalary)
                    {
                        higherSalary = wage;
                    }

                    if (wage <= 100)
                    {
                        wageGreaterThan100++;
                    }
                }
                else
                {
                    newPerson = false;
                }
                personId++;
            }

            Console.Clear();

            var averageWage = wageSum / population;
            Console.WriteLine("Média salarial da população: R$" + averageWage);

            // faz cast para double para pegar número quebrado na divisão.
            var averageOfChildrens = (double)totalSonQuantity / population;

            Console.WriteLine("Média número de filhos: " + averageOfChildrens);

            Console.WriteLine("Maior salário: " + higherSalary);

            var percentageOfSalariesGreaterThan100 = (wageGreaterThan100 * 100) / population;
            Console.WriteLine(
                "Percentual de pessoas com salário até R$100,00: "
                    + percentageOfSalariesGreaterThan100
                    + "%"
            );
        }
    }
}
