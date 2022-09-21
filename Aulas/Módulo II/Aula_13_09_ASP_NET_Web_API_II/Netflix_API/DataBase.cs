using System.Collections.Generic;
using static Netflix_API.Filme;

namespace Netflix_API
{
    public class DataBase
    {
        public static List<Filme> listaDeFilmes = new()
        {
            new Filme() { Id = 1, Titulo = "Filme de Acao", Sinopse = "Vingadores loucos brigando", AnoDeLancamento = 2021, Ativo = true, Genero = ListaDeGeneros.Acao },
            new Filme() { Id = 2, Titulo = "Filme de Drama", Sinopse = "Vingadores Chorando", AnoDeLancamento = 2018, Ativo = false, Genero = ListaDeGeneros.Drama },
            new Filme() { Id = 3, Titulo = "Filme de Comedia", Sinopse = "Vingadores Rindo", AnoDeLancamento = 2012, Ativo = true, Genero = ListaDeGeneros.Comedia },
            new Filme() { Id = 4, Titulo = "Filme de Ficção", Sinopse = "Vingadores ET's", AnoDeLancamento = 1999, Ativo = false, Genero = ListaDeGeneros.Ficcao },
            new Filme() { Id = 5, Titulo = "Filme de Terror", Sinopse = "Vingadores com medo", AnoDeLancamento = 1998, Ativo = true, Genero = ListaDeGeneros.Terror },
        };

        public static List<Serie> listaDeSeries = new()
        {
            new Serie() { Id = 1, Titulo = "Serie de Acao", QuantidadeDeTemporadas = 2, AnoDeLancamento = 2021, Ativo = true, Genero = ListaDeGeneros.Acao },
            new Serie() { Id = 2, Titulo = "Serie de Drama", QuantidadeDeTemporadas = 10, AnoDeLancamento = 2018, Ativo = false, Genero = ListaDeGeneros.Drama },
            new Serie() { Id = 3, Titulo = "Serie de Comedia", QuantidadeDeTemporadas = 15, AnoDeLancamento = 2012, Ativo = true, Genero = ListaDeGeneros.Comedia },
            new Serie() { Id = 4, Titulo = "Serie de Ficção", QuantidadeDeTemporadas = 4, AnoDeLancamento = 1999, Ativo = false, Genero = ListaDeGeneros.Ficcao },
            new Serie() { Id = 5, Titulo = "Serie de Terror", QuantidadeDeTemporadas = 1, AnoDeLancamento = 1998, Ativo = true, Genero = ListaDeGeneros.Terror },
        };
    }
}
