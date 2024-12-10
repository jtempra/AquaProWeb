using AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioRebut;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class SituacionsRebutController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddSituacioRebutAsync([FromBody] CreateSituacioRebutDTO createSituacioRebutDTO)
        {
            var response = await Sender.Send(new CreateSituacioRebutCommand { CreateSituacioRebut = createSituacioRebutDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSituacioRebutAsync([FromBody] UpdateSituacioRebutDTO updateSituacioRebutDTO)
        {
            var response = await Sender.Send(new UpdateSituacioRebutCommand { UpdateSituacioRebut = updateSituacioRebutDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSituacioRebutAsync(int id)
        {
            var response = await Sender.Send(new DeleteSituacioRebutCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSituacioRebutByIdAsync(int id)
        {
            var response = await Sender.Send(new GetSituacioRebutByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetSituacionsRebutsAsync()
        {
            var response = await Sender.Send(new GetSituacionsRebutQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSituacionsRebutsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetSituacionsRebutByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
