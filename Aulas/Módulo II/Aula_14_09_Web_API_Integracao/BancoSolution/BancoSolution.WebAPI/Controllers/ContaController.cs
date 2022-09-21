using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoSolution.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private IContaRepository _contaRepository = new ContaRepository();

        [HttpGet]
        public ActionResult GetContas()
        {
            var contas = _contaRepository.BuscarTodasContas();

            return Ok(contas);
        }

        [HttpGet("cpf")]
        public ActionResult GetContasPorCliente(long cpf)
        {
            try
            {
                var conta = _contaRepository.BuscarContasPorCliente(cpf);

                return Ok(conta);
            }
            catch (System.Exception)
            {
                return BadRequest(new Resposta("C001", "Nenhuma conta encontrada!"));
            }


        }

        [HttpPost]
        public ActionResult PostConta([FromBody] Conta conta)
        {
            _contaRepository.CadastraNovaConta(conta);

            return Ok(conta);
        }
    }
}
