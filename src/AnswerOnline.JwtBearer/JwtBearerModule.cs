using AnswerOnline.Toolkit.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnswerOnline.JwtBearer
{
    public class JwtBearerModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}