using AgenciaBancaria.Domain.Entidades;
using System.Collections.Generic;

namespace AgenciaBancaria.Domain.IRepositorios
{
    public interface IContratoRepositorio
    {
        public bool InserirContrato(Contrato contrato);

        public List<Contrato> ListarContratosPorCliente(long cpf);

        public string ObterNomeDoCliente(long cpf);
    }
}
