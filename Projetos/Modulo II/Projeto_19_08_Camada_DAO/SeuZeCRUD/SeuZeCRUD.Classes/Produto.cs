namespace SeuZeCRUD.Classes
{
    public class Produto
    {
        private int _id;

        private string _nome;

        private string _descricao;

        private int _quantidade;

        private decimal _preco;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string Descricao
        {
            get => _descricao;
            set => _descricao = value;
        }

        public int Quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }
        public decimal Preco
        {
            get => _preco;
            set => _preco = value;
        }
    }
}
