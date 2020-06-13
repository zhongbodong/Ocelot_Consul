using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

namespace ApigatewayCenter
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
            //添加Ocelot服务
            services.AddSwaggerGen(c =>
         c.SwaggerDoc("v1", new OpenApiInfo
         {
             Title = "Gateway api",
             Version = "v1"
         })
         );
            services.AddOcelot().AddConsul();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/ServiceA/swagger.json", "ApiServiceA api");
                c.SwaggerEndpoint("/ServiceB/swagger.json", "ApiServiceB api");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //添加Ocelot中间件到管道
            app.UseOcelot();
        }
    }
}
