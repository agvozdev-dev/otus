using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Otus.Crud.Infrastructure;
using Otus.Crud.Options;
using Otus.Crud.Services;

namespace Otus.Crud.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("Database:Otus").Get<DbOptions>());

            return services;
        }
        
        public static IServiceCollection RegisterOptions(this IServiceCollection services)
        {
            var dbOptions = new DbOptions
                            {
                                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString")
                            };
            
            services.AddSingleton(dbOptions);

            return services;
        }
        
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICreateService<>), typeof(CreateService<>));
            services.AddSingleton(typeof(IQueryService<>), typeof(QueryService<>));
            services.AddSingleton(typeof(IUpdateService<>), typeof(UpdateService<>));
            services.AddSingleton(typeof(IDeleteService<>), typeof(DeleteService<>));
            services.AddSingleton<IUserService, UserService>();

            return services;
        }
    }
}