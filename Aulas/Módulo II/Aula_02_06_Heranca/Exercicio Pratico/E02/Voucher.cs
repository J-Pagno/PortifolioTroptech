using System.Collections;

namespace E02
{
    public abstract class Voucher
    {
        protected string Company { get; set; }

        protected double Value { get; set; }

        protected Stack UseHistory { get; set; }

        protected Voucher(string company, int value)
        {
            this.Company = company;
            this.Value = value;
            UseHistory = new Stack();
        }

        protected void UpdateValue(double productPrice, string buyProduct)
        {
            if (this.Value > 0 && this.Value >= productPrice)
            {
                this.UseHistory.Push(
                    $"[{this.Company}]: ${productPrice} utilizado em {buyProduct} ─ Saldo restante {CurrentValue(this.Value, productPrice)}"
                );

                this.Value -= productPrice;
            }
            else
                System.Console.WriteLine("Saldo indisponível!");
        }

        private double CurrentValue(double currentValue, double novoGasto) =>
            currentValue - novoGasto;

    }
}
