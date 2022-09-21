using System;

namespace Operadores
{
    class Program
    {
        //!Para facilitar os testes, comentei o ccódigo das outras questões, para testar, acho melhor executar um de cada vez
        static void Main(string[] args)
        {
            //1)

            Console.WriteLine("Digite o primeiro número decimal");
            decimal num1 = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Digite o segundo número decimal");
            decimal num2 = Convert.ToDecimal(Console.ReadLine());

            decimal sum = num1 + num2,
                    sub = num1 - num2,
                    mult = num1 * num2,
                    div = num1 / num2;

            Console.WriteLine($"{num1} + {num2} = {sum}");
            Console.WriteLine($"{num1} - {num2} = {sub}");
            Console.WriteLine($"{num1} / {num2} = {div}");
            Console.WriteLine($"{num1} * {num2} = {mult}");

            // 2)============================================

            // Console.WriteLine("Digite o valor dos lados do triângulo");
            // decimal lado = Convert.ToDecimal(Console.ReadLine());
            // Console.WriteLine("Digite o valor da altura do triângulo");
            // decimal altura = Convert.ToDecimal(Console.ReadLine());

            // Console.WriteLine($"A área do triângulo é de {(lado * lado) / 2}");

            // 3)=====================================================

            // Console.WriteLine("Digite o comprimento (cm) do lado 1 do triângulo");
            // int lado1 = Convert.ToInt32(Console.ReadLine());

            // Console.WriteLine("Digite o comprimento (cm) do lado 2 do triângulo");
            // int lado2 = Convert.ToInt32(Console.ReadLine());

            // Console.WriteLine("Digite o comprimento (cm) do lado 3 do triângulo");
            // int lado3 = Convert.ToInt32(Console.ReadLine());

            // bool equilatero = (lado1 == lado2 && lado2 == lado3);
            // bool escaleno = (lado1 != lado2 && lado1 != lado3 && lado2 != lado3);
            // bool isoceles = (
            //     (lado1 == lado2 && lado2 != lado3)
            //     || (lado1 == lado3 && lado1 != lado2)
            //     || (lado2 == lado3 && lado1 != lado3)
            // );

            // Console.WriteLine($"Equilatero: {equilatero}");
            // Console.WriteLine($"Escaleno: {escaleno}");
            // Console.WriteLine($"Isóceles: {isoceles}");

            // 4)=======================================================================

            // Console.WriteLine("Digite sua idade");
            // int idade = Convert.ToInt32(Console.ReadLine());
            // bool maioridade = (idade >= 18);

            // Console.WriteLine($"Maior de Idade: {maioridade}");

            // 5)==========================================================================

            // Console.WriteLine("Digite um número");
            // int num = Convert.ToInt32(Console.ReadLine()),
            //     dobro = num * 2;
            // dobro++;

            // Console.WriteLine($"O dobro de {num} + 1 é igual à {dobro}");

            // 6)============================================================================

            // Console.WriteLine("Digite o primeiro número");
            // int num_1 = Convert.ToInt32(Console.ReadLine()),
            //     sum2 = num_1,
            //     sub2 = num_1,
            //     mult2 = num_1,
            //     div2 = num_1;

            // Console.WriteLine($"{num_1} + 2 = {sum2 += 2}");
            // Console.WriteLine($"{num_1} - 2 = {sub2 -= 2}");
            // Console.WriteLine($"{num_1} * 2 = {mult2 *= 2}");
            // Console.WriteLine($"{num_1} / 2 = {div2 /= 2}");
        }
    }
}
