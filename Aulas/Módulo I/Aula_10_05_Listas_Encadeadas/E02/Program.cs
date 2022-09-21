using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> days = new LinkedList<string>();

            days.AddLast("Quarta");
            days.AddLast("Segunda");
            days.AddLast("Sábado");
            days.AddLast("Quinta");
            days.AddLast("Terça");
            days.AddLast("Domingo");
            days.AddLast("Sexta");

            Console.WriteLine(
                $"{days.Find("Domingo").Value}\n{days.Find("Segunda").Value}\n{days.Find("Terça").Value}\n{days.Find("Quarta").Value}\n{days.Find("Quinta").Value}\n{days.Find("Sexta").Value}\n{days.Find("Sábado").Value}"    
            );
        }
    }
}
