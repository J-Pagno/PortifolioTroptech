using System;

namespace AgendaComArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var registeredPeoples = new AgendaItem[2];

            for (int i = 0; i < 2; i++)
            {
                Console.Clear();

                AgendaItem item;

                Console.WriteLine("Digite seu nome:");
                string name = Console.ReadLine();

                Console.WriteLine("Digite seu telefone:");
                string phone = Console.ReadLine();

                Console.WriteLine("Digite seu endereço:");
                string address = Console.ReadLine();

                Console.WriteLine("Digite sua profissão:");
                string profession = Console.ReadLine();

                if (string.IsNullOrEmpty(address) && string.IsNullOrEmpty(profession))
                {
                    item = new AgendaItem(name, phone);
                }
                else
                {
                    item = new AgendaItem(name, phone, address, profession);
                }

                registeredPeoples[i] = item;
            }

            Console.Clear();

            Console.WriteLine($"\nNúmero de pessoas cadastradas: {AgendaItem.peopleCounter}\n");

            for (int i = 0; i < AgendaItem.peopleCounter; i++)
            {
                var currentName = registeredPeoples[i].Name;
                var currentPhone = registeredPeoples[i].Phone;
                var currentAddress = !string.IsNullOrEmpty(registeredPeoples[i].Address)
                    ? registeredPeoples[i].Address
                    : "Campo vazio";
                var currentProfession = !string.IsNullOrEmpty(registeredPeoples[i].Profession)
                    ? registeredPeoples[i].Profession
                    : "Campo vazio";

                Console.WriteLine("\n===============");
                Console.WriteLine($"—► Pessoa {i + 1} ◄—");
                Console.WriteLine("===============\n");

                Console.WriteLine(
                    $"Nome: {currentName}\nTelefone: {currentPhone}\nEndereço: {currentAddress}\nProfissão: {currentProfession}"
                );
            }
            Console.ReadKey();
        }
    }
}
