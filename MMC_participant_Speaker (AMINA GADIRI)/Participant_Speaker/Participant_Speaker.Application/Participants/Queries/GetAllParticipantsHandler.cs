using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.Participants.Queries;

public class GetAllParticipantsHandler:IRequestHandler<GetAllParticipants,List<SelectParticipant>>
{
	private readonly IParticipantRepository participantRepository;
	private readonly IMapper mapper;
	public GetAllParticipantsHandler(IParticipantRepository participantRepository,IMapper mapper)
    {
		this.participantRepository = participantRepository;
		this.mapper = mapper;
	}

	public async Task<List<SelectParticipant>> Handle(GetAllParticipants request, CancellationToken cancellationToken)
	{
		var res = await participantRepository.GetAllParticipantsAsync();
		return mapper.Map<List<SelectParticipant>>(res);
	}
}
