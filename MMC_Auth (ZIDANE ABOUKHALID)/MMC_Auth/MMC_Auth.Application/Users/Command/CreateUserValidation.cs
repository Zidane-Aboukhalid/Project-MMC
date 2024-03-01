using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Application.Users.Command;

public class CreateUserValidation:AbstractValidator<CreateUser>
{
    public CreateUserValidation()
    {
		RuleFor(v => v.fullname)
		   .Cascade(CascadeMode.Stop)
		   .NotEmpty().WithMessage("fullname is required.")
		   .NotNull().WithMessage("fullname cannot be null.")
		   .MaximumLength(30).WithMessage("'fullname' must not exceed 30 characters.");

		RuleFor(v => v.username)
		   .Cascade(CascadeMode.Stop)
		   .NotEmpty().WithMessage("username is required.")
		   .NotNull().WithMessage("username cannot be null.")
		   .MaximumLength(20).WithMessage("'username' must not exceed 20 characters.");


		RuleFor(v => v.email)
			.NotEmpty().WithMessage("'Email' is required.")
			.EmailAddress().WithMessage("This is an example of a valid email: example@example.com");

		RuleFor(v => v.password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(7).WithMessage("Password must have a minimum of 7 characters.")
			.MaximumLength(15).WithMessage("Password must not exceed 15 characters.");
	}
}
