using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode
    {
        public int code { get; }
        public string message { get; } = null!;

        public StatusCode(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
