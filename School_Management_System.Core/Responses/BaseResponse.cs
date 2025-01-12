using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Responses
{
    public abstract class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
