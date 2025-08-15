namespace BoletoCloudApi.Business.HttpClient
{
    /// <summary>
    /// Representa as opções de configuração para integração com a API BoletoCloud.
    /// Armazena a chave de acesso (API Key) e a URL da API.
    /// </summary>
    public class BoletoCloudOptions
    {
        /// <summary>
        /// Chave de acesso à API BoletoCloud.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// URL de acesso à API BoletoCloud.
        /// </summary>
        public string ApiUrl { get; set; }
    }
}
