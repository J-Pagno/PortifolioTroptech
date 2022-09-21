using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o tempo em dias:");
            int days = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine($"{days} dias em horas: {Date.daysToHours(days)}");
            Console.WriteLine($"{days} dias em minutos: {Date.daysToMinutes(days)}");
            Console.WriteLine($"{days} dias em segundos {Date.daysToSeconds(days)}");
        }
    }
}
