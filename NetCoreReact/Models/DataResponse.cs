using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReact.Models
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
