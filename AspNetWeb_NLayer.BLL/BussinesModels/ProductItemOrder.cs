using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Models
{
    public class ProductItemOrder
    {
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int totalMonth { get; set; }
        public float totalPrice { get; set; }
    }
}
