using System.Net;
using System.Text.Json;

namespace SeatManagement2.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            
            catch
            {
                context.Response.ContentType = "application/json";
                var errorResponse = new 
                {
                    statusCode =(int)HttpStatusCode.InternalServerError,
                    message = "Internal Server Error"
                };

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(result);
            }
           
        }
    }
}
