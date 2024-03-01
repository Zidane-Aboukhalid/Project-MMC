
using MediatR;
using Participant_Speaker.Domain.IServices;

namespace Participant_Speaker.Application.LinkSms.Command;

public class RemoveLinkSmHandler:IRequestHandler<RemoveLinkSm,int>
{
	private readonly ILinkSmRepository linkSmRepository;

	public RemoveLinkSmHandler(ILinkSmRepository linkSmRepository)
    {
		this.linkSmRepository = linkSmRepository;
	}

	public async Task<int> Handle(RemoveLinkSm request, CancellationToken cancellationToken)
	{
		return await linkSmRepository.RemoveLinkSmAsync(request.id);
	}
}
