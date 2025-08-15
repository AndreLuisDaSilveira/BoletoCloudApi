namespace BoletoCloudApi.Api.Configurations
{
    using BoletoCloudApi.Business.HttpClient;
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Notificacoes;
    using BoletoCloudApi.Business.Services;
    using BoletoCloudApi.Data.Context;
    using BoletoCloudApi.Data.Repository;

    /// <summary>
    /// Fornece métodos de extensão para configurar a injeção de dependências da aplicação.
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Configura e registra os serviços e dependências da aplicação no contêiner de injeção de dependência.
        /// </summary>
        /// <param name="services">A coleção de serviços da aplicação.</param>
        /// <param name="configuration">As configurações da aplicação.</param>
        /// <returns>A coleção de serviços atualizada com as dependências registradas.</returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IBoletoRepository, BoletoRepository>();

            // Business
            services.Configure<BoletoCloudOptions>(configuration.GetSection("BoletoCloud"));
            services.Configure<BoletoCloudOptions>(configuration.GetSection("BoletoCloudOptions"));
            services.AddScoped(sp => sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<BoletoCloudOptions>>().Value);
            services.AddScoped<IBoletoCloudIntegrationService, BoletoCloudIntegrationService>();
            services.AddScoped<BoletoCloudIntegrationService>();
            services.AddScoped<IBoletoService, BoletoService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
