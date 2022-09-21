using System;
using SeuZeCRUD.Classes.Struct;

namespace SeuZeCRUD.Classes
{
    public class Cliente
    {
        private string _nome;

        private string _cpf;

        private DateTime _dataNascimento;

        private decimal _pontosDeFidelidade = 0m;

        private Endereco _endereco;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }
        public string Cpf
        {
            get => _cpf;
            set => _cpf = value;
        }
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set => _dataNascimento = value;
        }
        public decimal PontosDeFidelidade
        {
            get => _pontosDeFidelidade;
            set => _pontosDeFidelidade = value;
        }
        public Endereco Endereco
        {
            get => _endereco;
            set => _endereco = value;
        }
    }
}
