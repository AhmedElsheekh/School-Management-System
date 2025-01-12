using School_Management_System.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Responses
{
    public static class BaseResponseExtension
    {
        public static TData GetData<TData>(this BaseResponse response)
        {
            return ((SuccessResponse<TData>)response).Data;
        }
    }
}
