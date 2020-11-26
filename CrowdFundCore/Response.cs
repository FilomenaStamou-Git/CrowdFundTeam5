using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundCore
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
    

}
