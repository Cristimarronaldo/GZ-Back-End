using Gazin.Dominio.Interfaces;
using Gazin.Dominio.Models;
using Gazin.Dominio.Notificacoes;
using Gazin.Dominio.Services;
using Gazin.Infra.Data;
using Gazin.Infra.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Gazin.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<GazinContext>();
            services.AddScoped<INiveisRepository, NiveisRepository>();
            services.AddScoped<IDesenvolvedorRepository, DesenvolvedorRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<INiveisService, NiveisService>();
            services.AddScoped<IDesenvolvedorService, DesenvolvedorService>();

            services.AddSingleton(AutomapperConfig.AutoMapperConfiguration());

            services.AddScoped<INiveisRepository, NiveisRepository>();            
        }
    }
}
