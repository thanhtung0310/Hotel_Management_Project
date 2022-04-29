using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProvider
{
    public class Response<T>
    {
        public bool success { get; set; }

        public int? errorCode { get; set; }

        public string message { get; set; }

        public T Data { get; set; }
    }
}
