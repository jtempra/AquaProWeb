using AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Queries;
using AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class ConcepteFacturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddConcepteFacturaAsync([FromBody] CreateConcepteFacturaDTO createConcepteFacturaDTO)
        {
            var response = await Sender.Send(new CreateConcepteFacturaCommand { CreateConcepteFactura = createConcepteFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateConcepteFacturaAsync([FromBody] UpdateConcepteFacturaDTO updateConcepteFacturaDTO)
        {
            var response = await Sender.Send(new UpdateConcepteFacturaCommand { UpdateConcepteFactura = updateConcepteFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcepteFacturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteConcepteFacturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcepteFacturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetConcepteFacturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetConceptesFacturaAsync()
        {
            var response = await Sender.Send(new GetConceptesCobramentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetConceptesFacturaByTextAsync(string text)
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
