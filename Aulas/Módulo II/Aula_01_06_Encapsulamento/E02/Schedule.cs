using System;
using System.Collections.Generic;

namespace E02
{
    public class Schedule
    {
        private List<Contact> _contactsList;

        public Schedule()
        {
            _contactsList = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            if (!_contactsList.Contains(contact))
            {
                foreach (var currentContact in _contactsList)
                {
                    if (currentContact.name == contact.name)
                    {
                        Console.WriteLine($"O nome {contact.name} já existe na agenda");

                        Console.ReadKey();

                        return;
                    }
                }
                _contactsList.Add(contact);
            }
        }

        public void RemoveContact(string contactName)
        {
            foreach (var currentContact in _contactsList)
            {
                if (currentContact.name == contactName)
                {
                    _contactsList.Remove(currentContact);

                    Console.WriteLine($"O contato {contactName} foi removido com sucesso!");

                    Console.ReadKey();

                    return;
                }
            }

            Console.WriteLine($"O contato {contactName} não existe dentro da lista!");

            Console.ReadKey();
        }

        public bool ContactExists(string contactName)
        {
            foreach (var currentContact in _contactsList)
            {
                if (currentContact.name == contactName)
                {
                    return true;
                }
            }

            return false;
        }

        public int SearchContact(string contactName)
        {
            List<string> foundNames = new List<string>();

            if (contactName == "")
            {
                Console.WriteLine("O valor buscado não pode ser vazio!");

                Console.ReadKey();

                return foundNames.Count;
            }

            foreach (var currentContact in _contactsList)
            {
                if (currentContact.name.ToLower().Contains(contactName.ToLower()))
                {
                    foundNames.Add(currentContact.name);
                }
            }

            Console.WriteLine(
                $"Existem {foundNames.Count} items similares à busca por: {contactName}"
            );

            Console.WriteLine("──────────────────────────────");

            foreach (var foundName in foundNames)
            {
                Console.WriteLine("─► " + foundName);
            }

            Console.ReadKey();

            return foundNames.Count;
        }

        public List<string> SortContactList()
        {
            List<string> newList = new List<string>();

            if (_contactsList.Count == 0)
            {
                Console.WriteLine("A lista está vazia!");

                Console.ReadKey();

                return newList;
            }

            for (int i = 97; i < 123; i++)
            {
                foreach (var currentContact in _contactsList)
                {
                    if ((int)currentContact.name.ToLower()[0] == i)
                    {
                        newList.Add(currentContact.name);
                    }
                }
            }

            return newList;
        }
    }
}
