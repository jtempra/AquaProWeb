using AquaProWeb.Application.Features.Parametrens.Commands;
using AquaProWeb.Application.Features.Parametres.Commands;
using AquaProWeb.Application.Features.Parametres.Queries;
using AquaProWeb.Common.Requests.Parametres;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.Parametres
{
    [Route("api/[controller]")]
    public class ParametresController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddParametreAsync([FromBody] SaveParametreDTO createParametreDTO)
        {
            var response = await Sender.Send(new CreateParametreCommand { CreateParametre = createParametreDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateParametreAsync([FromBody] SaveParametreDTO updateParametreDTO)
        {
            var response = await Sender.Send(new UpdateParametreCommand { UpdateParametre = updateParametreDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametreAsync(int id)
        {
            var response = await Sender.Send(new DeleteParametreCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParametreByIdAsync(int id)
        {
            var response = await Sender.Send(new GetParametreByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetParametresAsync()
        {
            var response = await Sender.Send(new GetParametresQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetParametresByTextAsync(string text)
        {
            var response = await Sender.Send(new GetParametresByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
