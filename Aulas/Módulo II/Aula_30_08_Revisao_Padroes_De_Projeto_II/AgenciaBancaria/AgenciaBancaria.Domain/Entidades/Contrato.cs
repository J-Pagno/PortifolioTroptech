using System;

namespace AgenciaBancaria.Domain.Entidades
{
    public class Contrato
    {
        public enum Contratos
        {
            Habitacional,
            Consignato,
            CDC,
        };

        public int Numero { get; set; }
        public Contratos TipoContrato { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorParcela { get { return ValorTotal / QuantidadeParcelas; } }
        public long CpfCliente { get; set; }

        public Contrato()
        {

        }

        public Contrato(int numero, int tipoContrato, int quantidadeParcelas, DateTime dataInicial, decimal valorTotal, long cpfCliente)
        {
            this.Numero = numero;
            this.TipoContrato = (Contratos)(tipoContrato - 1);
            this.QuantidadeParcelas = quantidadeParcelas;
            this.DataInicial = dataInicial;
            this.DataFinal = dataInicial.AddMonths(quantidadeParcelas);
            this.ValorTotal = valorTotal;
            this.CpfCliente = cpfCliente;
        }
    }
}
