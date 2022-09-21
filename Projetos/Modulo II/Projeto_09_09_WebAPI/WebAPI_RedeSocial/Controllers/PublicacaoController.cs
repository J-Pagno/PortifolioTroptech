using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Publicacao> Get(int id)
        {
            var publicacaoBuscada = DataBase.listaDePublicacoes.Find(x => x.Id == id);

            return publicacaoBuscada;
        }

        [HttpPost]
        public ActionResult<Publicacao> Post([FromBody] Publicacao publicacao)
        {
            publicacao.Id = (DataBase.listaDePublicacoes.FindLastIndex(p => p.Id != 0)) + 2;
            publicacao.DataPublicacao = DateTime.Now;

            DataBase.listaDePublicacoes.Add(publicacao);

            return publicacao;
        }

        [HttpPut]
        public ActionResult Put([FromBody] Publicacao publicacao)
        {
            var publicacaoAntiga = DataBase.listaDePublicacoes.Find(p => p.Id == publicacao.Id);

            publicacaoAntiga.NomeUsuario = publicacao.NomeUsuario;
            publicacaoAntiga.Titulo = publicacao.Titulo;
            publicacaoAntiga.DataPublicacao = DateTime.Now;

            return new OkResult();
        }

        [HttpPut("{id}")]
        public ActionResult<int> Put(int id)
        {
            var publicacaoCurtida = DataBase.listaDePublicacoes.Find(p => p.Id == id);

            publicacaoCurtida.QuantidadeCurtidas += 1;

            return publicacaoCurtida.QuantidadeCurtidas;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var publicacaoExcluida = DataBase.listaDePublicacoes.Find(p => p.Id == id);

            DataBase.listaDePublicacoes.Remove(publicacaoExcluida);

            return new StatusCodeResult(204);
        }
    }
}
