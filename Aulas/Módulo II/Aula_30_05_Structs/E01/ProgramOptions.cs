using System;
using System.Collections.Generic;

namespace E01
{
    public static class ProgramOptions
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Sair");
        }

        public static LinkedList<Client> ClientRegister(LinkedList<Client> clientList)
        {
            Client newClient = new Client();

            Console.WriteLine("Digite seu nome:");
            newClient.name = Console.ReadLine();

            Console.WriteLine("Digite sua idade:");
            bool isNumber = int.TryParse(Console.ReadLine(), out int currentAge);

            if (isNumber)
                newClient.age = currentAge;
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Valor inválido!");
                Console.ResetColor();
                Console.ReadKey();
                return clientList;
            }

            Console.WriteLine("Digite o nome da sua rua:");
            newClient.street = Console.ReadLine();

            Console.WriteLine("Digite o nome do seu bairro:");
            newClient.district = Console.ReadLine();

            Console.WriteLine("Digite o número de onde você mora:");
            newClient.houseNumber = Console.ReadLine();

            Console.WriteLine("Digite o nome de sua cidade:");
            newClient.city = Console.ReadLine();

            Console.WriteLine("Digite o seu estado:");
            newClient.state = Console.ReadLine();

            clientList.AddLast(newClient);

            return clientList;
        }

        public static void ShowAllClients(LinkedList<Client> clientList)
        {
            Console.Clear();

            if (clientList.Count == 0)
            {
                Console.WriteLine("Nenhum cadastro foi efetuado ainda!");
                Console.ReadKey();
                return;
            }

            foreach (var client in clientList)
            {
                Console.WriteLine(client.name + " - " + client.city);
                Console.WriteLine("==============================");
            }
            
            Console.ReadKey();
        }
    }
}
