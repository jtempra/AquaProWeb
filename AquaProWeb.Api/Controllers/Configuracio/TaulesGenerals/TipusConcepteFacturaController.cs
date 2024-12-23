using AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusConceptesFactura;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusConcepteFacturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusConcepteFacturaAsync([FromBody] SaveTipusConcepteFacturaDTO createTipusConcepteFacturaDTO)
        {
            var response = await Sender.Send(new CreateTipusConcepteFacturaCommand { CreateTipusConcepteFactura = createTipusConcepteFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusConcepteFacturaAsync([FromBody] SaveTipusConcepteFacturaDTO updateTipusConcepteFacturaDTO)
        {
            var response = await Sender.Send(new UpdateTipusConcepteFacturaCommand { UpdateTipusConcepteFactura = updateTipusConcepteFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusConcepteFacturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusConcepteFacturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusConcepteFacturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusConcepteFacturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusConcepteFacturasAsync()
        {
            var response = await Sender.Send(new GetTipusConcepteFacturaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusConcepteFacturasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusConcepteFacturaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
