using System;
using System.Collections.Generic;

namespace Projeto_15_06_Sistema_de_Emails
{
    class Program
    {
        public static int CurrentEmailIdentification = 1;
        public static List<AnswerEmail> AnswerList = new();
        public static List<QuestionEmail> QuestionList = new();

        private static Student student = new();
        private static Teacher teacher = new();

        static void Main(string[] args)
        {
            do
            {
                ChangeUserType();
            } while (true);
        }

        static void ChangeUserType()
        {
            do
            {
                Console.WriteLine(
                    "Qual o usuário atual do sistema? \n[ 1 ] Aluno\n[ 2 ] Professor\n[ 3 ] Sair"
                );
                bool isNumber = int.TryParse(Console.ReadLine(), out int userType);

                if (!isNumber)
                {
                    Warning("Digite um valor válido!");
                    continue;
                }

                switch (userType)
                {
                    case 1:
                        student.Menu();
                        break;

                    case 2:
                        teacher.Menu();
                        break;

                    case 3:
                        return;

                    default:

                        Warning("Valor inválido!!");
                        continue;
                }
            } while (true);
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
