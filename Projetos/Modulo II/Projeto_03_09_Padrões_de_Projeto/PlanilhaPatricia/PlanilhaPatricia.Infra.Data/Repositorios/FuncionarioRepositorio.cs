using PlanilhaPatricia.Domain.Entidades;
using PlanilhaPatricia.Domain.IRepositorios;
using PlanilhaPatricia.Infra.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanilhaPatricia.Infra.Data.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private static FuncionarioDAO s_funcionarioDAO;

        public FuncionarioRepositorio()
        {
            s_funcionarioDAO = new FuncionarioDAO();
        }

        public int CadastrarFuncionario(Funcionario funcionario)
        {
            int idFuncionarioCadastrado = s_funcionarioDAO.CadastrarFuncionario(funcionario);

            return idFuncionarioCadastrado;
        }
    }
}
