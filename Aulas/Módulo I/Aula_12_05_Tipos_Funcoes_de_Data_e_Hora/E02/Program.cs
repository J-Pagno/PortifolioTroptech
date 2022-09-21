using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um ano:");
            int year = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Digite um mês:");
            int month = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Digite um ano:");
            int day = Convert.ToInt16(Console.ReadLine());

            var date = new DateTime(year, month, day);
            Console.WriteLine(date.AddDays(7));
            Console.WriteLine(date.AddDays(-15));
            Console.WriteLine(date.AddMonths(2));
            Console.WriteLine(date.AddYears(40));
        }
    }
}
