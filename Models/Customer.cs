using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XHomes.Models
{
    public class Customer
    {   
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }


        [Required]
        public string zip { get; set; }


        [Required]
        public string phone { get; set; }


        [Required]
        public string email{ get; set; }


        [Required]
        public string description { get; set; }
    }
}
