using FluentValidation;
using Participant_Speaker.Application.Speakes.Command;

namespace Participant_Speaker.Application.Speakes.Validation
{
	public class CreateSpeakerValidation:AbstractValidator<CreateSpeakes>
	{
        public CreateSpeakerValidation()
        {
			//RuleFor(v => v.Biographi)
		 //  .Cascade(CascadeMode.Stop)
		 //  .NotEmpty().WithMessage("fullname is required.")
		 //  .NotNull().WithMessage("fullname cannot be null.")
		 //  .MaximumLength(30).WithMessage("'fullname' must not exceed");
        }
    }
}
