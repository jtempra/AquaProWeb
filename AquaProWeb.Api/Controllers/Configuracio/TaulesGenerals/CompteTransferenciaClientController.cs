using AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesTransferenciaClient;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class CompteTransferenciaClientController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddCompteTransferenciaClientsync([FromBody] CreateCompteTransferenciaClientDTO createCompteTransferenciaClientDTO)
        {
            var response = await Sender.Send(new CreateCompteTransferenciaClientCommand { CreateCompteTransferenciaClient = createCompteTransferenciaClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTransferenciaCarrerAsync([FromBody] UpdateCompteTransferenciaClientDTO updateCompteTransferenciaClientDTO)
        {
            var response = await Sender.Send(new UpdateCompteTransferenciaClientCommand { UpdateCompteTransferenciaClient = updateCompteTransferenciaClientDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompteTransferenciaClientAsync(int id)
        {
            var response = await Sender.Send(new DeleteCompteTransferenciaClientCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompteTransferenciaClientByIdAsync(int id)
        {
            var response = await Sender.Send(new GetCompteTransferenciaClientByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetComptesTransferenciaClientAsync()
        {
            var response = await Sender.Send(new GetComptesTransferenciaClientQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCompteTransferenciaClientByTextAsync(string text)
        {
            var response = await Sender.Send(new GetComptesTransferenciaClientByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
