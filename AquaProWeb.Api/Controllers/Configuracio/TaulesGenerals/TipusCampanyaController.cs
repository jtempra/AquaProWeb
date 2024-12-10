using AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusCampanyes;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusCampanyaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusCampanyaAsync([FromBody] CreateTipusCampanyaDTO createTipusCampanyaDTO)
        {
            var response = await Sender.Send(new CreateTipusCampanyaCommand { CreateTipusCampanya = createTipusCampanyaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusCampanyaAsync([FromBody] UpdateTipusCampanyaDTO updateTipusCampanyaDTO)
        {
            var response = await Sender.Send(new UpdateTipusCampanyaCommand { UpdateTipusCampanya = updateTipusCampanyaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusCampanyaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusCampanyaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusCampanyaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusCampanyaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusCampanyasAsync()
        {
            var response = await Sender.Send(new GetTipusCampanyaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusCampanyasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusCampanyaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
