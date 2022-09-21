using System;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectPerson = new Person("Jorginho", 89, 1.77, "Masculino");

            Console.WriteLine("Nome: " + objectPerson.GetName());
            Console.WriteLine("Peso: " + objectPerson.GetWeight());
            Console.WriteLine("Altura: " + objectPerson.GetHeight());
            Console.WriteLine("Gênero: " + objectPerson.GetGender());
            Console.WriteLine("IMC: " + objectPerson.GetIMC());

            objectPerson.ChangeName("Jorjana");
            objectPerson.ChangeWeight(80);
            objectPerson.ChangeHeight(1.65);
            objectPerson.ChangeGender("Feminino");

            Console.WriteLine("Novo nome: " + objectPerson.GetName());
            Console.WriteLine("Novo peso: " + objectPerson.GetWeight());
            Console.WriteLine("Nova altura: " + objectPerson.GetHeight());
            Console.WriteLine("Novo gênero: " + objectPerson.GetGender());
            Console.WriteLine("Novo IMC: " + objectPerson.GetIMC());

        }
    }
}
