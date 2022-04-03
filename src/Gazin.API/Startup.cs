using Gazin.API.Configuration;

namespace Gazin.API
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfiguration(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();

            services.RegisterServices();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {                     
            app.UseApiConfiguration(environment);
        }
    }

    public interface IStartup
    { 
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartup;

            if (startup == null) throw new ArgumentNullException("Classe Startup.cs inválida");

            startup.ConfigureServices(webAppBuilder.Services);

            var app = webAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();

          return webAppBuilder;
        }        
    }
}
