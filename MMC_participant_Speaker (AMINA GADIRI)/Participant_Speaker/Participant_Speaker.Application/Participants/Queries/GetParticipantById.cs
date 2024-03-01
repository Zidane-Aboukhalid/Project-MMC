using MediatR;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.Participants.Queries;

public record GetParticipantById(Guid id):IRequest<SelectParticipant>;