using System;

namespace E02
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

            Console.Clear();

            Console.WriteLine("Data inserida pelo usuário: " + dateObject.CompleteDate);

            dateObject.DaysToAdd = 1;
            Console.WriteLine("Data +1 dia: " + dateObject.CompleteDate);

            dateObject.MonthsToAdd = 3;
            Console.WriteLine("Data +3 meses: " + dateObject.CompleteDate);

            dateObject.YearsToAdd = 2;
            Console.WriteLine("Data +2 anos: " + dateObject.CompleteDate);
        }
    }
}
