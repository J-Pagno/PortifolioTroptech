using System;
using System.Collections.Generic;

namespace Projeto_03_06_Loja_de_Roupas
{
    public class ClientActions
    {
        //Criar verificação sobre CPF/CNPJ repetidos
        public static bool RegisterClient()
        {
            Client basicaData = new Client();

            Adderess adderess = new Adderess();

            Console.WriteLine("Digite o Nome do cliente:");
            basicaData.Name = Console.ReadLine();

            Console.WriteLine("Digite o Telefone do cliente:");
            basicaData.Phone = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Rua do cliente:");
            adderess.Street = Console.ReadLine();

            Console.WriteLine("Digite o Número do Endereço do cliente:");
            adderess.Number = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a cidade do cliente:");
            adderess.City = Console.ReadLine();

            Console.WriteLine("Digite o Estado do cliente:");
            adderess.State = Console.ReadLine();

            Console.WriteLine("Digite o Pais do cliente:");
            adderess.Country = Console.ReadLine();

            do
            {
                dynamic person;

                bool identificationNumberExists = false;

                Console.WriteLine("O cliente é do tipo pessoa [1] Física ou [2] Jurídica?");

                int chosenOption = int.Parse(Console.ReadLine());

                if (chosenOption == 1)
                {
                    person = new NaturalPerson(basicaData, adderess);

                    Console.WriteLine("Digite o CPF do cliente:");

                    person.Cpf = Console.ReadLine();

                    foreach (var item in Program.naturalPersonList)
                    {
                        if (item.Cpf == person.Cpf)
                        {
                            identificationNumberExists = true;

                            break;
                        }
                    }

                    if (identificationNumberExists)
                    {

                        Program.WarningAlert("Valor já existente!");

                        continue;
                    }
                }
                else if (chosenOption == 2)
                {
                    person = new LegalPerson(basicaData, adderess);

                    Console.WriteLine("Digite o CNPJ do cliente:");

                    person.Cnpj = Console.ReadLine();

                    foreach (var item in Program.legalPersonList)
                    {
                        if (item.Cnpj == person.Cnpj)
                        {
                            identificationNumberExists = true;

                            break;
                        }
                    }
                }
                else
                {
                    continue;
                }

                if (ClientActions.AddClientToTheList(person))
                    return true;
                else
                    return false;
            } while (true);
        }

        public static bool ShowAllClients()
        {
            Console.Clear();

            Console.WriteLine("Cliente Físicos");

            foreach (var naturalPerson in Program.naturalPersonList)
            {
                Console.WriteLine(naturalPerson.ToString());
            }

            Console.WriteLine("\nCliente Jurídicos");

            foreach (var legalPerson in Program.legalPersonList)
            {
                Console.WriteLine(legalPerson.ToString());
            }

            Console.ReadKey();

            return true;
        }

        public static bool SearchClientByName()
        {
            List<LegalPerson> valuesFoundedLP = new List<LegalPerson>();
            List<NaturalPerson> valuesFoundedNP = new List<NaturalPerson>();

            Console.WriteLine("Digite o valor buscado: ");
            string name = Console.ReadLine();

            foreach (var legalPerson in Program.legalPersonList)
            {
                if (legalPerson.Name.ToLower().Contains(name.ToLower()))
                {
                    valuesFoundedLP.Add(legalPerson);
                }
            }

            foreach (var naturalPerson in Program.naturalPersonList)
            {
                if (naturalPerson.Name.ToLower().Contains(name.ToLower()))
                {
                    valuesFoundedNP.Add(naturalPerson);
                }
            }

            Console.Clear();

            int totalResults = valuesFoundedLP.Count + valuesFoundedNP.Count;

            if (totalResults > 0)
                Console.WriteLine(
                    $"Foram encontrados {totalResults} resultado(s) semelhante(s) à {name}"
                );
            else
                Console.WriteLine("Nenhum valor encontrado!");

            Console.WriteLine("───────────────────────────────────");

            foreach (var item in valuesFoundedLP)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (var item in valuesFoundedNP)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();

            return true;
        }

        public static bool RemoveClientById()
        {
            do
            {
                Console.WriteLine("O cliente é do tipo [1] Pessoa Física ou [2] Pessoa Jurídica?");

                string chosenOption = Console.ReadLine();

                string identificationNumber = "";

                if (chosenOption == "1")
                {
                    Console.WriteLine("Digite o CPF do cliente: ");

                    identificationNumber = Console.ReadLine();

                    foreach (var naturalPerson in Program.naturalPersonList)
                    {
                        if (naturalPerson.Cpf == identificationNumber)
                        {
                            NaturalPerson person = naturalPerson;

                            Program.naturalPersonList.Remove(person);

                            break;
                        }
                    }
                }
                else if (chosenOption == "2")
                {
                    Console.WriteLine("Digite o CNPJ do cliente: ");

                    identificationNumber = Console.ReadLine();

                    foreach (var legalPerson in Program.legalPersonList)
                    {
                        if (legalPerson.Cnpj == identificationNumber)
                        {
                            var person = legalPerson;

                            Program.legalPersonList.Remove(person);

                            break;
                        }
                    }
                }
                else
                {
                    Program.WarningAlert("Valor Inválido!");

                    continue;
                }

                break;
            } while (true);

            return true;
        }

        public static dynamic GetExactlyClientByName()
        {
            Console.WriteLine("Digite o nome buscado: ");
            string name = Console.ReadLine();

            foreach (var legalPerson in Program.legalPersonList)
            {
                if (legalPerson.Name.Equals(name))
                {
                    return legalPerson;
                }
            }

            foreach (var naturalPerson in Program.naturalPersonList)
            {
                if (naturalPerson.Name.Contains(name))
                {
                    return naturalPerson;
                }
            }

            Console.Clear();

            return null;
        }

        public static bool AddClientToTheList(LegalPerson obj)
        {
            int initialCount = Program.legalPersonList.Count;

            Program.legalPersonList.Add(obj);
            if (Program.legalPersonList.Count > initialCount)
                return true;
            else
                return false;
        }

        public static bool AddClientToTheList(NaturalPerson obj)
        {
            int initialCount = Program.naturalPersonList.Count;

            Program.naturalPersonList.Add(obj);

            if (Program.naturalPersonList.Count > initialCount)
                return true;
            else
                return false;
        }
    }
}
