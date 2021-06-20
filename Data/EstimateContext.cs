using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XHomes.Models;

namespace XHomes.Data
{
    public class EstimateContext : DbContext

    {

        public DbSet<Estimate> Estimate { get; set; }

        public DbSet<Material> Material { get; set; }

        public DbSet<WorkTask> WorkTask { get; set; }

        public EstimateContext(DbContextOptions<EstimateContext> opt) : base(opt)
        {

           

        }

    }
}
