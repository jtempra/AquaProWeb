using AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusBaixaClients;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusBaixaClientController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusBaixaClientAsync([FromBody] SaveTipusBaixaClientDTO createTipusBaixaClientDTO)
        {
            var response = await Sender.Send(new CreateTipusBaixaClientCommand { CreateTipusBaixaClient = createTipusBaixaClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusBaixaClientAsync([FromBody] SaveTipusBaixaClientDTO updateTipusBaixaClientDTO)
        {
            var response = await Sender.Send(new UpdateTipusBaixaClientCommand { UpdateTipusBaixaClient = updateTipusBaixaClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusBaixaClientAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusBaixaClientCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusBaixaClientByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusBaixaClientByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusBaixaClientsAsync()
        {
            var response = await Sender.Send(new GetTipusBaixaClientQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusBaixaClientsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusBaixaClientByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
