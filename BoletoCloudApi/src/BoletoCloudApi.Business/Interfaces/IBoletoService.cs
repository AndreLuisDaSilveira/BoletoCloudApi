namespace BoletoCloudApi.Business.Interfaces
{
    using BoletoCloudApi.Business.Models;

    /// <summary>
    /// Interface para serviços relacionados à gestão e geração de boletos.
    /// </summary>
    public interface IBoletoService : IDisposable
    {
        /// <summary>
        /// Adiciona um novo boleto ao sistema.
        /// </summary>
        /// <param name="boleto">O boleto a ser adicionado.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task Adicionar(Boleto boleto);

        /// <summary>
        /// Gera o arquivo PDF correspondente ao boleto informado.
        /// </summary>
        /// <param name="boleto">O boleto para o qual o PDF será gerado.</param>
        /// <returns>Um array de bytes contendo o PDF do boleto.</returns>
        Task<byte[]> GerarBoletoPdfAsync(Boleto boleto);

        /// <summary>
        /// Obtém o arquivo PDF de um boleto a partir do token informado.
        /// </summary>
        /// <param name="token">O token identificador do boleto.</param>
        /// <returns>Um array de bytes contendo o PDF do boleto.</returns>
        Task<byte[]> ObterBoletoPDFAsync(string token);
    }
}
