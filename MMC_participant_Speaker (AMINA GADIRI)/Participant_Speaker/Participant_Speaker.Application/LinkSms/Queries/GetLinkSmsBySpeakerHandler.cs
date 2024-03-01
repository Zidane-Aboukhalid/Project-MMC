using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.LinkSms.Queries
{
	public class GetLinkSmsBySpeakerHandler:IRequestHandler<GetLinkSmsBySpeaker,List<SelectLinkSm>>
	{
		private readonly ILinkSmRepository linkSmRepository;
		private readonly IMapper mapper;

		public GetLinkSmsBySpeakerHandler(ILinkSmRepository linkSmRepository , IMapper mapper)
		{
			this.linkSmRepository = linkSmRepository;
			this.mapper = mapper;
		}

		public async Task<List<SelectLinkSm>> Handle(GetLinkSmsBySpeaker request, CancellationToken cancellationToken)
		{
			return mapper.Map<List<SelectLinkSm>>(await linkSmRepository.GetLinkSmsBySpeakerAsync(request.id));
		}
	}
}
