using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Abonats.PuntsSubministrament
{
    [Route("api/[controller]")]
    public class PuntsSubministramentController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddPuntSubministramentAsync([FromBody] CreatePuntSubministramentDTO createPuntSubministramentDTO)
        {
            var response = await Sender.Send(new CreatePuntSubministramentCommand { CreatePuntSubministrament = createPuntSubministramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePuntSubministramentAsync([FromBody] UpdatePuntSubministramentDTO updatePuntSubministramentDTO)
        {
            var response = await Sender.Send(new UpdatePuntSubministramentCommand { UpdatePuntSubministrament = updatePuntSubministramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuntSubministramentAsync(int id)
        {
            var response = await Sender.Send(new DeletePuntSubministramentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPuntSubministramentByIdAsync(int id)
        {
            var response = await Sender.Send(new GetPuntSubministramentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPuntsSubministramentsAsync()
        {
            var response = await Sender.Send(new GetPuntSubministramentsQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPuntsSubministramentsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetPuntSubministramentsByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
