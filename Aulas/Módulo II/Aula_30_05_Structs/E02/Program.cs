using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Patient patient = new Patient();

                Console.WriteLine("Digite o nome do paciente:");
                patient.name = Console.ReadLine();

                Console.WriteLine("Digite a idade do paciente:");
                bool isAge = int.TryParse(Console.ReadLine(), out int age);
                if (!isAge)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Valor de idade inválido!");
                    Console.ResetColor();
                    continue;
                }
                else
                    patient.age = age;

                Console.WriteLine("Digite o peso do paciente:");
                bool isWeight = double.TryParse(Console.ReadLine(), out double weight);
                if (!isWeight)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Valor de peso inválido!");
                    Console.ResetColor();
                    continue;
                }
                else
                    patient.IMC.weight = weight;

                Console.WriteLine("Digite a altura (m) do paciente:");
                bool isHeight = double.TryParse(Console.ReadLine(), out double height);
                if (!isHeight)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Valor de altura inválido!");
                    Console.ResetColor();
                    continue;
                }
                else
                    patient.IMC.height = height;

                double IMCValue = Patient.ImcCalculator(weight, height);

                Console.WriteLine(
                    $"Paciente {patient.name} - IMC: {IMCValue} - {Patient.ImcDiagnosis(IMCValue)}"
                );

                Console.ReadKey();
                Console.Clear();

                do
                {
                    Console.WriteLine("Existem mais pacientes para cadastro? [y / n]");
                    string userChoice = Console.ReadLine();

                    if (userChoice.ToLower() == "y")
                        break;
                    else if (userChoice.ToLower() == "n")
                        return;
                    else
                        Console.WriteLine("Valor Inválido!");

                    Console.ReadKey();
                } while (true);
            } while (true);
        }
    }
}
