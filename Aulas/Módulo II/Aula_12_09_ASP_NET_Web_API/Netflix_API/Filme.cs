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

    }
}
