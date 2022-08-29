using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Core.Models.Base
{
    public class EntityResponse<T>
    {
        public T Data { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
