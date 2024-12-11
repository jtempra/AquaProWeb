using AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesOrdresTreball;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class ZonesOrdreTreballController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddZonaOrdreTreballAsync([FromBody] CreateZonaOrdreTreballDTO createZonaOrdreTreballDTO)
        {
            var response = await Sender.Send(new CreateZonaOrdreTreballCommand { CreateZonaOrdreTreball = createZonaOrdreTreballDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateZonaOrdreTreballAsync([FromBody] UpdateZonaOrdreTreballDTO updateZonaOrdreTreballDTO)
        {
            var response = await Sender.Send(new UpdateZonaOrdreTreballCommand { UpdateZonaOrdreTreball = updateZonaOrdreTreballDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZonaOrdreTreballAsync(int id)
        {
            var response = await Sender.Send(new DeleteZonaOrdreTreballCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZonaOrdreTreballByIdAsync(int id)
        {
            var response = await Sender.Send(new GetZonaOrdreTreballByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetZonesOrdreTreballAsync()
        {
            var response = await Sender.Send(new GetZonesOrdreTreballQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }


    }
}
