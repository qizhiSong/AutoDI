using AutoDI.Entity;
using AutoDI.IRepository;
using AutoDI.Other;
using AutoDI.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AutoDI.Extensions
{
    /// <summary>
    /// Version: v1.0
    /// Author: Simonsong
    /// Date: 2020/10/22 星期四 21:20:49
    /// Description:
    /// </summary>
    public static class AutoDIExtension
    {
        public static void AddScopedRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            //Here, write a loop to get all the entities

            var demoEntityType = typeof(DemoEntity);
            //create the repository generic interface
            var repositoryGeneric = typeof(IDemoRepository<>).MakeGenericType(demoEntityType);
            //create the func delegate
            //var funcType = typeof(Func<,>).MakeGenericType(typeof(IServiceProvider), typeof(object));
            //create the repository generic class
            var repositoryType = typeof(DemoRepository<>).MakeGenericType(demoEntityType);

            services.AddScoped(repositoryGeneric, x => CreateRepositoryInstance(x, repositoryType));
        }
        private static object CreateRepositoryInstance(IServiceProvider provider, Type repositoryType)
        {
            return Activator.CreateInstance(repositoryType, new object[] { provider.GetRequiredService<DemoDbContext>() });
        }
    }
}
