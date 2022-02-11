using AppDeslocamento.Application.Condutores.Queries;
using MediatR;
using AppDeslocamento.Application.Condutores.Commands.CadastrarCondutor;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebAPI.Controllers
{
    public class CondutorController : ApiController
    {
        [HttpGet]

        public async Task<IActionResult> GetSync([FromQuery] GetCondutorQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
