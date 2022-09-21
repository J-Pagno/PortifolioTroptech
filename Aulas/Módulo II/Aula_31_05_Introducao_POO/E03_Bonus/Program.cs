using System;

namespace E03_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual filme será visto?");
            string movieName = Console.ReadLine();

            Console.WriteLine("Qual a duração do filme? (hh:mm:ss)");
            string fullDuration = Console.ReadLine();

            Session session = new Session(movieName, fullDuration);

            do
            {
                Console.Clear();

                Console.WriteLine("Qual assento deseja escolher? (01 - 10)");
                string userChoice = Console.ReadLine();

                bool isNumber = int.TryParse(userChoice, out int seatId);

                if (userChoice == "-1")
                {
                    break;
                }
                else if (!isNumber || (seatId < 1 || seatId > 10))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;

                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Valor inválido!");

                    Console.ResetColor();

                    Console.ReadKey();

                    continue;
                }
                else if (!session.isVacant(seatId))
                {
                    continue;
                }
                else
                    session.ChosenSeat(seatId);
            } while (!session.isFull());

            if (session.NumberOfFreeSeats() > 0)
                Console.WriteLine($"Sobraram {session.NumberOfFreeSeats()} assentos livres!");
            else
                Console.WriteLine("Todos os assentos foram ocupados!");
        }
    }
}
