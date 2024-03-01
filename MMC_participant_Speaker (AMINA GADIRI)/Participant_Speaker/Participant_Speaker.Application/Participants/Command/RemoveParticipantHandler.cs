using MediatR;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Participants.Command;

public class RemoveParticipantHandler:IRequestHandler<RemoveParticipant,int>
{
	private readonly IParticipantRepository participantRepository;

	public RemoveParticipantHandler(IParticipantRepository participantRepository)
    {
		this.participantRepository = participantRepository;
	}

	public async Task<int> Handle(RemoveParticipant request, CancellationToken cancellationToken)
	{
		return await participantRepository.RemoveParticipantAsync(request.id);
	}
}
