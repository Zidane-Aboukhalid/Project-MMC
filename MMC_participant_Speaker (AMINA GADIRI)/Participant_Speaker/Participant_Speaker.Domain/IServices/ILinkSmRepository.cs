using Participant_Speaker.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Domain.IServices
{
	public interface ILinkSmRepository
	{
		public Task<LinkSm> GetLinkSmByIdAsync(Guid linkSmId);
		public Task<List<LinkSm>> GetAllLinkSmsAsync();
		public Task<List<LinkSm>> GetLinkSmsBySpeakerAsync(Guid speakerId);
		public Task<int> AddLinkSmAsync(LinkSm linkSm);
		public Task<int> UpdateLinkSmAsync(LinkSm linkSm);
		public Task<int> RemoveLinkSmAsync(Guid linkSmId);
	}
}
