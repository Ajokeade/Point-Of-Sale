using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSmvc.Models.PosViewModel
{
    public class MakeSalesData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<SalesDetail> SalesDetails { get; set; }
      
        public IEnumerable<Sales> Sales { get; set; }
        public Sales Sale { get; set; } // a sale entity
        public SalesDetail SalesDetail { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
