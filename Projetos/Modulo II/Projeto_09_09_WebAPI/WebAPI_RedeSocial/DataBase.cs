using System;
using System.Collections.Generic;

namespace WebAPI_RedeSocial
{
    public static class DataBase
    {
        public static List<Publicacao> listaDePublicacoes = new List<Publicacao>()
        {
            new Publicacao(){ Id = 1, NomeUsuario = "Jorge", Titulo = "Jorge vai a praia", DataPublicacao = new DateTime(2022, 03, 18), QuantidadeCurtidas = 14 },
            new Publicacao(){ Id = 2, NomeUsuario = "Jorjana", Titulo = "Jorjana comendo spaghetti", DataPublicacao = new DateTime(2022, 03, 18), QuantidadeCurtidas = 1 },
            new Publicacao(){ Id = 3, NomeUsuario = "Josivaldo", Titulo = "Josivaldo comprando leite", DataPublicacao = new DateTime(2022, 03, 18), QuantidadeCurtidas = 27 },
        };

        public static List<Comentario> listaDeComentarios = new List<Comentario>()
        {
            new Comentario(){ Id = 1, NomeUsuario = "Jorjana", DataCriacao = new DateTime(2022, 04, 18), Descricao = "Que praia bonita!", IdPublicacao = 1 },
            new Comentario(){ Id = 2, NomeUsuario = "Jorjana", DataCriacao = new DateTime(2022, 04, 21), Descricao = "O leite ta caro né?!", IdPublicacao = 3 },
            new Comentario(){ Id = 3, NomeUsuario = "Josivaldo", DataCriacao = new DateTime(2022, 04, 20), Descricao = "Que demais!", IdPublicacao = 1 },
            new Comentario(){ Id = 4, NomeUsuario = "Josivaldo", DataCriacao = new DateTime(2022, 04, 21), Descricao = "Deliciaaaaa!", IdPublicacao = 2 },
            new Comentario(){ Id = 5, NomeUsuario = "Jorge", DataCriacao = new DateTime(2022, 04, 22), Descricao = "Saudades da praia!", IdPublicacao = 3 },
            new Comentario(){ Id = 6, NomeUsuario = "Jorge", DataCriacao = new DateTime(2022, 04, 19), Descricao = "Que demais!", IdPublicacao = 2 },
        };
    }
}
