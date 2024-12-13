using AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusReclamacions;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusReclamacioController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusReclamacioAsync([FromBody] CreateTipusReclamacioDTO createTipusReclamacioDTO)
        {
            var response = await Sender.Send(new CreateTipusReclamacioCommand { CreateTipusReclamacio = createTipusReclamacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusReclamacioAsync([FromBody] UpdateTipusReclamacioDTO updateTipusReclamacioDTO)
        {
            var response = await Sender.Send(new UpdateTipusReclamacioCommand { UpdateTipusReclamacio = updateTipusReclamacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusReclamacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusReclamacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusReclamacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusReclamacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusReclamacioAsync()
        {
            var response = await Sender.Send(new GetTipusReclamacioQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusReclamacioByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusReclamacioByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
