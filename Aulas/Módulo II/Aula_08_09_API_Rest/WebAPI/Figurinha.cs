namespace WebAPI
{
    public class Figurinha
    {
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public TipoDeFigurinha Tipo { get; set; }
        public string Resumo { get { return $"{Numero} - {Tipo} - {Descricao}"; } }

        public enum TipoDeFigurinha 
        { 
            Jogador,
            Treinador,
        }

    }
}
