﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSmvc.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

       // public ICollection<Sales> Sales { get; set; }
    }
}
