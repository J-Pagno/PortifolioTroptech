using Microsoft.AspNetCore.Mvc;
using static Netflix_API.DataBase;


namespace Netflix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            if (listaDeSeries is null)
                return NotFound();

            return Ok(listaDeSeries);
        }

        [HttpPost]
        public ActionResult<Serie> Post([FromBody] Serie serie)
        {
            int lastIndex = (listaDeSeries.FindLastIndex(f => f.Id != 0)) + 1;

            try
            {
                serie.Id = lastIndex + 1;

                listaDeSeries.Add(serie);

                return Created("https://localhost:5001/api/Filme", listaDeSeries[lastIndex]);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var busca = listaDeSeries.Find(f => f.Id == id);

            if (busca is null)
                return NotFound();

            return Ok(busca);
        }

        [HttpPut]
        public IActionResult Get(Serie serie)
        {
            var busca = listaDeSeries.Find(f => f.Id == serie.Id);

            if (busca.Ativo)
                return BadRequest("Não é possível atualizar uma serie ativa");

            busca.Titulo = serie.Titulo;
            busca.QuantidadeDeTemporadas = serie.QuantidadeDeTemporadas;
            busca.AnoDeLancamento = serie.AnoDeLancamento;
            busca.Genero = serie.Genero;
            busca.Ativo = serie.Ativo;

            return Ok(busca);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var busca = listaDeSeries.Find(f => f.Id == id);

            if (busca is null)
                return NotFound("Objeto não encontrado");

            listaDeSeries.Remove(busca);

            return StatusCode(204, busca);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            var busca = listaDeSeries.Find(f => f.Id == id);

            if (busca is null)
                return NotFound("Objeto não encontrado");

            busca.Ativo = false;

            return StatusCode(204, busca);
        }
    }
}
