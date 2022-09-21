using Microsoft.AspNetCore.Mvc;
using static Netflix_API.Filme;
using static Netflix_API.DataBase;
using System.Collections.Generic;


namespace Netflix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            if (listaDeFilmes is null)
                return NotFound();

            return Ok(listaDeFilmes);
        }

        [HttpPost]
        public ActionResult<Filme> Post([FromBody] Filme filme)
        {
            int lastIndex = (listaDeFilmes.FindLastIndex(f => f.Id != 0)) + 1;

            try
            {
                filme.Id = lastIndex + 1;

                listaDeFilmes.Add(filme);

                return Created("https://localhost:5001/api/Filme", listaDeFilmes[lastIndex]);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var busca = listaDeFilmes.Find(f => f.Id == id);

            if (busca is null)
                return NotFound();

            return Ok(busca);
        }

        [HttpPut]
        public IActionResult Get(Filme filme)
        {
            var busca = listaDeFilmes.Find(f => f.Id == filme.Id);

            if (busca.Ativo)
                return BadRequest("Não é possível atualizar um filme ativo");

            busca.Titulo = filme.Titulo;
            busca.Sinopse = filme.Sinopse;
            busca.AnoDeLancamento = filme.AnoDeLancamento;
            busca.Genero = filme.Genero;
            busca.Ativo = filme.Ativo;

            return Ok(busca);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var busca = listaDeFilmes.Find(f => f.Id == id);

            if (busca is null)
                return NotFound("Objeto não encontrado");

            listaDeFilmes.Remove(busca);

            return StatusCode(204, busca);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            var busca = listaDeFilmes.Find(f => f.Id == id);

            if (busca is null)
                return NotFound("Objeto não encontrado");

            busca.Ativo = false;

            return StatusCode(204, busca);
        }
    }
}
