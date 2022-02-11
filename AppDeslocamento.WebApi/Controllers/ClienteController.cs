using AppDeslocamento.Application.Clientes.Commands.CadastrarCliente;
using AppDeslocamento.Application.Clientes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
           [FromQuery] GetClienteQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
