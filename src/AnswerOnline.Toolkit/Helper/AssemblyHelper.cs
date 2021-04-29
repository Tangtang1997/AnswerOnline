using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;

namespace AnswerOnline.Toolkit.Helper
{ 
    public class AssemblyHelper
    {
        public static List<Assembly> GetReferenceAssemblies => DependencyContext.Default
                                                                                .CompileLibraries
                                                                                .Where(lib => !lib.Serviceable && lib.Type != "package" && lib.Name.StartsWith(nameof(AnswerOnline)))
                                                                                .Select(lib => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name)))
                                                                                .ToList();

        /// <summary>
        /// 找出<paramref name="assemblies"/>集合中所有指定类型的派生类型
        /// </summary>
        /// <param name="assemblies">需要查找的<see cref="Assembly"/>集合</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<Type> LoadTypes<T>(IEnumerable<Assembly> assemblies)
        {
            var profiles = new List<Type>();
            var parentType = typeof(T);
            foreach (var item in assemblies)
            {
                var types = item.GetTypes().Where(i => i.BaseType != null && i.BaseType.Name == parentType.Name);
                var typeArray = types as Type[] ?? types.ToArray();
                if (typeArray.Length != 0 || typeArray.Any())
                {
                    profiles.AddRange(typeArray);
                }
            }

            return profiles;
        }
    }
} 