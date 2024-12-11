using AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusQueixes;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusQueixaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusQueixaAsync([FromBody] CreateTipusQueixaDTO createTipusQueixaDTO)
        {
            var response = await Sender.Send(new CreateTipusQueixaCommand { CreateTipusQueixa = createTipusQueixaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusQueixaAsync([FromBody] UpdateTipusQueixaDTO updateTipusQueixaDTO)
        {
            var response = await Sender.Send(new UpdateTipusQueixaCommand { UpdateTipusQueixa = updateTipusQueixaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusQueixaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusQueixaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusQueixaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusQueixaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusQueixaAsync()
        {
            var response = await Sender.Send(new GetTipusQueixaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
