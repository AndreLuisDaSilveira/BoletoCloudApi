namespace BoletoCloudApi.Api.Controllers
{
    using System.Net;
    using BoletoCloudApi.Api.ViewModels;
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Notificacoes;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Classe base para os controllers da API.
    /// </summary>
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="MainController"/>.
        /// </summary>
        /// <param name="notificador">Instância de <see cref="INotificador"/> para gerenciar notificações de erro.</param>
        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        /// <summary>
        /// Verifica se a operação atual não possui notificações de erro.
        /// </summary>
        /// <returns>
        /// <c>true</c> se não houver notificações de erro; caso contrário, <c>false</c>.
        /// </returns>
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        /// <summary>
        /// Retorna uma resposta HTTP customizada com base no status da operação e nos dados informados.
        /// </summary>
        /// <param name="statusCode">Código de status HTTP a ser retornado (padrão: <see cref="HttpStatusCode.OK"/>).</param>
        /// <param name="result">Objeto de resultado a ser retornado no corpo da resposta.</param>
        /// <returns>Um <see cref="ActionResult"/> contendo a resposta HTTP apropriada.</returns>
        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (OperacaoValida())
            {
                if (result is CustomFileResult fileResult)
                {
                    return File(fileResult.FileBytes, fileResult.ContentType, fileResult.FileName);
                }

                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode),
                };
            }

            return BadRequest(new
            {
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        /// <summary>
        /// Retorna uma resposta HTTP customizada com base no estado do modelo.
        /// </summary>
        /// <param name="modelState">Dicionário de estado do modelo contendo possíveis erros de validação.</param>
        /// <returns>Um <see cref="ActionResult"/> contendo a resposta HTTP apropriada.</returns>
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        /// <summary>
        /// Registra notificações de erro a partir dos erros de validação presentes no estado do modelo.
        /// </summary>
        /// <param name="modelState">Dicionário de estado do modelo contendo erros de validação.</param>
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        /// <summary>
        /// Registra uma notificação de erro.
        /// </summary>
        /// <param name="mensagem">Mensagem descritiva do erro.</param>
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
