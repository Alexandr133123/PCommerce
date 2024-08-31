using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;

namespace PCommerce.API.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
       
        public async  ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int statusCode;
            string responseMessage;

            if(exception is ValidationException validation)
            {
                responseMessage = string.Join("\n" , validation.Errors.Select(p => p.ErrorMessage));
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
