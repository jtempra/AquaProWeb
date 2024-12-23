using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompte.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompteCompte.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaCompte;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class MotiusBaixaCompteController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMotiuBaixaCompteAsync([FromBody] SaveMotiuBaixaCompteDTO createMotiuBaixaCompteDTO)
        {
            var response = await Sender.Send(new CreateMotiuBaixaCompteCommand { CreateMotiuBaixaCompte = createMotiuBaixaCompteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMotiuBaixaCompteAsync([FromBody] SaveMotiuBaixaCompteDTO updateMotiuBaixaCompteDTO)
        {
            var response = await Sender.Send(new UpdateMotiuBaixaCompteCommand { UpdateMotiuBaixaCompte = updateMotiuBaixaCompteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotiuBaixaCompteAsync(int id)
        {
            var response = await Sender.Send(new DeleteMotiuBaixaCompteCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotiuBaixaCompteByIdAsync(int id)
        {
            var response = await Sender.Send(new GetMotiuBaixaCompteByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetMotiusBaixaCompteAsync()
        {
            var response = await Sender.Send(new GetMotiusBaixaCompteQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMotiusBaixaCompteByTextAsync(string text)
        {
            var response = await Sender.Send(new GetMotiusBaixaCompteByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
