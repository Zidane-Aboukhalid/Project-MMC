using MediatR;
using Participant_Speaker.Domain.IServices;

namespace Participant_Speaker.Application.LinkSms.Command;

public class UpdateLinkSmHandler: IRequestHandler<UpdateLinkSm,int>
{
	private readonly ILinkSmRepository linkSmRepository;

	public UpdateLinkSmHandler(ILinkSmRepository linkSmRepository)
        {
		this.linkSmRepository = linkSmRepository;
	}

	public async Task<int> Handle(UpdateLinkSm request, CancellationToken cancellationToken)
	{
		var lnik = await linkSmRepository.GetLinkSmByIdAsync(request.LinkSmId);
		return lnik != null ? await linkSmRepository.UpdateLinkSmAsync(lnik) : 0;
	}
}
