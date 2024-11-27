using AquaProWeb.Application.Features.Explotacions.Commands;
using AquaProWeb.Application.Features.Explotacions.Queries;
using AquaProWeb.Common.Requests.Explotacions;
using Microsoft.AspNetCore.Mvc;
using GetCanalCobramentByIdQuery = AquaProWeb.Application.Features.CanalsCobrament.Queries.GetCanalCobramentByIdQuery;

namespace AquaProWeb.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExplotacionsController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddExplotacioAsync([FromBody] CreateExplotacioDTO createExplotacioDTO)
        {
            var response = await Sender.Send(new CreateExplotacioCommand { CreateExplotacio = createExplotacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateExplotacioAsync([FromBody] UpdateExplotacioDTO updateExplotacioDTO)
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
            var response = await Sender.Send(new GetExplotacionsQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
