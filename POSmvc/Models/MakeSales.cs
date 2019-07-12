using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSmvc.Models
{
    public class MakeSales
    {
        public int ID { get; set; }


        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int QuanitityPurchased{ get; set; }

         public string  SubTotal { get; set; }
    }
}
