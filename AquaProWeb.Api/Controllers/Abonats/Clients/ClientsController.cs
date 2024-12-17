using AquaProWeb.Application.Features.Abonats.Clients.Queries;

using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Abonats.Clients
{
    [Route("api/[controller]")]
    public class ClientsController : BaseApiController
    {
        //[HttpPost("add")]
        //public async Task<IActionResult> AddClientAsync([FromBody] CreateClientDTO createClientDTO)
        //{
        //    var response = await Sender.Send(new CreateClientCommand { CreateClient = createClientDTO });

        //    if (response.IsSuccessful)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response);
        //}

        //[HttpPut("update")]
        //public async Task<IActionResult> UpdateClientAsync([FromBody] UpdateClientDTO updateClientDTO)
        //{
        //    var response = await Sender.Send(new UpdateClientCommand { UpdateClient = updateClientDTO });

        //    if (response.IsSuccessful)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClientAsync(int id)
        //{
        //    var response = await Sender.Send(new DeleteClientCommand { Id = id });

        //    if (response.IsSuccessful)
        //    {
        //        return Ok(response);
        //    }
        //    return BadRequest(response);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetClientByIdAsync(int id)
        //{
        //    var response = await Sender.Send(new GetClientByIdQuery { Id = id });

        //    if (response.IsSuccessful)
        //    {
        //        return Ok(response);
        //    }
        //    return NotFound(response);
        //}

        [HttpGet("all")]
        public async Task<IActionResult> GetClientsAsync()
        {
            var response = await Sender.Send(new GetClientsQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        //[HttpGet("search")]
        //public async Task<IActionResult> GetClientsByTextAsync(string text)
        //{
        //    var response = await Sender.Send(new GetClientsByTextQuery { Text = text });

        //    if (response.IsSuccessful)
        //    {
        //        return Ok(response);
        //    }
        //    return NotFound(response);
        //}
    }
}
