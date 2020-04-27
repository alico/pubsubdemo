using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.ProductAPI.Business;
using PubSubDemo.ProductAPI.Business.Contract;
using System;

namespace PubSubDemo.ProductAPI.Bootstrapper
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
