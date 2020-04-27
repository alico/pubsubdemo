using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace PubSubDemo.ProductAPI.Bootstrapper
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection RegisterSwager(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
            });

            return services;
        }
    }
}
