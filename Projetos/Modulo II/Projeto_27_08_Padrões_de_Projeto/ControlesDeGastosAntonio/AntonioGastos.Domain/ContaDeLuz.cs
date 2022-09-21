using System;

namespace AntonioGastos.Domain
{
    public class ContaDeLuz
    {
        public string NumeroDaLeitura { get; set; }

        public DateTime DataDeLeitura { get; set; }

        public int KWGastos { get; set; }

        public decimal Valor { get; set; }

        public int MediaDeConsumo { get; set; }

        public DateTime DataDePagamento { get; set; }

        public ContaDeLuz()
        {

        }

        public ContaDeLuz(string numeroDaLeitura)
        {
            NumeroDaLeitura = numeroDaLeitura.ToUpper();
        }

        private string GerarValorAleatorio()
        {
            string listaDeCaracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            char[] caracteresSelecionados = new char[6];

            Random random = new Random();

            for (int i = 0; i < caracteresSelecionados.Length; i++)
            {
                caracteresSelecionados[i] = listaDeCaracteres[random.Next(listaDeCaracteres.Length)];
            }

            var resultString = new String(caracteresSelecionados);

            return resultString;
        }
    }
}
