using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode
    {
        public int code { get; protected set; }
        public string message { get; protected set; } = null!;

        public StatusCode(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
