using AquaProWeb.Application.Features.Abonats.Escomeses.Commands;
using AquaProWeb.Application.Features.Abonats.Escomeses.Queries;
using AquaProWeb.Common.Requests.Abonats.Escomeses;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Abonats.Escomeses
{
    [Route("api/[controller]")]
    public class EscomesesController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddEscomesaAsync([FromBody] SaveEscomesaDTO createEscomesaDTO)
        {
            var response = await Sender.Send(new CreateEscomesaCommand { CreateEscomesa = createEscomesaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEscomesaAsync([FromBody] SaveEscomesaDTO updateEscomesaDTO)
        {
            var response = await Sender.Send(new UpdateEscomesaCommand { UpdateEscomesa = updateEscomesaDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscomesaAsync(int id)
        {
            var response = await Sender.Send(new DeleteEscomesaCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEscomesaByIdAsync(int id)
        {
            var response = await Sender.Send(new GetEscomesaByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetEscomesesAsync()
        {
            var response = await Sender.Send(new GetEscomesesQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetEscomesesByTextAsync(string text)
        {
            var response = await Sender.Send(new GetEscomesesByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
    }
}
