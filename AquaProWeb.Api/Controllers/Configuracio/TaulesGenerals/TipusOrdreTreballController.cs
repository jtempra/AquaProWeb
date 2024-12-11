using AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusOrdresTreball;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusOrdreTreballController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusOrdreTreballAsync([FromBody] CreateTipusOrdreTreballDTO createTipusOrdreTreballDTO)
        {
            var response = await Sender.Send(new CreateTipusOrdreTreballCommand { CreateTipusOrdreTreball = createTipusOrdreTreballDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusOrdreTreballAsync([FromBody] UpdateTipusOrdreTreballDTO updateTipusOrdreTreballDTO)
        {
            var response = await Sender.Send(new UpdateTipusOrdreTreballCommand { UpdateTipusOrdreTreball = updateTipusOrdreTreballDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusOrdreTreballAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusOrdreTreballCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusOrdreTreballByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusOrdreTreballByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusOrdreTreballAsync()
        {
            var response = await Sender.Send(new GetTipusOrdreTreballQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
