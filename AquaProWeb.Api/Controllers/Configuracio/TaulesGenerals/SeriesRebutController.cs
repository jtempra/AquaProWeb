using AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesRebut;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class SeriesRebutController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddSerieRebutAsync([FromBody] CreateSerieRebutDTO createSerieRebutDTO)
        {
            var response = await Sender.Send(new CreateSerieRebutCommand { CreateSerieRebut = createSerieRebutDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSerieRebutAsync([FromBody] UpdateSerieRebutDTO updateSerieRebutDTO)
        {
            var response = await Sender.Send(new UpdateSerieRebutCommand { UpdateSerieRebut = updateSerieRebutDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerieRebutAsync(int id)
        {
            var response = await Sender.Send(new DeleteSerieRebutCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerieRebutByIdAsync(int id)
        {
            var response = await Sender.Send(new GetSerieRebutByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetSeriesRebutAsync()
        {
            var response = await Sender.Send(new GetSeriesRebutQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSeriesRebutByTextAsync(string text)
        {
            var response = await Sender.Send(new GetSeriesRebutByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
