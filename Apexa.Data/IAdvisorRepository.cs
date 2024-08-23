using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.Data
{
    public interface IAdvisorRepository
    {
        Task<int> SaveChangesAsync();
        Task<bool> SinExists(string sin);
        Task<bool> AdviorExists(int advisorId);
        Task<List<Advisor>> GetAdvisors();
        Task<Advisor?> GetAdvisorById(int advisorId);
        Task<bool> AddAdvior(Advisor advisor);
        bool DeleteAdvisor(Advisor advisor);
    }
}