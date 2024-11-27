using AquaProWeb.Application.Features.CanalsCobrament.Commands;
using AquaProWeb.Application.Features.CanalsCobrament.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers
{
    [Route("api/[controller]")]
    public class CanalsCobramentController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddPoblacioAsync([FromBody] CreateCanalCobramentDTO createCanalCobramentDTO)
        {
            var response = await Sender.Send(new CreateCanalCobramentCommand { CreateCanalCobrament = createCanalCobramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCanalCobramentAsync([FromBody] UpdateCanalCobramentDTO updateCanalCobramentDTO)
        {
            var response = await Sender.Send(new UpdateCanalCobramentCommand { UpdateCanalCobrament = updateCanalCobramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanalCobramentAsync(int id)
        {
            var response = await Sender.Send(new DeleteCanalCobramentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCanalCobramentByIdAsync(int id)
        {
            var response = await Sender.Send(new GetCanalCobramentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCanalsCobramentAsync()
        {
            var response = await Sender.Send(new GetCanalsCobramentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        //[HttpGet("search")]
        //public async Task<IActionResult> GetCanalCobramentByTextAsync(string text)
        //{
        //    var response = await Sender.Send(new GetCanalCobramentByTextQuery { Text = text });

        //    if (response.IsSuccessful)
        //    {
        //        return Ok(response);
        //    }
        //    return NotFound(response);
        //}
    }
}
