using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Otus.Crud.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder appBuilder, IConfiguration configuration)
        {
            void ConfigureRunner(IMigrationRunnerBuilder runnerBuilder)
            {
                var connectionString = configuration.GetSection("Database:Otus")
                                                    .GetValue<string>("ConnectionString");

                runnerBuilder.AddPostgres()
                             .WithGlobalConnectionString(connectionString)
                             .ScanIn(typeof(Startup).Assembly).For.Migrations();
            }

            var serviceProvider = new ServiceCollection()
                                  .AddFluentMigratorCore()
                                  .ConfigureRunner(ConfigureRunner)
                                  .AddLogging(loggingBuilder => loggingBuilder.AddFluentMigratorConsole())
                                  .BuildServiceProvider(false);

            using var scope = serviceProvider.CreateScope();

            serviceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();

            return appBuilder;
        }
    }
}