using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Bases
{
    public class Response<T>
    {
        public Response()
        {

        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public object Meta { get; set; }
        public T Data { get; set; }
    }
}
