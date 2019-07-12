using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSmvc.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int QuantityAvailable { get; set; }

        //foreign key
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
