using AquaProWeb.Application.Features.Abonats.PuntsSubministrament.Queries;
using AquaProWeb.Application.Features.Abonats.Ubicacions.Commands;
using AquaProWeb.Application.Features.Abonats.Ubicacions.Queries;
using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Abonats.PuntsSubministrament
{
    [Route("api/[controller]")]
    public class UbicacionsController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddUbicacioAsync([FromBody] SaveUbicacioDTO createUbicacioDTO)
        {
            var response = await Sender.Send(new CreateUbicacioCommand { CreateUbicacio = createUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUbicacioAsync([FromBody] SaveUbicacioDTO updateUbicacioDTO)
        {
            var response = await Sender.Send(new UpdateUbicacioCommand { UpdateUbicacio = updateUbicacioDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacioAsync(int id)
        {
            var response = await Sender.Send(new DeleteUbicacioCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUbicacioByIdAsync(int id)
        {
            var response = await Sender.Send(new GetUbicacioByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUbicacionsAsync()
        {
            var response = await Sender.Send(new GetUbicacionsQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetUbicacionsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetUbicacionsByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
