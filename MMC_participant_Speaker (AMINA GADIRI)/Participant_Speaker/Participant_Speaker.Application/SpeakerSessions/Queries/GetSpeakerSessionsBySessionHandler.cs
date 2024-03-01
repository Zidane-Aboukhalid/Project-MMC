
using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.SpeakerSessions.Queries
{
	public class GetSpeakerSessionsBySessionHandler:IRequestHandler<GetSpeakerSessionsBySession,List<SelectSpeakerSession>>
	{
		private readonly ISpeakerSessionRepository speakerSessionRepository;
		private readonly IMapper mapper;

		public GetSpeakerSessionsBySessionHandler(ISpeakerSessionRepository speakerSessionRepository , IMapper mapper)
        {
			this.speakerSessionRepository = speakerSessionRepository;
			this.mapper = mapper;
		}

		public async Task<List<SelectSpeakerSession>> Handle(GetSpeakerSessionsBySession request, CancellationToken cancellationToken)
		{
			return mapper.Map<List<SelectSpeakerSession>>(await speakerSessionRepository.GetSpeakerSessionsBySessionAsync(request.id));
		}
	}
}
