using AutoMapper;
using MediatR;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.Application.LinkSms.Queries
{
	public class GetLinkSmByIdHandler:IRequestHandler<GetLinkSmById,SelectLinkSm>
	{
		private readonly ILinkSmRepository linkSmRepository;
		private readonly IMapper mapper;

		public GetLinkSmByIdHandler(ILinkSmRepository linkSmRepository,IMapper mapper)
        {
			this.linkSmRepository = linkSmRepository;
			this.mapper = mapper;
		}

		public async Task<SelectLinkSm> Handle(GetLinkSmById request, CancellationToken cancellationToken)
		{
			var res = await linkSmRepository.GetLinkSmByIdAsync(request.id);
			return mapper.Map<SelectLinkSm>(res);
		}
	}
}
