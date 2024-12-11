
using AquaProWeb.Application.Features.TaulesGenerals.CanalsCobrament.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.CanalsCobrament.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class CanalsCobramentController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddPoblacioAsync([FromBody] CreateCanalCobramentDTO createCanalCobramentDTO)
        {
            var response = await Sender.Send(new CreateCanalCobramentCommand { CreateCanalCobrament = createCanalCobramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCanalCobramentAsync([FromBody] UpdateCanalCobramentDTO updateCanalCobramentDTO)
        {
            var response = await Sender.Send(new UpdateCanalCobramentCommand { UpdateCanalCobrament = updateCanalCobramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanalCobramentAsync(int id)
        {
            var response = await Sender.Send(new DeleteCanalCobramentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCanalCobramentByIdAsync(int id)
        {
            var response = await Sender.Send(new GetCanalCobramentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCanalsCobramentAsync()
        {
            var response = await Sender.Send(new GetCanalsCobramentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCanalsCobramentByTextAsync(string text)
        {
            var response = await Sender.Send(new GetCanalsCobramentByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
