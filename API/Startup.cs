using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate.NetCore;
using Microsoft.Extensions.Configuration;
using Core.Services;
using API.Middleware;

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
            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews();

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

            services.AddScoped<IHoldingsProcessor, HoldingsProcessor>();

            services.AddScoped<IUserQueryService, UserQueryService>();

            services.AddScoped<IWalletQueryService, WalletQueryService>();

            services.AddScoped<ITransactionQueryService, TransactionQueryService>();

            var config = new NHibernate.Cfg.Configuration().Configure();
            var server = _configuration["Database:Server"];
            var database = _configuration["Database:Database"];
            var userId = _configuration["Database:UserId"];
            var password = _configuration["Database:Password"];

            config.SetProperty(NHibernate.Cfg.Environment.ConnectionString, $"server={server};database={database};user id={userId};password={password}");

            services.AddHibernate(config);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

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
