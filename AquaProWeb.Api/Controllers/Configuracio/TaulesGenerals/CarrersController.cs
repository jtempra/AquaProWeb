﻿
using AquaProWeb.Application.Features.TaulesGenerals.Carrers.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.Carrers.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{

    [Route("api/[controller]")]
    public class CarrersController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddCarrerAsync([FromBody] SaveCarrerDTO createCarrerDTO)
        {
            var response = await Sender.Send(new CreateCarrerCommand { CreateCarrer = createCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCarrerAsync([FromBody] SaveCarrerDTO updateCarrerDTO)
        {
            var response = await Sender.Send(new UpdateCarrerCommand { UpdateCarrer = updateCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrerAsync(int id)
        {
            var response = await Sender.Send(new DeleteCarrerCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrerByIdAsync(int id)
        {
            var response = await Sender.Send(new GetCarrerByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("poblacio/{id}")]
        public async Task<IActionResult> GetCarrersByIdPoblacioAsync(int id)
        {
            var response = await Sender.Send(new GetCarrersByIdPoblacioQuery { IdPoblacio = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCarrersAsync()
        {
            var response = await Sender.Send(new GetCarrersQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCarrersByTextAsync(string text)
        {
            var response = await Sender.Send(new GetCarrersByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
