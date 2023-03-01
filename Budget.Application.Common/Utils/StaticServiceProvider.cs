using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common.Utils
{
    public static class StaticServiceProvider
    {
        static IServiceProvider provider;

        public static void BuildProvider(IServiceCollection serviceCollection)
        {
            provider = serviceCollection.BuildServiceProvider();
        }

        public static T GetService<T>() 
        {
            return provider.GetService<T>();
        }
    }
}
