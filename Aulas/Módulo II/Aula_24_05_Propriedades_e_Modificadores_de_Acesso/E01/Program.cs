using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o valor da base do retângulo:");
            int retangleBase = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Digite o valor da altura do retângulo:");
            int retangleHeigh = Convert.ToInt16(Console.ReadLine());

            var retangleObject = new Retangle(retangleBase, retangleHeigh);

            Console.WriteLine(retangleObject.RetangleArea);
        }
    }
}
