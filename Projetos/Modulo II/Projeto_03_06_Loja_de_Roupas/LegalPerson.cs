using System;

namespace Projeto_03_06_Loja_de_Roupas
{
    public class LegalPerson : Client
    {
        private string _cnpj;

        public string Cnpj
        {
            get => _cnpj;
            set => _cnpj = value;
        }

        public LegalPerson(Client client, Adderess adderess)
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
                + "CNPJ: "
                + this.Cnpj;
        }
    }
}
