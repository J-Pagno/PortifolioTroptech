using System;
using AntonioGastos.Domain;
using AntonioGastos.Domain.IRepositories;
using AntonioGastos.Infra.Data.DAO;

namespace AntonioGastos.Infra.Data.Repositories
{

    public class ContaDeLuzRepository : IContaDeLuzRepository
    {
        private ContaDeLuzDAO _contaDeLuzDAO;

        public ContaDeLuzRepository()
        {
            this._contaDeLuzDAO = new ContaDeLuzDAO();
        }

        public void Inserir(ContaDeLuz contaDeLuz)
        {
            _contaDeLuzDAO.Inserir(contaDeLuz);
        }

        public ContaDeLuz BuscarContaPorData(DateTime dataBuscada) 
        {
            ContaDeLuz contaDeLuz = _contaDeLuzDAO.BuscarContaPorData(dataBuscada);

            return contaDeLuz;
        }

        public bool VerificarSeDataEValida(DateTime dataLeitura)
        {
            bool dataEValida = _contaDeLuzDAO.VerificarSeDataEValida(dataLeitura);

            return dataEValida;
        }
    }
}
