using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Participants.Queries
{
	public class GetParticipantsBySessionHandler:IRequestHandler<GetParticipantsBySession,List<SelectParticipant>>
	{
		private readonly IParticipantRepository participantRepository;
		private readonly IMapper mapper;

		public GetParticipantsBySessionHandler(IParticipantRepository participantRepository,IMapper mapper)
        {
			this.participantRepository = participantRepository;
			this.mapper = mapper;
		}

		public async Task<List<SelectParticipant>> Handle(GetParticipantsBySession request, CancellationToken cancellationToken)
		{
			return mapper.Map<List<SelectParticipant>>(await participantRepository.GetParticipantsBySessionAsync(request.id));
		}
	}
}
