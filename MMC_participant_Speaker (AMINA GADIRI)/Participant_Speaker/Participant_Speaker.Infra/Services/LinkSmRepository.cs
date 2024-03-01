using Microsoft.EntityFrameworkCore;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Infra.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Infra.Services
{
	public class LinkSmRepository : ILinkSmRepository
	{
		private readonly ApplicationContext _dbContext;

		public LinkSmRepository(ApplicationContext context)
        {
			this._dbContext = context;
		}

		public async Task<LinkSm> GetLinkSmByIdAsync(Guid linkSmId)
		{
			return await _dbContext.LinkSms.FindAsync(linkSmId);
		}

		public async Task<List<LinkSm>> GetAllLinkSmsAsync()
		{
			return await _dbContext.LinkSms.ToListAsync();
		}

		public async Task<List<LinkSm>> GetLinkSmsBySpeakerAsync(Guid speakerId)
		{
			return await _dbContext.LinkSms
				.Where(ls => ls.SpeakerId == speakerId)
				.ToListAsync();
		}

		public async Task<int> AddLinkSmAsync(LinkSm linkSm)
		{
			_dbContext.LinkSms.Add(linkSm);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> UpdateLinkSmAsync(LinkSm linkSm)
		{
			_dbContext.Entry(linkSm).State = EntityState.Modified;
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> RemoveLinkSmAsync(Guid linkSmId)
		{
			var linkSm = await _dbContext.LinkSms.FindAsync(linkSmId);
			if (linkSm != null)
			{
				_dbContext.LinkSms.Remove(linkSm);
				return await _dbContext.SaveChangesAsync();
			}
			return 0;
		}
	}
}
