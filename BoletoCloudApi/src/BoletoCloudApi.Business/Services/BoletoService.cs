using BoletoCloudApi.Business.httpClient;
using BoletoCloudApi.Business.Interfaces;
using BoletoCloudApi.Business.Models;
using BoletoCloudApi.Business.Models.Validation;

namespace BoletoCloudApi.Business.Services
{
    public class BoletoService : BaseService, IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly BoletoCloudIntegrationService _boletoCloudIntegrationService;
        public BoletoService(IBoletoRepository boletoRepository,
                             BoletoCloudIntegrationService boletoCloudIntegrationService,
                             INotificador notificador) : base(notificador)
        {
            _boletoCloudIntegrationService = boletoCloudIntegrationService;
            _boletoRepository = boletoRepository;
        }

        public async Task Adicionar(Boleto boleto)
        {
            await _boletoRepository.Adicionar(boleto);
        }

        public void Dispose()
        {
            _boletoRepository?.Dispose();
        }

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

        public async Task<byte[]> ObterBoletoPDFAsync(string token)
        {
            return await _boletoCloudIntegrationService.ObterBoletoPDFAsync(token);
        }
    }
}
