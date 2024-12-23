using AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusComptadors;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusComptadorController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusComptadorAsync([FromBody] SaveTipusComptadorDTO createTipusComptadorDTO)
        {
            var response = await Sender.Send(new CreateTipusComptadorCommand { CreateTipusComptador = createTipusComptadorDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusComptadorAsync([FromBody] SaveTipusComptadorDTO updateTipusComptadorDTO)
        {
            var response = await Sender.Send(new UpdateTipusComptadorCommand { UpdateTipusComptador = updateTipusComptadorDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusComptadorAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusComptadorCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusComptadorByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusComptadorByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusComptadorsAsync()
        {
            var response = await Sender.Send(new GetTipusComptadorQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusComptadorsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusComptadorByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
