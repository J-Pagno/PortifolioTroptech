namespace E02
{
    public class AmazonasVoucher : Voucher
    {
        public enum AmazonasProducts
        {
            Livro,
            Chaveiro,
            Caneta
        }

        public AmazonasVoucher() : base("Amazonas", 100) { }

        public void BuyItem(AmazonasProducts buyItem, double value)
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
