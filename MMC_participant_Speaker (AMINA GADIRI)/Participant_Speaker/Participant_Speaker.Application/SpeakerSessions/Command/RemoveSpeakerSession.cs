using MediatR;

namespace Participant_Speaker.Application.SpeakerSessions.Command;

public record RemoveSpeakerSession(Guid id):IRequest<int>;
