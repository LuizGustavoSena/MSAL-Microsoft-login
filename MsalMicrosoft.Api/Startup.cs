using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MsalMicrosoft.CrossCutting;
using MsalMicrosoft.Domain.Commands.v1.Login;
using MsalMicrosoft.Infrastructure.MsalMicrosoft;
using System.Reflection;

namespace MsalMicrosoft.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MsalMicrosoft.Api", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection(AppSettings.ActionName));
            services.AddMediatR(typeof(LoginCommand).GetTypeInfo().Assembly);
            services.AddSingleton<IMsalServices, MsalServices>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MsalMicrosoft.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
