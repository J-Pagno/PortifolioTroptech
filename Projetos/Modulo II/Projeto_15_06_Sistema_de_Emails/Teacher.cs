using System;
using System.Collections.Generic;

namespace Projeto_15_06_Sistema_de_Emails
{
    public class Teacher
    {
        private static void SendEmail()
        {
            do
            {
                Console.WriteLine("Digite o id da pergunta: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int id);

                Console.WriteLine("Digite uma resposta para a pergunta: ");
                string answer = Console.ReadLine();

                if (!isNumber)
                {
                    Program.Warning("Valor inválido!");

                    Console.Clear();

                    continue;
                }

                AnswerEmail email = new(answer, id);

                Program.AnswerList.Add(email);

                return;
            } while (true);
        }

        private static void ShowAllEmails()
        {
            foreach (var item in Program.QuestionList)
            {
                if (!item.WasAnswered)
                    Console.WriteLine(item.Display() + "\n");
            }
        }

        public void Menu()
        {
            do
            {
                Console.WriteLine("Escolha uma das opções abaixo:");

                Console.WriteLine("[1] - Visualizar dúvidas");
                Console.WriteLine("[2] - Enviar resposta");
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
                        ShowAllEmails();
                        break;

                    case 2:
                        SendEmail();
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
