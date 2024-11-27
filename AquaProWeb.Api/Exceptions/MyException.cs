using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AquaProWeb.Api.Exceptions
{
    public class MyException
    {
        public static async Task ExceptionMessage(HttpContext httpContext, System.Exception exception,
            HttpStatusCode httpStatusCode, string title)
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Type = exception.GetType().Name,
                Title = "Error de argumentos!",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });
        }
    }
}
