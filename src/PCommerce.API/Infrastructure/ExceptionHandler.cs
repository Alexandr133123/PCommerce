using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


namespace PCommerce.API.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        public int statusCode;
        public string responseMessage;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ValidationException ex)
            {
                var errorMassage = ex.Errors.Select(x => x.ErrorMessage);
                responseMessage = string.Join("\n", errorMassage);
                statusCode = 400;
            }
            else
            {
                responseMessage = exception.Message;
                statusCode = 500;
            }
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "text / plain";
            await httpContext.Response.WriteAsync(responseMessage, cancellationToken);
            return true;
        }
    }
}
