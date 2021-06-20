using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XHomes.Models
{
    public class Estimate
    {

        public int Id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string description { get; set; }

        public string jobType { get; set; }

        public int difficulty { get; set; }

        public int condition { get; set; }

        public string workDescription { get; set; }

        public virtual List<WorkTask> tasks { get; set; }

        public string  matDescription { get; set; }

        public virtual List<Material> materials { get; set; }

        public string fileName { get; set; }

        public string filePath { get; set; }
       
        public override string ToString()
        {

            return firstName + lastName + city + state + zip + phone + email + description;
        }


    }
}
