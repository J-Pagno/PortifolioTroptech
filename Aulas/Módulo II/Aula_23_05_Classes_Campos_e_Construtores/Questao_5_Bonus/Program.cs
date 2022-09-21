using System;
using System.Collections;

namespace Questao_5_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            var registeredAnimals = new Animal[5];

            var validAnimalTypes = Animal.ValidAnimalTypes;

            validAnimalTypes.AddLast("cachorro");
            validAnimalTypes.AddLast("gato");
            validAnimalTypes.AddLast("peixe");

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();

                Animal currentAnimal;

                Console.WriteLine("Digite o nome do seu animal:");
                string animalName = Console.ReadLine();

                Console.WriteLine("Digite o tipo do seu animal (Cachorro, Gato ou Peixe):");
                string animalType = Console.ReadLine();

                if (!validAnimalTypes.Contains(animalType.ToLower()))
                    animalType = "Peixe";

                currentAnimal = new Animal(animalName, animalType);

                registeredAnimals[i] = currentAnimal;
            }

            Console.WriteLine(
                $"Resultado: \n—► Cachorros: {Animal.DogQuatity} \n—► Gatos: {Animal.CatQuatity} \n—► PeixesS: {Animal.FishQuatity} "
            );
            
            Console.ReadKey();
        }
    }
}
