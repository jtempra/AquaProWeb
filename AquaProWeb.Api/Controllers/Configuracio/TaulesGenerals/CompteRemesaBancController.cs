using AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{

    [Route("api/[controller]")]
    public class CompteRemesaBancController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddCompteRemesaBancAsync([FromBody] SaveCompteRemesaBancDTO createCompteRemesaBancDTO)
        {
            var response = await Sender.Send(new CreateCompteTransferenciaClientCommand { CreateCompteRemesaBanc = createCompteRemesaBancDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCompteRemesaBancAsync([FromBody] SaveCompteRemesaBancDTO updateCompteRemesaBancDTO)
        {
            var response = await Sender.Send(new UpdateCompteRemesaBancCommand { UpdateCompteRemesaBanc = updateCompteRemesaBancDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompteRemesaBancAsync(int id)
        {
            var response = await Sender.Send(new DeleteCompteTransferenciaClientCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompteRemesaBancByIdAsync(int id)
        {
            var response = await Sender.Send(new GetCompteTransferenciaClientByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetComptesRemesaBancAsync()
        {
            var response = await Sender.Send(new GetComptesTransferenciaClientQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCompteRemesaBancByTextAsync(string text)
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
