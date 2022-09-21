using PlanilhaPatricia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanilhaPatricia.Domain.IRepositorios
{
    public interface IReservaRepositorio
    {
        public bool ReservarHorario(Reserva reserva);
        public List<Reserva> ValidarReserva(Reserva reserva);
    }
}
