using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.DAL.Entities
{
    public class ProductOrder
    {
        public int id {  get; set; }
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int timeStudy { get; set; }
        public float sumPay { get; set; }
        public string guid { get; set; } = null!;
        public DateTime dateTime { get; set; }

    }
}
