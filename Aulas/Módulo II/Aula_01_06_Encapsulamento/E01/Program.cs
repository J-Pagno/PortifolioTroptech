using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            do
            {
                Console.WriteLine("Digite seu nome:");

                if ((person.name = Console.ReadLine()) == "")
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"Valor para 'Nome' inválido");

                    Console.ResetColor();

                    Console.ReadKey();

                    Console.Clear();
                }
                else
                {
                    break;
                }
            } while (true);

            Console.WriteLine("Digite seu pronome de tratamento:");
            person.treatmentPronoun = Console.ReadLine();

            Console.WriteLine("Digite seu ano de nascimento:");
            int year = int.Parse(Console.ReadLine());

            person.birthYear = new DateTime(year, 1, 1);

            Console.WriteLine("Digite seu telefone:");
            person.phone = Convert.ToInt16(Console.ReadLine());

            Console.Clear();

            Console.WriteLine(person.name);
            Console.WriteLine($"Ano de Nascimento: {person.birthYear}");
            Console.WriteLine($"Telefone: {person.phone}");
            Console.WriteLine($"Idade: {person.age}");
        }
    }
}
