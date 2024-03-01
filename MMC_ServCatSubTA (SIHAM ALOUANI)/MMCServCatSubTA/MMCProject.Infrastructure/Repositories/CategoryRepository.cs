using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Domain.Entities;
using MMCProject.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MMCDBContext _dBContext;
        private IMapper _mapper;
        public CategoryRepository(MMCDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<Category> CreateAsync(OpCategoryViewModel opCategoryViewModel)
        {

            var category = _mapper.Map<Category>(opCategoryViewModel);
            category.CategoryId = new Guid();
            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();
            return category;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {

            var category = await _dBContext.Categories
              .Where(model => model.CategoryId == id)
              .FirstOrDefaultAsync();

            if (category != null)
            {
                _dBContext.Categories.Remove(category);
                await _dBContext.SaveChangesAsync();
                return id; 
            }
            else
            {
                throw new Exception($"Category with ID {id} not found");
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dBContext.Categories.Include(x => x.SubCategories).ToListAsync();
        }

        public async  Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _dBContext.Categories.AsNoTracking()
                          .FirstOrDefaultAsync(u => u.CategoryId == id);

            if (category == null)
            {
                throw new InvalidOperationException($"Category with ID {id} not found");
            }

            return category;
        }

        public async Task<int> UpdateAsync(Guid id, OpUpdateCategoryViewModel opUpdateCategoryViewModel)
        {
            var category = await _dBContext.Categories.FindAsync(id);

            if (category == null)
            {
                throw new InvalidOperationException($"Category with ID {id} not found");
            }

            // Update individual properties
            category.NameCategory = opUpdateCategoryViewModel.NameCategory;

            // Save changes
            return await _dBContext.SaveChangesAsync();

        }
    }
}
