using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.SpeakerSessions.Queries;

public class GetSpeakerSessionsBySpeakerHandler:IRequestHandler<GetSpeakerSessionsBySpeaker, List<SelectSpeakerSession>>
{

		private readonly ISpeakerSessionRepository speakerSessionRepository;
		private readonly IMapper mapper;

		public GetSpeakerSessionsBySpeakerHandler(ISpeakerSessionRepository speakerSessionRepository, IMapper mapper)
		{
			this.speakerSessionRepository = speakerSessionRepository;
			this.mapper = mapper;
		}

	public async Task<List<SelectSpeakerSession>> Handle(GetSpeakerSessionsBySpeaker request, CancellationToken cancellationToken)
	{
		return mapper.Map<List<SelectSpeakerSession>>(await speakerSessionRepository.GetSpeakerSessionsBySpeakerAsync(request.id));
	}
}
