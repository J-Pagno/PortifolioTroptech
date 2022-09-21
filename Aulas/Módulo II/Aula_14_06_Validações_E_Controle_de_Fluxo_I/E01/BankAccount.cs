using System;
using System.Collections.Generic;

namespace E01
{
    public class BankAccount
    {
        //         Poupanca = 1288,
        //         Corrente = 001,
        //         Investimento = 009
        private static int[] _validCodes = { 1288, 001, 009 };

        public List<int> ValidCodes = new(_validCodes);

        public int Agency { get; set; }
        public int Number { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        public BankAccount()
        {
            SetProperties();
        }

        void SetProperties()
        {
            bool isNumberAgency = false,
                isNumber = false;

            do
            {
                Console.WriteLine("Digite o número de sua agência: ");
                isNumberAgency = int.TryParse(Console.ReadLine(), out int agency);
                Agency = agency;

                Console.WriteLine("Digite o número de sua conta: ");
                isNumber = int.TryParse(Console.ReadLine(), out int number);
                Number = number;

                if (!isNumberAgency)
                {
                    Program.Warning("Valor da agência inválido!");
                    continue;
                }
                else if (!isNumber)
                {
                    Program.Warning("Número da conta inválido!");
                    continue;
                }
                break;
            } while (true);

            do
            {
                Console.WriteLine(
                    "Digite o tipo de conta: [1 - 001 Corrente, 2 - 009 Investimento, 2 - 1288 Poupança]"
                );

                if (!int.TryParse(Console.ReadLine(), out int accountType))
                    continue;

                if (ValidCodes.Contains(accountType))
                {
                    switch (accountType)
                    {
                        case 1:
                            AccountType = "001 Corrente";
                            break;

                        case 2:
                            AccountType = "009 Investimento";
                            break;

                        case 3:
                            AccountType = "1288 Poupança";
                            break;

                        default:
                            Program.Warning("Valor Inválido!");
                            break;
                    }
                    break;
                }
                else
                {
                    Program.Warning("Tipo de conta inválido!");
                }
            } while (true);

            do
            {
                Console.WriteLine("Digite o nome do Cliente: ");
                Name = Console.ReadLine();

                if (String.IsNullOrEmpty(Name))
                {
                    Program.Warning("O campo 'nome' é obrigatório!");

                    continue;
                }

                break;
            } while (true);

            do
            {
                Console.WriteLine("Digite Digite o CPF do cliente (apenas os números): ");
                CPF = Console.ReadLine();

                bool hasNoNumbers = false;

                foreach (var letter in CPF)
                {
                    if ((int)letter < 48 || (int)letter > 57)
                    {
                        Console.WriteLine((int)letter);

                        hasNoNumbers = true;

                        break;
                    }
                }

                if (!hasNoNumbers)
                {
                    if (CPF.Length == 11)
                    {
                        break;
                    }
                    else
                    {
                        Program.Warning("O valor deve conter 11 caracteres!");
                    }
                }
                else
                {
                    Program.Warning("O valor deve conter apenas números");
                }
            } while (true);

            Program.Success("Cadastro efetuado com sucesso!");
        }
    }
}
