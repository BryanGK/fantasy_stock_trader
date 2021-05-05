using System;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NHibernate.NetCore;
using NHibernate;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hibernate.cfg.xml");

            services.AddControllers();

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "client/build";
            });

            services.AddScoped<IApiHelper, ApiHelper>();

            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ICreateUserService, CreateUserService>();

            services.AddHibernate(path);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(configuration: spa =>
            {
                spa.Options.SourcePath = "client";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
