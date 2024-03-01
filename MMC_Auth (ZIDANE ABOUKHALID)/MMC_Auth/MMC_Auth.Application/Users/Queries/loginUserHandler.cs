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
	public class loginUserHandler : IRequestHandler<loginUser , AuthModel>
	{
		private readonly IAuthServices authServices;
		private readonly IMapper mapper;

		public loginUserHandler(IAuthServices authServices ,IMapper mapper)
        {
			this.authServices = authServices;
			this.mapper = mapper;
		}
        public async Task<AuthModel> Handle(loginUser request, CancellationToken cancellationToken)
		{
			var loginUser = mapper.Map<LoginModel>(request);
			var res = await authServices.LoginAsync(loginUser);
			return res;
		}
	}
}
