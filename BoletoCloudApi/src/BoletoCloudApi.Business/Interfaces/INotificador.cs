namespace BoletoCloudApi.Business.Interfaces
{
    using BoletoCloudApi.Business.Notificacoes;

    /// <summary>
    /// Interface para gerenciamento de notificações de negócio.
    /// </summary>
    public interface INotificador
    {
        /// <summary>
        /// Verifica se existem notificações registradas.
        /// </summary>
        /// <returns><c>true</c> se houver notificações; caso contrário, <c>false</c>.</returns>
        bool TemNotificacao();

        /// <summary>
        /// Obtém a lista de notificações registradas.
        /// </summary>
        /// <returns>Uma lista de <see cref="Notificacao"/>.</returns>
        List<Notificacao> ObterNotificacoes();

        /// <summary>
        /// Registra uma nova notificação.
        /// </summary>
        /// <param name="notificacao">A notificação a ser registrada.</param>
        void Handle(Notificacao notificacao);
    }
}
