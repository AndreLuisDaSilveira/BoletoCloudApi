namespace BoletoCloudApi.Business.Models
{
    /// <summary>
    /// Representa um boleto bancário, contendo informações essenciais para emissão, identificação e relacionamento
    /// com entidades como conta bancária, beneficiário e pagador.
    /// </summary>
    public class Boleto : Entity
    {
        /// <summary>
        /// Número identificador do boleto.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Documento associado ao boleto (ex: número do documento fiscal).
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Número sequencial do boleto.
        /// </summary>
        public int Sequencial { get; set; }

        /// <summary>
        /// Valor monetário do boleto.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Data de vencimento do boleto.
        /// </summary>
        public DateTime Vencimento { get; set; }

        /// <summary>
        /// Data de emissão do boleto.
        /// </summary>
        public DateTime Emissao { get; set; }

        /// <summary>
        /// Título ou descrição do boleto.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Token de autenticação ou identificação adicional do boleto.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Data de criação do boleto.
        /// </summary>
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        /// <summary>
        /// Conta bancária associada ao boleto.
        /// </summary>
        public ContaBancaria? Conta { get; set; }

        /// <summary>
        /// Beneficiário do boleto.
        /// </summary>
        public Beneficiario? Beneficiario { get; set; }

        /// <summary>
        /// Pagador do boleto.
        /// </summary>
        public Pagador? Pagador { get; set; }
    }
}
