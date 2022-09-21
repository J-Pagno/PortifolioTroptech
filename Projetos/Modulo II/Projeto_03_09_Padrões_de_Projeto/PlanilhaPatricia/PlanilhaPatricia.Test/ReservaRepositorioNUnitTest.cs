using NUnit.Framework;
using PlanilhaPatricia.Domain.Entidades;
using PlanilhaPatricia.Infra.Data.Repositorios;
using System;

namespace PlanilhaPatricia.Test
{
    public class ReservaRepositorioNUnitTest
    {
        [Test]
        public void QuandoReservaForFeitaCorretamente_EntaoRetornarVerdadeiro()
        {
            ReservaRepositorio reservaRepositorio = new();
            DateTime dataInicio = new DateTime(2022, 03, 18, 18, 25, 00);
            DateTime dataFim = new DateTime(2022, 03, 18, 19, 00, 00);
            Reserva reserva = new Reserva(dataInicio, dataFim, 1, "Jorge");

            bool reservada = reservaRepositorio.ReservarHorario(reserva);

            Assert.IsTrue(reservada);
        }
    }
}