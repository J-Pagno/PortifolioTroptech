using System;

namespace teste1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual seu nome?");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual seu salário?");
            float salario = float.Parse(Console.ReadLine());

            Console.WriteLine("Qual sua função?");
            string funcao_atual = Console.ReadLine();

            Console.WriteLine("Qual sua idade?");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual sua altura? (cm)");
            float altura = float.Parse(Console.ReadLine());



            Console.Write("meu nome é: ");
            Console.WriteLine(nome);

            Console.Write("meu sálario é:");
            Console.WriteLine(salario);

            Console.Write("minha função é:");
            Console.WriteLine(funcao_atual);

            Console.Write("minha idade é:");
            Console.WriteLine(idade);
            
            Console.Write("minha altura é:");
            Console.WriteLine(altura);

            
        }
    }
}
