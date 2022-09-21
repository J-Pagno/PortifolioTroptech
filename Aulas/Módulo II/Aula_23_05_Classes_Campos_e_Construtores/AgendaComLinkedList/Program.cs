using System.Collections.Generic;
using System;

namespace AgendaComLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            LinkedList<AgendaItem> registeredPeoples = new LinkedList<AgendaItem>();

            Console.WriteLine("Quantos cadastros serão feitos?");
            int numberofRecords = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < numberofRecords; i++)
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

                registeredPeoples.AddLast(item);
            }

            Console.WriteLine($"\nNúmero de pessoas cadastradas: {AgendaItem.peopleCounter}\n");

            int peopleNumber = 1;

            Console.Clear();

            foreach (var item in registeredPeoples)
            {
                var currentName = item.Name;
                var currentPhone = item.Phone;
                var currentAddress = !string.IsNullOrEmpty(item.Address)
                    ? item.Address
                    : "Campo vazio";
                var currentProfession = !string.IsNullOrEmpty(item.Profession)
                    ? item.Profession
                    : "Campo vazio";

                Console.WriteLine("\n===============");
                Console.WriteLine($"—► Pessoa {peopleNumber} ◄—");
                Console.WriteLine("===============\n");

                Console.WriteLine(
                    $"Nome: {currentName}\nTelefone: {currentPhone}\nEndereço: {currentAddress}\nProfissão: {currentProfession}"
                );

                peopleNumber++;
            }

            Console.ReadKey();
        }
    }
}
