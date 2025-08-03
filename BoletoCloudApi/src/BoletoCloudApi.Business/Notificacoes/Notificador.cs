namespace BoletoCloudApi.Business.Notificacoes
{
    using BoletoCloudApi.Business.Interfaces;

    /// <summary>
    /// Implementa o gerenciamento de notificações de negócio, permitindo registrar, consultar e verificar notificações.
    /// </summary>
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Notificador"/>.
        /// </summary>
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        /// <summary>
        /// Registra uma nova notificação.
        /// </summary>
        /// <param name="notificacao">A notificação a ser registrada.</param>
        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        /// <summary>
        /// Obtém a lista de notificações registradas.
        /// </summary>
        /// <returns>Uma lista de <see cref="Notificacao"/>.</returns>
        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        /// <summary>
        /// Verifica se existem notificações registradas.
        /// </summary>
        /// <returns><c>true</c> se houver notificações; caso contrário, <c>false</c>.</returns>
        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
