using System;

namespace Estruturas_de_Decisão
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)===================================

            Console.WriteLine("Digite o código do produto");
            var codigoProduto = Convert.ToInt16(Console.ReadLine());

            if(codigoProduto == 1){
                Console.WriteLine("Alimento Não-Perecível");
            }else if(codigoProduto == 2 || codigoProduto == 3 || codigoProduto == 4){
                Console.WriteLine("Alimento Perecível");
            }else if(codigoProduto == 5 || codigoProduto == 6){
                Console.WriteLine("Vestuário");
            }else if(codigoProduto == 7){
                Console.WriteLine("Higiene Pessoal");
            }else if(codigoProduto == 8 || codigoProduto == 9 || codigoProduto == 10){
                Console.WriteLine("Utensílio Doméstico");
            }else{
                Console.WriteLine("Código Inválido!");
            }

            //2)===================================
            // Console.WriteLine("Digite o código do produto");
            // var codigoProduto = Console.ReadLine();

            // switch (codigoProduto)
            // {
            //     case "1":
            //         Console.WriteLine("Alimento Não-Perecível");
            //         break;
            //     case "2":
            //     case "3":
            //     case "4":
            //         Console.WriteLine("Alimento Perecível");
            //         break;
            //     case "5":
            //     case "6":
            //         Console.WriteLine("Vestuário");
            //         break;
            //     case "7":
            //         Console.WriteLine("Higiene Pessoal");
            //         break;
            //     case "8":
            //     case "9":
            //     case "10":
            //         Console.WriteLine("Utensílio Doméstico");
            //         break;

            //     default:
            //         Console.WriteLine("Código Inválido!");
            //         break;
            // }

            //3)===================================
            // Console.WriteLine("Digite o preço do produto");
            // var precoProduto = Convert.ToDouble(Console.ReadLine());

            // Console.WriteLine("Digite a forma de pagamento");
            // Console.WriteLine("\nFormas de pagamento disponíveis:");
            // Console.WriteLine("1 - À vista com Dinheiro ou Cheque");
            // Console.WriteLine("2 - À vista com cartão de crédito");
            // Console.WriteLine("3 - Em 2 vezes");
            // Console.WriteLine("4 - Em 3 vezes");

            // var pagamento = Console.ReadLine();
            // double valorFinal;

            // switch (pagamento)
            // {
            //     case "1":
            //         valorFinal = precoProduto - (precoProduto * 0.1);
            //         Console.WriteLine(
            //             $"Valor final do produto passou de {precoProduto} para {valorFinal}"
            //         );
            //         break;
            //     case "2":
            //         valorFinal = precoProduto - (precoProduto * 0.05);
            //         Console.WriteLine(
            //             $"Valor final do produto passou de {precoProduto} para {valorFinal}"
            //         );
            //         break;
            //     case "3":
            //         valorFinal = precoProduto;
            //         Console.WriteLine(
            //             $"Valor final do produto passou de {precoProduto} para {valorFinal}"
            //         );
            //         break;
            //     case "4":
            //         valorFinal = precoProduto + (precoProduto * 0.1);
            //         Console.WriteLine($"Valor final do produto passou de {precoProduto} para {valorFinal}");
            //         break;
            //     default:
            //         Console.WriteLine("Método de pagamento inválido!");
            //         break;
            // }

            //4)===================================

            // Console.WriteLine("Qual seu nome?");
            // string nome = Console.ReadLine();

            // Console.WriteLine($"{nome}, quantos anos tem?");
            // int idade = Convert.ToInt16(Console.ReadLine());

            // Console.WriteLine($"{nome}, quantos anos de serviço o senhor tem?");
            // int tempoServico = Convert.ToInt16(Console.ReadLine());

            // if(idade >= 65 || tempoServico >= 30 || (idade >= 60 && tempoServico >= 25))
            // {
            //     Console.WriteLine($"Aptidão para aposntadoria: Apto");
            // }
            // else
            // {
            //     Console.WriteLine($"Aptidão para aposntadoria: Inapto");
            // }
        }
    }
}
