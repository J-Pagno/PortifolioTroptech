using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Schedule schedule = new Schedule();

            do
            {
                Console.Clear();

                Contact contact = new Contact();

                string option;

                MenuOptions.PrintMenu();

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Qual o nome do novo usuário?");
                            string newName = Console.ReadLine();

                            if (newName.Length == 0)
                            {
                                Console.WriteLine("O campo do nome não pode ser vazio!");

                                Console.ReadKey();
                            }
                            else if (
                                (int)newName.ToLower()[0] < 97 || (int)newName.ToLower()[0] > 122
                            )
                                Console.WriteLine("Letra inicial inválida!");
                            else
                            {
                                contact.name = newName;
                                break;
                            }
                        } while (true);

                        if (contact.name.ToLower() == "encerrar")
                            break;

                        do
                        {
                            Console.WriteLine("Qual o telefone do novo usuário?");
                            bool isNumber = int.TryParse(Console.ReadLine(), out int phone);

                            if (isNumber)
                            {
                                contact.phone = phone;
                            }
                            else
                            {
                                Console.WriteLine("O valor precisa ser um número!");

                                Console.ReadKey();

                                continue;
                            }

                            schedule.AddContact(contact);

                            break;
                        } while (true);
                        break;

                    case "2":
                        Console.WriteLine("Qual contato deseja remover?");
                        schedule.RemoveContact(Console.ReadLine());
                        break;

                    case "3":
                        Console.WriteLine("Qual contato deseja verificar?");
                        string valToCheck = Console.ReadLine();

                        if (schedule.ContactExists(valToCheck))
                        {
                            Console.WriteLine("O valor existe na lista!");
                        }
                        else
                            Console.WriteLine("O valor não existe na lista!");

                        Console.ReadKey();

                        break;

                    case "4":
                        Console.WriteLine("Qual contato deseja buscar?");

                        string valToSearch = Console.ReadLine();

                        schedule.SearchContact(valToSearch);

                        break;

                    case "5":

                        var ordelyContactList = schedule.SortContactList();

                        if (ordelyContactList.Count > 0)
                        {
                            foreach (var contactItem in ordelyContactList)
                            {
                                Console.WriteLine(contactItem);
                            }

                            Console.ReadKey();
                        }

                        break;

                    default:

                        Console.WriteLine("Valor inválido!");

                        Console.ReadKey();

                        Console.Clear();

                        break;
                }
            } while (true);
        }
    }
}
