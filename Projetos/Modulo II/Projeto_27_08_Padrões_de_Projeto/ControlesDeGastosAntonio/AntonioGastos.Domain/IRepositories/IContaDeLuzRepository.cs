using System;

namespace AntonioGastos.Domain.IRepositories
{
    public interface IContaDeLuzRepository
    {
        public void Inserir(ContaDeLuz contaDeLuz);

        public ContaDeLuz BuscarContaPorData(DateTime dataBuscada);

        public bool VerificarSeDataEValida(DateTime dataLeitura);
    }
}
