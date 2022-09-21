using AgenciaBancaria.Domain.Entidades;
using AgenciaBancaria.Domain.IRepositorios;
using AgenciaBancaria.Infra.Data.DAO;
using System.Collections.Generic;

namespace AgenciaBancaria.Infra.Data.Repositorios
{
    public class ContaRepositorio : IContaRepositorio
    {
        private ContaDAO s_contaDAO;

        public ContaRepositorio()
        {
            s_contaDAO = new ContaDAO();
        }

        public void CadastrarUmaNovaConta(Conta conta)
        {
            s_contaDAO.CadastrarUmaNovaConta(conta);
        }

        public List<Conta> MostrarTodasAsContas()
        {
            List<Conta> listaDeContas = s_contaDAO.MostrarTodasAsContas();

            return listaDeContas;
        }

        public List<Conta> BuscarContaPorCliente(long cpf)
        {
            List<Conta> listaDeContas = s_contaDAO.BuscarContaPorCliente(cpf);

            return listaDeContas;
        }

        public bool ValidarCpf(long cpf)
        {
            ClienteDAO clienteDAO = new();

            if (clienteDAO.BuscarClientePorCPF(cpf) == null)
                return false;

            return true;
        }

        public bool ValidarNumeroDaConta(int numero)
        {
            ContaDAO contaDAO = new();

            if (contaDAO.BuscarContaPorNumero(numero) == null)
                return false;

            return true;
        }
    }
}
