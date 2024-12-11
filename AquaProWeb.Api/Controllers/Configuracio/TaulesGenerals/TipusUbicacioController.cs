using AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusUbicacions;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusUbicacioController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusUbicacioAsync([FromBody] CreateTipusUbicacioDTO createTipusUbicacioDTO)
        {
            var response = await Sender.Send(new CreateTipusUbicacioCommand { CreateTipusUbicacio = createTipusUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusUbicacioAsync([FromBody] UpdateTipusUbicacioDTO updateTipusUbicacioDTO)
        {
            var response = await Sender.Send(new UpdateTipusUbicacioCommand { UpdateTipusUbicacio = updateTipusUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusUbicacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusUbicacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusUbicacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusUbicacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusUbicacioAsync()
        {
            var response = await Sender.Send(new GetTipusUbicacioQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
