using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Netflix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AvaliacaoController : ControllerBase
    {
        [HttpPost("Filme/{id}/Avaliacao")]
        public IActionResult Post(int id, [FromBody] Avaliacao avaliacao)
        {
            Filme busca = DataBase.listaDeFilmes.Find(f => f.Id == id);

            if (busca is null)
                return BadRequest(new Resposta("NF001", "Filme não encontrado"));

            busca.Avaliacoes.Add(avaliacao);

            return Ok(avaliacao);
        }

        [HttpGet("Filme/{idFilme}/Avaliacao/{id}")]
        public IActionResult Get(int idFilme, int id)
        {
            var busca = DataBase.listaDeFilmes.Find(f => f.Id == idFilme);

            if (busca is null)
                return BadRequest(new Resposta("NF001", "Filme não encontrado"));

            var avaliacaoBuscada = busca.Avaliacoes.Find(a => a.Id == id);

            if (avaliacaoBuscada is null)
                return BadRequest(new Resposta("NA001", "Avaliaçao não encontrada"));

            return Ok(avaliacaoBuscada);
        }

        [HttpDelete("Filme/{idFilme}/Avaliacao/{id}")]
        public IActionResult Delete(int idFilme, int id)
        {
            var busca = DataBase.listaDeFilmes.Find(f => f.Id == idFilme);

            if (busca is null)
                return BadRequest(new Resposta("NF001", "Filme não encontrado"));

            var avaliacaoBuscada = busca.Avaliacoes.Find(a => a.Id == id);

            if (avaliacaoBuscada is null)
                return BadRequest(new Resposta("NA001", "Avaliaçao não encontrada"));

            busca.Avaliacoes.Remove(avaliacaoBuscada);

            return NoContent();
        }
    }
}
