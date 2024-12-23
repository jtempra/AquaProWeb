using AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusClients;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusClientController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusClientAsync([FromBody] SaveTipusClientDTO createTipusClientDTO)
        {
            var response = await Sender.Send(new CreateTipusClientCommand { CreateTipusClient = createTipusClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusClientAsync([FromBody] SaveTipusClientDTO updateTipusClientDTO)
        {
            var response = await Sender.Send(new UpdateTipusClientCommand { UpdateTipusClient = updateTipusClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusClientAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusClientCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusClientByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusClientByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusClientsAsync()
        {
            var response = await Sender.Send(new GetTipusClientQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusClientsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusClientByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
