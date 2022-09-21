namespace Projeto_03_06_Loja_de_Roupas
{
    public class NaturalPerson : Client
    {
        private string _cpf;

        public string Cpf
        {
            get => _cpf;
            set => _cpf = value;
        }

        public NaturalPerson(Client client, Adderess adderess)
        {
            this.Name = client.Name;
            this.Phone = client.Phone;
            this.Adderess = adderess;
        }

        public override string ToString()
        {
            return "\nNome: "
                + base.Name
                + "\nTelefone: "
                + base.Phone
                + "\nEndereço: "
                + base.Adderess.CompleteAdderess
                + "CPF: "
                + this.Cpf;
        }
    }
}
