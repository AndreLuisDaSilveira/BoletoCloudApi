namespace BoletoCloudApi.Business.Services
{
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Business.Notificacoes;
    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>
    /// Classe base abstrata para serviços de negócio, fornecendo métodos utilitários para validação
    /// e notificação de erros ou mensagens de negócio.
    /// </summary>
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BaseService"/> com o gerenciador de notificações informado.
        /// </summary>
        /// <param name="notificador">Instância do gerenciador de notificações.</param>
        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        /// <summary>
        /// Notifica todas as mensagens de erro presentes em um <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="validationResult">Resultado da validação contendo os erros.</param>
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificar(item.ErrorMessage);
            }
        }

        /// <summary>
        /// Notifica uma mensagem específica.
        /// </summary>
        /// <param name="mensagem">Mensagem a ser notificada.</param>
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        /// <summary>
        /// Executa a validação de uma entidade utilizando o validador informado.
        /// Caso existam erros, notifica as mensagens e retorna <c>false</c>.
        /// </summary>
        /// <typeparam name="TV">Tipo do validador.</typeparam>
        /// <typeparam name="TE">Tipo da entidade.</typeparam>
        /// <param name="validacao">Instância do validador.</param>
        /// <param name="entidade">Entidade a ser validada.</param>
        /// <returns><c>true</c> se a validação for bem-sucedida; caso contrário, <c>false</c>.</returns>
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }

}
