using System;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;

            Console.WriteLine("► Dia: " + now.Day);
            Console.WriteLine("► Mês: " + now.Month);
            Console.WriteLine("► Ano: " + now.Year);
            Console.WriteLine("► Data Simples: " + now.ToShortDateString());
            Console.WriteLine("► Data Completa" + now.ToLongDateString());

            Console.WriteLine("► Hora: " + now.Hour);
            Console.WriteLine("► Minuto: " + now.Minute);
            Console.WriteLine("► Segundo: " + now.Second);
            Console.WriteLine("► Hora Simples: " + now.ToShortTimeString());
            Console.WriteLine("► Hora Completa: " + now.ToLongTimeString());
        }
    }
}
