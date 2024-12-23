using AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.FamiliesConcepteFactura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesConcepteFactura;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class FamiliesConcepteFacturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddFamiliaConcepteFacturaAsync([FromBody] SaveFamiliaConcepteFacturaDTO createFamiliaConcepteFacturaDTO)
        {
            var response = await Sender.Send(new CreateFamiliaConcepteFacturaCommand { CreateFamiliaConcepteFactura = createFamiliaConcepteFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFamiliaConcepteFacturaAsync([FromBody] SaveFamiliaConcepteFacturaDTO updateFamiliaConcepteFacturaDTO)
        {
            var response = await Sender.Send(new UpdateFamiliaConcepteFacturaCommand { UpdateFamiliaConcepteFactura = updateFamiliaConcepteFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamiliaConcepteFacturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteFamiliaConcepteFacturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamiliaConcepteFacturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetFamiliaConcepteFacturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetFamiliesConcepteFacturaAsync()
        {
            var response = await Sender.Send(new GetFamiliesConcepteFacturaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetFamiliaConcepteFacturaByTextAsync(string text)
        {
            var response = await Sender.Send(new GetFamiliesConcepteFacturaByTextQuery() { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
