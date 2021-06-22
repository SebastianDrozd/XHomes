using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XHomes.Models;

namespace XHomes.Data
{
    public class EstimatePgRepo : IEstimatePgRepo
    {
        private readonly EstimateContext context;

        public EstimatePgRepo(EstimateContext estimateContext)
        {
            this.context = estimateContext;
        }


        public IEnumerable<Estimate> GetAllEstimates()
        {
            return context.Estimate.Include(b => b.materials).Include(b => b.tasks).ToList();
        }

        public void SaveEstimate(Estimate estimate)
        {
                     
           
            this.context.Add(estimate);

        }

        public bool SaveChanges()
        {

            return context.SaveChanges() >= 0;
        }

        public void DeleteEstimate(Estimate estimate)
        {

            


            context.Estimate.Remove(estimate);
            
        }

        public Estimate GetEstimate(int id)
        {
            return context.Estimate.Include(b => b.materials).Include(b=>b.tasks).FirstOrDefault(p => p.Id == id);

           
        }

        
    }
}
