using MediatR;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Queries;

public class CheckUserIsSpeakersHandler : IRequestHandler<CheckUserIsSpeakers,bool>
{
	private readonly ISpeakerRepository speakerRepository;

	public CheckUserIsSpeakersHandler(ISpeakerRepository speakerRepository)
    {
		this.speakerRepository = speakerRepository;
	}

	public async Task<bool> Handle(CheckUserIsSpeakers request, CancellationToken cancellationToken)
	{
		return await speakerRepository.CheckUserIsSpeaker(request.id);
	}
}
