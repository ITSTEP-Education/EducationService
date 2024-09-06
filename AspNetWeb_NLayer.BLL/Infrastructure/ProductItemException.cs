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
        public ProductItemException(string message, string property) : base(message) 
        { 
            this.property = property;
        }
    }
}
