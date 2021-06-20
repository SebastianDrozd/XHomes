using System.Collections.Generic;
using XHomes.Models;

namespace XHomes.Data
{
    public interface IEstimatePgRepo
    {
        IEnumerable<Estimate> GetAllEstimates();
        bool SaveChanges();
        void SaveEstimate(Estimate estimate);

        void DeleteEstimate(Estimate estimate);

        Estimate GetEstimate(int id);
    }
}