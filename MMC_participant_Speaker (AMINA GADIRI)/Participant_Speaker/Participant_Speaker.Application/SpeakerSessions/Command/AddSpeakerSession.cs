using MediatR;
using Participant_Speaker.Domain.Identity;

namespace Participant_Speaker.Application.SpeakerSessions.Command;

public record  AddSpeakerSession(Guid SessionId,Guid SpeakerId) :IRequest<int>;
