using BoletoCloudApi.Business.Models;

namespace BoletoCloudApi.Business.Interfaces
{
    public interface IBoletoService : IDisposable
    {
        Task Adicionar(Boleto boleto);
        Task<byte[]> GerarBoletoPdfAsync(Boleto boleto);
        Task<byte[]> ObterBoletoPDFAsync(string token);
    }
}