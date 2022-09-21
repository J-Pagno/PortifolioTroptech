using System.Collections.Generic;

namespace Projeto_03_06_Loja_de_Roupas
{
    public class Client
    {
        private string _name;

        private int _phone;

        private Adderess _adderess;

        private List<Purchase> _purchases;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Phone
        {
            get => _phone;
            set => _phone = value;
        }
        public Adderess Adderess
        {
            get => _adderess;
            set => _adderess = value;
        }
        public List<Purchase> Purchases
        {
            get => _purchases;
            set => _purchases = value;
        }
    }
}
