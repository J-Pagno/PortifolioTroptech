using System.Collections.Generic;
using System;

namespace Questao_5_Bonus
{
    public class Animal
    {
        public string Name;
        public string Type;
        
        public static LinkedList<string> ValidAnimalTypes = new LinkedList<string>();
        public static int DogQuatity = 0;
        public static int CatQuatity = 0;
        public static int FishQuatity = 0;

        public Animal(string name, string type)
        {
            Name = name;
            Type = type;

            if (type.ToLower() == "cachorro")
                DogQuatity++;
            else if (type.ToLower() == "gato")
                CatQuatity++;
            else
                FishQuatity++;
        }
    }
}
