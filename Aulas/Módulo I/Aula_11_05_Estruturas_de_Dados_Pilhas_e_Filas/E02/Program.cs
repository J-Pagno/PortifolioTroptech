using System.Collections;
using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Push('T');
            stack.Push(false);
            stack.Push(true);
            stack.Push("Trop");
            stack.Push(1);
            stack.Push(7.6);

            stack.Pop();
            stack.Pop();
            stack.Pop();

            stack.Push("Trop");
            stack.Push(1);
            stack.Push(7.6);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
