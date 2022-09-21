using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a nota 1");
            double nota1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite a nota 2");
            double nota2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite a nota 3");
            double nota3 = Convert.ToDouble(Console.ReadLine());

            var objectMedia = new Media(nota1, nota2, nota3);

            Console.WriteLine("Deseja arredondar a média? [s/n]");
            string userChoose = Console.ReadLine();

            if (userChoose.ToLower() == "s")
                Console.WriteLine(objectMedia.GetFullMedia());
            else
                Console.WriteLine(objectMedia.GetIntegerMedia());
        }
    }
}
