using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesClients;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusIncidenciaClientController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusIncidenciaClientAsync([FromBody] SaveTipusIncidenciaClientDTO createTipusIncidenciaClientDTO)
        {
            var response = await Sender.Send(new CreateTipusIncidenciaClientCommand { CreateTipusIncidenciaClient = createTipusIncidenciaClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusIncidenciaClientAsync([FromBody] SaveTipusIncidenciaClientDTO updateTipusIncidenciaClientDTO)
        {
            var response = await Sender.Send(new UpdateTipusIncidenciaClientCommand { UpdateTipusIncidenciaClient = updateTipusIncidenciaClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusIncidenciaClientAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusIncidenciaClientCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusIncidenciaClientByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusIncidenciaClientByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusIncidenciaClientsAsync()
        {
            var response = await Sender.Send(new GetTipusIncidenciaClientQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusIncidenciaClientsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusIncidenciaClientByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
