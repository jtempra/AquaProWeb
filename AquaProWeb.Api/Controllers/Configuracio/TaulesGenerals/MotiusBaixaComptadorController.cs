using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaComptador;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class MotiusBaixaComptadorController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMotiuBaixaComptadorAsync([FromBody] CreateMotiuBaixaComptadorDTO createMotiuBaixaComptadorDTO)
        {
            var response = await Sender.Send(new CreateMotiuBaixaComptadorCommand { CreateMotiuBaixaComptador = createMotiuBaixaComptadorDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMotiuBaixaComptadorAsync([FromBody] UpdateMotiuBaixaComptadorDTO updateMotiuBaixaComptadorDTO)
        {
            var response = await Sender.Send(new UpdateMotiuBaixaComptadorCommand { UpdateMotiuBaixaComptador = updateMotiuBaixaComptadorDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotiuBaixaComptadorAsync(int id)
        {
            var response = await Sender.Send(new DeleteMotiuBaixaComptadorCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotiuBaixaComptadorByIdAsync(int id)
        {
            var response = await Sender.Send(new GetMotiuBaixaComptadorByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetMotiusBaixaComptadorsAsync()
        {
            var response = await Sender.Send(new GetMotiusBaixaComptadorQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMotiusBaixaComptadorByTextAsync(string text)
        {
            var response = await Sender.Send(new GetMotiusBaixaComptadorByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
