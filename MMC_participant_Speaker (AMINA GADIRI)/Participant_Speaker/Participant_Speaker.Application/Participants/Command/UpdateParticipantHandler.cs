using MediatR;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Participants.Command;

public class UpdateParticipantHandler:IRequestHandler<UpdateParticipant,int>	
{
	private readonly IParticipantRepository participantRepository;

	public UpdateParticipantHandler(IParticipantRepository participantRepository)
    {
		this.participantRepository = participantRepository;
	}

	public async Task<int> Handle(UpdateParticipant request, CancellationToken cancellationToken)
	{
		var par= await participantRepository.GetParticipantByIdAsync(request.ParticipantId);
		par.IdSession=request.IdSession;
		par.IdUser=request.IdUser;
		return await participantRepository.UpdateParticipantAsync(par);
	}
}
