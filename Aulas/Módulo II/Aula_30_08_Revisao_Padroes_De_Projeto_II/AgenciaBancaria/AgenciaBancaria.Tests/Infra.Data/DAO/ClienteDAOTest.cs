using NUnit.Framework;
using AgenciaBancaria.Infra.Data.DAO;
using AgenciaBancaria.Domain.Entidades;
using System.Collections.Generic;

namespace AgenciaBancaria.Tests.Infra.Data.DAO
{
    internal class ClienteDAOTest
    {
        private ClienteDAO _clienteDAO;

        [Test]
        public void Teste1()
        {
            _clienteDAO = new ClienteDAO();
            long cpf = 12312312345;

            Cliente cliente = _clienteDAO.BuscarClientePorCPF(cpf);

            Assert.IsNotNull(cliente);
        }
    }
}
