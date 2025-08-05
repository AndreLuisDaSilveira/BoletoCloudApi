namespace BoletoCloudApi.Business.Interfaces
{
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Business.Models.Results;

    /// <summary>
    /// Interface para o serviço de integração com a API BoletoCloud.
    /// Define operações para geração e obtenção do PDF de boletos.
    /// </summary>
    public interface IBoletoCloudIntegrationService
    {
        /// <summary>
        /// Obtém o PDF de um boleto a partir do token informado.
        /// </summary>
        /// <param name="token">Token identificador do boleto.</param>
        /// <returns>Array de bytes contendo o PDF do boleto.</returns>
        Task<byte[]> ObterBoletoPDFAsync(string token);

        /// <summary>
        /// Gera o PDF de um boleto a partir dos dados informados.
        /// </summary>
        /// <param name="boleto">Objeto <see cref="Boleto"/> com os dados do boleto.</param>
        /// <returns>Objeto <see cref="BoletoPdfResult"/> contendo os bytes do PDF e o token gerado.</returns>
        Task<BoletoPdfResult> GerarBoletoPdfAsync(Boleto boleto);
    }
}
