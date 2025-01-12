using System.Net;

namespace School_Management_System.API.Utilities
{
    public class ApiExceptionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public ApiExceptionResponse(HttpStatusCode statusCode, string? message = null, string? details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
    }
}
