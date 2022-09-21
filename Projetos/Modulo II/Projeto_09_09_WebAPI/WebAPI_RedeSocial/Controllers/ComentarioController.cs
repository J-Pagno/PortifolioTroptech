using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Comentario> Post([FromBody] Comentario comentario)
        {
            comentario.Id = (DataBase.listaDeComentarios.FindLastIndex(c => c.Id != 0)) + 2;

            DataBase.listaDeComentarios.Add(comentario);

            return comentario;
        }

        [HttpGet("{id}")]
        public ActionResult<Comentario> Get(int id)
        {
            var comentarioPublicacao = DataBase.listaDeComentarios.Find(c => c.Id == id);

            return comentarioPublicacao;
        }

        [HttpGet]
        [Route("Publicacao/{idPublicacao}")]
        public ActionResult<List<Comentario>> GetComentarioPorPublicacao(int idPublicacao)
        {
            var comentarioPublicacao = DataBase.listaDeComentarios.FindAll(c => c.IdPublicacao == idPublicacao);

            return comentarioPublicacao;
        }

        [HttpPut("{id}")]
        public ActionResult<int> Put(int id)
        {
            var comentarioCurtido = DataBase.listaDeComentarios.Find(c => c.Id == id);

            comentarioCurtido.QuantidadeCurtidas += 1;

            return comentarioCurtido.QuantidadeCurtidas;
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            var comentarioDeletado = DataBase.listaDeComentarios.Find(c => c.Id == id);

            DataBase.listaDeComentarios.Remove(comentarioDeletado);

            return new StatusCodeResult(204);
        }
    }
}
