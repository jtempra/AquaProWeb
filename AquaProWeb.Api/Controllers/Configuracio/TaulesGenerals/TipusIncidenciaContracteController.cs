using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesContractes;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusIncidenciaContracteController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusIncidenciaContracteAsync([FromBody] CreateTipusIncidenciaContracteDTO createTipusIncidenciaContracteDTO)
        {
            var response = await Sender.Send(new CreateTipusIncidenciaContracteCommand { CreateTipusIncidenciaContracte = createTipusIncidenciaContracteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusIncidenciaContracteAsync([FromBody] UpdateTipusIncidenciaContracteDTO updateTipusIncidenciaContracteDTO)
        {
            var response = await Sender.Send(new UpdateTipusIncidenciaContracteCommand { UpdateTipusIncidenciaContracte = updateTipusIncidenciaContracteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusIncidenciaContracteAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusIncidenciaContracteCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusIncidenciaContracteByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusIncidenciaContracteByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusIncidenciaContractesAsync()
        {
            var response = await Sender.Send(new GetTipusIncidenciaContracteQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusIncidenciaContractesByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusIncidenciaContracteByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
