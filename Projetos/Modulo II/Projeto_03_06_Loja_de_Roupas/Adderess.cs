namespace Projeto_03_06_Loja_de_Roupas
{
    public struct Adderess
    {
        private string _street;

        private int _number;

        private string _city;

        private string _state;

        private string _country;

        public string Street
        {
            get => _street;
            set => _street = value;
        }
        public int Number
        {
            get => _number;
            set => _number = value;
        }
        public string City
        {
            get => _city;
            set => _city = value;
        }

        public string State
        {
            get => _state;
            set => _state = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public string CompleteAdderess
        {
            get => $"Rua {_street}, {_number}, {_city}/{_state} - {_country}";
        }
    }
}
