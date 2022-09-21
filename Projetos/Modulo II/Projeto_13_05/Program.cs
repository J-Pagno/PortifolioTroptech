using System.Collections.Generic;
using System.Collections;
using System;

namespace Projeto_13_05
{
    class Program
    {
        static LinkedList<int> matrixDimensions = new LinkedList<int>();

        static Stack moves = new Stack(),
            movesHour = new Stack();
        static Queue playerOrder = new Queue();

        static bool playAgain = true,
            horizontalCheck = false,
            verticalCheck = false,
            acendingDiagonal = false,
            descendingDiagonal = false;

        static string winnerIndex = "";

        static string[,] movesData = new string[3, 3];

        static void Main(string[] args)
        {
            Console.Clear();

            matrixDimensions.AddLast(0);
            matrixDimensions.AddLast(2);
            matrixDimensions.AddLast(1);
            do
            {
                for (int line = 0; line < 3; line++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        movesData[line, column] = " ";
                    }
                }
                Console.WriteLine("─► Qual jogador começará? [X] ou [O]");
                string firstPLayer = Console.ReadLine();

                cleanTable(firstPLayer);

                bool win = false;

                while (playerOrder.Count != 0 && !win)
                {
                    var playedHour = DateTime.Now;
                    Console.WriteLine("Qual a posição em que deseja jogar? (Linha,Coluna)");
                    string chosenPosition = Console.ReadLine();

                    string[] positions = chosenPosition.Split(',');
                    int lineValue = Convert.ToInt16(positions[0]),
                        columnValue = Convert.ToInt16(positions[1]);
                    if (
                        (matrixDimensions.Contains(lineValue))
                        && (matrixDimensions.Contains(columnValue))
                        && (movesData[lineValue, columnValue] == " ")
                    )
                    {
                        Console.Clear();
                        if ((string)playerOrder.Peek() == "X")
                        {
                            movesData[lineValue, columnValue] = "X";
                        }
                        else
                        {
                            movesData[lineValue, columnValue] = "O";
                        }

                        for (int index = 0; index < 3; index++)
                        {
                            horizontalCheck = (
                                (movesData[index, 0] != " ")
                                && movesData[index, 0] == movesData[index, 1]
                                && movesData[index, 0] == movesData[index, 2]
                                && movesData[index, 1] == movesData[index, 2]
                            );
                            verticalCheck = (
                                (movesData[0, index] != " ")
                                && movesData[0, index] == movesData[1, index]
                                && movesData[0, index] == movesData[2, index]
                                && movesData[1, index] == movesData[2, index]
                            );
                            descendingDiagonal = (
                                movesData[0, 0] != " "
                                && (
                                    movesData[0, 0] == movesData[1, 1]
                                    && movesData[0, 0] == movesData[2, 2]
                                    && movesData[1, 1] == movesData[2, 2]
                                )
                            );
                            acendingDiagonal = (
                                movesData[0, 2] != " "
                                && (
                                    movesData[0, 2] == movesData[1, 1]
                                    && movesData[0, 2] == movesData[2, 0]
                                    && movesData[1, 1] == movesData[2, 0]
                                )
                            );

                            if (
                                horizontalCheck
                                || verticalCheck
                                || acendingDiagonal
                                || descendingDiagonal
                            )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(
                                    $"Parabéns Jogador {playerOrder.Peek()}, você ganhou!!\n\n"
                                );
                                Console.ResetColor();

                                winnerIndex = $"{index}";
                                win = true;
                                break;
                            }
                        }

                        playerOrder.Dequeue();
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        if (
                            !matrixDimensions.Contains(lineValue)
                            && !matrixDimensions.Contains(columnValue)
                        )
                            Console.Write($"A posição '{lineValue},{columnValue}' não existe!!");
                        else if (movesData[lineValue, columnValue] != " ")
                        {
                            Console.Write(
                                $"A posição '{lineValue},{columnValue}' já está preenchida!!"
                            );
                        }
                        else
                            Console.WriteLine("Valor Inválido");

                        Console.WriteLine();
                        Console.ResetColor();
                    }

                    for (int line = 0; line < 3; line++)
                    {
                        for (int column = 0; column < 3; column++)
                        {
                            if (
                                (horizontalCheck && Convert.ToInt16(winnerIndex) == line)
                                || (verticalCheck && Convert.ToInt16(winnerIndex) == column)
                                || (
                                    descendingDiagonal
                                    && (
                                        (line == 0 && column == 0)
                                        || (line == 1 && column == 1)
                                        || (line == 2 && column == 2)
                                    )
                                )
                                || acendingDiagonal
                                    && (
                                        (line == 0 && column == 2)
                                        || (line == 1 && column == 1)
                                        || (line == 2 && column == 0)
                                    )
                            )
                                Console.BackgroundColor = ConsoleColor.Green;
                            else
                                Console.ResetColor();

                            if (column == 2)
                            {
                                Console.Write(" " + movesData[line, column] + " ");

                                Console.ResetColor();

                                Console.WriteLine();
                                if (line == 0 || line == 1)
                                {
                                    Console.WriteLine("═══╬═══╬═══");
                                }
                                else
                                    Console.WriteLine(
                                        $"Horário da Jogada: {playedHour.ToShortTimeString()}"
                                    );
                            }
                            else
                            {
                                Console.Write(" " + movesData[line, column] + " ");
                                Console.ResetColor();
                                Console.Write("║");
                            }
                        }
                        Console.ResetColor();
                    }
                    if (playerOrder.Count == 0 && !win)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Suas chances acabaram, deu velha...");
                        Console.ReadKey();
                        Console.ResetColor();
                    }
                    else if (win)
                    {
                        Console.Write("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.WriteLine(
                            "Deseja jogar novamente? Digite [1] para 'Sim' ou qualquer outra tecla para 'Não'"
                        );
                        string playerWannaPlayAgain = Console.ReadLine();
                        playAgain = (playerWannaPlayAgain == "1");
                    }
                }
            } while (playAgain);
        }

        static void cleanTable(string firstPLayer)
        {
            for (int line = 0; line < 9; line++)
            {
                if (firstPLayer.ToLower() == "x")
                {
                    playerOrder.Enqueue("X");
                    firstPLayer = "O";
                }
                else if (firstPLayer.ToLower() == "o" || firstPLayer == "0")
                {
                    playerOrder.Enqueue("O");
                    firstPLayer = "X";
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"O valor '{firstPLayer}' não é válido!!");
                    Console.ResetColor();
                    break;
                }
            }
        }
    }
}
