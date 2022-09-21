using System;
using System.Collections.Generic;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> peoples = new LinkedList<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Digite o nome {i + 1}");
                peoples.AddLast(Console.ReadLine());
            }

            peoples.RemoveFirst();
            peoples.RemoveLast();

            for (var node = peoples.First; node != null; node = node.Next)
            {
                Console.WriteLine(node.Value);
            }
        }
    }
}
