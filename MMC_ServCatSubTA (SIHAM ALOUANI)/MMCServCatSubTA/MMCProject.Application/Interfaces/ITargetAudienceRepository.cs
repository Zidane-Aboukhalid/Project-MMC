using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.TargetAudience;
using MMCProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.Interfaces
{
    public interface ITargetAudienceRepository
    {
        Task<List<TargetAudience>> GetAllAsync();
        Task<TargetAudience> GetByIdAsync(Guid id);
        Task<TargetAudience> CreateAsync(OpTargetAudienceViewModel opTargetAudienceViewModel);
        Task<int> UpdateAsync(Guid id, OpUpdateTargetAudienceViewModel opUpdateTargetAudienceViewModel);
        Task<Guid> DeleteAsync(Guid id);    
    }
}
