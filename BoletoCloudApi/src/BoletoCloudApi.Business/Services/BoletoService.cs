namespace BoletoCloudApi.Business.Services
{
    using BoletoCloudApi.Business.httpClient;
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Business.Models.Validation;

    /// <summary>
    /// Serviço responsável pela gestão de boletos, incluindo operações de cadastro, geração e obtenção de PDF.
    /// Realiza validações e integrações necessárias para garantir a consistência dos dados e comunicação com serviços externos.
    /// </summary>
    public class BoletoService : BaseService, IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly BoletoCloudIntegrationService _boletoCloudIntegrationService;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BoletoService"/>.
        /// </summary>
        /// <param name="boletoRepository">Repositório de boletos.</param>
        /// <param name="boletoCloudIntegrationService">Serviço de integração com a BoletoCloud.</param>
        /// <param name="notificador">Gerenciador de notificações.</param>
        public BoletoService(IBoletoRepository boletoRepository,
                             BoletoCloudIntegrationService boletoCloudIntegrationService,
                             INotificador notificador) : base(notificador)
        {
            _boletoCloudIntegrationService = boletoCloudIntegrationService;
            _boletoRepository = boletoRepository;
        }

        /// <summary>
        /// Adiciona um novo boleto ao repositório.
        /// </summary>
        /// <param name="boleto">O boleto a ser adicionado.</param>
        public async Task Adicionar(Boleto boleto)
        {
            await _boletoRepository.Adicionar(boleto);
        }

        /// <summary>
        /// Libera os recursos utilizados pelo serviço.
        /// </summary>
        public void Dispose()
        {
            _boletoRepository?.Dispose();
        }

        /// <summary>
        /// Gera o PDF de um boleto após realizar todas as validações necessárias.
        /// Caso já exista um boleto com o mesmo número, notifica o erro e retorna um array vazio.
        /// </summary>
        /// <param name="boleto">O boleto para o qual o PDF será gerado.</param>
        /// <returns>Array de bytes contendo o PDF do boleto ou array vazio em caso de erro.</returns>
        public async Task<byte[]> GerarBoletoPdfAsync(Boleto boleto)
        {
            if (!ExecutarValidacao(new BoletoValidation(), boleto)
                || !ExecutarValidacao(new ContaBancariaValidation(), boleto.Conta)
                || !ExecutarValidacao(new PagadorValidation(), boleto.Pagador)
                || !ExecutarValidacao(new BeneficiarioValidation(), boleto.Beneficiario)) return [];

            if(_boletoRepository.Buscar(b => b.Numero == boleto.Numero).Result.Any())
            {
                Notificar("Já existe um boleto cadastrado com o mesmo número.");
                return [];
            }

            BoletoPdfResult boletoPdfResult = await _boletoCloudIntegrationService.GerarBoletoPdfAsync(boleto);

            boleto.Token = boletoPdfResult.Token;

            await Adicionar(boleto);

            return boletoPdfResult.PdfBytes;
        }

        /// <summary>
        /// Obtém o PDF de um boleto a partir do token informado.
        /// </summary>
        /// <param name="token">Token identificador do boleto.</param>
        /// <returns>Array de bytes contendo o PDF do boleto.</returns>
        public async Task<byte[]> ObterBoletoPDFAsync(string token)
        {
            return await _boletoCloudIntegrationService.ObterBoletoPDFAsync(token);
        }
    }
}
