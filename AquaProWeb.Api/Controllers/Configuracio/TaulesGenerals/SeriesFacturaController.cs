using AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesFactura;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class SeriesFacturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddSerieFacturaAsync([FromBody] SaveSerieFacturaDTO createSerieFacturaDTO)
        {
            var response = await Sender.Send(new CreateSerieFacturaCommand { CreateSerieFactura = createSerieFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSerieFacturaAsync([FromBody] SaveSerieFacturaDTO updateSerieFacturaDTO)
        {
            var response = await Sender.Send(new UpdateSerieFacturaCommand { UpdateSerieFactura = updateSerieFacturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerieFacturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteSerieFacturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerieFacturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetSerieFacturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetSeriesFacturasAsync()
        {
            var response = await Sender.Send(new GetSeriesFacturaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSeriesFacturasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetSeriesFacturaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
