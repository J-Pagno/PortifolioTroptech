using PlanilhaPatricia.Domain.Entidades;
using PlanilhaPatricia.Domain.IRepositorios;
using PlanilhaPatricia.Infra.Data.DAO;
using System.Collections.Generic;

namespace PlanilhaPatricia.Infra.Data.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private static ReservaDAO s_reservaDAO;

        public ReservaRepositorio()
        {
            s_reservaDAO = new();
        }

        public bool ReservarHorario(Reserva reserva)
        {
            bool reservada = false;

            if (s_reservaDAO.ValidarReserva(reserva) is null)
                reservada = s_reservaDAO.ReservarHorario(reserva);

            return reservada;
        }

        public List<Reserva> ValidarReserva(Reserva reserva)
        {
            List<Reserva> listaDeReservas = s_reservaDAO.ValidarReserva(reserva);

            return listaDeReservas;
        }
    }
}
