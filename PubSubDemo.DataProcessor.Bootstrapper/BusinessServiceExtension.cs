using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.DataProcessor.Business.Service;
using PubSubDemo.DataProcessor.Business.Service.Contract;
using System;

namespace PubSubDemo.DataProcessor.Bootstrapper
{
    public static class BusinessServiceExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
