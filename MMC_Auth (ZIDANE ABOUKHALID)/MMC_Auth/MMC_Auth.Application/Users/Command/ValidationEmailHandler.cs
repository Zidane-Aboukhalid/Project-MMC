using AutoMapper;
using MediatR;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Domain.models;

namespace MMC_Auth.Application.Users.Command;

public class ValidationEmailHandler : IRequestHandler<ValidationEmail, bool>
{
	private readonly IAuthServices authServices;
	private readonly IMapper mapper;

	public ValidationEmailHandler(IAuthServices authServices ,  IMapper mapper)
    {
		this.authServices = authServices;
		this.mapper = mapper;
	}

    public async Task<bool> Handle(ValidationEmail request, CancellationToken cancellationToken)
	{
		var vaEmailModel = mapper.Map<ValidationEmailModel>(request);
		var res = await authServices.ValidationEmail(vaEmailModel);
		return res;
	}
}
