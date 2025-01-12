using FluentValidation;
using School_Management_System.API.Utilities;
using System.Net;
using System.Text.Json;


namespace School_Management_System.API.Midddlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                httpContext.Response.ContentType = "application/json";

                ApiExceptionResponse response;
                if (ex.GetType() == typeof(ValidationException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new ApiExceptionResponse(HttpStatusCode.BadRequest, ex.Message);
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = _environment.IsDevelopment() ?
                     new ApiExceptionResponse(HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace) :
                     new ApiExceptionResponse(HttpStatusCode.InternalServerError);
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var responseInJson = JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsync(responseInJson);
            }
        }

    }
}
