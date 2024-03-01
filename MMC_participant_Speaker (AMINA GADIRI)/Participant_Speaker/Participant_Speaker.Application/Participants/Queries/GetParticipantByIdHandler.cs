using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.Participants.Queries;

public class GetParticipantByIdHandler : IRequestHandler<GetParticipantById, SelectParticipant>
{
	private readonly IParticipantRepository participantRepository;
	private readonly IMapper mapper;

	public GetParticipantByIdHandler(IParticipantRepository participantRepository , IMapper mapper)
    {
		this.participantRepository = participantRepository;
		this.mapper = mapper;
	}
    public async Task<SelectParticipant> Handle(GetParticipantById request, CancellationToken cancellationToken)
	{
		return mapper.Map<SelectParticipant>(await participantRepository.GetParticipantByIdAsync(request.id));
	}
}
