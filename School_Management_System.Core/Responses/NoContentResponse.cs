using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class NoContentResponse : BaseResponse
    {
        public NoContentResponse(string message = null)
        {
            StatusCode = HttpStatusCode.NoContent;
            Message = message == null ? "No content" : message;
        }
    }
}
