using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.Speakes.Queries;

public class GetAllSpeakerHandler : IRequestHandler<getAllSpeaker, List<SelectSpeake>>
{
	private readonly ISpeakerRepository speakerRepository;
	private readonly IMapper mapper;

	public GetAllSpeakerHandler(ISpeakerRepository speakerRepository ,IMapper mapper)
    {
		this.speakerRepository = speakerRepository;
		this.mapper = mapper;
	}

	public async Task<List<SelectSpeake>> Handle(getAllSpeaker request, CancellationToken cancellationToken)
	{
		var listSpeaker =mapper.Map<List<SelectSpeake>>(await speakerRepository.GetAllSpeakerAsync());
		return listSpeaker;
	}
}
