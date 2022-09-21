using System;
using System.Collections;

namespace Complementar
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack drivers = new Stack(),
                chosenPassengers = new Stack(),
                driversWhoAcceptedTrips = new Stack();

            Queue passengers = new Queue();

            drivers.Push("Jorge");
            drivers.Push("Thomas S");
            drivers.Push("John");
            drivers.Push("Mariano");
            drivers.Push("Cristopher");

            passengers.Enqueue("Jorge");
            passengers.Enqueue("Thomas S");
            passengers.Enqueue("Cristopher");
            passengers.Enqueue("John");
            passengers.Enqueue("Mariano");

            foreach (var driver in drivers)
            {
                bool passengerAccepted = false;
                char lastLetterOfDriverName = Convert.ToString(driver)[0];
                int driverNumber = Convert.ToInt32(lastLetterOfDriverName);
            
                while (!passengerAccepted)
                {
                    int lenghtOfPassengerName = Convert.ToString(passengers.Peek()).Length - 1;
                    char lastLetterOfPassengerName = Convert.ToString(passengers.Peek())[
                        lenghtOfPassengerName
                    ];
                    int passengerNumber = Convert.ToInt32(lastLetterOfPassengerName);

                    Console.Clear();
                    Console.WriteLine($"Motorista {driver}\n");
                    Console.WriteLine($"Passageiro: {passengers.Peek()}");
                    Console.WriteLine(
                        $"Distância: {((passengerNumber / 2) + (driverNumber / 2))}Km"
                    );

                    Console.WriteLine(
                        "Digite [Y] para aceitar ou [N] para ver o próximo passageiro"
                    );
                    string acceptPassenger = Console.ReadLine();
                    if (acceptPassenger == "Y" || acceptPassenger == "y")
                    {
                        driversWhoAcceptedTrips.Push(driver);
                        chosenPassengers.Push(passengers.Peek());

                        passengers.Dequeue();
                        passengerAccepted = true;
                    }
                    else
                    {
                        var goToEndQueue = passengers.Peek();
                        passengers.Dequeue();
                        passengers.Enqueue(goToEndQueue);
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("Relação de motoristas e passageiros escolhidos:\n");

            foreach (string driver in driversWhoAcceptedTrips)
            {
                Console.WriteLine($"Motorista: {driver}\nPassageiro: {chosenPassengers.Peek()}\n");
                chosenPassengers.Pop();
            }
        }
    }
}
