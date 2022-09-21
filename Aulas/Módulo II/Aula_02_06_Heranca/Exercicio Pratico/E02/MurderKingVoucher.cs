namespace E02
{
    public class MurderKingVoucher : Voucher
    {
        public enum MurderKingProducts
        {
            Hamburguer,
            Refrigerante,
            Batata_Frita
        }

        public MurderKingVoucher() : base("MurderKing", 250) { }

        public void BuyItem(MurderKingProducts buyItem, double value)
        {
            this.UpdateValue(value, buyItem.ToString());
        }

        public void PrintBuyHistory()
        {
            foreach (var item in this.UseHistory)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}