using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class InternalServerErrorResponse : BaseResponse
    {
        public InternalServerErrorResponse(string message = null)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            Message = message == null ? "Internal server error" : message;
        }
    }
}
