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
	public class VerificationEmailHandler : IRequestHandler<VerificationEmail, VerificationEmailModel>
	{
		private readonly IAuthServices authServices;

		public VerificationEmailHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}
        public async Task<VerificationEmailModel> Handle(VerificationEmail request, CancellationToken cancellationToken)
		{
			return await authServices.GenerateEmailConfirmationTokenAsync(request.Email);
		}
	}
}
