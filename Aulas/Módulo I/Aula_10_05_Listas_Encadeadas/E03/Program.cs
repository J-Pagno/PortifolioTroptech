using System;
using System.Collections.Generic;

namespace E0
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> numbers = new LinkedList<int>();

            for (int i = 0; i < 4; i++)
            {
                numbers.AddLast(Convert.ToInt16(Console.ReadLine()));
            }

            var one = numbers.Find(1);
            if (numbers.First != one)
            {
                numbers.Remove(one);
                numbers.AddFirst(one);
            }

            var two = numbers.Find(2);
            if (numbers.First != two)
            {
                numbers.Remove(two);
                numbers.AddLast(two);
            }

            var three = numbers.Find(3);
            if (numbers.First != three)
            {
                numbers.Remove(three);
                numbers.AddLast(three);
            }

            var four = numbers.Find(4);
            if (numbers.First != four)
            {
                numbers.Remove(four);
                numbers.AddLast(four);
            }

            for (var node = numbers.First; node != null; node = node.Next)
            {
                Console.WriteLine(node.Value);
            }
        }
    }
}
