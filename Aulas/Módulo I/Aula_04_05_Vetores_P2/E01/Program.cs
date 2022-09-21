using System;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite a sua senha: ");
            string senha = Console.ReadLine();

            int totalMinusculas = 0,
                totalMaiusculas = 0,
                totalNumero = 0,
                totalCaractereEspecial = 0;

            for (int i = 0; i < senha.Length; i++)
            {
                if ((int)senha[i] > 96 && (int)senha[i] < 123)
                    totalMinusculas++;
                else if ((int)senha[i] > 64 && (int)senha[i] < 91)
                    totalMaiusculas++;
                else if ((int)senha[i] > 47 && (int)senha[i] < 58)
                    totalNumero++;
                else
                    totalCaractereEspecial++;
            }

            Console.WriteLine($"Total de letras minúculas: {totalMinusculas}");
            Console.WriteLine($"Total de letras minúculas: {totalMinusculas}");
            Console.WriteLine($"Total de números: {totalNumero}");
            Console.WriteLine($"Total de caracteres especiais: {totalCaractereEspecial}");
        }
    }
}
