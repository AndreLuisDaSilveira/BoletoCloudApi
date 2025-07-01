using BoletoCloudApi.Business.Models;
using System.Text;

namespace BoletoCloudApi.Business.httpClient
{
    public class BoletoCloudIntegrationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BoletoCloudOptions _boletoCloudOptions;

        public BoletoCloudIntegrationService(IHttpClientFactory factory, BoletoCloudOptions boletoCloudOptions)
        {
            _httpClientFactory = factory;
            _boletoCloudOptions = boletoCloudOptions ?? throw new ArgumentNullException(nameof(boletoCloudOptions), "BoletoCloudOptions cannot be null");
        }

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

        public async Task<BoletoPdfResult> GerarBoletoPdfAsync(Boleto boleto)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["boleto.titulo"] = boleto.Titulo,
                    ["boleto.documento"] = boleto.Documento,
                    ["boleto.numero"] = boleto.Numero,
                    //["boleto.sequencial"] = boleto.Sequencial.ToString(),
                    ["boleto.emissao"] = boleto.Emissao.ToString("yyyy-MM-dd"),
                    ["boleto.vencimento"] = boleto.Vencimento.ToString("yyyy-MM-dd"),
                    ["boleto.valor"] = boleto.Valor.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),

                    ["boleto.beneficiario.nome"] = boleto.Beneficiario.Nome,
                    ["boleto.beneficiario.cprf"] = MascaraCpf(boleto.Beneficiario.Cprf),
                    ["boleto.beneficiario.endereco.cep"] = MascaraCep(boleto.Beneficiario.Cep),
                    ["boleto.beneficiario.endereco.uf"] = boleto.Beneficiario.Uf,
                    ["boleto.beneficiario.endereco.localidade"] = boleto.Beneficiario.Localidade,
                    ["boleto.beneficiario.endereco.bairro"] = boleto.Beneficiario.Bairro,
                    ["boleto.beneficiario.endereco.logradouro"] = boleto.Beneficiario.Logradouro,
                    ["boleto.beneficiario.endereco.numero"] = boleto.Beneficiario.Numero,
                    ["boleto.conta.banco"] = boleto.Conta.Banco,
                    ["boleto.conta.agencia"] = boleto.Conta.Agencia,
                    ["boleto.conta.numero"] = boleto.Conta.Numero,
                    ["boleto.conta.carteira"] = boleto.Conta.Carteira,
                    ["boleto.pagador.nome"] = boleto.Pagador.Nome,
                    ["boleto.pagador.cprf"] = MascaraCpf(boleto.Pagador.CpfCnpj),
                    ["boleto.pagador.endereco.cep"] = MascaraCep(boleto.Pagador.Cep),
                    ["boleto.pagador.endereco.uf"] = boleto.Pagador.Uf,
                    ["boleto.pagador.endereco.localidade"] = boleto.Pagador.Localidade,
                    ["boleto.pagador.endereco.bairro"] = boleto.Pagador.Bairro,
                    ["boleto.pagador.endereco.logradouro"] = boleto.Pagador.Logradouro,
                    ["boleto.pagador.endereco.numero"] = boleto.Pagador.Numero
                };

                var client = _httpClientFactory.CreateClient();
                var content = new FormUrlEncodedContent(parameters);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded")
                {
                    CharSet = "utf-8"
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

        public static string MascaraCpf(string cpf)
        {
            var numeros = new string(cpf.Where(char.IsDigit).ToArray());
            if (numeros.Length == 11)
                return Convert.ToUInt64(numeros).ToString(@"000\.000\.000\-00");
            return cpf;
        }

        public static string MascaraCnpj(string cnpj)
        {
            var numeros = new string(cnpj.Where(char.IsDigit).ToArray());
            if (numeros.Length == 14)
                return Convert.ToUInt64(numeros).ToString(@"00\.000\.000\/0000\-00");
            return cnpj;
        }

        public static string MascaraCep(string cep)
        {
            var numeros = new string(cep.Where(char.IsDigit).ToArray());
            if (numeros.Length == 8)
                return Convert.ToUInt64(numeros).ToString(@"00000\-000");
            return cep;
        }
    }
}
