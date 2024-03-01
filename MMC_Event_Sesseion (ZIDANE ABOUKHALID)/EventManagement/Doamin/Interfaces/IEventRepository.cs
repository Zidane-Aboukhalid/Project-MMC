using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<List<Event>> GetEventOfThisWeek();
        Task<Event?> GetByIdAsync(Guid id);
        Task<List<Event>> FiltrerParDate(DateTime? sortBy = null);
        Task<Event> CreateAsync(Event events);

        Task<bool> UpdateAsync(Event events);

        Task<Event?> DeleteAsync(Guid id);
        
        IQueryable<Event> IncludeSessions();
        Task<int> SaveAsync();
    }
}
