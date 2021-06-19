using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XHomes.Models;

namespace XHomes.Data
{
    public class PgCustomerRepo : ICustomerRepo
    {
        private readonly CustomerContext context;

        public PgCustomerRepo(CustomerContext context)
        {
            this.context = context;
        }
        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            context.Add(customer);
        }

        public Customer GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }
    }
}
