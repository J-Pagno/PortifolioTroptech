using System;
using System.Collections.Generic;

namespace E03_Bonus
{
    public class Session
    {
        private string _movieName { get; set; }
        
        private string _duration;

        private List<Seat> _seats = new List<Seat>(10);

        public Session(string name, string fullDuration)
        {
            string[] duration = fullDuration.Split(':');

            _movieName = name;

            _duration = $"{duration[0]}:{duration[1]}:{duration[2]}";

            for (int i = 0; i < 10; i++)
            {
                
                Seat seat = new Seat(i + 1);

                _seats.Add(seat);

            }
        }

        public void ChosenSeat(int seatId)
        {
            foreach (var seat in _seats)
            {
                if (seat.seatId == seatId && isVacant(seat.seatId))
                {
                    seat.isBeingUsed = true;

                    Console.BackgroundColor = ConsoleColor.Green;

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Assento escolhido com sucesso!");

                    Console.ResetColor();

                    Console.ReadKey();

                    break;
                }
            }
        }

        public bool isVacant(int seatId)
        {
            bool seatIdExists = false;

            foreach (Seat seat in _seats)
            {
                if (seat.seatId == seatId)
                {
                    seatIdExists = true;

                    if (!seat.isBeingUsed)
                    {
                        return true;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;

                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine($"O assento {seat.seatId} já foi escolhido!");

                        Console.ResetColor();

                        break;
                    }
                }
            }

            if (!seatIdExists)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;

                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("Assento não encontradol!");

                Console.ResetColor();

                Console.ReadKey();
            }
            Console.ReadKey();

            Console.Clear();

            return false;
        }

        public bool isFull()
        {
            foreach (var seat in _seats)
            {
                if (!seat.isBeingUsed)
                    return false;
            }

            return true;
        }

        public int NumberOfFreeSeats()
        {
            int availableSeats = 0;

            foreach (var seat in _seats)
            {
                if (!seat.isBeingUsed)
                    availableSeats++;
            }

            return availableSeats;
        }
    }
}
