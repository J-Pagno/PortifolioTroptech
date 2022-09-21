using System;

namespace WebAPI_RedeSocial
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeUsuario { get; set; }
        public int QuantidadeCurtidas { get; set; }
        public int IdPublicacao { get; set; }

        public override string ToString()
        {
            return $"{NomeUsuario}\n{DataCriacao}\n{Descricao}\n---------\n";
        }
    }
}
