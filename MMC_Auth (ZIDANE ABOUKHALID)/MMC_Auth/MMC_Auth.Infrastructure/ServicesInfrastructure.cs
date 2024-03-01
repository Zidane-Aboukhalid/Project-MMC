using Infra.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMC_Auth.Domain.Entitys;
using MMC_Auth.Domain.Helpers;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Infrastructure.data;
using MMC_Auth.Infrastructure.Helpers;

namespace MMC_Auth.Infrastructure;

public static class ServicesInfrastructure
{
	public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddIdentity<User, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();
		services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("cnx")));
		services.AddScoped<IAuthServices, AuthServices>();
		services.Configure<JWT>(configuration.GetSection("JWT"));
		services.Configure<SMTPSettings>(configuration.GetSection("SMTPSettings"));
		return services;
	}
}
