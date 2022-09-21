using System;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            var retangleObject = new Retangle();

            var anotherRetangleObject = new Retangle(10, 10);

            Console.WriteLine("Altura: " + anotherRetangleObject.GetHeight());

            Console.WriteLine("Largura: " + anotherRetangleObject.GetWidth());

            Console.WriteLine("Area: " + anotherRetangleObject.GetRetangleArea());

            anotherRetangleObject.ChangeHeight(11);

            anotherRetangleObject.ChangeWidth(11);

            Console.WriteLine("Nova altura: " + anotherRetangleObject.GetHeight());

            Console.WriteLine("Nova largura: " + anotherRetangleObject.GetWidth());

            Console.WriteLine("Nova area: " + anotherRetangleObject.GetRetangleArea());
        }
    }
}
