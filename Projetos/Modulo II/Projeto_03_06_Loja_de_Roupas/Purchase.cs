namespace Projeto_03_06_Loja_de_Roupas
{
    public class Purchase
    {
        private decimal _totalValue;

        private string _description;

        private string _client;

        public decimal TotalValue
        {
            get => _totalValue;
            set => _totalValue = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Client
        {
            get => _client;
            set => _client = value;
        }

        public Purchase(LegalPerson client)
        {
            _client = $"\nCategoria: PJ\nNome: {client.Name}\nCNPJ: {client.Cnpj}";
        }

        public Purchase(NaturalPerson client)
        {
            _client = $"\nCategoria: PF\nNome: {client.Name}\nCPF: {client.Cpf}";
        }
    }
}
