using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaTitular;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class MotiusBaixaTitularController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMotiuBaixaTitularAsync([FromBody] SaveMotiuBaixaTitularDTO createMotiuBaixaTitularDTO)
        {
            var response = await Sender.Send(new CreateMotiuBaixaTitularCommand { CreateMotiuBaixaTitular = createMotiuBaixaTitularDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMotiuBaixaTitularAsync([FromBody] SaveMotiuBaixaTitularDTO updateMotiuBaixaTitularDTO)
        {
            var response = await Sender.Send(new UpdateMotiuBaixaTitularCommand { UpdateMotiuBaixaTitular = updateMotiuBaixaTitularDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotiuBaixaTitularAsync(int id)
        {
            var response = await Sender.Send(new DeleteMotiuBaixaTitularCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotiuBaixaTitularByIdAsync(int id)
        {
            var response = await Sender.Send(new GetMotiuBaixaTitularByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetMotiusBaixaTitularAsync()
        {
            var response = await Sender.Send(new GetMotiusBaixaTitularQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMotiusBaixaTitularByTextAsync(string text)
        {
            var response = await Sender.Send(new GetMotiusBaixaTitularByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
