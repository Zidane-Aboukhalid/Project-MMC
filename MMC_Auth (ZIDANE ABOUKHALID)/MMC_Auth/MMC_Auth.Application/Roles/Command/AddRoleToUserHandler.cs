using AutoMapper;
using MediatR;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Roles.Command;

public class AddRoleToUserHandler : IRequestHandler<AddRoleToUser, string>
{
	private readonly IAuthServices authServices;
	private readonly IMapper mapper;

	public AddRoleToUserHandler(IAuthServices authServices , IMapper mapper)
    {
		this.authServices = authServices;
		this.mapper = mapper;
	}
    public async Task<string> Handle(AddRoleToUser request, CancellationToken cancellationToken)
	{
		var userRole = mapper.Map<RolesToUserModel>(request);
		var res= await authServices.AddRolesToUser(userRole);
		return res;
	}
}
