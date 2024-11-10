using blog_management_service.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace blog_management_service.Middlewares
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorResponse errorResponse = new ErrorResponse()
            {
                Code = (int)StatusCodes.Status500InternalServerError,
                Message = exception.Message,
                Title = "Internal Server Error"
            };
            httpContext.Response.WriteAsJsonAsync(errorResponse);
            return ValueTask.FromResult(true);
        }
    }
}
