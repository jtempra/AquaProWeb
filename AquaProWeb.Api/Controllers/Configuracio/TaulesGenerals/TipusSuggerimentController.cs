using AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusSuggeriments;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusSuggerimentController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusSuggerimentAsync([FromBody] SaveTipusSuggerimentDTO createTipusSuggerimentDTO)
        {
            var response = await Sender.Send(new CreateTipusSuggerimentCommand { CreateTipusSuggeriment = createTipusSuggerimentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusSuggerimentAsync([FromBody] SaveTipusSuggerimentDTO updateTipusSuggerimentDTO)
        {
            var response = await Sender.Send(new UpdateTipusSuggerimentCommand { UpdateTipusSuggeriment = updateTipusSuggerimentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusSuggerimentAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusSuggerimentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusSuggerimentByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusSuggerimentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusSuggerimentAsync()
        {
            var response = await Sender.Send(new GetTipusSuggerimentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusSuggerimentByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusSuggerimentByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

    }
}
