using FluentValidation;


namespace MMC_Auth.Application.Users.Queries;

public class CreateUserLoginValidation:AbstractValidator<loginUser>
{
    public CreateUserLoginValidation()
    {
		RuleFor(v => v.Email)
	.NotEmpty().WithMessage("'Email' is required.")
	.EmailAddress().WithMessage("This is an example of a valid email: example@example.com");

		RuleFor(v => v.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(7).WithMessage("Password must have a minimum of 7 characters.")
			.MaximumLength(15).WithMessage("Password must not exceed 15 characters.");
	}
}
