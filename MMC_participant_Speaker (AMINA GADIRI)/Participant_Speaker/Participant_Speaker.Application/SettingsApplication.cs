using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Participant_Speaker.Application.Behaviours;
using System.Reflection;

public static class SettingsApplication
{
	public static void ConfigApplication(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddHttpContextAccessor();
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddMediatR(ctg =>
		{
			ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		}
		);
	}
}
