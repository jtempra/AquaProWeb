using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesTecniques;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusIncidenciaTecnicaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusIncidenciaTecnicaAsync([FromBody] SaveTipusIncidenciaTecnicaDTO createTipusIncidenciaTecnicaDTO)
        {
            var response = await Sender.Send(new CreateTipusIncidenciaTecnicaCommand { CreateTipusIncidenciaTecnica = createTipusIncidenciaTecnicaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusIncidenciaTecnicaAsync([FromBody] SaveTipusIncidenciaTecnicaDTO updateTipusIncidenciaTecnicaDTO)
        {
            var response = await Sender.Send(new UpdateTipusIncidenciaTecnicaCommand { UpdateTipusIncidenciaTecnica = updateTipusIncidenciaTecnicaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusIncidenciaTecnicaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusIncidenciaTecnicaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusIncidenciaTecnicaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusIncidenciaTecnicaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusIncidenciaTecnicasAsync()
        {
            var response = await Sender.Send(new GetTipusIncidenciaTecnicaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusIncidenciaTecnicasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusIncidenciaTecnicaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
