using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.SubCategory;
using MMCProject.Application.ViewModel.TargetAudience;
using MMCProject.Domain.Entities;
using MMCProject.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Infrastructure.Repositories
{
    public class TargetAudienceRepository : ITargetAudienceRepository
    {
        private readonly MMCDBContext _dBContext;
        private IMapper _mapper;
        public TargetAudienceRepository(MMCDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<TargetAudience> CreateAsync(OpTargetAudienceViewModel opTargetAudienceViewModel)
        {
            var targetAudience = _mapper.Map<TargetAudience>(opTargetAudienceViewModel);
            targetAudience.TargetAudienceId = new Guid();
            await _dBContext.TargetAudiences.AddAsync(targetAudience);
            await _dBContext.SaveChangesAsync();
            return targetAudience;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var targetAudience = await _dBContext.TargetAudiences
            .Where(model => model.TargetAudienceId == id)
            .FirstOrDefaultAsync();

            if (targetAudience != null)
            {
                _dBContext.TargetAudiences.Remove(targetAudience);
                await _dBContext.SaveChangesAsync();
                return id;
            }
            else
            {
                throw new Exception($"TargetAudience with ID {id} not found");
            }
        }

        public async Task<List<TargetAudience>> GetAllAsync()
        {
            return await _dBContext.TargetAudiences.Include(x => x.SesionTargetAudiences).ToListAsync();
        }

        public async Task<TargetAudience> GetByIdAsync(Guid id)
        {
            var targetAudience = await _dBContext.TargetAudiences.AsNoTracking()
                                .FirstOrDefaultAsync(u => u.TargetAudienceId == id);

            if (targetAudience == null)
            {
                throw new InvalidOperationException($"TargetAudience with ID {id} not found");
            }

            return targetAudience;
        }

        public async Task<int> UpdateAsync(Guid id, OpUpdateTargetAudienceViewModel opUpdateTargetAudienceViewModel)
        {
            var targetAudience = await _dBContext.TargetAudiences.FindAsync(id);

            if (targetAudience == null)
            {
                throw new InvalidOperationException($"TargetAudience with ID {id} not found");
            }

            // Update individual properties
            targetAudience.NameTargetAudience = opUpdateTargetAudienceViewModel.NameTargetAudience;

            // Save changes
            return await _dBContext.SaveChangesAsync();

        }
    }
}
