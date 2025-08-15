namespace BoletoCloudApi.Api.Controllers
{
    using System.Net;
    using AutoMapper;
    using BoletoCloudApi.Api.ViewModels;
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Business.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller responsável por gerenciar operações relacionadas a boletos.
    /// </summary>
    [Route("api/boletos")]
    public class BoletosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IBoletoRepository _boletosRepository;
        private readonly IBoletoService _boletoService;

        /// <summary>
        /// Obtém um boleto pelo identificador.
        /// </summary>
        /// <param name="mapper">Instância do <see cref="IMapper"/> para mapeamento entre modelos de domínio e ViewModels.</param>
        /// <param name="boletosRepository">Repositório para acesso e manipulação de dados de boletos.</param>
        /// <param name="boletoService">Serviço responsável pelas regras de negócio relacionadas a boletos.</param>
        /// <param name="notificador">Instância de <see cref="INotificador"/> para gerenciar notificações.</param>
        public BoletosController(IMapper mapper,
                                 IBoletoRepository boletosRepository,
                                 IBoletoService boletoService,
                                 INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _boletosRepository = boletosRepository;
            _boletoService = boletoService;
        }

        /// <summary>
        /// Obtém todos os boletos cadastrados.
        /// </summary>
        /// <returns>Lista de <see cref="BoletoViewModel"/>.</returns>
        [HttpGet]
        public async Task<IEnumerable<BoletoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<BoletoViewModel>>(await _boletosRepository.ObterTodos());
        }

        /// <summary>
        /// Obtém um boleto pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do boleto.</param>
        /// <returns>O <see cref="BoletoViewModel"/> correspondente ou NotFound.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BoletoViewModel>> ObterPorId(Guid id)
        {
            var boleto = _mapper.Map<BoletoViewModel>(await _boletosRepository.ObterBoletoPorIdAsync(id));

            if (boleto == null) return NotFound();

            return boleto;
        }

        /// <summary>
        /// Busca boletos por número, CPF, e intervalo de datas de emissão.
        /// </summary>
        /// <param name="numero">Número do boleto.</param>
        /// <param name="cpf">CPF do pagador.</param>
        /// <param name="DataEmissaoInicio">Data inicial de emissão.</param>
        /// <param name="DataEmissaoFim">Data final de emissão.</param>
        /// <returns>Lista de <see cref="BoletoViewModel"/> encontrados ou NotFound.</returns>
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<BoletoViewModel>>> Buscar(
            [FromQuery]string? numero,
            [FromQuery] string? cpf,
            [FromQuery] DateTime? DataEmissaoInicio,
            [FromQuery] DateTime? DataEmissaoFim)
        {
            var result = await _boletosRepository.Buscar(b => 
                (string.IsNullOrEmpty(numero) || b.Numero.Contains(numero)) &&
                (string.IsNullOrEmpty(cpf) || b.Pagador.CpfCnpj.Contains(cpf)) &&
                (!DataEmissaoInicio.HasValue || b.Emissao >= DataEmissaoInicio.Value) &&
                (!DataEmissaoFim.HasValue || b.Emissao <= DataEmissaoFim.Value));

            var viwModels = _mapper.Map<IEnumerable<BoletoViewModel>>(result);

            if (!viwModels.Any())
                return NotFound();

            return Ok(viwModels) ;
        }

        /// <summary>
        /// Obtém o PDF do boleto pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do boleto.</param>
        /// <returns>Arquivo PDF do boleto ou NotFound.</returns>
        [HttpGet("{id:guid}/pdf")]
        public async Task<ActionResult<byte[]>> ObterBoletoPDFAsync(Guid id)
        {
            var boleto = _mapper.Map<BoletoViewModel>(await _boletosRepository.ObterPorId(id));

            if (boleto == null) return NotFound();

            var pdfBytes = await _boletoService.ObterBoletoPDFAsync(boleto.Token);

            return CustomResponse(HttpStatusCode.OK, new CustomFileResult
            {
                FileBytes = pdfBytes,
                ContentType = "application/pdf",
                FileName = "boleto.pdf"
            });
        }

        /// <summary>
        /// Gera um boleto e retorna o PDF para download.
        /// </summary>
        /// <param name="boletoViewModel">Dados do boleto a ser gerado.</param>
        /// <returns>Arquivo PDF do boleto gerado.</returns>
        [HttpPost]
        public async Task<ActionResult<byte[]>> GerarBoletoDownload([FromBody] BoletoViewModel boletoViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var boleto = _mapper.Map<Boleto>(boletoViewModel);

            var pdfBytes = await _boletoService.GerarBoletoPdfAsync(boleto);

            return CustomResponse(HttpStatusCode.OK, new CustomFileResult
            {
                FileBytes = pdfBytes,
                ContentType = "application/pdf",
                FileName = "boleto.pdf"
            });
        }
    }
}
