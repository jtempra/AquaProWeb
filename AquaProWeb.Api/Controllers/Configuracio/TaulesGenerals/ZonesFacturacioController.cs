using AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesFacturacio;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class ZonesFacturacioController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddZonaFacturacioAsync([FromBody] SaveZonaFacturacioDTO createZonaFacturacioDTO)
        {
            var response = await Sender.Send(new CreateZonaFacturacioCommand { CreateZonaFacturacio = createZonaFacturacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateZonaFacturacioAsync([FromBody] SaveZonaFacturacioDTO updateZonaFacturacioDTO)
        {
            var response = await Sender.Send(new UpdateZonaFacturacioCommand { UpdateZonaFacturacio = updateZonaFacturacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZonaFacturacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteZonaFacturacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZonaFacturacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetZonaFacturacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetZonesFacturacioAsync()
        {
            var response = await Sender.Send(new GetZonesFacturacioQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetZonesFacturacioByTextAsync(string text)
        {
            var response = await Sender.Send(new GetZonesFacturacioByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
