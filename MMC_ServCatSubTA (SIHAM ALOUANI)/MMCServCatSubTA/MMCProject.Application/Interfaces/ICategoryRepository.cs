using MMCProject.Application.ViewModel.Category;
using MMCProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(OpCategoryViewModel opCategoryViewModel);
        Task<int> UpdateAsync(Guid id , OpUpdateCategoryViewModel opUpdateCategoryViewModel);
        Task<Guid> DeleteAsync(Guid id);    
    }
}
        