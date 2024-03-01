using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SubCategory;
using MMCProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategory>> GetAllAsync();
        Task<SubCategory> GetByIdAsync(Guid id);
        Task<SubCategory> CreateAsync(OpSubCategoryViewModel opSubCategoryViewModel );
        Task<int> UpdateAsync(Guid id, OpUpdateSubCategoryViewModel opUpdateSubCategoryViewModel);
        Task<Guid> DeleteAsync(Guid id);
    }
}
