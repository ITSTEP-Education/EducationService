using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class ProductItemException : Exception
    {
        public string property { get; } = null!;
        public int code { get; }
        public ProductItemException(int code, string message, string property) : base(message) 
        { 
            this.property = property;
            this.code = code;
        }

        public ProductItemException(ProductItemException ex) : base(ex.Message) { this.property = ex.property; }

    }
}
