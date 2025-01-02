using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AquaProWeb.Api.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception is TimeoutException)
            {
                _logger.LogError(exception, "Error de Time Out!!!");

                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.RequestTimeout, "Error de tiempo de espera!");

                return true;
            }

            if (exception is ArgumentException)
            {
                _logger.LogError(exception, "Argument Exception!!!");

                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.BadRequest, "Error de parámetros!");

                return true;
            }

            //if (exception is ArgumentNullException)
            //{
            //    _logger.LogError(exception, "Argument Exception!!!");

            //    await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.BadRequest, "Parametros nulos!");

            //    return true;
            //}
            else
            {
                _logger.LogError(exception, "Unexpected Error!!!");

                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.InternalServerError, "Error inesperado!");

                return true;
            }

            return false;
        }

    }
}
