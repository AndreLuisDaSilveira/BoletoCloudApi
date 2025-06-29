using BoletoCloudApi.Business.httpClient;
using BoletoCloudApi.Business.Interfaces;
using BoletoCloudApi.Business.Notificacoes;
using BoletoCloudApi.Business.Services;
using BoletoCloudApi.Data.Context;
using BoletoCloudApi.Data.Repository;

namespace BoletoCloudApi.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {          
            //Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IBoletoRepository, BoletoRepository>();

            //Business
            services.Configure<BoletoCloudOptions>(configuration.GetSection("BoletoCloud"));
            services.Configure<BoletoCloudOptions>(configuration.GetSection("BoletoCloudOptions"));
            services.AddScoped(sp => sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<BoletoCloudOptions>>().Value);
            services.AddScoped<BoletoCloudIntegrationService>();
            services.AddScoped<IBoletoService, BoletoService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
