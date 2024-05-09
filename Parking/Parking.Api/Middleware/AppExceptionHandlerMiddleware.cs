using Parking.Domain.Exceptions;
using Parking.Infrastructure.Exceptions;
using System.Net;

namespace Parking.Api.Middleware
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionHandlerMiddleware> _logger;
        private const string LOG_ERROR = "Se ha presentado un error no controlado {exception.Message} {exception.StackTrace}";
        private const string LOG_INFORMACION = "Se ha presentado un error controlado {exception.Message} {exception.StackTrace}";

        public AppExceptionHandlerMiddleware(RequestDelegate next, ILogger<AppExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    MensajeError = exception.Message
                });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = exception switch
                {
                    ArgumentNullException => (int)HttpStatusCode.BadRequest,
                    VehiculeMotorCycleException => (int)HttpStatusCode.BadRequest,
                    BrockerException => (int)HttpStatusCode.InternalServerError,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                if (context.Response.StatusCode == (int)HttpStatusCode.BadRequest)
                {
                    _logger.LogInformation(exception, LOG_INFORMACION, exception.Message, exception.StackTrace);
                }
                else
                {
                    _logger.LogError(exception, LOG_ERROR, exception.Message, exception.StackTrace);
                }

                await context.Response.WriteAsync(result);
            }
        }
    }
}
