using AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesContracte;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class FamiliesContracteController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddFamiliaContracteAsync([FromBody] CreateFamiliaContracteDTO createFamiliaContracteDTO)
        {
            var response = await Sender.Send(new CreateFamiliaContracteCommand { CreateFamiliaContracte = createFamiliaContracteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFamiliaContracteAsync([FromBody] UpdateFamiliaContracteDTO updateFamiliaContracteDTO)
        {
            var response = await Sender.Send(new UpdateFamiliaContracteCommand { UpdateFamiliaContracte = updateFamiliaContracteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamiliaContracteAsync(int id)
        {
            var response = await Sender.Send(new DeleteCompteTransferenciaClientCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamiliaContracteByIdAsync(int id)
        {
            var response = await Sender.Send(new GetFamiliaContracteByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetComptesRemesaBancAsync()
        {
            var response = await Sender.Send(new GetFamiliesContracteQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetFamiliaContracteByTextAsync(string text)
        {
            var response = await Sender.Send(new GetFamiliesContracteByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
