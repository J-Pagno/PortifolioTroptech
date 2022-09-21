using System.Collections;
using System;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] senhasBanco = { "P01", "S01", "S02", "P02", "S03", "S04", "S05", "P03" };

            Queue fila = new Queue(),
                comum = new Queue();

            foreach (string item in senhasBanco)
            {
                if (item.Contains("P"))
                    fila.Enqueue(item);
                else
                    comum.Enqueue(item);
            }

            foreach (string item in comum)
            {
                fila.Enqueue(item);
            }

            foreach (var item in fila)
            {
                Console.WriteLine(item);
            }
        }
    }
}
