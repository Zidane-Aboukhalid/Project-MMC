using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MMCProject.Application.Interfaces;
using MMCProject.Infrastructure.DBContext;
using MMCProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MMCDBContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("defaultconnection"))
                         .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));


            


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ITargetAudienceRepository, TargetAudienceRepository>();
            services.AddScoped<ISessionTargetAudienceRepository, SessionTargetAudienceRepository>();
            


            return services;
        }
    }
}
