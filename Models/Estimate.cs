using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XHomes.Models
{
    public class Estimate
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string description { get; set; }

        public override string ToString()
        {
            return firstName + lastName + city + state + zip + phone + email + description;
        }


    }
}
