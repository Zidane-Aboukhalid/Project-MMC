using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Participant_Speaker.Domain.Helpers;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Infra.data;
using Participant_Speaker.Infra.Services;

namespace Participant_Speaker.Infra;

public static class SettingsInfra
{
	public static void ConfigInfra(this IServiceCollection services ,IConfiguration configuration)
	{
		services.AddDbContext<ApplicationContext>(op => op.UseSqlServer(configuration.GetConnectionString("cnx")));
		services.AddScoped<IParticipantRepository, ParticipantRepository>();
		services.AddScoped<ISpeakerSessionRepository, SpeakerSessionRepository>();
		services.AddScoped<ILinkSmRepository, LinkSmRepository>();
		services.AddScoped<ISpeakerRepository, SpeakerRepository>();
		services.Configure<SMTPSettings>(configuration.GetSection("SMTPSettings"));
	}

}
