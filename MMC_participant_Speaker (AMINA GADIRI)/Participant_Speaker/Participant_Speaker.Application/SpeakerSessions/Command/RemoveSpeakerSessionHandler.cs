using MediatR;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.SpeakerSessions.Command
{
	public class RemoveSpeakerSessionHandler:IRequestHandler<RemoveSpeakerSession,int>
	{
		private readonly ISpeakerSessionRepository speakerSessionRepository;

		public RemoveSpeakerSessionHandler(ISpeakerSessionRepository speakerSessionRepository)
        {
			this.speakerSessionRepository = speakerSessionRepository;
		}

		public async Task<int> Handle(RemoveSpeakerSession request, CancellationToken cancellationToken)
		{
			return await speakerSessionRepository.RemoveSpeakerSessionAsync(request.id);
		}
	}
}
