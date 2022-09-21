using System;

namespace PlanilhaPatricia.Domain.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public int IdSala { get; set; }
        public string NomeSala { get; set; }
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }

        public Reserva()
        {

        }

        public Reserva(DateTime horarioInicio, DateTime horarioFim, int idSala, string nomeFuncionario)
        {
            this.HorarioInicio = horarioInicio;
            this.HorarioFim = horarioFim;
            this.IdSala = idSala;
            this.NomeFuncionario = nomeFuncionario;
        }
    }
}
