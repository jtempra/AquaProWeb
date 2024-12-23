using AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusFactures;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusFacturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusFacturaAsync([FromBody] SaveTipusFacturaDTO createTipusFacturaDTO)
        {
            var response = await Sender.Send(new CreateTipusFacturaCommand { CreateTipusFactura = createTipusFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusFacturaAsync([FromBody] SaveTipusFacturaDTO updateTipusFacturaDTO)
        {
            var response = await Sender.Send(new UpdateTipusFacturaCommand { UpdateTipusFactura = updateTipusFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusFacturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusFacturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusFacturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusFacturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusFacturasAsync()
        {
            var response = await Sender.Send(new GetTipusFacturaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusFacturasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusFacturaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
