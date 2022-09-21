using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoSolution.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IContratoRepository _contratoRepository = new ContratoRepository();

        [HttpPost]
        public ActionResult PostContrato(Contrato contrato)
        {
            _contratoRepository.CadastraNovoContrato(contrato);

            return Ok(contrato);
        }


        [HttpGet("{cpf}")]
        public ActionResult GetContratosPorCliente(long cpf)
        {
            try
            {
                var contratos = _contratoRepository.BuscarContratosPorCliente(cpf);

                return Ok(contratos);
            }
            catch (System.Exception)
            {
                return BadRequest(new Resposta("GC001", "Nenhum contrato encontrado!"));
            }
        }

    }
}
