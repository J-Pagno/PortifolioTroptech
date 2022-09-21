using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o número de funcionários: ");
            int workersQuantity = Convert.ToInt16(Console.ReadLine());

            string[] name = new string[workersQuantity];

            int[] age = new int[workersQuantity],
                serviceTimeQuantity = new int[workersQuantity];

            for (int i = 0; i < workersQuantity; i++)
            {
                int questionNumber = 0;

                while (questionNumber < 3)
                {
                    Console.Clear();

                    Console.WriteLine("==================================");
                    Console.WriteLine($"Trabalhador {i + 1}: ");
                    Console.WriteLine("==================================");

                    switch (questionNumber)
                    {
                        case 0:
                            Console.WriteLine("Nome: ");
                            name[i] = Console.ReadLine();
                            break;
                        case 1:
                            Console.WriteLine("Idade: ");
                            age[i] = Convert.ToInt16(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Tempo de Serviço (Em Anos): ");
                            serviceTimeQuantity[i] = Convert.ToInt16(Console.ReadLine());
                            break;
                    }
                    questionNumber++;
                }
            }

            Console.Clear();

            Console.Write("Nome");
            Console.CursorLeft = 15;
            Console.Write("Idade");
            Console.CursorLeft = 30;
            Console.Write("Tempo");
            Console.CursorLeft = 45;
            Console.WriteLine("Situação");

            Console.Write("-----");
            Console.CursorLeft = 15;
            Console.Write("------");
            Console.CursorLeft = 30;
            Console.Write("------");
            Console.CursorLeft = 45;
            Console.WriteLine("---------");

            for (int i = 0; i < workersQuantity; i++)
            {
                Console.Write(name[i]);
                Console.CursorLeft = 15;
                Console.Write(age[i]);
                Console.CursorLeft = 30;
                Console.Write(serviceTimeQuantity[i]);
                Console.CursorLeft = 45;
                if (
                    age[i] >= 65
                    || serviceTimeQuantity[i] >= 30
                    || (age[i] < 60 && serviceTimeQuantity[i] >= 25)
                )
                    Console.WriteLine("Sim");
                else
                    Console.WriteLine("Não");
            }
        }
    }
}
