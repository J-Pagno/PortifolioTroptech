namespace SeuZeCRUD.Classes.Struct
{
    public struct Endereco
    {
        private string _rua;

        private int _numero;

        private string _bairro;

        private string _cep;

        private string _complemento;

        public string Rua
        {
            get => _rua;
            set => _rua = value;
        }
        public int Numero
        {
            get => _numero;
            set => _numero = value;
        }
        public string Bairro
        {
            get => _bairro;
            set => _bairro = value;
        }
        public string Cep
        {
            get => _cep;
            set => _cep = value;
        }
        public string Complemento
        {
            get => _complemento;
            set => _complemento = value;
        }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro}";
        }
    }
}
