
using AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.MarquesComptador;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class MarquesComptadorController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMarcaComptadorAsync([FromBody] CreateMarcaComptadorDTO createMarcaComptadorDTO)
        {
            var response = await Sender.Send(new CreateMarcaComptadorCommand { CreateMarcaComptador = createMarcaComptadorDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMarcaComptadorAsync([FromBody] UpdateMarcaComptadorDTO updateMarcaComptadorDTO)
        {
            var response = await Sender.Send(new UpdateMarcaComptadorCommand { UpdateMarcaComptador = updateMarcaComptadorDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarcaComptadorAsync(int id)
        {
            var response = await Sender.Send(new DeleteMarcaComptadorCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaComptadorByIdAsync(int id)
        {
            var response = await Sender.Send(new GetMarcaComptadorByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetMarquesComptadorAsync()
        {
            var response = await Sender.Send(new GetMarquesComptadorQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMarquesComptadorByTextAsync(string text)
        {
            var response = await Sender.Send(new GetMarquesComptadorByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
