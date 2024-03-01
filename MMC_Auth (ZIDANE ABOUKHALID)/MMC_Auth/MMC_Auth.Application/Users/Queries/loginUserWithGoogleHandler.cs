using AutoMapper;
using MediatR;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Users.Queries
{
	public class loginUserWithGoogleHandler : IRequestHandler<loginUserWithGoogle, AuthModel>
	{
		private readonly IAuthServices authServices;
		private readonly IMapper mapper;

		public loginUserWithGoogleHandler(IAuthServices authServices,IMapper mapper)
        {
			this.authServices = authServices;
			this.mapper = mapper;
		}


        public async Task<AuthModel> Handle(loginUserWithGoogle request, CancellationToken cancellationToken)
		{
			var loginUserWithGoogle = mapper.Map<LoginGoogleModel>(request);
			var res = await authServices.LoginGoogleAsync(loginUserWithGoogle);
			return res;
		}
	}
}
