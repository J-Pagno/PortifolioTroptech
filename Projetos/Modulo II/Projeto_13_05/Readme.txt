Esse era o código que eu ia fazer para validar as repostas certas e pinta-las na minha primeira tentativa de resolver isso,
mas quando deixei pra outra hora e fui jantar e ver série, aí tive uma idéia de melhorar isso e diminui o código em
torno de umas 60 linhas pelo menos.


                            if (
                                (
                                    (movesData[0, 0] == movesData[0, 1])
                                    && (movesData[0, 0] == movesData[0, 2])
                                    && (movesData[0, 1] == movesData[0, 2])
                                )
                                && movesData[0, 0] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[1, 0] == movesData[1, 1])
                                    && (movesData[1, 0] == movesData[1, 2])
                                    && (movesData[1, 1] == movesData[1, 2])
                                )
                                && movesData[1, 0] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[2, 0] == movesData[2, 1])
                                    && (movesData[2, 0] == movesData[2, 2])
                                    && (movesData[2, 1] == movesData[2, 2])
                                )
                                && movesData[2, 0] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[0, 0] == movesData[1, 0])
                                    && (movesData[0, 0] == movesData[2, 0])
                                    && (movesData[1, 0] == movesData[2, 0])
                                )
                                && movesData[0, 0] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[0, 1] == movesData[1, 1])
                                    && (movesData[0, 1] == movesData[2, 1])
                                    && (movesData[1, 1] == movesData[2, 1])
                                )
                                && movesData[0, 1] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[0, 0] == movesData[1, 0])
                                    && (movesData[0, 0] == movesData[2, 0])
                                    && (movesData[1, 0] == movesData[2, 0])
                                )
                                && movesData[1, 0] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[0, 0] == movesData[1, 1])
                                    && (movesData[0, 0] == movesData[2, 2])
                                    && (movesData[1, 1] == movesData[2, 2])
                                )
                                && movesData[1, 1] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else if (
                                (
                                    (movesData[0, 2] == movesData[1, 1])
                                    && (movesData[0, 2] == movesData[0, 0])
                                    && (movesData[1, 1] == movesData[2, 0])
                                )
                                && movesData[0, 2] != " "
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Você ganhou!!");
                                Console.WriteLine();
                                Console.ResetColor();
                                win = true;
                            }
                            else
                            {
                                if (playerOrder.Count == 0)
                                {
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Deu Velha!!");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    win = true;
                                }
                            }