using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class UnauthorizedResponse : BaseResponse
    {
        public UnauthorizedResponse(string message = null)
        {
            StatusCode = HttpStatusCode.Unauthorized;
            Message = message == null ? "Unauthorized" : message;
        }
    }
}
