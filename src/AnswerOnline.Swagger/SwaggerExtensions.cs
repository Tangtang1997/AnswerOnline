using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.IO;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerUi(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AnswerOnline.WebApi", 
                    Version = "v1",
                    Description = "三生制药答题H5 WebApi"
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "AnswerOnline.WebApi.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "AnswerOnline.Application.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "AnswerOnline.Toolkit.xml"));
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnswerOnline.WebApi v1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
                c.DocumentTitle = "😍接口文档⭐⭐⭐";
            });

            return app;
        }
    }
}