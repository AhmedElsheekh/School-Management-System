using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace School_Management_System.Core.Responses
{
    public class SuccessResponse<TResult> : BaseResponse
    {
        public SuccessResponse(TResult data, string message = null)
        {
            StatusCode = HttpStatusCode.OK;
            Message = message == null ? "Successfull response" : message;
            Data = data;
        }

        public TResult Data { get; set; }
    }
}
