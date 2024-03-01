using MediatR;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Domain.models;

namespace MMC_Auth.Application.Users.Queries
{
	public class GetDataUserByEmailHandler:IRequestHandler<GetDataUserByEmail, userData>
	{
		private readonly IAuthServices authServices;

		public GetDataUserByEmailHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<userData> Handle(GetDataUserByEmail request, CancellationToken cancellationToken)
		{
			var userdata = await authServices.GetDataUserByEmailAsync(request.email);
			return userdata;
		}
	}
}
