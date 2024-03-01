using MediatR;
using Participant_Speaker.Domain.IServices;

namespace Participant_Speaker.Application.SpeakerSessions.Command;

public class UpdateSpeakerSessionHandler:IRequestHandler<UpdateSpeakerSession, int>
{
private readonly ISpeakerSessionRepository speakerSessionRepository;

public UpdateSpeakerSessionHandler(ISpeakerSessionRepository speakerSessionRepository)
{
	this.speakerSessionRepository = speakerSessionRepository;
}

	public async Task<int> Handle(UpdateSpeakerSession request, CancellationToken cancellationToken)
	{
		var SpeakerSession=await speakerSessionRepository.GetSpeakerSessionByIdAsync(request.SpeakerSessionId);
		SpeakerSession.SessionId = request.SessionId;
		SpeakerSession.SpeakerId = request.SpeakerId;
		return await speakerSessionRepository.UpdateSpeakerSessionAsync(SpeakerSession);
	}
}