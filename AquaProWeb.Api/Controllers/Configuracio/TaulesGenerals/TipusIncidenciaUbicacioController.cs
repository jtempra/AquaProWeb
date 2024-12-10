using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesUbicacions;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusIncidenciaUbicacioController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusIncidenciaUbicacioAsync([FromBody] CreateTipusIncidenciaUbicacioDTO createTipusIncidenciaUbicacioDTO)
        {
            var response = await Sender.Send(new CreateTipusIncidenciaUbicacioCommand { CreateTipusIncidenciaUbicacio = createTipusIncidenciaUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusIncidenciaUbicacioAsync([FromBody] UpdateTipusIncidenciaUbicacioDTO updateTipusIncidenciaUbicacioDTO)
        {
            var response = await Sender.Send(new UpdateTipusIncidenciaUbicacioCommand { UpdateTipusIncidenciaUbicacio = updateTipusIncidenciaUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusIncidenciaUbicacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusIncidenciaUbicacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusIncidenciaUbicacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusIncidenciaUbicacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusIncidenciaUbicaciosAsync()
        {
            var response = await Sender.Send(new GetTipusIncidenciaUbicacioQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusIncidenciaUbicaciosByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusIncidenciaUbicacioByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
