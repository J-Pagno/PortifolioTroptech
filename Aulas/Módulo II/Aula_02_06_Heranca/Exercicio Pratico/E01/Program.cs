using System;

namespace Aula_02_06_Heranca
{
    public enum AnimalCategorys
    {
        Cachorro,
        Gato,
        Peixe,
        Coelho
    }

    class Program
    {
        public static void Main(string[] args)
        {
            AnimalRegister animal = new AnimalRegister("Jorge", "Trovão", AnimalCategorys.Cachorro);
            AnimalRegister animal1 = new AnimalRegister("Rajada", "Juninho", AnimalCategorys.Gato);
            AnimalRegister animal2 = new AnimalRegister(
                "Senhor Pompom",
                "Trovão",
                AnimalCategorys.Coelho
            );
            AnimalRegister animal3 = new AnimalRegister("Jorge", "Trovão", AnimalCategorys.Peixe);

            Console.WriteLine($"[{animal.GetCategory}] ─ Nome: {animal.GetName} ─ Dono(a): {animal.GetOwner}");
            Console.WriteLine($"[{animal1.GetCategory}] ─ Nome: {animal1.GetName} ─ Dono(a): {animal1.GetOwner}");
            Console.WriteLine($"[{animal2.GetCategory}] ─ Nome: {animal2.GetName} ─ Dono(a): {animal2.GetOwner}");
            Console.WriteLine($"[{animal3.GetCategory}] ─ Nome: {animal3.GetName} ─ Dono(a): {animal3.GetOwner}");

        }
    }

    public class AnimalRegister : Animal
    {
        public string GetName
        {
            get { return this.name; }
        }

        public string GetOwner
        {
            get { return this.owner; }
        }

        public AnimalCategorys GetCategory
        {
            get { return this.category; }
        }

        public AnimalRegister(string name, string owner, AnimalCategorys category)
            : base(name, owner, category) { }
    }

    public abstract class Animal
    {
        protected string name { get; set; }
        protected string owner { get; set; }
        protected AnimalCategorys category { get; set; }

        protected Animal(string name, string owner, AnimalCategorys category)
        {
            this.name = name;
            this.owner = owner;
            this.category = category;
        }
    }
}
