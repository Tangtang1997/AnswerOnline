using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnswerOnline.Toolkit.Modules 
{
    public interface IModule
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
} 