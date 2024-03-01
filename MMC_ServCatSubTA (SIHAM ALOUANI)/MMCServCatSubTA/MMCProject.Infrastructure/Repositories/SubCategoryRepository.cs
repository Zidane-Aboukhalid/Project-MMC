using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SubCategory;
using MMCProject.Domain.Entities;
using MMCProject.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Infrastructure.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly MMCDBContext _dBContext;
        private IMapper _mapper;
        public SubCategoryRepository(MMCDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<SubCategory> CreateAsync(OpSubCategoryViewModel opSubCategoryViewModel)
        {
            var subCategory = _mapper.Map<SubCategory>(opSubCategoryViewModel);
            subCategory.SubCategoryId = new Guid();
            await _dBContext.SubCategories.AddAsync(subCategory);
            await _dBContext.SaveChangesAsync();
            return subCategory;
        }
            
        public async Task<Guid> DeleteAsync(Guid id)
        {
            var subCategory = await _dBContext.SubCategories
             .Where(model => model.SubCategoryId == id)
             .FirstOrDefaultAsync();

            if (subCategory != null)
            {
                _dBContext.SubCategories.Remove(subCategory);
                await _dBContext.SaveChangesAsync();
                return id;
            }
            else
            {
                throw new Exception($"SubCategory with ID {id} not found");
            }
        }

        public async Task<List<SubCategory>> GetAllAsync()
        {
            return await _dBContext.SubCategories.ToListAsync();
        }

        public async Task<SubCategory> GetByIdAsync(Guid id)
        {
            var subCategory = await _dBContext.SubCategories.AsNoTracking()
                              .FirstOrDefaultAsync(u => u.SubCategoryId == id);

            if (subCategory == null)
            {
                throw new InvalidOperationException($"SubCategory with ID {id} not found");
            }

            return subCategory;
        }

        public async Task<int> UpdateAsync(Guid id, OpUpdateSubCategoryViewModel opUpdateSubCategoryViewModel)
        {
            var subcategory = await _dBContext.SubCategories.FindAsync(id);

            if (subcategory == null)
            {
                throw new InvalidOperationException($"SubCategory with ID {id} not found");
            }

            // Update individual properties
            subcategory.NameSubCategory = opUpdateSubCategoryViewModel.NameSubCategory;
            subcategory.CategoryId = opUpdateSubCategoryViewModel.CategoryId;

            // Save changes
            return await _dBContext.SaveChangesAsync();
        }
    }
}
