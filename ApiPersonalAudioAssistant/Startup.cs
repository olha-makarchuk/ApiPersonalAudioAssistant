using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using System;
using System.Reflection;

namespace ApiPersonalAudioAssistant
{
    public class Startup
    {
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile($"appsettings.json", false, true)
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddApiVersioning(t =>
            {
                t.ApiVersionReader = new UrlSegmentApiVersionReader();
                t.ReportApiVersions = true;
            });
            services.AddApiVersioning();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<ISubUserRepository, SubUserRepository>();
            services.AddScoped<IVoiceRepository, VoiceRepository>();

            ConfigureDb(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void ConfigureDb(IServiceCollection services)
        {
            services.AddCosmos<CosmosDbContext>(_configuration.GetConnectionString("CosmosConnection")!,
                "AudioAssistantDB"); 
        }
    }
}
