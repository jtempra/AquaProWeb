using AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Commands;
using AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Queries;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusDocuments;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers.Configuracio.TaulesGenerals
{
    [Route("api/[controller]")]
    public class TipusDocumentController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddTipusDocumentAsync([FromBody] CreateTipusDocumentDTO createTipusDocumentDTO)
        {
            var response = await Sender.Send(new CreateTipusDocumentCommand { CreateTipusDocument = createTipusDocumentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTipusDocumentAsync([FromBody] UpdateTipusDocumentDTO updateTipusDocumentDTO)
        {
            var response = await Sender.Send(new UpdateTipusDocumentCommand { UpdateTipusDocument = updateTipusDocumentDTO });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipusDocumentAsync(int id)
        {
            var response = await Sender.Send(new DeleteTipusDocumentCommand { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipusDocumentByIdAsync(int id)
        {
            var response = await Sender.Send(new GetTipusDocumentByIdQuery { Id = id });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTipusDocumentsAsync()
        {
            var response = await Sender.Send(new GetTipusDocumentQuery());

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTipusDocumentsByTextAsync(string text)
        {
            var response = await Sender.Send(new GetTipusDocumentByTextQuery { Text = text });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
