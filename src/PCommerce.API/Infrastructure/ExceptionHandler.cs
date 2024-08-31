using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;


namespace PCommerce.API.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int statusCode;

            string responseMessage;

            if(exception is ValidationException validationException)
            {
                var errorMessage = validationException.Errors.Select(e => e.ErrorMessage);

                responseMessage = string.Join("\n", errorMessage);

                statusCode = 400;
            }
            else
            {
                responseMessage = exception.Message;

                statusCode = 500;
            }
            
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "text/plain";
            await httpContext.Response.WriteAsync(responseMessage, cancellationToken);
            
            return true;
        }
    }
}
