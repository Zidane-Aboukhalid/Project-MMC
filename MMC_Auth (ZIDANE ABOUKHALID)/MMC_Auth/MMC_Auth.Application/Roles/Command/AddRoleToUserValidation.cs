using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Roles.Command;

public class AddRoleToUserValidation:AbstractValidator<AddRoleToUser>
{
    public AddRoleToUserValidation()
    {
		RuleFor(v => v.id)
			.NotNull().WithMessage("Id is required.");

		RuleFor(v => v.RoleName)
		  .NotEmpty().WithMessage("Role name is required.");
	}
}
