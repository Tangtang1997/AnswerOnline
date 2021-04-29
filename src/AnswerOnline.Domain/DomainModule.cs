using AnswerOnline.Toolkit.Helper;
using AnswerOnline.Toolkit.Modules;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnswerOnline.Domain
{
    public class DomainModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDomainServices();

            services.AddMediatR(AssemblyHelper.GetReferenceAssemblies.ToArray());
        }
    }
}