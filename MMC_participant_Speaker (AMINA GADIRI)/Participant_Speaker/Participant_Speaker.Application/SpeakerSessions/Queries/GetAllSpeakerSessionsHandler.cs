using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.SpeakerSessions.Queries
{
	public class GetAllSpeakerSessionsHandler:IRequestHandler<GetAllSpeakerSessions, List<SelectSpeakerSession>>
	{
		private readonly ISpeakerSessionRepository speakerSessionRepository;
		private readonly IMapper mapper;

		public GetAllSpeakerSessionsHandler(ISpeakerSessionRepository speakerSessionRepository,IMapper mapper)
        {
			this.speakerSessionRepository = speakerSessionRepository;
			this.mapper = mapper;
		}

		public async Task<List<SelectSpeakerSession>> Handle(GetAllSpeakerSessions request, CancellationToken cancellationToken)
		{
			return mapper.Map<List<SelectSpeakerSession>>(await speakerSessionRepository.GetAllSpeakerSessionsAsync());
		}
	}
}
