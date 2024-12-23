using AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class ZonesCarrersController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddZonaCarrerAsync([FromBody] SaveZonaCarrerDTO createZonaCarrerDTO)
        {
            var response = await Sender.Send(new CreateZonaCarrerCommand { CreateZonaCarrer = createZonaCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateZonaCarrerAsync([FromBody] SaveZonaCarrerDTO updateZonaCarrerDTO)
        {
            var response = await Sender.Send(new UpdateZonaCarrerCommand { UpdateZonaCarrer = updateZonaCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZonaCarrerAsync(int id)
        {
            var response = await Sender.Send(new DeleteZonaCarrerCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZonaCarrerByIdAsync(int id)
        {
            var response = await Sender.Send(new GetZonaCarrerByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetZonesCarrerAsync()
        {
            var response = await Sender.Send(new GetZonesCarrerQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetZonesCarrerByTextAsync(string text)
        {
            var response = await Sender.Send(new GetZonesCarrerByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}