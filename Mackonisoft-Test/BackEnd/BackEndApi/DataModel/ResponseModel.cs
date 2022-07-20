using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class ResponseModel<T>
    {
        public string ExceptionMessage { get; set; }

        public bool Status { get; set; }

        public T Data { get; set; }
    }
}
