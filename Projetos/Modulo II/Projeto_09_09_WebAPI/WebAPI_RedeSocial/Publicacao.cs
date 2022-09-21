using System;

namespace WebAPI_RedeSocial
{
    public class Publicacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string NomeUsuario { get; set; }
        public int QuantidadeCurtidas { get; set; }
    }
}
