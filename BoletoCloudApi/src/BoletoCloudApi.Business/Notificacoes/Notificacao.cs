namespace BoletoCloudApi.Business.Notificacoes
{
    /// <summary>
    /// Representa uma notificação de negócio, geralmente utilizada para comunicar mensagens de validação ou erro.
    /// </summary>
    public class Notificacao
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Notificacao"/> com a mensagem informada.
        /// </summary>
        /// <param name="mensagem">Mensagem da notificação.</param>
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        /// <summary>
        /// Mensagem associada à notificação.
        /// </summary>
        public string? Mensagem { get; }
    }
}
