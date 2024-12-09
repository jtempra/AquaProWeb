using AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class ConcepteCobramentController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddConcepteCobramentAsync([FromBody] CreateConcepteCobramentDTO createConcepteCobramentDTO)
        {
            var response = await Sender.Send(new CreateConcepteCobramentCommand { CreateConcepteCobrament = createConcepteCobramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateConcepteCobramentAsync([FromBody] UpdateConcepteCobramentDTO updateConcepteCobramentDTO)
        {
            var response = await Sender.Send(new UpdateConcepteCobramentCommand { UpdateConcepteCobrament = updateConcepteCobramentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcepteCobramentAsync(int id)
        {
            var response = await Sender.Send(new DeleteConcepteCobramentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcepteCobramentByIdAsync(int id)
        {
            var response = await Sender.Send(new GetConcepteCobramentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetConceptesCobramentsAsync()
        {
            var response = await Sender.Send(new GetConceptesCobramentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetConcepteCobramentByTextAsync(string text)
        {
            var response = await Sender.Send(new GetConceptesCobramentByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
