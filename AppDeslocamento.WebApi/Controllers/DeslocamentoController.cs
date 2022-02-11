using AppDeslocamento.Application.Deslocamentos.Commands;
using AppDeslocamento.Application.Deslocamentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebAPI.Controllers
{
    public class DeslocamentoController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{deslocamentoId:long}")]
        public async Task<IActionResult> GetSync(long deslocamentoId)
        {
            var query = new GetDeslocamentoQuery() 
            { 
                DeslocamentoId = deslocamentoId 
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpPut("{deslocamentoId:long}/finalizar_deslocamento")]
        public async Task<IActionResult> PutAdicionarSignatarioAsync(
            [FromRoute] long deslocamentoId,
            [FromBody] FinalizarDeslocamentoCommand command)
        {
            if (deslocamentoId != command.DeslocamentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
