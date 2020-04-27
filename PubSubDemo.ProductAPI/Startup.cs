using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubSubDemo.ProductAPI.Bootstrapper;
using Serilog;

namespace PubSubDemo.ProductAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterSwager();
            services.AddMvc();
            services.AddControllers();
            services.RegisterCorsPolicy();
            services.RegisterConfigurationServices(Configuration);
            services.RegisterQueueServices(Configuration);
            services.RegisterBusinessServices();
            services.RegisterLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("DefaultPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwaggerConfiguration();
            app.UseAuthorization();
            loggerFactory.AddSerilog();
            app.UseMiddleware(typeof(APIResponseMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
