using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MMC_Auth.Application.Behaviours;
using System.Reflection;

namespace MMC_Auth.Application;

public static class ServicesApplication
{
	public static IServiceCollection AddServicesApplication(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddMediatR(ctg =>
		{
			ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		}
		);
		return services;
	}
}	
