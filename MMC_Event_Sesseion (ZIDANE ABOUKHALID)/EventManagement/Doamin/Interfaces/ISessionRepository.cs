using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task<List<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(Guid id);

        Task<Session> CreateAsync(Session session);

        Task<bool> UpdateAsync(Session session);

        Task<Session?> DeleteAsync(Guid id);
        Task<int> SaveAsync();
    }
}
