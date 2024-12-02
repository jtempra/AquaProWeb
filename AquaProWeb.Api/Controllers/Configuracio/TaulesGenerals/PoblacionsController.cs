
using AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class PoblacionsController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddPoblacioAsync([FromBody] CreatePoblacioDTO createPoblacioDTO)
        {
            var response = await Sender.Send(new CreatePoblacioCommand { CreatePoblacio = createPoblacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePoblacioAsync([FromBody] UpdatePoblacioDTO updatePoblacioDTO)
        {
            var response = await Sender.Send(new UpdatePoblacioCommand { UpdatePoblacio = updatePoblacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoblacioAsync(int id)
        {
            var response = await Sender.Send(new DeletePoblacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoblacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetPoblacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPoblaciosAsync()
        {
            var response = await Sender.Send(new GetPoblacionsQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPoblacioByTextAsync(string text)
        {
            var response = await Sender.Send(new GetPoblacioByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
