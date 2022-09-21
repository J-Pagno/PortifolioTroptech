using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Domain.IRepositorios;
using AgenciaBancaria.Infra.Data.DAO;
using System.Collections.Generic;

namespace AgenciaBancaria.Infra.Data.Repositorios
{
    public class ContratoRepositorio : IContratoRepositorio
    {
        private ContratoDAO s_contratoDAO;

        public ContratoRepositorio()
        {
            s_contratoDAO = new ContratoDAO();
        }

        public bool InserirContrato(Contrato contrato)
        {
            bool contratoInserido = s_contratoDAO.InserirContrato(contrato);

            return contratoInserido;
        }

        public List<Contrato> ListarContratosPorCliente(long cpf)
        {
            List<Contrato> listaDeContratos = s_contratoDAO.ListarContratosPorCliente(cpf);

            return listaDeContratos;
        }

        public string ObterNomeDoCliente(long cpf)
        {
            string nomeCliente = s_contratoDAO.ObterNomeDoCliente(cpf);

            return nomeCliente;
        }
    }
}
