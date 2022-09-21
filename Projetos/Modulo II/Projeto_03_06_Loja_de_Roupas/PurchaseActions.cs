using System;

namespace Projeto_03_06_Loja_de_Roupas
{
    public class PurchaseActions
    {
        public static bool AddPurcharse()
        {
            var clientObj = ClientActions.GetExactlyClientByName();

            if (clientObj == null)
            {
                Program.WarningAlert("Nome não encontrado!");

                Console.ReadKey();

                return false;
            }

            Purchase purchase = new Purchase(clientObj);

            Console.WriteLine("Digite a descrição da venda: ");

            purchase.Description = Console.ReadLine();

            Console.WriteLine("Digite o valor total da venda: ");

            purchase.TotalValue = decimal.Parse(Console.ReadLine());

            Program.PurchaseList.Add(purchase);

            return true;
        }

        public static bool ShowAllPurchase()
        {
            Console.Clear();

            foreach (var purchase in Program.PurchaseList)
            {
                Console.WriteLine(
                    $"\n{purchase.Client}\nValor Total da Compra: {purchase.TotalValue}"
                );
            }

            Console.ReadKey();

            return true;
        }
    }
}
