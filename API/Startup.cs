using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NHibernate.NetCore;
using NHibernate;
using Microsoft.Extensions.Configuration;
using Core.Services;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "client/build";
            });

            services.AddScoped<IApiHelper, ApiHelper>();

            services.AddScoped<IStockService, StockService>();

            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<ICreateUserService, CreateUserService>();

            services.AddScoped<ITransService, TransService>();

            services.AddScoped<IHoldingsService, HoldingsService>();

            var config = new NHibernate.Cfg.Configuration().Configure();
            var server = _configuration["Database:Server"];
            var database = _configuration["Database:Database"];
            var userId = _configuration["Database:UserId"];
            var password = _configuration["Database:Password"];

            config.SetProperty(NHibernate.Cfg.Environment.ConnectionString, $"server={server};database={database};user id={userId};password={password}");

            services.AddHibernate(config);

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
