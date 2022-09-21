

using System.Collections.Generic;
using static Netflix_API.Filme;

namespace Netflix_API
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeDeTemporadas { get; set; }
        public int AnoDeLancamento { get; set; }
        public bool Ativo { get; set; }
        public ListaDeGeneros Genero { get; set; }

        public List<Avaliacao> Avaliacoes { get; set; }

        public string NomeResumido { get { return $"{Titulo} - {AnoDeLancamento} - {Genero}"; } }

    }
}
