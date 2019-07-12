using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSmvc.Models
{
    public class SalesDetail
    {
        public int ID { get; set; }
       
        public int ProductID { get; set; }
        public int QuantityPurchased { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime DatePurchased { get; set; }

       // public int SalesID { get; set; }

        public int TransctionID { get; set; }
       // public Sales Sales { get; set; } //a salesDetail belong to one sale

        public Product Products { get; set; } // a salesDetail can have any number of products
                                              //public ICollection<Product> 
        public ICollection<SalesDetail> SalesDetails;
    }
}
