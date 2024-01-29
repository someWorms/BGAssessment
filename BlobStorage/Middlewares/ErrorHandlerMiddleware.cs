using System.Net;
using System.Text.Json;

namespace BlobStorage.API.Middlewares
{
    /// <summary>
    ///     Error handler middleware.
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = (int)HttpStatusCode.NotFound;

                string result = JsonSerializer.Serialize(new { message = ex?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
