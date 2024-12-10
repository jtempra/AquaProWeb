using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaContacte;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class MotiusBaixaContacteController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMotiuBaixaContacteAsync([FromBody] CreateMotiuBaixaContacteDTO createMotiuBaixaContacteDTO)
        {
            var response = await Sender.Send(new CreateMotiuBaixaContacteCommand { CreateMotiuBaixaContacte = createMotiuBaixaContacteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMotiuBaixaContacteAsync([FromBody] UpdateMotiuBaixaContacteDTO updateMotiuBaixaContacteDTO)
        {
            var response = await Sender.Send(new UpdateMotiuBaixaContacteCommand { UpdateMotiuBaixaContacte = updateMotiuBaixaContacteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotiuBaixaContacteAsync(int id)
        {
            var response = await Sender.Send(new DeleteMotiuBaixaContacteCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotiuBaixaContacteByIdAsync(int id)
        {
            var response = await Sender.Send(new GetMotiuBaixaContacteByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetMotiusBaixaContacteAsync()
        {
            var response = await Sender.Send(new GetMotiusBaixaContacteQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMotiusBaixaContacteByTextAsync(string text)
        {
            var response = await Sender.Send(new GetMotiusBaixaContacteByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
