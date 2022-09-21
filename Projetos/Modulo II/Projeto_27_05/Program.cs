using System;

namespace Aula_26_05
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue myStack = new MyQueue();

            bool isMenu = true;

            do
            {
                Console.Clear();

                QueueSystemOptions.PrintSystemMenu();
                string option = Console.ReadLine();

                isMenu = QueueSystemOptions.UserChoice(option, myStack);
            } while (isMenu);
            Console.ResetColor();
        }
    }
}
