using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigurinhaController : ControllerBase
    {
        public static List<Figurinha> listaDeFigurinhas = new List<Figurinha>()
        {
                new Figurinha(){Numero = 1, Descricao = "Leonel Messi", Tipo = 0},
                new Figurinha(){Numero = 2, Descricao = "Cristiano Ronaldo", Tipo = 0},
                new Figurinha(){Numero = 3, Descricao = "Pelé", Tipo = 0},
                new Figurinha(){Numero = 4, Descricao = "Maradona", Tipo = 0},
                new Figurinha(){Numero = 5, Descricao = "Neymar", Tipo = 0},
        };

        // GET: api/<AlunoController>
        [HttpGet]
        public List<Figurinha> Get()
        {
            return listaDeFigurinhas;
        }

        // GET api/<AlunoController>/5
        [HttpGet("{numero}")]
        public Figurinha Get(int numero)
        {
            var figurinhaBuscada = listaDeFigurinhas.Find(f => f.Numero == numero);

            return figurinhaBuscada;
        }

        // POST api/<AlunoController>
        [HttpPost]
        public ActionResult<List<Figurinha>> Post([FromBody] Figurinha figurinha)
        {
            listaDeFigurinhas.Add(figurinha);

            return listaDeFigurinhas;
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{numero}")]
        public ActionResult Put(int numero, [FromBody] Figurinha figurinha)
        {
            var figurinhaBuscada = listaDeFigurinhas.FindIndex(f => f.Numero == numero);

            listaDeFigurinhas[figurinhaBuscada].Descricao = figurinha.Descricao;
            listaDeFigurinhas[figurinhaBuscada].Tipo = (Figurinha.TipoDeFigurinha   )figurinha.Tipo;

            return new OkResult();
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{numero}")]
        public ActionResult Delete(int numero)
        {
            var figurinhaBuscada = listaDeFigurinhas.Find(f => f.Numero == numero);

            listaDeFigurinhas.Remove(figurinhaBuscada);

            return new StatusCodeResult(204);
        }
    }
}
