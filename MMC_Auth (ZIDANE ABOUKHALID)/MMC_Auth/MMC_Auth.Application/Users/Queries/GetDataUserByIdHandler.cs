using MediatR;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Domain.models;

namespace MMC_Auth.Application.Users.Queries
{
	public class GetDataUserByIdHandler:IRequestHandler<GetDataUserById, userData>
	{
		private readonly IAuthServices authServices;

		public GetDataUserByIdHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<userData> Handle(GetDataUserById request, CancellationToken cancellationToken)
		{
			var userdata = await authServices.GetDataUserByIdAsync(request.id);
			return userdata;
		}
	}
}
