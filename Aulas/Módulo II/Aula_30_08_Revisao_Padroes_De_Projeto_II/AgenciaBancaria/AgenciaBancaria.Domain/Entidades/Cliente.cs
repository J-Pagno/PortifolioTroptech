using System;

namespace AgenciaBancaria.Domain.Entidades
{
    public class Cliente
    {
        public long Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}
