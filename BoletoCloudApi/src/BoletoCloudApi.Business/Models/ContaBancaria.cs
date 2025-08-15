namespace BoletoCloudApi.Business.Models
{
    /// <summary>
    /// Representa uma conta bancária vinculada a um boleto, contendo informações essenciais para identificação e relacionamento.
    /// </summary>
    public class ContaBancaria : Entity
    {
        /// <summary>
        /// Identificador do boleto associado à conta bancária.
        /// </summary>
        public Guid BoletoId { get; set; }

        /// <summary>
        /// Número da conta bancária.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Número sequencial da conta bancária.
        /// </summary>
        public int Sequencial { get; set; }

        /// <summary>
        /// Nome ou código do banco.
        /// </summary>
        public string Banco { get; set; }

        /// <summary>
        /// Número da agência bancária.
        /// </summary>
        public string Agencia { get; set; }

        /// <summary>
        /// Código da carteira bancária.
        /// </summary>
        public string Carteira { get; set; }

        /// <summary>
        /// Referência ao boleto associado a esta conta bancária.
        /// </summary>
        public Boleto Boleto { get; set; }
    }
}
