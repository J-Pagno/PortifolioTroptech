using System;
using System.Collections.Generic;

namespace Projeto_15_06_Sistema_de_Emails
{
    public class Student
    {
        private static void SendEmail()
        {
            Console.WriteLine("Digite a sua dúvida: ");
            string question = Console.ReadLine();

            QuestionEmail email = new(question);

            Program.QuestionList.Add(email);
        }

        private static void ShowAllEmails()
        {
            foreach (var email in Program.QuestionList)
            {
                Console.WriteLine(email.Display() + "\n");
            }
        }

        public void Menu()
        {
            do
            {
                Console.WriteLine("Escolha uma das opções abaixo:");

                Console.WriteLine("[1] - Enviar dúvidas");
                Console.WriteLine("[2] - Visualizar todos os emails");
                Console.WriteLine("[3] - Voltar para o menu principal");

                bool isNumber = int.TryParse(Console.ReadLine(), out int chosenOption);

                if (!isNumber)
                {
                    Program.Warning("Valor inválido!");

                    Console.Clear();

                    continue;
                }

                switch (chosenOption)
                {
                    case 1:
                        SendEmail();
                        break;

                    case 2:
                        ShowAllEmails();
                        break;

                    case 3:
                        return;

                    default:
                        Program.Warning("Valor inválido!");
                        break;
                }
            } while (true);
        }
    }
}
