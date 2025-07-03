using BoletoCloudApi.Business.Models;

namespace BoletoCloudApi.Business.Interfaces
{
    public interface IBoletoRepository : IRepository<Boleto>
    {
        Task<Boleto> ObterBoletoPorIdAsync(Guid BoletoId);
    }
}
