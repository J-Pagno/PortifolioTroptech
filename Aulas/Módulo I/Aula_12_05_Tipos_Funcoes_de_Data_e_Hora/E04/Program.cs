using System;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Now;

            if (date.Hour >= 6 && date.Hour < 12)
                Console.WriteLine(
                    $"Bom Dia ►► Data: {date.ToString("dd/MM")} Hora: {date.ToShortTimeString()}"
                );
            else if (date.Hour >= 12 && date.Hour <= 18)
                Console.WriteLine(
                    $"Boa Tarde ►► Data: {date.ToString("dd/MM")} Hora: {date.ToShortTimeString()}"
                );
            else
                Console.WriteLine(
                    $"Boa Noite ►► Data: {date.ToString("dd/MM")} Hora: {date.ToShortTimeString()}"
                );
        }
    }
}
