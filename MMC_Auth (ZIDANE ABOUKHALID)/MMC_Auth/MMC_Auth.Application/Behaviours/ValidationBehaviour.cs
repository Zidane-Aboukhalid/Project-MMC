using FluentValidation;
using MediatR;

namespace MMC_Auth.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : notnull
{
	private readonly IEnumerable<IValidator<TRequest>> validators;

	public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
		this.validators = validators;
	}
    public async Task<TResponse> Handle(TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		if(validators.Any())
		{
			var Context = new ValidationContext<TRequest>(request);
			var ValidationResults = await Task.WhenAll(
				validators.Select(
				v => v.ValidateAsync(Context, cancellationToken)
			));

			var failures = ValidationResults
				.Where(v => v.Errors.Any())
				.SelectMany(v => v.Errors)
				.ToList() ;
			if (failures.Any())
				throw new ValidationException(failures);
		}
		return await next();

	}
}
