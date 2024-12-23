using AquaProWeb.Application.Features.Explotacions.Commands;
using AquaProWeb.Application.Features.Explotacions.Queries;
using AquaProWeb.Application.Features.Parametres.Commands;
using AquaProWeb.Common.Requests.Explotacions;
using Microsoft.AspNetCore.Mvc;
using CreateParametreCommand = AquaProWeb.Application.Features.Explotacions.Commands.CreateParametreCommand;
using GetCanalCobramentByIdQuery = AquaProWeb.Application.Features.TaulesGenerals.CanalsCobrament.Queries.GetCanalCobramentByIdQuery;

namespace AquaProWeb.Api.Controllers.Configuracio.Explotacio
{
    [Route("api/[controller]")]
    public class ExplotacionsController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddExplotacioAsync([FromBody] SaveExplotacioDTO createExplotacioDTO)
        {
            var response = await Sender.Send(new CreateParametreCommand { CreateExplotacio = createExplotacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateExplotacioAsync([FromBody] SaveExplotacioDTO updateExplotacioDTO)
        {
            var response = await Sender.Send(new UpdateExplotacioCommand { UpdateExplotacio = updateExplotacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExplotacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteExplotacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExplotacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetCanalCobramentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetExplotacionsAsync()
        {
            var response = await Sender.Send(new GetParametreQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
