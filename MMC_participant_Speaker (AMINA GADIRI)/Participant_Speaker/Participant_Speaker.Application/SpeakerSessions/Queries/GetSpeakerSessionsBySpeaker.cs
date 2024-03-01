using MediatR;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.SpeakerSessions.Queries;

public record GetSpeakerSessionsBySpeaker(Guid id) : IRequest<List<SelectSpeakerSession>>;
