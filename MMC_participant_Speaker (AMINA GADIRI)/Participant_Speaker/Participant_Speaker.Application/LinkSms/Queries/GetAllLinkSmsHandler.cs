

using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.LinkSms.Queries;

public class GetAllLinkSmsHandler:IRequestHandler<GetAllLinkSms,List<SelectLinkSm>>
{
	private readonly ILinkSmRepository linkSmRepository;
	private readonly IMapper mapper;

	public GetAllLinkSmsHandler(ILinkSmRepository linkSmRepository,IMapper mapper)
    {
		this.linkSmRepository = linkSmRepository;
		this.mapper = mapper;
	}

	public async Task<List<SelectLinkSm>> Handle(GetAllLinkSms request, CancellationToken cancellationToken)
	{
		return mapper.Map<List<SelectLinkSm>>(await linkSmRepository.GetAllLinkSmsAsync());
	}
}
