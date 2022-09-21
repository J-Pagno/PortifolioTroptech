using System;

namespace JoaoPagnoProjeto3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            int loginAttempts = 0;

            double result = 0,
                val1 = 0,
                val2 = 0;

            string login = "",
                password = "",
                chosenOperation = "",
                operationSymbol = "";

            bool isLoginLoop = true,
                isMenuLoop = true,
                isSubMenuLoop = true,
                isOperationLoop = true,
                isCorrectName = false,
                isCorrectPassword = false;
            
            while (isLoginLoop)
            {
                if (loginAttempts >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Limite de tenttivas excedido!!!");
                    Console.ResetColor();
                    Environment.Exit(0);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------- LOGIN --------");
                Console.ResetColor();

                Console.Write("Digite o login: ");
                login = Console.ReadLine();

                Console.Write("\nDigite a senha: ");
                password = Console.ReadLine();

                isCorrectName = login == "Jorge";
                isCorrectPassword = password == "123";

                if (isCorrectName && isCorrectPassword)
                {
                    Console.Clear();
                    isLoginLoop = false;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (isCorrectName && !isCorrectPassword)
                    {
                        Console.WriteLine("Senha incorreta!!!");
                    }
                    else if (!isCorrectName && isCorrectPassword)
                    {
                        Console.WriteLine("Login inválido!!!");
                    }
                    else
                    {
                        Console.WriteLine("Login e Senha incorretos!!!");
                    }
                    loginAttempts++;
                }
            }

            string header = "------------------------------------\n" + "Usuário: " + login;

            while (isMenuLoop)
            {
                Console.WriteLine(header);
                Console.WriteLine("--------------- MENU ---------------");
                Console.WriteLine("Escolha uma da opções abaixo: ");
                Console.WriteLine("[1] + Soma");
                Console.WriteLine("[2] - Subtração");
                Console.WriteLine("[3] * Multiplicação");
                Console.WriteLine("[4] / Divisão");
                Console.WriteLine("[5] | Sair");
                Console.WriteLine("--------------------------------------");

                Console.Write("=> ");
                chosenOperation = Console.ReadLine();
                isSubMenuLoop = true;
                Console.Clear();

                while (isSubMenuLoop)
                {
                    switch (chosenOperation)
                    {
                        case "1":
                            operationSymbol = "+";
                            break;

                        case "2":
                            operationSymbol = "-";
                            break;

                        case "3":
                            operationSymbol = "*";
                            break;

                        case "4":
                            operationSymbol = "/";
                            break;

                        case "5":

                            isMenuLoop = false;
                            isSubMenuLoop = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Clear();
                            Console.WriteLine("ATENÇÃO: Digite um valor válido!");
                            Console.ResetColor();
                            isSubMenuLoop = false;
                            break;
                    }

                    if (!isSubMenuLoop)
                        break;

                    do
                    {
                        Console.WriteLine(header);
                        Console.WriteLine($"-------- OPERAÇÃO {operationSymbol} -------");

                        Console.WriteLine("Digite o primeiro número: ");
                        Console.Write("=> ");
                        val1 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Digite o segundo número: ");
                        Console.Write("=> ");
                        val2 = Convert.ToDouble(Console.ReadLine());

                        switch (operationSymbol)
                        {
                            case "+":
                                result = val1 + val2;
                                break;
                            case "-":
                                result = val1 - val2;
                                break;
                            case "*":
                                result = val1 * val2;
                                break;
                            case "/":
                                result = val1 / val2;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Clear();
                                Console.WriteLine("ATENÇÃO: Digite um valor válido!");
                                Console.ResetColor();
                                isOperationLoop = false;
                                break;
                        }

                        Console.WriteLine($"RESULTADO: {val1} {operationSymbol} {val2} = {result}");

                        Console.WriteLine("--------------------------------------");

                        Console.WriteLine("Pressione ENTER para prosseguir!");
                        Console.ReadKey();

                        Console.Clear();

                        Console.WriteLine(header);
                        Console.WriteLine($"-------- OPERAÇÃO {operationSymbol} -------");
                        Console.WriteLine("Escolha uma das opções abaixo: ");
                        Console.WriteLine("[1] - REFAZER OPERAÇÃO");
                        Console.WriteLine("[2] - VOLTAR PARA OPERAÇÕES");
                        Console.WriteLine("--------------------------------------");

                        Console.Write("=> ");
                        string vari = Console.ReadLine();

                        if (vari != "1")
                        {
                            isOperationLoop = false;
                            isSubMenuLoop = false;
                        }

                        Console.Clear();
                    } while (isOperationLoop);
                }
            }
            Console.ResetColor();
        }
    }
}
