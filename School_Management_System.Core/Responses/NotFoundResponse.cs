using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class NotFoundResponse : BaseResponse
    {
        public NotFoundResponse(string message = null)
        {
            StatusCode = HttpStatusCode.NotFound;
            Message = message == null ? "Not found" : message;
        }
    }
}
