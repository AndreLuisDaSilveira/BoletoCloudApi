namespace BoletoCloudApi.Business.HttpClient
{
    using System.Text;
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Business.Models.Results;
    using BoletoCloudApi.Business.Models.Utils;

    /// <summary>
    /// Serviço responsável pela integração com a API BoletoCloud.
    /// Permite gerar e obter o PDF de boletos, além de aplicar máscaras em dados sensíveis.
    /// </summary>
    public class BoletoCloudIntegrationService : IBoletoCloudIntegrationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BoletoCloudOptions _boletoCloudOptions;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BoletoCloudIntegrationService"/>.
        /// </summary>
        /// <param name="factory">Fábrica de clientes HTTP.</param>
        /// <param name="boletoCloudOptions">Opções de configuração da integração com a BoletoCloud.</param>
        public BoletoCloudIntegrationService(IHttpClientFactory factory, BoletoCloudOptions boletoCloudOptions)
        {
            _httpClientFactory = factory;
            _boletoCloudOptions = boletoCloudOptions ?? throw new ArgumentNullException(nameof(boletoCloudOptions), "BoletoCloudOptions cannot be null");
        }

        /// <summary>
        /// Obtém o PDF de um boleto a partir do token informado.
        /// </summary>
        /// <param name="token">Token identificador do boleto.</param>
        /// <returns>Array de bytes contendo o PDF do boleto.</returns>
        /// <exception cref="ArgumentException">Lançada se o token for nulo ou vazio.</exception>
        /// <exception cref="Exception">Lançada em caso de erro na comunicação ou resposta da API.</exception>
        public async Task<byte[]> ObterBoletoPDFAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token cannot be null or empty", nameof(token));
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var apiKey = _boletoCloudOptions.ApiKey;
                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:token"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

                var response = await client.GetAsync($"{_boletoCloudOptions.ApiUrl}/{token}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao obter boleto PDF: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (HttpRequestException ex)
            {
                // Captura erros de requisição HTTP
                throw new Exception("Erro de comunicação com a API BoletoCloud: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Captura qualquer outro erro
                throw new Exception("Erro inesperado ao obter boleto PDF: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Gera o PDF de um boleto a partir dos dados informados.
        /// </summary>
        /// <param name="boleto">Objeto <see cref="Boleto"/> com os dados do boleto.</param>
        /// <returns>Objeto <see cref="BoletoPdfResult"/> contendo os bytes do PDF e o token gerado.</returns>
        /// <exception cref="Exception">Lançada em caso de erro na comunicação ou resposta da API.</exception>
        public async Task<BoletoPdfResult> GerarBoletoPdfAsync(Boleto boleto)
        {
            try
            {
                var parameters = BoletoUtils.MontarParametrosBoleto(boleto);

                var client = _httpClientFactory.CreateClient();
                var content = new FormUrlEncodedContent(parameters);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded")
                {
                    CharSet = "utf-8",
                };

                var apiKey = _boletoCloudOptions.ApiKey;
                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:token"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

                var response = await client.PostAsync(_boletoCloudOptions.ApiUrl, content);

                // Tenta obter o token do header
                string? boletoToken = null;
                if (response.Headers.TryGetValues("X-BoletoCloud-Token", out var tokenValues))
                {
                    boletoToken = tokenValues.FirstOrDefault();
                }

                var pdfBytes = await response.Content.ReadAsByteArrayAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao criar boleto: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                return new BoletoPdfResult
                {
                    PdfBytes = pdfBytes,
                    Token = boletoToken
                };

            }
            catch (HttpRequestException ex)
            {
                // Captura erros de requisição HTTP
                // Você pode logar ou customizar a mensagem
                throw new Exception("Erro de comunicação com a API BoletoCloud: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Captura qualquer outro erro
                throw new Exception("Erro inesperado ao criar boleto: " + ex.Message, ex);
            }
        }
    }
}
