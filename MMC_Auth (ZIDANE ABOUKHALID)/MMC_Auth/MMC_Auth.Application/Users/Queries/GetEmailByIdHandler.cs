using MediatR;
using MMC_Auth.Domain.InterfacesServices;

namespace MMC_Auth.Application.Users.Queries
{
	public class GetEmailByIdHandler:IRequestHandler<GetEmailById, string>
	{
		private readonly IAuthServices authServices;

		public GetEmailByIdHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<string> Handle(GetEmailById request, CancellationToken cancellationToken)
		{
			return await authServices.GetEmailById(request.id);
		}
	}
}
