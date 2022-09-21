using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o número de produtos: ");
            int productQuantity = Convert.ToInt16(Console.ReadLine());

            string[] name = new string[productQuantity],
                classification = new string[productQuantity];

            for (int i = 0; i < productQuantity; i++)
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine($"Produto {i + 1}: ");
                Console.WriteLine("==================================");

                Console.WriteLine("Nome do Produto: ");
                name[i] = Console.ReadLine();

                bool isValidClassificationCode = false;
                while (!isValidClassificationCode)
                {
                    Console.WriteLine(
                        "Classificação do Produto\n1 - Alimento não-perecível\n2, 3 ou 4 - Alimento perecível\n5 ou 6 - Vestuário\n7 - Higiene pessoal\n8, 9, 10 - Utensílios domésticos"
                    );
                    int classificationCode = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Classificação do Prduto:");
                    
                    switch (classificationCode)
                    {
                        case 1:
                            classification[i] = "Alimento Não-Perecível";
                            isValidClassificationCode = true;
                            break;
                        case 2:
                        case 3:
                        case 4:
                            classification[i] = "Alimento Perecível";
                            isValidClassificationCode = true;
                            break;
                        case 5:
                        case 6:
                            classification[i] = "Vestuário";
                            isValidClassificationCode = true;
                            break;
                        case 7:
                            classification[i] = "Higiene Pessoal";
                            isValidClassificationCode = true;
                            break;
                        case 8:
                        case 9:
                        case 10:
                            classification[i] = "Utensílios Domésticos";
                            isValidClassificationCode = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Código Inválido!");
                            break;
                    }
                }
            }

            Console.Clear();

            Console.Write("Nome do Produto");
            Console.CursorLeft = 30;
            Console.WriteLine("Classificação");

            Console.Write("----------------");
            Console.CursorLeft = 30;
            Console.WriteLine("---------------");

            for (int i = 0; i < productQuantity; i++)
            {
                Console.Write(name[i]);
                Console.CursorLeft = 30;
                Console.WriteLine(classification[i]);
            }
        }
    }
}
