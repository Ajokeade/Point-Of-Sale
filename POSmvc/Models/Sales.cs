using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace POSmvc.Models
{
    public class Sales
    {
        public int ID { get; set; }

       
        public int TransctionID { get; set; }
        public decimal TotalAmount { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal Balance { get; set; }
        public DateTime TranscationDate { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } // a sale belong to one customer
       // public int? CategoryID { get; set; }

        //public ICollection<Customer> Customers { get; set; }
        // public ICollection<Category> Categories { get; set; }
        //  public ICollection<Product> Products { get; set; }
    }
}
