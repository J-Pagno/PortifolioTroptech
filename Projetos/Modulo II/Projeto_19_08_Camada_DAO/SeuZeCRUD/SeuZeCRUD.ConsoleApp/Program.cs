using System;
using SeuZeCRUD.ConsoleApp.Messages;

namespace SeuZeCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                
                Console.WriteLine("Mercado do Seu Ze:");

                Console.WriteLine("a. Menu de Clientes");
                Console.WriteLine("b. Menu de Produtos");
                Console.WriteLine("c. Menu de Pedidos");
                Console.WriteLine("d. Sair");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "a":
                        MenuCliente.MenuPrincipal();
                        break;

                    case "b":
                        MenuProduto.MenuPrincipal();
                        break;

                    case "c":
                        MenuPedido.MenuPrincipal();
                        break;

                    case "d":
                        return;

                    default:
                        Messages.Falha("Opção inválida!");
                        break;
                }
            } while (true);
        }
    }
}
