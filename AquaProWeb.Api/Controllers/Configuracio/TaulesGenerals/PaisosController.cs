using AquaProWeb.Application.Features.TaulesGenerals.Paisos.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.Paisos.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.Paisos;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class PaisosController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddPaisAsync([FromBody] SavePaisDTO createPaisDTO)
        {
            var response = await Sender.Send(new CreatePaisCommand { CreatePais = createPaisDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePaisAsync([FromBody] SavePaisDTO updatePaisDTO)
        {
            var response = await Sender.Send(new UpdatePaisCommand { UpdatePais = updatePaisDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaisAsync(int id)
        {
            var response = await Sender.Send(new DeletePaisCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaisByIdAsync(int id)
        {
            var response = await Sender.Send(new GetPaisByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPaisosAsync()
        {
            var response = await Sender.Send(new GetPaisosQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPaisosByTextAsync(string text)
        {
            var response = await Sender.Send(new GetPaisosByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
