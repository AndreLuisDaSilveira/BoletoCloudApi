namespace BoletoCloudApi.Api.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// view model para representar um boleto.
    /// </summary>
    public class BoletoViewModel
    {
        /// <summary>
        /// Identificador único do boleto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Número unico do boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }

        /// <summary>
        /// Identificador da conta bancária associada ao boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Documento { get; set; }

        /// <summary>
        /// Numero sequencial associada ao boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sequencial { get; set; }

        /// <summary>
        /// Valor associada ao boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        /// <summary>
        /// Data de vencimento do boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Vencimento { get; set; }

        /// <summary>
        /// Data de emissão do boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Emissao { get; set; }

        /// <summary>
        /// Titulo do boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        /// <summary>
        /// Token único gerado do boleto.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Data de criação do boleto.
        /// </summary>
        public DateTime CriadoEm { get; set; }

        /// <summary>
        /// Conta do boleto.
        /// </summary>
        public ContaBancariaViewModel? Conta { get; set; }

        /// <summary>
        /// Beneficiario do boleto.
        /// </summary>
        public BeneficiarioViewModel? Beneficiario { get; set; }

        /// <summary>
        /// Pagador do boleto.
        /// </summary>
        public PagadorViewModel? Pagador { get; set; }
    }
}
