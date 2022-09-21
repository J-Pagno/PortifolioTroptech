namespace E02
{
    public class HellVoucher : Voucher
    {
        public enum HellProducts
        {
            Gasolina_Aditivada,
            Gasolina_Comum,
            Etanol
        }

        public HellVoucher() : base("Hell", 500) { }

        public void BuyItem(HellProducts buyItem, double value)
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
