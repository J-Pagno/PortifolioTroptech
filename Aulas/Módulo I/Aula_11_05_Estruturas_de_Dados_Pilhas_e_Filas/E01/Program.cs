using System.Collections;
using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            int number = 0,
                totalOfBits = 0;

            Console.Write("Digite um número: ");
            number = Convert.ToInt32(Console.ReadLine());

            do
            {
                stack.Push(number % 2);
                number /= 2;
                totalOfBits++;
            } while (number != 0);

            if (totalOfBits % 4 != 0)
                while (totalOfBits % 4 != 0)
                {
                    stack.Push(number);
                    totalOfBits++;
                }

            foreach (var item in stack)
                Console.Write(item);
            //110 0100
        }
    }
}
