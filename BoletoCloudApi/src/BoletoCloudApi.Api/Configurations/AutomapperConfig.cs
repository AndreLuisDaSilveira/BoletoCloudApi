using AutoMapper;
using BoletoCloudApi.Api.ViewModels;
using BoletoCloudApi.Business.Models;

namespace BoletoCloudApi.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Boleto,BoletoViewModel>().ReverseMap();
            CreateMap<ContaBancaria, ContaBancariaViewModel>().ReverseMap();
            CreateMap<Beneficiario, BeneficiarioViewModel>().ReverseMap();
            CreateMap<Pagador, PagadorViewModel>().ReverseMap();    
        }
    }
}
