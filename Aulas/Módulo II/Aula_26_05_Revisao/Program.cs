using System;

namespace Aula_26_05
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack myStack = new MyStack();

            bool isMenu = true;

            do
            {
                Console.Clear();

                StackSystemOptions.PrintSystemMenu();
                string option = Console.ReadLine();

                isMenu = StackSystemOptions.UserChoice(option, myStack);
            } while (isMenu);
            Console.ResetColor();
        }
    }
}
