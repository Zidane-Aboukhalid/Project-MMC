using Application.AutoMapper;
using Application.Offers.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDependecyInjectionApplication(this IServiceCollection services)
        {
       
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            //use the url for handler of a image
            services.AddHttpContextAccessor();
            // versioning
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            }
             );

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // mediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(GetEventQueryHandler).Assembly));


            return services;
        }
    }
}
