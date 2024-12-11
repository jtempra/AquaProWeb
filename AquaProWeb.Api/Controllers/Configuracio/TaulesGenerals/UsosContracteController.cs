using AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.UsosContracte;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class UsosContracteController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddUsContracteAsync([FromBody] CreateUsContracteDTO createUsContracteDTO)
        {
            var response = await Sender.Send(new CreateUsContracteCommand { CreateUsContracte = createUsContracteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUsContracteAsync([FromBody] UpdateUsContracteDTO updateUsContracteDTO)
        {
            var response = await Sender.Send(new UpdateUsContracteCommand { UpdateUsContracte = updateUsContracteDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsContracteAsync(int id)
        {
            var response = await Sender.Send(new DeleteUsContracteCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsContracteByIdAsync(int id)
        {
            var response = await Sender.Send(new GetUsContracteByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUsContracteAsync()
        {
            var response = await Sender.Send(new GetUsosContracteQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }


    }
}
