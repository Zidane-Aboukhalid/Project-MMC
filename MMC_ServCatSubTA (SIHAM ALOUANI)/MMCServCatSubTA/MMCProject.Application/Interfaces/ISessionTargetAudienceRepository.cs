using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using MMCProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.Interfaces
{
    public interface ISessionTargetAudienceRepository
    {
        Task<List<SessionTargetAudience>> GetAllAsync();
        Task<SessionTargetAudience> GetByIdAsync(Guid id);
        Task<List<SessionTargetAudience>> GetBySessionIdAsync(Guid id);
        Task<SessionTargetAudience> CreateAsync(OpSessionTargetAudienceViewModel opSessionTargetAudienceViewModel);
        Task<int> UpdateAsync(Guid id, OpUpdateSessionTargetAudienceViewModel opUpdateSessionTargetAudienceViewModel);
        Task<Guid> DeleteAsync(Guid id);
    }
}   
    