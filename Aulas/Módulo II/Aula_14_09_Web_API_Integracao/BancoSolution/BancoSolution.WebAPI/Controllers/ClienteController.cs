using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BancoSolution.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository = new ClienteRepository();

        [HttpGet]
        public ActionResult GetClientes()
        {
            var clientes = _clienteRepository.BuscarTodosClientes();

            return Ok(clientes);
        }

        [HttpGet("{cpf}")]
        public ActionResult GetClientesPorCpf(long cpf)
        {
            try
            {
                var cliente = _clienteRepository.BuscarClientePorCpf(cpf);

                return Ok(cliente);
            }
            catch (System.Exception)
            {
                return BadRequest(new Resposta("GC001", "Nenhum cliente encontrado!"));
            }
        }
    }
}
