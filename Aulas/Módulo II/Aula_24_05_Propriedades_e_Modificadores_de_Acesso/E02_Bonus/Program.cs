using System;

namespace E02_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o dia (1 - 31):");
            int chosenDay = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Digite o mês (1 - 12):");
            int chosenMonth = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Digite o ano:");
            int chosenYear = Convert.ToInt16(Console.ReadLine());

            var dateObject = new Date(chosenDay, chosenMonth, chosenYear);

            string initialDate = $"{chosenDay}/{chosenMonth}/{chosenYear}";

            bool isToContinue = true;

            while (isToContinue)
            {
                Console.WriteLine("Data Atual: " + dateObject.CompleteDate);
                Console.WriteLine(
                    "\nDeseja fazer alguma alteração?\n1 - Adicionar x dias\n2 - Adicionar x meses\n3 - Adicionar x anos\n4 - Não fazer nenhuma alteração"
                );
                int userAction = Convert.ToInt16(Console.ReadLine());

                Console.Clear();

                switch (userAction)
                {
                    case 1:
                        Console.WriteLine("Quantos dias deseja adicionar?");
                        dateObject.DaysToAdd = Convert.ToInt16(Console.ReadLine());
                        break;

                    case 2:
                        Console.WriteLine("Quantos meses deseja adicionar?");
                        dateObject.MonthsToAdd = Convert.ToInt16(Console.ReadLine());
                        break;

                    case 3:
                        Console.WriteLine("Quantos anos deseja adicionar?");
                        dateObject.YearsToAdd = Convert.ToInt16(Console.ReadLine());
                        break;

                    case 4:
                        isToContinue = false;
                        break;

                    default:
                        Console.Write("Valor inválido!");
                        break;
                }
            }

            Console.Clear();

            Console.WriteLine(
                $"A data inicial escolhida era: {initialDate}\nA data após as modificações feitas é: {dateObject.CompleteDate}"
            );
        }
    }
}
