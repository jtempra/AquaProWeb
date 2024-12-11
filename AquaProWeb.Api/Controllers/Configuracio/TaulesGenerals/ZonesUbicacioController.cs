using AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesUbicacions;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class ZonesUbicacioController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddZonaUbicacioAsync([FromBody] CreateZonaUbicacioDTO createZonaUbicacioDTO)
        {
            var response = await Sender.Send(new CreateZonaUbicacioCommand { CreateZonaUbicacio = createZonaUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateZonaUbicacioAsync([FromBody] UpdateZonaUbicacioDTO updateZonaUbicacioDTO)
        {
            var response = await Sender.Send(new UpdateZonaUbicacioCommand { UpdateZonaUbicacio = updateZonaUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZonaUbicacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteZonaUbicacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZonaUbicacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetZonaUbicacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetZonesUbicacioAsync()
        {
            var response = await Sender.Send(new GetZonesUbicacioQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }


    }
}
