using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;

namespace PCommerce.API.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
       
        public async  ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "text/plain";
            await httpContext.Response.WriteAsync(exception.Message, cancellationToken);

            return true;
        }
    }
}
