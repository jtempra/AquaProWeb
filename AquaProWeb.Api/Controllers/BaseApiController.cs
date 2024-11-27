using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AquaProWeb.Api.Controllers
{

    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private ISender _sender = null;

        public ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
