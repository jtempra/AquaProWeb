using AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioFactura;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class SituacionsFacturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddSituacioFacturaAsync([FromBody] CreateSituacioFacturaDTO createSituacioFacturaDTO)
        {
            var response = await Sender.Send(new CreateSituacioFacturaCommand { CreateSituacioFactura = createSituacioFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSituacioFacturaAsync([FromBody] UpdateSituacioFacturaDTO updateSituacioFacturaDTO)
        {
            var response = await Sender.Send(new UpdateSituacioFacturaCommand { UpdateSituacioFactura = updateSituacioFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSituacioFacturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteSituacioFacturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSituacioFacturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetSituacioFacturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetSituacionsFacturasAsync()
        {
            var response = await Sender.Send(new GetSituacionsFacturaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSituacionsFacturasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetSituacionsFacturaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
