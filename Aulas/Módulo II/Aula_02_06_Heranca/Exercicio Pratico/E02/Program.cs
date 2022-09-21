using System;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            var amazonas = new AmazonasVoucher();
            var murderKing = new MurderKingVoucher();
            var hell = new HellVoucher();

            amazonas.BuyItem(AmazonasVoucher.AmazonasProducts.Livro, 20);
            amazonas.BuyItem(AmazonasVoucher.AmazonasProducts.Caneta, 60);
            amazonas.BuyItem(AmazonasVoucher.AmazonasProducts.Chaveiro, 15);

            amazonas.PrintBuyHistory();
            System.Console.WriteLine("\n─────────────────\n");

            murderKing.BuyItem(MurderKingVoucher.MurderKingProducts.Hamburguer, 150);
            murderKing.BuyItem(MurderKingVoucher.MurderKingProducts.Batata_Frita, 50);
            murderKing.BuyItem(MurderKingVoucher.MurderKingProducts.Refrigerante, 100);

            murderKing.PrintBuyHistory();
            System.Console.WriteLine("\n─────────────────\n");

            hell.BuyItem(HellVoucher.HellProducts.Gasolina_Aditivada, 400);
            hell.BuyItem(HellVoucher.HellProducts.Gasolina_Comum, 10);
            hell.BuyItem(HellVoucher.HellProducts.Etanol, 20);

            hell.PrintBuyHistory();
        }
    }
}
