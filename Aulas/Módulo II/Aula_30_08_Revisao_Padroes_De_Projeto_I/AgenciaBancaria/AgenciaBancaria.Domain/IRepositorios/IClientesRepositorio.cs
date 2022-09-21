using AgenciaBancaria.Domain.Entidades;
using System.Collections.Generic;

namespace AgenciaBancaria.Domain.IRepositorios
{
    public interface IClientesRepositorio
    {
        public List<Cliente> ListarTodosOsClientes();

        public Cliente BuscarClientePorCPF(long cpf);
    }
}
