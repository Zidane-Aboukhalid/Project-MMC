using MediatR;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;


namespace Participant_Speaker.Application.SpeakerSessions.Command;

public class AddSpeakerSessionHandler:IRequestHandler<AddSpeakerSession,int>
{
	private readonly ISpeakerSessionRepository speakerSessionRepository;

	public AddSpeakerSessionHandler(ISpeakerSessionRepository speakerSessionRepository)
    {
		this.speakerSessionRepository = speakerSessionRepository;
	}

	public async Task<int> Handle(AddSpeakerSession request, CancellationToken cancellationToken)
	{
		var SS = new SpeakerSession
		{
		SpeakerSessionId=Guid.NewGuid(),
		SpeakerId=request.SpeakerId,
		SessionId=request.SessionId,
		CreateAt=DateTime.UtcNow,
		};

		return await speakerSessionRepository.AddSpeakerSessionAsync(SS);
	}
}
