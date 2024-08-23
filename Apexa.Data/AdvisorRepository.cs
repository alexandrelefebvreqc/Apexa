using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly ApexaDbContext _apexaDbContext;

        public AdvisorRepository(ApexaDbContext apexaDbContext)
        {
            _apexaDbContext = apexaDbContext;
        }

        public async Task<bool> SinExists(string sin)
        {
            return await _apexaDbContext.Advisors.AnyAsync(a => a.Sin == sin);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _apexaDbContext.SaveChangesAsync();
        }

        public async Task<bool> AddAdvior(Advisor advisor)
        {
            var result = await _apexaDbContext.Advisors.AddAsync(advisor);
            return result.State == EntityState.Modified;
        }

        public Task<bool> AdviorExists(int advisorId)
        {
           return _apexaDbContext.Advisors.AnyAsync(a => a.AdvisorId == advisorId);
        }

        public bool DeleteAdvisor(Advisor advisor)
        {
            var result = _apexaDbContext.Advisors.Remove(advisor);
            return result.State == EntityState.Deleted;
        }

        public async Task<Advisor?> GetAdvisorById(int advisorId)
        {
            return await _apexaDbContext.Advisors.Where(a => a.AdvisorId == advisorId).FirstOrDefaultAsync();
        }

        public async Task<List<Advisor>> GetAdvisors()
        {
            return await _apexaDbContext.Advisors.AsNoTracking().ToListAsync();
        }
    }
}
