using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.EventProcessor.Business.Contract;
using PubSubDemo.EventProcessor.Business.Service;
using PubSubDemo.EventProcessor.Data;
using PubSubDemo.EventProcessor.Data.Contract;
using System;

namespace PubSubDemo.EventProcessor.Bootstrapper
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IProductIndexService, ProductIndexService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IDataContext, DataContext>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
