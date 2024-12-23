using AquaProWeb.Application.Features.TaulesGenerals.Operaris.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.Operaris.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.Operaris;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class OperarisController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddOperariAsync([FromBody] SaveOperariDTO createOperariDTO)
        {
            var response = await Sender.Send(new CreateOperariCommand { CreateOperari = createOperariDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOperariAsync([FromBody] SaveOperariDTO updateOperariDTO)
        {
            var response = await Sender.Send(new UpdateOperariCommand { UpdateOperari = updateOperariDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperariAsync(int id)
        {
            var response = await Sender.Send(new DeleteOperariCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperariByIdAsync(int id)
        {
            var response = await Sender.Send(new GetOperariByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetOperarisAsync()
        {
            var response = await Sender.Send(new GetOperarisQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetOperarisByTextAsync(string text)
        {
            var response = await Sender.Send(new GetOperarisByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
