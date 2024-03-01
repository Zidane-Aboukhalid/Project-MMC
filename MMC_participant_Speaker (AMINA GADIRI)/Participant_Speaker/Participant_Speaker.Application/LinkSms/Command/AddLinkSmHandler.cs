

using MediatR;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;

namespace Participant_Speaker.Application.LinkSms.Command
{
	public class AddLinkSmHandler:IRequestHandler<AddLinkSm,int>
	{
		private readonly ILinkSmRepository linkSmRepositoryd;

		public AddLinkSmHandler(ILinkSmRepository linkSmRepositoryd)
        {
			this.linkSmRepositoryd = linkSmRepositoryd;
		}

		public async Task<int> Handle(AddLinkSm request, CancellationToken cancellationToken)
		{
			var lnk = new LinkSm
			{
				LinkSmId=Guid.NewGuid(),
				Type=request.Type,
				Url=request.Url,
				SpeakerId=request.SpeakerId,
			}								;
			return await linkSmRepositoryd.AddLinkSmAsync(lnk);
		}
	}
}
