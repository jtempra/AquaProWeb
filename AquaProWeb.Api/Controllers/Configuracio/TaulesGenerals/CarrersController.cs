
using AquaProWeb.Application.Features.TaulesGenerals.Carrers.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.Carrers.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{

    [Route("api/[controller]")]
    public class CarrersController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddCarrerAsync([FromBody] CreateCarrerDTO createCarrerDTO)
        {
            var response = await Sender.Send(new CreateConcepteCobramentCommand { CreateCarrer = createCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCarrerAsync([FromBody] UpdateCarrerDTO updateCarrerDTO)
        {
            var response = await Sender.Send(new UpdateConcepteCobramentCommand { UpdateCarrer = updateCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrerAsync(int id)
        {
            var response = await Sender.Send(new DeleteConcepteCobramentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrerByIdAsync(int id)
        {
            var response = await Sender.Send(new GetConcepteCobramentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCarrersAsync()
        {
            var response = await Sender.Send(new GetConceptesCobramentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCarrerByTextAsync(string text)
        {
            var response = await Sender.Send(new GetConceptesCobramentersByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
