using System.Collections.Generic;

namespace Netflix_API
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int AnoDeLancamento { get; set; }
        public bool Ativo { get; set; }
        public ListaDeGeneros Genero { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
        public decimal MediaDeAvaliacoes
        {
            get
            {
                return GetMediaAvaliacoes();
            }
        }


        public string NomeResumido { get { return $"{Titulo} - {AnoDeLancamento} - {Genero}"; } }

        public enum ListaDeGeneros
        {
            Acao,
            Comedia,
            Documentario,
            Drama,
            Ficcao,
            Terror,
        }

        private decimal GetMediaAvaliacoes()
        {
            decimal mediaAvaliacoes = 0;

            foreach (var avaliacao in Avaliacoes)
            {
                mediaAvaliacoes += avaliacao.Nota;
            }

            mediaAvaliacoes /= Avaliacoes.Count;

            return 0;
        }

    }
}
