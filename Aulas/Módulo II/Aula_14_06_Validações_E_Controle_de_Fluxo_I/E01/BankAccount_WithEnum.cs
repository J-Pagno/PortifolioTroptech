using System;

namespace E01
{
    public class BankAccount_WithEnum
    {
        public enum ValidCodes
        {
            Poupanca = 1288,
            Corrente = 001,
            Investimento = 009
        }

        public int Agency { get; set; }
        public int Number { get; set; }
        public ValidCodes AccountType { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        public BankAccount_WithEnum()
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

            bool accountTypeExists = false;

            do
            {
                Console.WriteLine(
                    "Digite o tipo de conta: [001 - Corrente, 009 - Investimento, 1288 - Poupança]"
                );
                accountTypeExists = int.TryParse(Console.ReadLine(), out int accountType);

                if (Enum.IsDefined(typeof(ValidCodes), accountType))
                {
                    AccountType = (ValidCodes)accountType;
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
                    Console.WriteLine(CPF.Length);
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
