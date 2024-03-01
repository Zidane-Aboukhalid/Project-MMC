using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Queries
{
	public class GetAllSpeakerBySessionsHandler : IRequestHandler<GetAllSpeakerBySessions, List<SelectSpeake>>
	{
		private readonly ISpeakerRepository speakerRepository;
		private readonly IMapper mapper;

		public GetAllSpeakerBySessionsHandler(ISpeakerRepository speakerRepository , IMapper mapper)
        {
			this.speakerRepository = speakerRepository;
			this.mapper = mapper;
		}
        public async Task<List<SelectSpeake>> Handle(GetAllSpeakerBySessions request, CancellationToken cancellationToken)
		{
			return mapper.Map<List<SelectSpeake>>(await speakerRepository.GetAllSpeakerBySessionAsync(request.id));
		}
	}
}
