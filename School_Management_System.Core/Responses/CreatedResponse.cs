using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class CreatedResponse : BaseResponse
    {
        public CreatedResponse(string message = null)
        {
            StatusCode = HttpStatusCode.Created;
            Message = message == null ? "Created Successfully" : message;
        }
    }
}
