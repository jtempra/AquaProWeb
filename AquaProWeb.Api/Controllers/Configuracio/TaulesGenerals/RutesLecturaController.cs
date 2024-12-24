
using AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.RutaLectura;

using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
	[Route("api/[controller]")]
	public class RutesLecturaController : BaseApiController
	{
		[HttpPost("add")]
		public async Task<IActionResult> AddRutaLecturaAsync([FromBody] SaveRutaLecturaDTO createRutaLecturaDTO)
		{
			var response = await Sender.Send(new CreateRutaLecturaCommand { CreateRutaLectura = createRutaLecturaDTO });

			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}

		[HttpPut("update")]
		public async Task<IActionResult> UpdateRutaLecturaAsync([FromBody] SaveRutaLecturaDTO updateRutaLecturaDTO)
		{
			var response = await Sender.Send(new UpdateRutaLecturaCommand { UpdateRutaLectura = updateRutaLecturaDTO });

			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRutaLecturaAsync(int id)
		{
			var response = await Sender.Send(new DeleteRutaLecturaCommand { Id = id });

			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetRutaLecturaByIdAsync(int id)
		{
			var response = await Sender.Send(new GetRutaLecturaByIdQuery { Id = id });

			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetRutaLecturasAsync()
		{
			var response = await Sender.Send(new GetRutesLecturaQuery());

			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[HttpGet("search")]
		public async Task<IActionResult> GetRutaLecturaByTextAsync(string text)
		{
			var response = await Sender.Send(new GetRutesLecturaByTextQuery { Text = text });

			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return NotFound(response);
		}
	}
}
