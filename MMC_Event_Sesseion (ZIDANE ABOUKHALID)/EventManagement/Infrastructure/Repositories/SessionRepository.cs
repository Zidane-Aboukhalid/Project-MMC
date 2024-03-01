using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly EventManagementDbContext dbContext;
        public SessionRepository(EventManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Session> CreateAsync(Session session)
        {
            await dbContext.Sessions.AddAsync(session);
            await dbContext.SaveChangesAsync();
            return session;
        }

        public async Task<Session?> DeleteAsync(Guid id)
        {
            var existingSession = await dbContext.Sessions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingSession == null)
            {
                return null;
            }

            dbContext.Sessions.Remove(existingSession);
            await dbContext.SaveChangesAsync();
            return existingSession;
        }

        public async Task<List<Session>> GetAllAsync()
        {
            return await dbContext.Sessions.ToListAsync();
        }

        public async Task<Session?> GetByIdAsync(Guid id)
        {
            return await dbContext.Sessions.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<bool> UpdateAsync(Session session)
        {
            if (session != null)
            {
                dbContext.Set<Session>().Update(session);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

    }
}
