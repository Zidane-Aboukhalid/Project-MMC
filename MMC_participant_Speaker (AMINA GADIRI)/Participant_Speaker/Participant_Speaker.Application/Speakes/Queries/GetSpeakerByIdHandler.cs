using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Queries;

public class GetSpeakerByIdHandler : IRequestHandler<GetSpeakerById, SelectSpeake>
{
	private readonly ISpeakerRepository speakerRepository;
	private readonly IMapper mapper;

	public GetSpeakerByIdHandler(ISpeakerRepository speakerRepository , IMapper mapper)
    {
		this.speakerRepository = speakerRepository;
		this.mapper = mapper;
	}
	public async Task<SelectSpeake> Handle(GetSpeakerById request, CancellationToken cancellationToken)
	{
		return mapper.Map<SelectSpeake>(await speakerRepository.GetSpeakerByIdAsync(request.id));
	}
}
