using AnswerOnline.EntityFrameworkCore.Loggers;
using AnswerOnline.Toolkit.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AnswerOnline.EntityFrameworkCore
{
    public class EntityFrameworkCoreModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLserver"));

                var loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(new EfCoreLoggerProvider());
                options.UseLoggerFactory(loggerFactory);

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.EnableServiceProviderCaching();
            });

            services.RegisterRepositories();
        }
    }
}