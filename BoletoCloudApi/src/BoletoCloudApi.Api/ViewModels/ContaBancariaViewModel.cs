namespace BoletoCloudApi.Api.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// view model para representar conta bancaria.
    /// </summary>
    public class ContaBancariaViewModel
    {
        /// <summary>
        /// Identificador único do boleto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Numero associado do boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }

        /// <summary>
        /// Sequencial associado do boleto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sequencial { get; set; }

        /// <summary>
        /// Banco associado a conta bancaria.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Banco { get; set; }

        /// <summary>
        /// Agencia associado a conta bancaria.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Agencia { get; set; }

        /// <summary>
        /// Carteria associado a conta bancaria.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Carteira { get; set; }

        /// <summary>
        /// Boleto id associado ao boleto.
        /// </summary>
        public Guid BoletoId { get; set; }
    }
}
