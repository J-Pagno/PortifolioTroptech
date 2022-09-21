using System.Collections.Generic;
using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Domain.IRepositorios;
using AgenciaBancaria.Infra.Data.DAO;

namespace AgenciaBancaria.Infra.Data.Repositorios
{
    public class ClienteRepositorio : IClientesRepositorio
    {
        private ClienteDAO _clienteDAO;

        public ClienteRepositorio()
        {
            _clienteDAO = new ClienteDAO();
        }

        public Cliente BuscarClientePorCPF(long cpf)
        {
            Cliente cliente = _clienteDAO.BuscarClientePorCPF(cpf);

            return cliente;
        }

        public List<Cliente> ListarTodosOsClientes()
        {
            List<Cliente> listaDeClientes = _clienteDAO.ListarTodosOsClientes();

            return listaDeClientes;
        }
    }
}
