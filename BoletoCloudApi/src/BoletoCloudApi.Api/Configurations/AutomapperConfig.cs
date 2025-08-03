namespace BoletoCloudApi.Api.Configurations
{
    using AutoMapper;
    using BoletoCloudApi.Api.ViewModels;
    using BoletoCloudApi.Business.Models;

    /// <summary>
    /// Configuração dos mapeamentos do AutoMapper para as entidades e view models da aplicação.
    /// </summary>
    public class AutomapperConfig : Profile
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="AutomapperConfig"/> e define os mapeamentos entre entidades e view models.
        /// </summary>
        public AutomapperConfig()
        {
            CreateMap<Boleto,BoletoViewModel>().ReverseMap();
            CreateMap<ContaBancaria, ContaBancariaViewModel>().ReverseMap();
            CreateMap<Beneficiario, BeneficiarioViewModel>().ReverseMap();
            CreateMap<Pagador, PagadorViewModel>().ReverseMap();
        }
    }
}
