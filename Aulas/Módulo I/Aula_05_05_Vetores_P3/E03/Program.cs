using System;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o número de produtos: ");
            int productQuantity = Convert.ToInt16(Console.ReadLine());

            string[] name = new string[productQuantity];

            double[] price = new double[productQuantity];

            for (int i = 0; i < productQuantity; i++)
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine($"Produto {i + 1}: ");
                Console.WriteLine("==================================");

                Console.WriteLine("Nome do Produto: ");
                name[i] = Console.ReadLine();

                Console.WriteLine("Preço: ");
                price[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.Clear();

            Console.Write("Nome do Produto");
            Console.CursorLeft = 20;
            Console.Write("Preço");
            Console.CursorLeft = 32;
            Console.Write("Opção 1");
            Console.CursorLeft = 45;
            Console.Write("Opção 2");
            Console.CursorLeft = 57;
            Console.Write("Opção 3");
            Console.CursorLeft = 70;
            Console.WriteLine("Opção 4");

            Console.Write("----------------");
            Console.CursorLeft = 20;
            Console.Write("------");
            Console.CursorLeft = 32;
            Console.Write("-------");
            Console.CursorLeft = 45;
            Console.Write("-------");
            Console.CursorLeft = 57;
            Console.Write("-------");
            Console.CursorLeft = 70;
            Console.WriteLine("-------");

            for (int i = 0; i < productQuantity; i++)
            {
                Console.Write(name[i]);
                Console.CursorLeft = 20;
                Console.Write(price[i].ToString("C"));
                Console.CursorLeft = 32;
                Console.Write((price[i] * 0.9).ToString("C"));
                Console.CursorLeft = 45;
                Console.Write((price[i] * 0.05).ToString("C"));
                Console.CursorLeft = 57;
                Console.Write(price[i].ToString("C"));
                Console.CursorLeft = 70;
                Console.WriteLine((price[i] * 1.1).ToString("C"));
            }
        }
    }
}
