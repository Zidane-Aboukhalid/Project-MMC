using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.SessionTargetAudience;
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
    public class SessionTargetAudienceRepository : ISessionTargetAudienceRepository
    {

        private readonly MMCDBContext _dBContext;
        private IMapper _mapper;
        public SessionTargetAudienceRepository(MMCDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<SessionTargetAudience> CreateAsync(OpSessionTargetAudienceViewModel opSessionTargetAudienceViewModel)
        {
            var sessionTargetAudience = _mapper.Map<SessionTargetAudience>(opSessionTargetAudienceViewModel);
            sessionTargetAudience.SessionTargetAudienceId = new Guid();
            await _dBContext.SessionTargetAudiences.AddAsync(sessionTargetAudience);
            await _dBContext.SaveChangesAsync();
            return sessionTargetAudience;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var sessionTargetAudience = await _dBContext.SessionTargetAudiences
             .Where(model => model.SessionTargetAudienceId == id)
             .FirstOrDefaultAsync();

            if (sessionTargetAudience != null)
            {
                _dBContext.SessionTargetAudiences.Remove(sessionTargetAudience);
                await _dBContext.SaveChangesAsync();
                return id;
            }
            else
            {
                throw new Exception($"SessionTargetAudience with ID {id} not found");
            }
        }

        public async Task<List<SessionTargetAudience>> GetAllAsync()
        {
            return await _dBContext.SessionTargetAudiences.ToListAsync();
        }

        public async Task<SessionTargetAudience> GetByIdAsync(Guid id)
        {
            var sessionTargetAudience = await _dBContext.SessionTargetAudiences.AsNoTracking()
                                .FirstOrDefaultAsync(u => u.SessionTargetAudienceId == id);

            if (sessionTargetAudience == null)
            {
                throw new InvalidOperationException($"SessionTargetAudience with ID {id} not found");
            }

            return sessionTargetAudience;
        }

        public async Task<List<SessionTargetAudience>> GetBySessionIdAsync(Guid id)
        {
            var sessionTargetAudience = await _dBContext.SessionTargetAudiences.AsNoTracking()
                                .Where(u => u.SessionId == id).ToListAsync();

            if (sessionTargetAudience == null)
            {
                throw new InvalidOperationException($"Session with ID {id} not found");
            }

            return sessionTargetAudience;
        }

        public async  Task<int> UpdateAsync(Guid id, OpUpdateSessionTargetAudienceViewModel opUpdateSessionTargetAudienceViewModel)
        {
            var sessionTA = await _dBContext.SessionTargetAudiences.FindAsync(id);

            if (sessionTA == null)
            {
                throw new InvalidOperationException($"SessionTargetAudience with ID {id} not found");
            }

            // Update individual properties
            sessionTA.SessionId = opUpdateSessionTargetAudienceViewModel.SessionId;
            sessionTA.TargetAudienceId = opUpdateSessionTargetAudienceViewModel.TargetAudienceId;

            // Save changes
            return await _dBContext.SaveChangesAsync();
        }
    }
}
