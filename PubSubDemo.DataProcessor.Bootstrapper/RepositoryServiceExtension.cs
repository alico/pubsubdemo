using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.DataProcessor.Data;
using PubSubDemo.DataProcessor.Data.Contract;
using System;

namespace PubSubDemo.DataProcessor.Bootstrapper
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IDataContext, DataContext>();
            
            return services;
        }
    }
}
