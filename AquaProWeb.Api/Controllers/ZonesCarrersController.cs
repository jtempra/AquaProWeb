﻿using AquaProWeb.Application.Features.ZonesCarrers.Commands;
using AquaProWeb.Application.Features.ZonesCarrers.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers
{
    [Route("api/[controller]")]
    public class ZonesCarrersController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddZonaCarrerAsync([FromBody] CreateZonaCarrerDTO createZonaCarrerDTO)
        {
            var response = await Sender.Send(new CreateZonaCarrerCommand { CreateZonaCarrer = createZonaCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateZonaCarrerAsync([FromBody] UpdateZonaCarrerDTO updateZonaCarrerDTO)
        {
            var response = await Sender.Send(new UpdateZonaCarrerCommand { UpdateZonaCarrer = updateZonaCarrerDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZonaCarrerAsync(int id)
        {
            var response = await Sender.Send(new DeleteZonaCarrerCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZonaCarrerByIdAsync(int id)
        {
            var response = await Sender.Send(new GetZonaCarrerByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetZonesCarrerAsync()
        {
            var response = await Sender.Send(new GetZonesCarrerQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }

            return NotFound(response);
        }


    }
}