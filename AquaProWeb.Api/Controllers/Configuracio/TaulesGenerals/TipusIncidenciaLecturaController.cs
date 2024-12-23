using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesLectures;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusIncidenciaLecturaController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusIncidenciaLecturaAsync([FromBody] SaveTipusIncidenciaLecturaDTO createTipusIncidenciaLecturaDTO)
        {
            var response = await Sender.Send(new CreateTipusIncidenciaLecturaCommand { CreateTipusIncidenciaLectura = createTipusIncidenciaLecturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusIncidenciaLecturaAsync([FromBody] SaveTipusIncidenciaLecturaDTO updateTipusIncidenciaLecturaDTO)
        {
            var response = await Sender.Send(new UpdateTipusIncidenciaLecturaCommand { UpdateTipusIncidenciaLectura = updateTipusIncidenciaLecturaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusIncidenciaLecturaAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusIncidenciaLecturaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusIncidenciaLecturaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusIncidenciaLecturaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusIncidenciaLecturasAsync()
        {
            var response = await Sender.Send(new GetTipusIncidenciaLecturaQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusIncidenciaLecturasByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusIncidenciaLecturaByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
