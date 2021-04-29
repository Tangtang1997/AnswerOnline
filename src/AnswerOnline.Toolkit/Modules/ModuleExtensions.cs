using System.Linq;
using AnswerOnline.Toolkit.Helper;
using AnswerOnline.Toolkit.Modules;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{ 
    public static class ModuleExtensions
    {
        public static IServiceCollection ConfigureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterAutoMapperProfile();

            RegisterModule(services);

            RegisterServices(services, configuration);

            return services;
        }

        private static void RegisterModule(IServiceCollection services)
        {
            var assemblies = AssemblyHelper.GetReferenceAssemblies;

            CheckHelper.CheckNull(assemblies);

            foreach (var moduleType in assemblies.Select(assembly => assembly.GetTypes().FirstOrDefault(t => typeof(IModule).IsAssignableFrom(t))).Where(moduleType => moduleType != null && moduleType != typeof(IModule)))
            {
                services.AddSingleton(typeof(IModule), moduleType);
            }
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            foreach (var module in services.BuildServiceProvider().GetServices<IModule>())
            {
                module.ConfigureServices(services, configuration);
            }
        }
    }
}