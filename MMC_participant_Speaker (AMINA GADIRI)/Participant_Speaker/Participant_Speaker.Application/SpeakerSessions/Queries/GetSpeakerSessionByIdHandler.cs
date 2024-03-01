using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.SpeakerSessions.Queries
{
	public class GetSpeakerSessionByIdHandler : IRequestHandler<GetSpeakerSessionById, SelectSpeakerSession>
	{
		private readonly ISpeakerSessionRepository speakerSessionRepository;
		private readonly IMapper mapper;

		public GetSpeakerSessionByIdHandler(ISpeakerSessionRepository speakerSessionRepository,IMapper mapper)
        {
			this.speakerSessionRepository = speakerSessionRepository;
			this.mapper = mapper;
		}
        public async Task<SelectSpeakerSession> Handle(GetSpeakerSessionById request, CancellationToken cancellationToken)
		{
			return mapper.Map<SelectSpeakerSession>(await speakerSessionRepository.GetSpeakerSessionByIdAsync(request.id));
		}
	}
}
