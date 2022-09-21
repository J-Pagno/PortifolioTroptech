using PlanilhaPatricia.Domain.Entidades;

namespace PlanilhaPatricia.Domain.IRepositorios
{
    public interface IFuncionarioRepositorio
    {
        public int CadastrarFuncionario(Funcionario funcionario);
    }
}
