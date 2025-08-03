namespace BoletoCloudApi.Business.Interfaces
{
    using BoletoCloudApi.Business.Models;

    /// <summary>
    /// Interface para operações de persistência e consulta de boletos.
    /// </summary>
    public interface IBoletoRepository : IRepository<Boleto>
    {
        /// <summary>
        /// Obtém um boleto pelo identificador informado.
        /// </summary>
        /// <param name="boletoId">Identificador único do boleto.</param>
        /// <returns>O <see cref="Boleto"/> correspondente ao identificador ou <c>null</c> se não encontrado.</returns>
        Task<Boleto> ObterBoletoPorIdAsync(Guid boletoId);
    }
}
