using AutoMapper;
using BoletoCloudApi.Api.ViewModels;
using BoletoCloudApi.Business.Interfaces;
using BoletoCloudApi.Business.Models;
using BoletoCloudApi.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BoletoCloudApi.Api.Controllers
{
    [Route("api/boletos")]
    public class BoletosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IBoletoRepository _boletosRepository;
        private readonly IBoletoService _boletoService;
        
        public BoletosController(IMapper mapper,
                                 IBoletoRepository boletosRepository,
                                 IBoletoService boletoService,
                                 INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _boletosRepository = boletosRepository;
            _boletoService = boletoService;
        }

        [HttpGet]
        public async Task<IEnumerable<BoletoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<BoletoViewModel>>(await _boletosRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BoletoViewModel>> ObterPorId(Guid id)
        {
           var boleto =  _mapper.Map<BoletoViewModel>(await _boletosRepository.ObterPorId(id));


            if (boleto == null) return NotFound();

            return boleto;
        }

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
