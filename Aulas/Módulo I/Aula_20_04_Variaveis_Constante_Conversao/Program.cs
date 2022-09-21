using System;

namespace Aula3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1)");

            string valor1 = "2";
            string valor2 = "5";

            int numero1 = Convert.ToInt16(valor1);
            int numero2 = Int16.Parse(valor2);

            Console.WriteLine(valor1 + " + " + valor2 + " = " + numero1 + numero2);

            //==============================================

            Console.WriteLine("\n2)");

            Console.WriteLine("Digite o nome de uma fruta: ");
            string nomeFruta = Console.ReadLine();
            
            Console.WriteLine("Digite a cor da fruta escolhida: ");
            string corFruta = Console.ReadLine();

            Console.WriteLine("Digite uma característica da fruta escolhida: ");
            string caracteristicaFruta = Console.ReadLine();

            Console.WriteLine(nomeFruta + " é uma fruta "+ corFruta + " e " + caracteristicaFruta);
            
            //==============================================

            Console.WriteLine("\n3)");

            int numeroInteiro = 1;
            decimal numeroDecimal = 2.5m;
            string numeroEmString = "7";
            double numeroDouble = 3.7;

            Convert.ToDecimal(numeroInteiro);
            Convert.ToInt16(numeroDecimal);
            Convert.ToInt16(numeroEmString);
            Convert.ToDecimal(numeroEmString);
            Convert.ToDecimal(numeroDouble);

            //==============================================

            Console.WriteLine("\n4)");

            Console.WriteLine("Digite um caractere: ");
            string o = Console.ReadLine();

            Console.WriteLine($"    {o}                     ");
            Console.WriteLine($"   {o}{o}{o}                ");
            Console.WriteLine($"  {o}{o}{o}{o}{o}           ");
            Console.WriteLine($" {o}{o}{o}{o}{o}{o}{o}      ");
            Console.WriteLine($"{o}{o}{o}{o}{o}{o}{o}{o}{o} ");


        }
    }
}
