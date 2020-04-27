using Microsoft.AspNetCore.Builder;
using System;

namespace PubSubDemo.ProductAPI.Bootstrapper
{
    public static class SwaggerExtension
    {
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
            });

            return app;
        }
    }
}
