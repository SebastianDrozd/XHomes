using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XHomes.Models;

namespace XHomes.Data
{
    public interface ICustomerRepo
    {
        bool SaveChanges();
        public IEnumerable<Customer> GetCustomers();
        public Customer GetCustomerById(Guid id);
        void CreateCustomer(Customer customer);

    }
}
