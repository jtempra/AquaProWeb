using AquaProWeb.Application.Features.TipusVies.Commands;
using AquaProWeb.Application.Features.TipusVies.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers
{
    [Route("api/[controller]")]
    public class TipusViaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusViaAsync([FromBody] CreateTipusViaDTO createTipusViaDTO)
        {
            var response = await Sender.Send(new CreateTipusViaCommand { CreateTipusVia = createTipusViaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusViaAsync([FromBody] UpdateTipusViaDTO updateTipusViaDTO)
        {
            var response = await Sender.Send(new UpdateTipusViaCommand { UpdateTipusVia = updateTipusViaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusViaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusViaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusViaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusViaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusViaAsync()
        {
            var response = await Sender.Send(new GetTipusViaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
