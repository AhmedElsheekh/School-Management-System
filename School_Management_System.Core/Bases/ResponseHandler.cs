using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Bases
{
    public class ResponseHandler
    {
        public Response<T> Success<T>(T data, string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = message == null ? "Successfull response" : message,
                Data = data
            };
        }

        public Response<T> Created<T>()
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Created,
                IsSuccess = true,
                Message = "Has been created successfully",
            };
        }

        public Response<T> NoContent<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.NoContent,
                IsSuccess = true,
                Message = message == null ? "No Content" : message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.NotFound,
                IsSuccess = false,
                Message = message == null ? "Not found" : message
            };
        }

        public Response<T> BadRequest<T>(string message = null, List<string> errors = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = message == null ? "Bad Request" : message,
                Errors = errors
            };
        }

        public Response<T> InternalServerError<T>(string message = null, List<string> errors = null)
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                IsSuccess = false,
                Message = message == null ? "Internal server error" : message,
                Errors = errors
            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Unauthorized,
                IsSuccess = false,
                Message = "Unauthorized"
            };
        }

        public Response<T> Forbidden<T>()
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Forbidden,
                IsSuccess = false,
                Message = "Forbidden"
            };
        }
    }
    
}
