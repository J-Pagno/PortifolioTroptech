using AgenciaBancaria.Domain.Entidades;
using System.Collections.Generic;

namespace AgenciaBancaria.Domain.IRepositorios
{
    public interface IContaRepositorio
    {
        public void CadastrarUmaNovaConta(Conta conta);

        public List<Conta> MostrarTodasAsContas();

        public List<Conta> BuscarContaPorCliente(long cpf);

        public bool ValidarCpf(long cpf);

        public bool ValidarNumeroDaConta(int numero);
    }
}
