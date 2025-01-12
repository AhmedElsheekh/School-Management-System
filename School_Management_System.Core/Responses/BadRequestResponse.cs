using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class BadRequestResponse : BaseResponse
    {
        public BadRequestResponse(string message = null)
        {
            StatusCode = HttpStatusCode.BadRequest;
            Message = message == null ? "Bad Request" : message;
        }
    }
}
