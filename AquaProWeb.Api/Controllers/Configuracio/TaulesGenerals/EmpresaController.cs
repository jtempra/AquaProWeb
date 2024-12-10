using AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.Empreses.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.Empreses;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class EmpresaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddEmpresaAsync([FromBody] CreateEmpresaDTO createEmpresaDTO)
        {
            var response = await Sender.Send(new CreateEmpresaCommand { CreateEmpresa = createEmpresaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmpresaAsync([FromBody] UpdateEmpresaDTO updateEmpresaDTO)
        {
            var response = await Sender.Send(new UpdateEmpresaCommand { UpdateEmpresa = updateEmpresaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaAsync(int id)
        {
            var response = await Sender.Send(new DeleteEmpresaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetEmpresaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetEmpresasAsync()
        {
            var response = await Sender.Send(new GetEmpresesQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetEmpresaByTextAsync(string text)
        {
            var response = await Sender.Send(new GetEmpresesByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
