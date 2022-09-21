using System;

namespace AgenciaBancaria.Domain.Entidades
{
    public class Conta
    {
        public int Numero { get; set; }

        public int Digito { get; set; }

        public string Agencia { get; set; }

        public int TipoConta { get; set; }

        public decimal Saldo { get; set; }

        public decimal Limite { get; set; }

        public DateTime DataAbertura { get; set; }

        public TipoDeCesta Cesta { get; set; }

        public long CpfCliente { get; set; }

        public enum TipoDeCesta
        {
            Ouro,
            Prata,
            Platina,
        }
    }
}
