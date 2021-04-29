using System.Linq;
using AnswerOnline.Toolkit.Helper;
using AutoMapper;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperServiceCollectionExtension
    {
        /// <summary>
        /// 添加AutoMapper配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterAutoMapperProfile(this IServiceCollection services)
        {
            var assemblies = AssemblyHelper.GetReferenceAssemblies;

            if (assemblies == null)
            {
                return services; 
            }

            var profiles = AssemblyHelper.LoadTypes<Profile>(assemblies).ToArray();

            if (profiles.Length != 0 || profiles.Any())
            {
                services.AddAutoMapper(profiles.ToArray());
            }

            return services;
        }
    }
}