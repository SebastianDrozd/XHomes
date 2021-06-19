using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XHomes.Models;

namespace XHomes.Data
{
    public class CustomerContext : DbContext
    {

        public DbSet<Customer> Customers {get; set;}

        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {

        }

        public CustomerContext()
        {
        }
    }
}
