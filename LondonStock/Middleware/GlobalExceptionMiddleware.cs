using System.Net;
using System.Text.Json;

namespace LondonStock.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                var statusCode = ex switch
                {
                    KeyNotFoundException => (int)HttpStatusCode.NotFound, // 404
                    InvalidOperationException => (int)HttpStatusCode.BadRequest, // 400
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // 401
                    _ => (int)HttpStatusCode.InternalServerError // 500
                };

                var response = new
                {
                    StatusCode = statusCode,
                    Message = ex.Message,
                    Timestamp = DateTime.UtcNow
                };

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
